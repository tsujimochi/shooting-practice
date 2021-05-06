﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }
}
