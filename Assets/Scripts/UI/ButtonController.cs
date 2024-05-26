using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject PanelPauseGame;
    private bool Pause;
    [SerializeField] private GameObject PanelLoseGame;
    public void PlayAgain()
    {
        PanelLoseGame.SetActive(false);
        SceneManager.LoadScene("Level 1");
    }

    public void PauseButton()
    {
        PanelPauseGame.SetActive(true);
        Time.timeScale = 0;
        Pause = true;
    }
    public void Replay()
    {
        PanelPauseGame.SetActive(false);
        Time.timeScale = 1;
        Pause = false;
    }
    public void exitGame()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
