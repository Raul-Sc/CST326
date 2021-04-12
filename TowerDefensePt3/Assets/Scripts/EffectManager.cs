using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(Detonate());
    }
    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
