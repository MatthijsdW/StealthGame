using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject gameWinUI, gameLoseUI;
    private bool gameOver;

    // Start is called before the first frame update
    private void Start()
    {
        Guard.OnPlayerSpotted += ShowGameLoseUI;
        Player.OnReachedFinish += ShowGameWinUI;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void ShowGameWinUI()
    {
        OnGameOver(gameWinUI);
    }

    private void ShowGameLoseUI()
    {
        OnGameOver(gameLoseUI);
    }

    private void OnGameOver(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
        gameOver = true;
        Guard.OnPlayerSpotted -= ShowGameLoseUI;
        Player.OnReachedFinish -= ShowGameWinUI;
    }
}
