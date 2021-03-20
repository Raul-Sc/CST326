using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Path path;
    private WayPoint[] myPath;
    public float speed = 5f;
    private int index = 0;

    public int bounty = 5;
    public int health = 100;

    private void Start()
    {
       
        path = GameObject.Find("Path").GetComponent<Path>();
        myPath = path.GetPoints();
        if (myPath != null)
        {
            MoveToSpawn();
        }
        index = 1;
        SetOrientation();
    }
    void Update()
    {
        SetOrientation();
        if (index < myPath.Length)
        {
            Move();
        }
        if (health <= 0)
            Destroy(gameObject);
       
    }

    void MoveToSpawn()
    {
        transform.position = myPath[0].transform.position ;
    }
    private void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        if (Mathf.Abs(transform.position.x - myPath[index].transform.position.x) < 0.1f ||
            Mathf.Abs(transform.position.y - myPath[index].transform.position.y) < 0.1f)
        {
            index++;
        }
    }
    private void SetOrientation()
    {
        if (index < myPath.Length)
        {
            float rise = transform.position.y - myPath[index].transform.position.y;
            float run = transform.position.x - myPath[index].transform.position.x;

            float angle = (Mathf.Atan(rise / run) * 180) / Mathf.PI;

            var roatation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(roatation.x, roatation.y, angle);
        }
    }
    public int GetBounty(int damage)
    {
        TakeHealth(damage);
        if(health <= 0)
            return bounty;
        return 0;
    }
    private void TakeHealth(int damage)
    {
        health -= damage;
    }
}


/*
class Enemy
    Functions:
        Start()//get path and move to spawn point
        MoveToSpawnPoint()
        Move()//constant x movement
        SetOrientation()// calc angle to next WayPoint;
        
        public int GetBounty()// returns bounty amount
        TakeHealth(damage)//subract damage amount to health
        

    Data members:
        Path path; // A path to follow
        WayPoint myPath; // points in the path
        int index;// path index

        float speed;//movemenet speed

        int health;
        int bounty;

        
  

*/

