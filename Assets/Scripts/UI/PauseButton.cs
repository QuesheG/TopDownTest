using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
   
    public static bool isPaused = false;
    //Aqui é pego o Objeto da UI
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    //Esse método é chamado a cada frame do jogo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Aqui são métodos para os botões e pausar o jogo com o Esc

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenSettings()
    {
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        //Make it quit
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Mainmenu");
    }

    public void BackToEscape(){
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

}
