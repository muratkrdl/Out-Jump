using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas finishCanvas;
    [SerializeField] Image[] stars;

    public int starCount;

    int currentSceneIndex;

    void Awake() 
    {
        finishCanvas.gameObject.SetActive(false);
        foreach(var item in stars) { item.gameObject.SetActive(false); }
    }

    void Start() 
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update() 
    {
        for(int i = 0; i < starCount; i++) { stars[i].gameObject.SetActive(true); }
    }

    public void GameOVer()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
        Time.timeScale = 1;
    }

    public void ShowFinishCanvas()
    {
        finishCanvas.gameObject.SetActive(true);
    }

}
