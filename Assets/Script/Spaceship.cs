using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class Spaceship : MonoBehaviour
{
    // 移動スピード
    public float speed;
    // 弾を撃つ間隔
    public float shotDelay;
    // 弾のPrefab
    public GameObject bullet;
    // 爆発のPrefab
    public GameObject explosion;
    // 弾を撃つかどうか
    public bool canShot;
    // アニメーターコンポーネント
    private Animator animator;

    /// <summary>
    /// 爆発の作成
    /// </summary>
    public void Explosion()
    {
        Instantiate (explosion, transform.position, transform.rotation);
    }

    /// <summary>
    /// 弾の作成
    /// </summary>
    /// <param name="origin"></param>
    public void Shot (Transform origin)
    {
        Instantiate (bullet, origin.position, origin.rotation);
    }

    /// <summary>
    /// アニメーターコンポーネントの取得
    /// </summary>
    /// <returns></returns>
    public Animator GetAnimator()
    {
        if (animator == null) {
            // アニメーターコンポーネントを取得
            animator = GetComponent<Animator>();
        }
        return animator;
    }

    protected abstract void Move(Vector2 direction);
}
