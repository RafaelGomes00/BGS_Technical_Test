using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float moveSpeed;

    private Character_AnimationController animController;

    private void Awake()
    {
        animController = GetComponent<Character_AnimationController>();
    }

    private void FixedUpdate()
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
}
