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

    private void Awake()
    {
        animController = GetComponent<Character_AnimationController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, overlapCircleSize, LayerMask.GetMask("Interactable"));
            if (hits.Length > 0)
                GetNearestObject(hits)?.Interact();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.ShowInventory();
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
        Vector2 moveDir = new Vector3(0, 0);
        float moveSpeedValue = 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Move up
            moveDir = Vector2.up;
            animController.SetDirection(Direction.Up);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move left
            moveDir = Vector2.left;
            animController.SetDirection(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Move Down
            moveDir = Vector2.down;
            animController.SetDirection(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Move Right
            moveDir = Vector2.right;
            animController.SetDirection(Direction.Right);
        }
        else
        {
            moveSpeedValue = 0;
        }

        animController.SetMoveValue(moveSpeedValue);
        rigidBody.MovePosition(rigidBody.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    private void CheckInteractableObjects()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, overlapCircleSize, LayerMask.GetMask("Interactable"));
        if (hit != null && hit.gameObject.GetComponent<Interactable>().IsInteractable())
            interactKey.SetActive(true);
        else
            interactKey.SetActive(false);
    }
}
