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
        if (this.CompareTag("LandTrigger"))
        {
            if (other.CompareTag("Player"))
            {
                TriggerEvent.Invoke();
            }
        }
            
        if (this.CompareTag("Enemy"))
        {
            print(this.name + "with" + other.name);
            if (other.CompareTag("Projectile"))
            {
                HitEvent.Invoke();
                Destroy(other.gameObject);
            }
        }
        if (this.CompareTag("Detection"))
        {
            if (other.CompareTag("Player"))
            {
                //GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
            
    }

}

