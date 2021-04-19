using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Land : MonoBehaviour
{
    MotherShip motherShip;
    private void Awake()
    {
        motherShip = GetComponentInChildren<MotherShip>();
    }
    public void InfromMotherShip()
    {
        if(motherShip != null)
            motherShip.DestroyPawns();
    }
}
/*
 Class Land

    Data members:

        MotherShip motherShip;

    Functions:

        Awake()
        InfromMotherShip(); //tells mothership when its about to be destroyed
 */