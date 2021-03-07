using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        if (!gameObject.CompareTag("Shredder") ) 
        {
            if (gameObject.name == "Enemy(Clone)")
            {
                gameObject.GetComponent<Enemy>().ReportDeath();
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<Player>().ReportDeath();

            }
            else
                Destroy(gameObject);
        }
    }
}
