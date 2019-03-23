/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startPanel;
    public GameObject endPanel;

    #region StartPanel
    public TMP_Text title;
    public TMP_Text scoreBoard;
    public GameObject startTapButton;
    public TMP_Text startBestScore;
    #endregion

    #region EndRegion
    public TMP_Text gameOverText;
    public GameObject finalScoreBoard;
    public GameObject retryButton;
    public TMP_Text finalScoreText;
    public TMP_Text bestScoreText;
    #endregion

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreBoard.text = newScore.ToString();
    }

    public void ScoreFadeOut()
    {
        scoreBoard.GetComponent<Animator>().SetTrigger("ScoreFadeOut");
    }

    public void TapButtonClick()
    {
        if (GameManager.instance.gameOver && GameManager.instance.freezeTiles)
        {
            scoreBoard.GetComponent<Animator>().SetTrigger("ScoreFadeIn");
            startTapButton.GetComponent<Animator>().SetTrigger("TapButtonFade");
            title.GetComponent<Animator>().SetTrigger("TitleFade");
            startBestScore.GetComponent<Animator>().SetTrigger("StartBestFade");
            StartCoroutine(FadeOutToGame());
        }
    }

    public void ArriveIntoGame()
    {
        title.GetComponent<Animator>().SetTrigger("TitleArrive");
        startTapButton.GetComponent<Animator>().SetTrigger("TapButtonArrive");
        startBestScore.text = "Best Score : " + GameManager.instance.GetBestScore();
        startBestScore.GetComponent<Animator>().SetTrigger("StartBestArrive");
    }

    private IEnumerator FadeOutToGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.gameOver = false;
        GameManager.instance.freezeTiles = false;
        startPanel.SetActive(false);
    }

    public void SetFinalScoreBoard(int score, int bestScore)
    {
        finalScoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
        ShowEndPanel();
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }

    public void RetryButton()
    {
        StartCoroutine(RetryAnimations());
    }

    private IEnumerator RetryAnimations()
    {
        gameOverText.GetComponent<Animator>().SetTrigger("GameOverFadeOut");
        finalScoreBoard.GetComponent<Animator>().SetTrigger("ScoreBoardFadeOut");
        retryButton.GetComponent<Animator>().SetTrigger("RetryButtonFadeOut");

        yield return new WaitForSeconds(0.5f);
        GameManager.instance.ReloadLevel();
    }
}
