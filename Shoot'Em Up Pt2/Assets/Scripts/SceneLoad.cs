using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    float delay = .1f;
    IEnumerator LoadNext()
    {
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 2)
            sceneIndex = -1;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex+1);
    }
    public void Next()
    {
        StartCoroutine(LoadNext());
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            delay = 5f;
            Next();
            delay = .1f;
        }
       
    

    }
}
