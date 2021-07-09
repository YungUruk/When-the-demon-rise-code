using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public void tryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    private void Update()
    {
        PauseCheck();

    }
    public void PauseCheck()
    {
       
            if (Input.GetKey(KeyCode.Escape))
            {

                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        
    
        
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);       
        Time.timeScale = 1f;
    }
    public void GotoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
}
