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
                hits[0].gameObject.GetComponent<Interactable>().Interact();
        }
    }

    private void FixedUpdate()
    {
        CheckMovement();
        CheckInteractableObjects();
    }

    private void CheckMovement()
    {
        Vector2 moveDir = new Vector3(0, 0);
        animController.SetMoveValue(1);

        if (Input.GetKey(KeyCode.W))
        {
            //Move up
            moveDir = Vector2.up;
            animController.SetDirection(Direction.Up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Move left
            moveDir = Vector2.left;
            animController.SetDirection(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move Down
            moveDir = Vector2.down;
            animController.SetDirection(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Move Right
            moveDir = Vector2.right;
            animController.SetDirection(Direction.Right);
        }
        else
        {
            animController.SetMoveValue(0);
        }

        rigidBody.MovePosition(rigidBody.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    private void CheckInteractableObjects()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, overlapCircleSize, LayerMask.GetMask("Interactable"));
        if (hit)
            interactKey.SetActive(true);
        else
            interactKey.SetActive(false);
    }
}
