using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class Spaceship : MonoBehaviour
{
    #region インスペクターで設定
    [Header("移動スピード")] public float speed;
    [Header("ショットレベル")] public int shotLevel;
    [Header("弾を撃つ間隔")] public float shotDelay;
    [Header("弾を撃つかどうか")] public bool canShot;
    [Header("弾のPrefab")] public GameObject bullet;
    [Header("爆発のPrefab")] public GameObject explosion;
    #endregion
    
    #region プライベート変数
    // アニメーターコンポーネント
    private Animator animator;
    // 画面内にいる
    protected bool inDisplay;
    #endregion

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
    /// <param name="outSound">SEを流す場合はtrue</param>
    /// <returns>待ち時間</returns>
    public void Shot (Transform origin, bool outSound = false)
    {
        if (canShot == false || inDisplay == false) {
            return;
        }
        GameObject bulletObject = (GameObject)Instantiate (bullet, origin.position, origin.rotation);
        // 弾の親要素を自分と同じにする
        bulletObject.transform.parent = transform.parent;
        if (outSound) {
            // ショット音を鳴らす
            GetComponent<AudioSource>().Play();
        }
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

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="direction"></param>
    protected abstract void Move(Vector2 direction);

    /// <summary>
    /// 被弾
    /// </summary>
    protected abstract void BeShot(int damage = 0);
}
