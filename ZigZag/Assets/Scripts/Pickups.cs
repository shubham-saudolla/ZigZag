/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public GameObject burstParticlesPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.Play("Pickup");
            GameManager.instance.IncrementScore(2);

            Instantiate(burstParticlesPrefab, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
