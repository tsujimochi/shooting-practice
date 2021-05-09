using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾のスピード
    public int speed = 10;
    // 攻撃力
    public int power = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }
}
