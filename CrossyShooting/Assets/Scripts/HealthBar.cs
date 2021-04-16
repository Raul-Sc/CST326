using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Health life;
    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
        life = transform.GetComponentInParent<Health>();
        if(life != null)
        {
            print(life.health);
        }

    }
    private void Update()
    {
        if(life != null)
            slider.value = life.health;
    }

}
