/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.instance.gameOver && GameManager.instance.freezeTiles && GameManager.instance.gameEnded)
        {
            if (GameManager.instance.freezeTiles)
            {
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.instance.SpawnTile();
            StartCoroutine(FallAndReplace());
        }
    }

    private IEnumerator FallAndReplace()
    {
        yield return new WaitForSeconds(0.1f);
        _rb.isKinematic = false;

        yield return new WaitForSeconds(3);
        if (!GameManager.instance.freezeTiles)
        {
            this.gameObject.SetActive(false);
            _rb.isKinematic = true;

            if (this.tag == "TopTile")
            {
                TileManager.instance.AddTopTile(gameObject);
            }
            else if (this.tag == "LeftTile")
            {
                TileManager.instance.AddLeftTile(gameObject);
            }
        }
        else
        {
            _rb.isKinematic = true;
        }
    }
}
