/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject leftTile;
    public GameObject topTile;

    public GameObject currentTile;

    private void Start()
    {
        SpawnTopTile();
        SpawnTopTile();
        SpawnLeftTile();
    }

    private void SpawnTopTile()
    {
        GameObject newTile = (GameObject)Instantiate(topTile, currentTile.transform.GetChild(0).GetChild(0).position, Quaternion.identity);
        currentTile = newTile;
    }

    private void SpawnLeftTile()
    {
        GameObject newTile = (GameObject)Instantiate(leftTile, currentTile.transform.GetChild(0).GetChild(1).position, Quaternion.identity);
        currentTile = newTile;
    }
}
