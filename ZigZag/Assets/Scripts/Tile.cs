/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.instance.SpawnTile();
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(1);

        GetComponent<Rigidbody>().isKinematic = true;

        if (name == "Top")
        {
            TileManager.instance.AddTopTile(gameObject);
        }
        else
        {
            TileManager.instance.AddLeftTile(gameObject);
        }
    }
}
