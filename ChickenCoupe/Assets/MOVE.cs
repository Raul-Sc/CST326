using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(-0.0f * Time.deltaTime, 0.0f *Time.deltaTime, 0.5f * Time.deltaTime, Space.Self);
    }
}
