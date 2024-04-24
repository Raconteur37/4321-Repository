using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class NormalSceneLoader : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    [SerializeField] private string sceneName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) return;

        isLoading = true;

        realtime.Disconnect();
        realtime = null;

        SceneManager.LoadScene(sceneName);

        realtime = FindObjectOfType<Realtime>();
        realtime.Connect(sceneName);

        isLoading = false;
    }
}
