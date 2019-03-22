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

    public GameObject Title;
    public TMP_Text scoreBoard;
    public GameObject TapButton;

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
            TapButton.GetComponent<Animator>().SetTrigger("TapButtonFade");
            Title.GetComponent<Animator>().SetTrigger("TitleFade");
            StartCoroutine(FadeInToGame());
        }
    }

    private IEnumerator FadeInToGame()
    {
        yield return new WaitForSeconds(1.0f);
        GameManager.instance.gameOver = false;
        GameManager.instance.freezeTiles = false;
        TapButton.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);

    }
}
