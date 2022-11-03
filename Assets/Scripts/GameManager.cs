using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject m_player;

    FishSpawner m_fishSpawner;
    UiManager m_uiManager;

    int m_score = 0;
    int m_lives = 3;

    void Start() {
        m_fishSpawner = GetComponent<FishSpawner>();
        m_uiManager = GetComponent<UiManager>();

        m_uiManager.ShowMainMenu();
    }

    public void StartGame() {
        m_player.SetActive(true);
        m_fishSpawner.enabled = true;

        m_score = 0;
        m_uiManager.UpdateScore(m_score);
        m_uiManager.ResetHearts();

        m_uiManager.ShowInGameMenu();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        m_uiManager.ShowPauseMenu();
    }

    public void UnPauseGame() {
        Time.timeScale = 1;
        m_uiManager.ShowInGameMenu();
    } 

    public void PlayerAteCorrectfish() {
        m_score += 100;
        m_uiManager.UpdateScore(m_score);  
    }

    public void PlayerAteWrongFish() {
        if(m_lives > 0) {
            m_lives--;
            m_uiManager.RemoveHeart(m_lives);
        } else {
            ResetGame();
            m_uiManager.ShowGameoverMenu();
        }
    }

    public void ResetGame() {
        Time.timeScale = 1;

        m_score = 0;
        m_lives = 3;

        m_player.SetActive(false);
        m_player.GetComponent<SharkMovement>().Reset();
        m_fishSpawner.enabled = false;
    }
}
