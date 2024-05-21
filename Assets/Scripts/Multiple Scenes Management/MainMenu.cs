using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject loadingInterface;
    public Image loadingProgressBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    // Start is called before the first frame update
    public void StartGame()
    {
        HideMenu();
        ShowLoadingScreen();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("GamePlay"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level01Part01", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    public void ShowLoadingScreen()
    {
        loadingInterface.SetActive(true);
    }

    IEnumerator LoadingScreen()
    {
        float workInProgress = 0f;

        for(int i = 0; i  < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                workInProgress += scenesToLoad[i].progress;
                loadingProgressBar.fillAmount = workInProgress / scenesToLoad.Count;
                yield return null;
            }
        }


        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
