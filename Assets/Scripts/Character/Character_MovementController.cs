using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_MovementController : MonoBehaviour
{
    [SerializeField] GameObject interactKey;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float moveSpeed;

    private Character_AnimationController animController;
    private float overlapCircleSize = 1;

    private bool blockInputs;

    private void OnEnable()
    {
        GameEvents.OnOpenMenu += OnOpenMenu;
        GameEvents.OnCloseMenu += OnCloseMenu;
    }

    private void Awake()
    {
        animController = GetComponent<Character_AnimationController>();
    }

    private void Update()
    {
        if (!blockInputs)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, overlapCircleSize, LayerMask.GetMask("Interactable"));
                if (hits.Length > 0)
                {
                    Interactable nearestInteractable = GetNearestObject(hits);
                    nearestInteractable?.Interact();

                    if (nearestInteractable?.GetType() == typeof(Shop)) GameEvents.OpenMenuMethod();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.Instance.ShowInventory();
                GameEvents.OpenMenuMethod();
            }
        }
    }

    private Interactable GetNearestObject(Collider2D[] hits)
    {
        Interactable result = null;
        float smallerDistance = float.MaxValue;
        foreach (Collider2D collider in hits)
        {
            float distance = Vector2.Distance(collider.transform.position, transform.position);
            Interactable interactableRef = collider.GetComponent<Interactable>();
            if (smallerDistance > distance && interactableRef.IsInteractable())
            {
                smallerDistance = distance;
                result = interactableRef;
            }
        }
        return result;
    }

    private void FixedUpdate()
    {
        CheckMovement();
        CheckInteractableObjects();
    }

    private void CheckMovement()
    {
        float moveFactor = 0;
        if (!blockInputs)
        {
            Vector2 moveDir = new Vector3(0, 0);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //Move up
                moveDir = Vector2.up;
                animController.SetDirection(Direction.Up);
                moveFactor = 1;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //Move left
                moveDir = Vector2.left;
                animController.SetDirection(Direction.Left);
                moveFactor = 1;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //Move Down
                moveDir = Vector2.down;
                animController.SetDirection(Direction.Down);
                moveFactor = 1;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //Move Right
                moveDir = Vector2.right;
                animController.SetDirection(Direction.Right);
                moveFactor = 1;
            }
            rigidBody.MovePosition(rigidBody.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        }
        animController.SetMoveValue(moveFactor);
    }

    private void CheckInteractableObjects()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, overlapCircleSize, LayerMask.GetMask("Interactable"));
        if (hit != null && hit.gameObject.GetComponent<Interactable>().IsInteractable())
            interactKey.SetActive(true);
        else
            interactKey.SetActive(false);
    }

    private void OnCloseMenu()
    {
        blockInputs = false;
    }

    private void OnOpenMenu()
    {
        blockInputs = true;
    }

    private void OnDisable()
    {
        GameEvents.OnOpenMenu -= OnOpenMenu;
        GameEvents.OnCloseMenu -= OnCloseMenu;
    }
}
