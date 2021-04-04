using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    public List<Vector3> myPath;
    int index = 1;

    public float speed = 1f;
    public int health = 100;
    int bounty = 3;
    bool beginMove = false;
    public bool smart = false;

    void Update()
    {
        if (beginMove == true)
        {
            if (index < myPath.Count)
            {
                Move();
            }
            if (health <= 0 || index == myPath.Count)
                Destroy(gameObject);
        }
    }
    public void MoveToSpawn()
    {
        transform.position = myPath[0];
        beginMove = true;
    }
    void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, myPath[index], step);
        if ( (transform.position - myPath[index]) == new Vector3(0,0,0))
        {
            index++;
        }
    }
    private void SetOrientation()
    {
        if (index < myPath.Count)
        {
            float rise = transform.position.y - myPath[index].y;
            float run = transform.position.x - myPath[index].x;

            float angle = (Mathf.Atan(rise / run) * 180) / Mathf.PI;

            var roatation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(roatation.x, roatation.y, angle);
        }
    }

    public int GetBounty(int damage)
    {
        TakeHealth(damage);
        if (health <= 0)
            return bounty;
        return 0;
    }
    private void TakeHealth(int damage)
    {
        health -= damage;
    }
}