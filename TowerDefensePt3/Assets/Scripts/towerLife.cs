using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerLife : MonoBehaviour
{
    Slider slider;
    Basetower basetower;
    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
        basetower = transform.GetComponentInParent<Basetower>();
    }
    private void Update()
    {
        if (basetower != null)
            slider.value = basetower.health;
    }
}
