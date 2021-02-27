using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EthanBehavior : MonoBehaviour
{
    private Animator animator;
    public float modifier = 8;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
      
        //determine if player jumped 
        bool jumped = Input.GetKey("space");
        animator.SetBool("Jump", jumped);
        //determine how heigh
        float height = Input.GetAxis("Jump");

        float horizontal = Input.GetAxis("Horizontal");
  
        


        //allow boost for a short burst
        float boost = 0;
        if(Input.GetKey("left shift") || Input.GetKey("right shift"))
          boost = 1 - Input.GetAxis("Boost");
    

        float y;
        if (horizontal < 0)
            y = -90;
        else if (horizontal > 0)
            y = 90;
        else//maintain current oritentation
            y = transform.eulerAngles.y;
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        //horizontal + 0 if shift pressed but not moving
        animator.SetFloat("Speed", Mathf.Abs(horizontal + (boost*horizontal)) );
        //move to right relative to camera view
        transform.Translate(horizontal * (modifier + (boost * modifier)) * Time.deltaTime,0,0,Camera.main.transform);
        //move up relative to camera
        transform.Translate(0, height * modifier * Time.deltaTime, 0, Camera.main.transform);
    }
}
