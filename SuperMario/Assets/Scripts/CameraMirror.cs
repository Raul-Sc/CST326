using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMirror : MonoBehaviour
{

    public Player follow;
    void Update()
    {
        if (follow.transform.position.x - transform.position.x > 1)
            transform.Translate(.1f, 0, 0, Camera.main.transform);
        if (follow.transform.position.x - transform.position.x > 6)
            transform.Translate(.9f,0,0,Camera.main.transform);
        if (follow.transform.position.x - transform.position.x < -1)
            transform.Translate(-.1f, 0, 0, Camera.main.transform);
        if(follow.transform.position.x - transform.position.x < -6)
             transform.Translate(-.9f, 0, 0, Camera.main.transform);

    }

}