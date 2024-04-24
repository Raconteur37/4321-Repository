using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime[] realtime;
    [SerializeField] private string sceneName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) { return; }

        isLoading = true;

        StartCoroutine(LoadSceneAdditive());
    }

    IEnumerator LoadSceneAdditive()
    {
        var loadAsync = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

        while (!loadAsync.isDone) { yield return null; }

        realtime = FindObjectsOfType<Realtime>();

        foreach (var rt in realtime)
        {
            if (rt != null)
            {
                rt.Connect(sceneName);
            }
        }

        isLoading = false;

    }

}
