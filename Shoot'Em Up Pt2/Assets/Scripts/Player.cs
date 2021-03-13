using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Game game;
    [SerializeField] GameObject projectile;
    //movement
    public float speed = 10;
    float xmin, xmax;

    //bullet info
    float bulletSpeed = 10;
    public float fireRate = 1;
    bool canFire;

    //life info
    Vector3 spawnLeft,spawnOut;
    int lives;
    private void Awake()
    {
        lives = 3;
    }

    private void Start()
    {
        GetBounds();
        canFire = true;
        spawnLeft = new Vector3(xmin, transform.position.y, 0);
        spawnOut = new Vector3(xmin - 3, transform.position.y, 0);
    }
    private void Update()
    {
        Move();
        if (Input.GetKeyDown("space") && canFire)
        {
                Fire();
        }
    }
    void GetBounds()
    {
        Camera camera = Camera.main;
        var buffer = transform.localScale.x / 2;
        xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + buffer;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - buffer;
    }
    private void Move()
    {
        bool canMove = true;
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0 && transform.position.x < xmin)canMove = false;
        if (horizontal > 0 && transform.position.x > xmax)canMove = false;
        if(canMove)
            transform.Translate(horizontal * speed * Time.deltaTime, 0, 0, Space.World);
    }

    private void Fire()
    {
        canFire = false;
        GameObject bullet =
            Instantiate(projectile, transform.position+ new Vector3(0,1,0), Quaternion.identity)
                as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, bulletSpeed, 0);
        StartCoroutine(FireRate());


    }
    IEnumerator FireRate()
    {
        
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    public void ReportDeath()
    {
        lives--;
        game.UpdatePlayerLives();
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        float delay = 1;
        transform.position = spawnOut;
        if (lives > 0) delay = .5f;
        yield return new WaitForSeconds(delay);
        if (lives > 0)
            transform.position = spawnLeft;
        else
        {
            transform.position = new Vector3(0, transform.position.y, 0);
            lives = 3;
        }

    }
}
