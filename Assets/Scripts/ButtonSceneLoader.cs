using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSceneLoader : MonoBehaviour
{
    // Variables
    [Header("Button Info")]
    public Button button;

    [Header("Scene data")]
    public bool loadingByIndex = true;
    public int sceneIndex = 0;
    public string sceneName = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions
    void TaskOnClick()
    {
        if (loadingByIndex)
        {
            LoadSceneAsyncByIndex(sceneIndex);
        }
        else
        {
            LoadSceneAsyncByName(sceneName);
        }

    }

    public void LoadSceneAsyncByIndex(int scene) // Function to load Scene by Index
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }

    public void LoadSceneAsyncByName(string scene) // Function to load Scene by Name
    {
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}
