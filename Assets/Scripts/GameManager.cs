using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    //[SerializeField] private List<Scene> _sceneList;

    //public int index;

    [SerializeField] private GameObject theBall;

    [SerializeField] private Transform spawnBallPoint;

    [SerializeField] private Transform parentObject;

    private GameObject RestartNextPreviousLevel;

    public GameObject DragonBall2;

    private void Start() {

        /*
        //Marche uniquement en mode test, mais plante pdt le build
        var guid = AssetDatabase.FindAssets("RestartNextPreviousLevel")[0];
        var path = AssetDatabase.GUIDToAssetPath(guid);
        var prefab = (GameObject)AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
        */

        /*
        //Pour gérer et instancier le bouton Exit
        var prefab = Resources.Load<GameObject>("ExitButtonCanvas");
        Instantiate(prefab);
        */

        /*
        var prefab = Resources.Load<GameObject>("RestartNextPreviousLevel");
        //RestartNextPreviousLevel = Instantiate(prefab);
        //Ne pas instancier le canvas permettant de passer d'un level à l'autre
        if(SceneManager.GetActiveScene().buildIndex != 0){
            RestartNextPreviousLevel = Instantiate(prefab);
            RestartNextPreviousLevel.SetActive(false);
        */
      

        /*
        //Pour instancier la balle au niveau 1
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Instantiate(DragonBall2, new Vector3(0.08, 6.81, 0.05), Quaternion.identity);
        }
        */
        
    }

    public void DisplayCanvas()
    {
        RestartNextPreviousLevel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    ////////////////////////////////////////////////////////////////////////////
        /*
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < _sceneList.Count)
        {
            SceneManager.LoadScene(_sceneList[currentScene + 1].buildIndex);
        }  
        else
        {
            print("Its last scene");
        }
        */
    ////////////////////////////////////////////////////////////////////////////

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    //Sélection aléatoire d'une scene
    /*
    int nextSceneIndex = Random.Range(0, 4);
    SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    */

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int index) {
        {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadPreviousScene()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
    }

    public void InstantiateTheBall()
    {
        Instantiate(theBall, spawnBallPoint.position, spawnBallPoint.rotation, parentObject);
    }
}
