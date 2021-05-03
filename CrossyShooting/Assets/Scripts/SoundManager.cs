using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ruffle,playerMove, enemyMove, gunShot, gunReload,gunEmpty,hit;
    GameObject player;
    private void Awake()
    {
        player = transform.gameObject;
        ruffle = Resources.Load<AudioClip>("ruffle");
        playerMove = Resources.Load<AudioClip>("playerMove");
        enemyMove = Resources.Load<AudioClip>("EnemyMove");
        gunShot = Resources.Load<AudioClip>("singleShot");
        gunReload = Resources.Load<AudioClip>("reload");
        gunEmpty = Resources.Load<AudioClip>("empty");
        hit = Resources.Load<AudioClip>("hit");

    }
    public void PlaySound(string sound)
    {
        if(sound == "ruffle")
            AudioSource.PlayClipAtPoint(ruffle, player.transform.position, .1f);
        if (sound ==  "jump")
        { 
          if(player.CompareTag("Player"))
            AudioSource.PlayClipAtPoint(playerMove, player.transform.position,.1f);
           if(player.CompareTag("Enemy"))
            AudioSource.PlayClipAtPoint(enemyMove, player.transform.position, .2f);
            else
            {
               AudioSource.PlayClipAtPoint(playerMove, Camera.main.transform.position, .2f);
            }
        }
        if(sound == "shot")
            AudioSource.PlayClipAtPoint(gunShot,player.transform.position, .3f);
        if (sound == "reload")
            AudioSource.PlayClipAtPoint(gunReload, player.transform.position, .5f);
        if(sound == "empty")
            AudioSource.PlayClipAtPoint(gunEmpty, player.transform.position, .5f);
        if(sound == "hit")
            AudioSource.PlayClipAtPoint(hit, player.transform.position, .5f);
    }
}
