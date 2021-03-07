using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    GameObject mother;
   

    private float xmin, xmax;
    float xspeed = 1;

    public int index;
    public bool canShoot = false;
  

    private void Start()
    {
        mother = GameObject.Find("MotherShip");
        GetBounds();
        SetColor();
    }
    private void Update()
    {
        ReportPos();
        transform.Translate(xspeed * Time.deltaTime,0, 0, Space.World);
    }
  
    void GetBounds()
    {
        Camera camera = Camera.main;
        var buffer = transform.localScale.x / 2;
        xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + buffer;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - buffer;
    }
    void ReportPos()
    {
        if (transform.position.x <= xmin || transform.position.x >= xmax)
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
    
        if (transform.tag == "?PTS")
        {
            var cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.magenta);

        }
        if (transform.tag == "30PTS")
        {
            var cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.red);

        }
        if (transform.tag == "20PTS")
        {
            var cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.cyan);

        }
        if (transform.tag == "10PTS")
        {
            var cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.yellow);

        }

    }
    public void ReportDeath()
    {
        mother.GetComponent<MotherShip>().PawnDeath(index);
       
    }
}
