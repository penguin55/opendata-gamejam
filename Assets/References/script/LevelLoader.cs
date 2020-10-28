using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool isLoading;
    public Canvas loadingCanvas;

    public static LevelLoader instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void LoadLevel(int sceneIndex)
    {
        isLoading = true;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingCanvas.gameObject.SetActive(true);


        while (!operation.isDone)
        {
            yield return null;
        }
        loadingCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        loadingCanvas.worldCamera = Camera.main;
    }

    public void LoadDone()
    {
        isLoading = false;
        loadingCanvas.gameObject.SetActive(false);
    }
}
