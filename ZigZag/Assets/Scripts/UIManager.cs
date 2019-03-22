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

    public GameObject title;
    public TMP_Text scoreBoard;
    public GameObject tapButton;

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

    public void TapButtonClick()
    {
        if (GameManager.instance.gameOver && GameManager.instance.freezeTiles)
        {
            scoreBoard.GetComponent<Animator>().SetTrigger("ScoreFadeIn");
            tapButton.GetComponent<Animator>().SetTrigger("TapButtonFade");
            title.GetComponent<Animator>().SetTrigger("TitleFade");
            StartCoroutine(FadeOutToGame());
        }
    }

    public void ArriveIntoGame()
    {
        title.GetComponent<Animator>().SetTrigger("TitleArrive");
        tapButton.GetComponent<Animator>().SetTrigger("TapButtonArrive");
    }

    private IEnumerator FadeOutToGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.gameOver = false;
        GameManager.instance.freezeTiles = false;
        startPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        endPanel.SetActive(true);
        scoreBoard.GetComponent<Animator>().SetTrigger("ScoreFadeOut");
    }
}
