using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Spaceship
{
    #region // インスペクターで設定
    [Header("ヒットポイント")] public int hp = 1;
    [Header("スコアのポイント")] public int point = 100;
    [Header("アイテムドロップ")] public bool isItemDrop = false;
    [Header("ドロップするアイテム")] public GameObject dropItem;
    #endregion

    #region 定数
    // プレイヤーの弾のレイヤー名
    private string LAYER_PLAYER_BULLET_NAME = "Bullet(Player)";
    // デストロイエリアのレイヤー名
    private string LAYER_DESTROY_AREA_NAME = "DestroyArea";
    // ダメージのアニメーター名
    private string ANIMATOR_DAMAGE_NAME = "Damage";
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        // ローカル座標のX軸のマイナス方向に移動する
        Move(transform.right * -1);
        while(true) {
            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotPosition = transform.GetChild(i);
                // ShotPositionの位置/角度で弾を撃つ
                Shot(shotPosition);
            }
            // 次の弾発出までのディレイ
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
        if (hp <= 0)
        {
            return;
        }
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // デストロイエリアと接触した場合は画面内に入ったフラグを立てる
        if (layerName == LAYER_DESTROY_AREA_NAME) {
            inDisplay = true;
        }
        // レイヤー名がBullet(Player)以外の時は何も行わない
        if (layerName != LAYER_PLAYER_BULLET_NAME) {
            return;
        }
        // 弾の削除
        Destroy(c.gameObject);
        BeShot(c.GetComponent<Bullet>().power);
    }

    /// <summary>
    /// 被弾
    /// </summary>
    protected override void BeShot(int damage = 0)
    {
        // ヒットポイントを減らす
        hp -= damage;
        if (hp <= 0) {
            // スコアコンポーネントを取得してポイントを追加
            FindObjectOfType<Score>().AddPoint(point);
            // 爆発する
            Explosion();
            if (isItemDrop) {
                GameObject item = (GameObject)Instantiate(dropItem, transform.position, Quaternion.identity);
                item.transform.parent = transform.parent.parent;
                item.GetComponent<Item>().Move();
            }
            // エネミーの削除
            Destroy(gameObject);
        } else {
            GetAnimator().SetTrigger(ANIMATOR_DAMAGE_NAME);
        }
    }
}
