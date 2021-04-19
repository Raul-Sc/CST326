using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent TriggerEvent;
    public UnityEvent HitEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            TriggerEvent.Invoke();
        if (this.CompareTag("Enemy"))
        {
            HitEvent.Invoke();
            if(other.CompareTag("Projectile" ))
                Destroy(other.gameObject);
        }
        if (this.CompareTag("Detection"))
        {
            if (other.CompareTag("Player"))
            {
                GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
            
    }

}

