using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Paddle leftPaddle;
    [SerializeField] Paddle rightPaddle;
    public Vector3 movementLeftInput { get; private set; }
    public Vector3 movementRightInput { get; private set; }
    private void Update()
    {
        movementLeftInput = new Vector3(0, Input.GetAxis("Left"), 0);
        movementRightInput = new Vector3(0, Input.GetAxis("Right"), 0);
        leftPaddle.Move(movementLeftInput);
        rightPaddle.Move(movementRightInput);
    }
}
