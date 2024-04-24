using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    [SerializeField] private string sceneName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) { return; }

        isLoading = true;

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        realtime.Disconnect();
        realtime = null;

        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (!loadAsync.isDone) { yield return null; }

        realtime = FindObjectOfType<Realtime>();

        realtime.Connect(sceneName);

        isLoading = false;
    }


}
