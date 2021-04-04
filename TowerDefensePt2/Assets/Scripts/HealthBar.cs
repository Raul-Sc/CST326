using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Enemy enemy;
    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
        enemy = transform.GetComponentInParent<Enemy>();
    }
    private void Update()
    {
        if(enemy != null)
            slider.value = enemy.health;
    }

}
