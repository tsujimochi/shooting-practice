using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float speed;
    // 弾を撃つ間隔
    public float shotDelay;
    // 弾のPrefab
    public GameObject bullet;
    // 弾を撃つかどうか
    public bool canShot;

    /// <summary>
    /// 弾の作成
    /// </summary>
    /// <param name="origin"></param>
    public void Shot (Transform origin)
    {
        Instantiate (bullet, origin.position, origin.rotation);
    }

    /// <summary>
    /// 機体の移動
    /// </summary>
    /// <param name="direction"></param>
    public void Move (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
