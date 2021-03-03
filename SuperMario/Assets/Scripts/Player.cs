using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    float speed = 10f;
    float jumpForce = 10;
    private Rigidbody rb;
    private Animator animator;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        //if player falls below lowest block,Lava blocks are just visual 4 now
        if (transform.position.y < 0)
            gameOver = true;
        //horizontal movement ---------------------------------------
        var horizontal = Input.GetAxis("Horizontal");

        //Set character rotation
        float y = 90;
        if (horizontal < 0) y = -90;
        if (horizontal == 0) y = transform.eulerAngles.y;
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;

        //small boost 
        float boost = 0;
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            boost = 1 - Input.GetAxis("Boost");
        animator.SetFloat("Speed", Mathf.Abs(horizontal + (boost * horizontal)));
        transform.Translate((horizontal + (boost * horizontal)) * Time.deltaTime * speed,0,0,Space.World );
    

        //jump---------------------------------------------------------
        animator.SetBool("Jump", Input.GetButtonDown("Jump"));
        if (Input.GetButtonDown("Jump") ) 
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

}
