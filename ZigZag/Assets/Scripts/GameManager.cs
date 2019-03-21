/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float slowDownFactor = 10f;
    public float slowMotionTime = 1.7f;
    public bool gameOver = false;
    public bool freezeTiles = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        freezeTiles = false;
        gameOver = false;
    }

    private void Update()
    {
        if (freezeTiles)
        {
            ReloadLevel();
        }
    }

    public void EndGame()
    {
        gameOver = true;
        StartCoroutine(SlowDownAndStop());
    }

    private IEnumerator SlowDownAndStop()
    {
        Time.timeScale = 1 / slowDownFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownFactor;

        yield return new WaitForSeconds(slowMotionTime / slowDownFactor);

        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownFactor;
        freezeTiles = true;
    }

    private void ReloadLevel()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
