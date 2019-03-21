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

    private Stack<GameObject> _topTiles = new Stack<GameObject>();
    private Stack<GameObject> _leftTiles = new Stack<GameObject>();

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
            _topTiles.Push(Instantiate(tiles[0]));
            _leftTiles.Push(Instantiate(tiles[1]));
            _topTiles.Peek().SetActive(false);
            _leftTiles.Peek().SetActive(false);
        }
    }

    public void SpawnTile()
    {
        if (_leftTiles.Count <= 0 || _topTiles.Count <= 0)
        {
            CreateTiles(100);
        }

        int index = Random.Range(0, 2);
        if (index == 0)
        {
            GameObject temp = _topTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).GetChild(index).position;
            currentTile = temp;
        }
        else if (index == 1)
        {
            GameObject temp = _leftTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).GetChild(index).position;
            currentTile = temp;
        }
    }

    public void AddTopTile(GameObject obj)
    {
        _topTiles.Push(obj);
    }

    public void AddLeftTile(GameObject obj)
    {
        _leftTiles.Push(obj);
    }
}
