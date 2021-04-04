using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int purse;
    readonly int damage = 38;
    Text purseUI;

    public GameObject tower;
    int laserTowerCost = 100;
    
    private void Awake()
    {
        purseUI = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();

    }
    // Update is called once per frame
    void Update()
    {
        purseUI.text = '$' + purse.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            
            if (hit.transform.CompareTag("Enemy"))
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                purse += enemy.GetBounty(damage);
            }
            if (hit.transform.CompareTag("Land"))
            {
                if (purse >= laserTowerCost)
                {
                    Instantiate(tower, hit.transform.position, Quaternion.identity);
                    purse -= laserTowerCost;
                }
            }
        }
    }

    /*
    class Player
        functions:
        shoot()// Shots a ray if enemy hit, try and collect our bounty

        Data Members
        int purse;//how much money a player gets from collectiing bounties
        int damage;//how much damage it deals


    */
}
