using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_MovementController : MonoBehaviour
{
    private Character_AnimationController animController;

    private void Awake()
    {
        animController = GetComponent<Character_AnimationController>();
    }

    private void Update()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);
        animController.SetMoveValue(1);

        if (Input.GetKey(KeyCode.W))
        {
            //Move up
            moveDir = Vector3.up;
            animController.SetDirection(Direction.Up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Move left
            moveDir = Vector3.left;
            animController.SetDirection(Direction.Left);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Move Down
            moveDir = Vector3.down;
            animController.SetDirection(Direction.Down);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Move Right
            moveDir = Vector3.right;
            animController.SetDirection(Direction.Right);
        }
        else
        {
            animController.SetMoveValue(0);
        }

    }
}
