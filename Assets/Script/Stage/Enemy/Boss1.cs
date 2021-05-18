using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : Spaceship
{
    #region // インスペクターで設定
    [Header("ヒットポイント")] public int hp = 500;
    [Header("スコアのポイント")] public int point = 100;
    #endregion

    #region 定数
    // プレイヤーの弾のレイヤー名
    private string LAYER_PLAYER_BULLET_NAME = "Bullet(Player)";
    // デストロイエリアのレイヤー名
    private string LAYER_DESTROY_AREA_NAME = "DestroyArea";
    #endregion

    #region プライベート変数
    // 動き出すかどうか
    private bool startMove = false;
    // ショットタイプ
    private List<Shot> shotTypes;
    // HPバーオブジェクト
    private GameObject bossHPObject;
    // HPスライダー
    private Slider bossHPSlider;
    // 最大HP
    private int maxHP;
    #endregion

    IEnumerator Start()
    {
        Initialize();

        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        Move(transform.right * -1);
        while (transform.position.x > 5)
        {
            yield return new WaitForEndOfFrame();
        }
        Move(transform.right * 0);
        collider.enabled = true;
        bossHPObject.SetActive(true);
        startMove = true;
        Move(transform.up);

        while (true) {
            Shot shot = shotTypes[GetAttackType()];
            foreach (BulletType bulletType in shot.Bullets)
            {
                Vector2 shotPosition = transform.position;
                shotPosition.x += bulletType.X;
                shotPosition.y += bulletType.Y;
                // ShotPositionの位置/角度で弾を撃つ
                GameObject bulletObject = (GameObject)Instantiate(bullet, shotPosition, Quaternion.Euler(0, 0, bulletType.Z));
                bulletObject.GetComponent<Transform>().localScale = new Vector2(bulletType.Scale, bulletType.Scale);
            }
            // 次の弾発出までのディレイ
            yield return new WaitForSeconds(shot.ShotDelay);
        }
    }

    void Update()
    {
        if (startMove)
        {
            if (transform.position.y >= 4)
            {
                Move(transform.up * -1);
            } 
            else if (transform.position.y <= -4) 
            {
                Move(transform.up);
            }
        }
        bossHPSlider.value = hp;
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
        if ((hp <= 0 || startMove == false) && inDisplay)
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
            bossHPObject.SetActive(false);
            // スコアコンポーネントを取得してポイントを追加
            FindObjectOfType<Score>().AddPoint(point);
            // 爆発する
            Explosion();
            // エネミーの削除
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        maxHP = hp;

        bossHPObject = FindObjectOfType<Manager>().bossHPBar;
        bossHPSlider = bossHPObject.GetComponent<Slider>();
        bossHPSlider.maxValue = maxHP;
        bossHPSlider.value = maxHP;

        shotTypes = new List<Shot>();

        shotTypes.Add(new Shot());
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, 0.3f, 180, 1, 1));
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, -0.3f, 180, 1, 1));
        shotTypes[shotTypes.Count - 1].ShotDelay = 1f;

        shotTypes.Add(new Shot());
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, 0.5f, 180, 1, 2f));
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, -0.5f, 180, 1, 2f));
        shotTypes[shotTypes.Count - 1].ShotDelay = 1f;

        shotTypes.Add(new Shot());
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0f, 0, 180, 1, 10));
        shotTypes[shotTypes.Count - 1].ShotDelay = 1f;

        shotTypes.Add(new Shot());
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(1, 0, 185, 1, 2));
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0f, 0, 180, 1, 4));
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(1, 0, 175, 1, 2));
        shotTypes[shotTypes.Count - 1].ShotDelay = 1f;

        shotTypes.Add(new Shot());
        for (int idx = 0; idx < 18; idx++)
        {
            shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, 0, 0 + (idx * 20), 1, 3));
        }
        shotTypes[shotTypes.Count - 1].ShotDelay = 1f;

        shotTypes.Add(new Shot());
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, 3, 180, 1, 10));
        shotTypes[shotTypes.Count - 1].AddBullet(new BulletType(0, -3, 180, 1, 10));
        shotTypes[shotTypes.Count - 1].ShotDelay = 0.4f;
    }

    private int GetAttackType()
    {
        int percentage = (int)Mathf.Floor(1.0f * hp / maxHP * 100);
        if (percentage <= 5)
        {
            return 5;
        }
        else if (percentage <= 20)
        {
            return 4;
        }
        else if (percentage <= 40)
        {
            return 3;
        }
        else if (percentage <= 60)
        {
            return 2;
        }
        else if (percentage <= 80)
        {
            return 1;
        }
        return 0;
    }
}
