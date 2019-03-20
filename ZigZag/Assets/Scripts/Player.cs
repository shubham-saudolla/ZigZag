/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 9.0f;

    public Vector3 dir;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }

        transform.Translate(dir * _speed * Time.deltaTime);
    }
}
