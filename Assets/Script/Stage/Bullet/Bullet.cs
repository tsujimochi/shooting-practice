using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region インスペクターで設定
    [Header("弾のスピード")] public int speed = 10;
    [Header("攻撃力")] public int power = 1;
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }
}
