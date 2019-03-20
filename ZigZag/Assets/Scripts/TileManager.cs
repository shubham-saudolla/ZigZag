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
        for (int i = 0; i < 50; i++)
            instance.SpawnTile();
    }

    public void SpawnTile()
    {
        int index = Random.Range(0, 2);
        currentTile = (GameObject)Instantiate(tiles[index], currentTile.transform.GetChild(0).GetChild(index).position, Quaternion.identity);
    }
}
