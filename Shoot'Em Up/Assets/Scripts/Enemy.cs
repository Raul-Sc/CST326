using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    GameObject mother;
   
    //movement
    private float xmin, xmax;
    float xspeed = 1;
    //clone number
    public int index;
  

    private void Start()
    {
        mother = GameObject.Find("MotherShip");
        GetBounds();
        SetColor();
    }
    private void Update()
    {
            ReportPos();
            transform.Translate(xspeed * Time.deltaTime, 0, 0, Space.World);
    }
  
    void GetBounds()
    {
        Camera camera = Camera.main;
        var padding = transform.localScale.x / 2;
        xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
    void ReportPos()
    {
        if (gameObject.CompareTag("?PTS"))
        {
            if (transform.position.x > xmax + 1)
                xspeed = 0;
        }
        else if (transform.position.x <= xmin || transform.position.x >= xmax)
        {
            mother.GetComponent<MotherShip>().pos = transform.position.x;
            mother.GetComponent<MotherShip>().makeMove = true;
        }
            
    }

    public void MoveLeft(float speed)
    {
        xspeed = -1 *speed;
    }
    public void MoveRight(float speed)
    {
        xspeed = speed;
    }
    public void MoveDown()
    {
        float n = .2f;
        if (transform.position.x < 0)
        {
            n *= 1;
        }
        else
        {
            
            n *= -.1f;
        }
        //n is padding to insure not hitting the same bound a second time
        transform.position = new Vector3(transform.position.x + n, transform.position.y - 1,0);
    }
    public void Fire(float bulletSpeed)
    {
        GameObject bullet =
            Instantiate(projectile, transform.position + new Vector3(0, -1, 0), Quaternion.identity)
                as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
    }
    private void SetColor()
    {
        var cubeRenderer = GetComponent<Renderer>();

        if (transform.CompareTag("?PTS"))
        {

            cubeRenderer.material.SetColor("_Color", Color.red);

        }
        if (transform.CompareTag("30PTS"))
        {
            cubeRenderer.material.SetColor("_Color", Color.magenta);

        }
        if (transform.CompareTag("20PTS"))
        {
            cubeRenderer.material.SetColor("_Color", Color.cyan);

        }
        if (transform.CompareTag("10PTS"))
        {
            cubeRenderer.material.SetColor("_Color", Color.yellow);

        }

    }
    public void ReportDeath()
    {
        mother.GetComponent<MotherShip>().PawnDeath(index);
       
    }
}
