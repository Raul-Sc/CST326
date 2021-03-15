using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimate : MonoBehaviour
{
    public Sprite[] idle;
    public Sprite[] shoot;
    public Enemy enemy;
    public SpriteRenderer sp;
    int index = 0;
    float delay = 1f;
    bool canSwap = false;
    private void Start()
    {
        canSwap = true;
        index = 0;
    }
    private void Update()
    {
        if(canSwap)
            SwapSprite();
    }
    IEnumerator Swap()
    {
        if (enemy.canFire)
            sp.sprite = shoot[index];
        else
            sp.sprite = idle[index];
        yield return new WaitForSeconds(delay);
        canSwap = true;
    }

    private void SwapSprite()
    {
        canSwap = false;
        StartCoroutine(Swap());
        index++;
        if (index == idle.Length)
            index = 0;
    }
}
