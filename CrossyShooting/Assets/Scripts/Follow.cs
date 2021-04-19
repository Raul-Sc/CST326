using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;

    public float smoothSpeed = 0.125f;
    Vector3 offset = new Vector3(1, 30, 4);

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
/*
 refrenced from https://youtu.be/MFQhpwc6cKE
 Class Follow
    Data Members:
        Transfrom Target;

    Functions:
        LateUpdate(); // move towards target



*/