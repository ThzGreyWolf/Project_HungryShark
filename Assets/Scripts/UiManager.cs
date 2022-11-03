using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour {
    
    [SerializeField] GameObject m_mainMenu, m_inGameMenu, m_pauseMenu, m_gameoverMenu;

    [Space]
    [SerializeField] TMP_Text m_scoreText, m_goScoreText;
    [SerializeField] GameObject[] m_hearts;

    public void ShowMainMenu() {
        m_inGameMenu.SetActive(false);
        HidePauseMenu();
        m_mainMenu.SetActive(true);
        m_gameoverMenu.SetActive(false);
    }

    public void ShowPauseMenu() {
        m_pauseMenu.SetActive(true);
    }

    public void HidePauseMenu() {
        m_pauseMenu.SetActive(false);
    }

    public void ShowInGameMenu() {
        m_inGameMenu.SetActive(true);
        HidePauseMenu();
        m_mainMenu.SetActive(false);
        m_gameoverMenu.SetActive(false);
    }

    public void ShowGameoverMenu() {
        m_inGameMenu.SetActive(false);
        HidePauseMenu();
        m_mainMenu.SetActive(false);
        m_gameoverMenu.SetActive(true);
    }

    public void UpdateScore(int value) {
        m_scoreText.text = value.ToString();
        m_goScoreText.text = value.ToString();
    }

    public void RemoveHeart(int lives) {
        m_hearts[lives].SetActive(false);
    }

    public void ResetHearts() {
        foreach(GameObject heart in m_hearts) {
            heart.SetActive(true);
        }
    }
}
