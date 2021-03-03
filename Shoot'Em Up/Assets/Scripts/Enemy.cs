using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] MotherShip mother;
    public float bulletSpeed = -1;
    private float xmin, xmax;
    public bool canShoot = true;
    float xspeed = 1;

    private void Start()
    {
        GetBounds();
    }
    private void Update()
    {
        CanShoot();
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
            n = 1;
        }
        else
        {
            
            n = -1;
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
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Enemy"))
                canShoot = false;
            else
                canShoot = true;
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        ReportDeath();
    }
    void ReportDeath()
    {

    }
}
