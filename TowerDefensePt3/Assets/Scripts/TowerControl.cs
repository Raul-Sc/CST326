using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    public List<Enemy> targets;
    Enemy currentTarget;
    Player player;
    float damage = 50;

    LineRenderer laserLine;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        damage *= Time.deltaTime;
        laserLine = GetComponent<LineRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy newtarget = other.GetComponent<Enemy>();
        if (newtarget != null)
        {
            newtarget.DeathEvent.AddListener(delegate { RemoveTarget(newtarget); });
            targets.Add(newtarget);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy oldtarget = other.GetComponent<Enemy>();
        if (oldtarget != null)
            RemoveTarget(oldtarget);
        
    }
    void RemoveTarget(Enemy target)
    {
        targets.Remove(target);
    }
    private void Update()
    {
        if (targets.Count > 0)
        {
            currentTarget = targets[0];
            Attack();
        }
        if (targets.Count == 0)
        {
            laserLine.enabled = false;
        }
    }
    void Attack()
    {
        if (player != null)
        {
            laserLine.enabled = true;
            laserLine.SetPosition(0, transform.position);
            laserLine.SetPosition(1, currentTarget.transform.position);
            player.purse += currentTarget.GetBounty(damage);
        }
        else
            print("cant find player");
    }
}
