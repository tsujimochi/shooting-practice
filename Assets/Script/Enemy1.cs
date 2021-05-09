using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Spaceship
{
    // ヒットポイント
    public int hp = 1;

    IEnumerator Start()
    {
        // ローカル座標のY軸のマイナス方向に移動する
        Move(transform.right * -1);

        if (canShot == false) {
            yield break;
        }

        while(true) {
            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotPosition = transform.GetChild(i);

                // ShotPositionの位置/角度で弾を撃つ
                Shot(shotPosition);
            }
            yield return new WaitForSeconds(shotDelay);
        }
    }

    /// <summary>
    /// 機体の移動
    /// </summary>
    /// <param name="direction"></param>
    protected override void Move (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    /// <summary>
    /// ぶつかった瞬間に呼び出される
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet(Player)以外の時は何も行わない
        if (layerName != "Bullet(Player)")
        {
            return;
        }

        // Bulletコンポーネントを取得
        Bullet bullet = c.GetComponent<Bullet>();

        // ヒットポイントを減らす
        hp = hp - bullet.power;

        // 弾の削除
        Destroy(c.gameObject);

        if (hp <= 0) 
        {
            // 爆発する
            Explosion();
            // プレイヤーの削除
            Destroy(gameObject);
        } else {
            GetAnimator().SetTrigger("Damage");
        }
    }
}
