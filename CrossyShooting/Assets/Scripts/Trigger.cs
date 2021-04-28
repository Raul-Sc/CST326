using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent LandTriggerEvent;
    public UnityEvent MotherShipTriggerEvent;
    public UnityEvent HitEvent;
    public UnityEvent PlayerHitEvent;
    private void OnTriggerEnter(Collider other)
    {

        if (this.CompareTag("MotherShipTrigger"))
        {
            if (other.CompareTag("Player"))
            {
                MotherShipTriggerEvent.Invoke();
                Destroy(this.gameObject);
            }
        }
        if (this.CompareTag("LandTrigger"))
        {
            if (other.CompareTag("Player"))
            {
                LandTriggerEvent.Invoke();
            }
        }
            
        if (this.CompareTag("Enemy"))
        {
            if (other.CompareTag("Projectile"))
            {
                HitEvent.Invoke();
                
            }
        }
        if (this.CompareTag("Player"))
            if (other.CompareTag("Projectile"))
            {
                PlayerHitEvent.Invoke();
            }
        if (this.CompareTag("Detection"))
        {
            
            if (other.CompareTag("Player"))
            {

               GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
        if (other.CompareTag("Projectile") && this.transform.tag!= "Detection")
            Destroy(other.gameObject);
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.CompareTag("Detection"))
        {
          
            if (other.CompareTag("Player"))
            {
    
                GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
    }

}

