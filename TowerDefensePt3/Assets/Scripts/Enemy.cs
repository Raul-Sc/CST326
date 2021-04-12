using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    public List<Vector3> myPath;
    int index = 1;

    public float speed = 4f;
    public float health = 100;
    public float damageMult = 1;
    public int bounty = 3;
    bool beginMove = false;

    public UnityEvent DeathEvent;
    private void Awake()
    {
     
    }
    void Update()
    {
        if (beginMove == true)
        {
            if (index < myPath.Count)
            {
                Move();
            }
            if (health <= 0)
            {
                DeathEvent.Invoke();
                if (deathEffect != null)
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (index == myPath.Count)
            {
                DeathEvent.Invoke();
                Destroy(gameObject);
            }
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

    public int GetBounty(float damage)
    {
        TakeHealth(damage);
        if (health <= 0)
            return bounty;
        return 0;
    }
    private void TakeHealth(float damage)
    {
        health -= damage * damageMult;
    }
}
