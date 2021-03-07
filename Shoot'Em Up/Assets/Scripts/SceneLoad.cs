using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(3f);
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private void Start()
    {
        StartCoroutine(LoadNext());
    }
}
