using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Paddle leftPaddle;
    [SerializeField] Paddle rightPaddle;
    public Vector3 movementInput { get; private set; }
    private void Update()
    {
        movementInput = new Vector3(0, Input.GetAxis("Vertical"), 0);
        if(Input.GetKeyDown(KeyCode.W))
            leftPaddle.Move();
    }
}
