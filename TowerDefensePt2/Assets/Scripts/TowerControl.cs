using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    public List<Enemy> targets;
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
}
