using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] MotherShip mother;
   

    public float bulletSpeed = -1;
    private float xmin, xmax;
    float xspeed = 1;

    public int index;
    public bool living = true;
   
    private void Start()
    {
        GetBounds();
    }
    private void Update()
    {
        ReportPos();
        transform.Translate(xspeed * Time.deltaTime,0, 0, Space.World);
    }
    private void FixedUpdate()
    {
        CanShoot();
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
            mother.makeMove = true;
            mother.xpos = transform.position.x;
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
        float n;
        if (transform.position.x < 0)
        {
            n = .2f;
        }
        else
        {
            
            n = -.2f;
        }
        transform.position = new Vector3(transform.position.x + n, transform.position.y - 1,0);
    }
    public void Fire()
    {
        GameObject bullet =
            Instantiate(projectile, transform.position + new Vector3(0, -1, 0), Quaternion.identity)
                as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
    }
    private void CanShoot()
    {

        if (mother.shooters[index])
        {
            var cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.yellow);

        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        ReportDeath();
    }
    void ReportDeath()
    {
        mother.alive--;
        mother.shooters[index] = false;
        if (index > 4)
            mother.shooters[index - 5] = true;
    }
}
