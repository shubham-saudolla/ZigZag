/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    public GameObject[] tiles;

    public GameObject currentTile;

    public Stack<GameObject> topTiles = new Stack<GameObject>();
    public Stack<GameObject> leftTiles = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        CreateTiles(100);

        for (int i = 0; i < 50; i++)
            instance.SpawnTile();
    }

    public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            topTiles.Push(Instantiate(tiles[0]));
            leftTiles.Push(Instantiate(tiles[1]));
            topTiles.Peek().SetActive(false);
            leftTiles.Peek().SetActive(false);

            topTiles.Peek().name = "Top";
            leftTiles.Peek().name = "Left";
        }
    }

    public void SpawnTile()
    {
        if (leftTiles.Count <= 0 || leftTiles.Count <= 0)
        {
            CreateTiles(100);
        }

        int index = Random.Range(0, 2);
        if (index == 0)
        {
            GameObject temp = topTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).GetChild(0).position;
            currentTile = temp;
        }
        else if (index == 1)
        {
            GameObject temp = leftTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).GetChild(1).position;
            currentTile = temp;
        }
    }

    public void AddTopTile(GameObject obj)
    {
        topTiles.Push(obj);
        topTiles.Peek().SetActive(false);
    }

    public void AddLeftTile(GameObject obj)
    {
        leftTiles.Push(obj);
        topTiles.Peek().SetActive(false);
    }
}
