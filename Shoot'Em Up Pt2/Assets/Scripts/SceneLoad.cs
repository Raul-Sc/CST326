using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    IEnumerator LoadNext()
    {
        float delay = .2f;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex == 3)
        {
            sceneIndex = 0;
            delay = 3f;
        }
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
    public void Next()
    {
        StartCoroutine(LoadNext());
    }
}
