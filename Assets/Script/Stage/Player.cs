using System.Collections;
using UnityEngine;

public class Player : Spaceship
{
    #region 定数
    // 敵のレイヤー名
    private const string LAYER_ENEMY_NAME = "Enemy";
    // 敵の弾レイヤー名
    private const string LAYER_ENEMY_BULLET_NAME = "Bullet(Enemy)";
    // アイテムのレイヤー名
    private const string LAYER_ITEM_NAME = "Item";
    // 最初の操作不可時間（秒）
    private const float NOT_CONTROL_SEC = 1;
    // キャラ登場時の初速
    private const float START_SPEED = 1;
    #endregion

    #region プライベート変数
    // プレイヤーの弾タイプ
    private PlayerShotType playerShotType;
    // プレイヤー操作可能判定
    private bool canControl = false;
    // 最大ショットレベル
    private int maxShotLevel = 0;
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    /// <returns></returns>
    IEnumerator Start ()
    {
        playerShotType = new PlayerShotType();
        maxShotLevel = playerShotType.GetMaxShotLevel();

        // 一定時間動く
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * START_SPEED;
        yield return new WaitForSeconds(NOT_CONTROL_SEC);
        canControl = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        while (true) {
            if (canControl)
            {
                Shot shot = playerShotType.GetShotType(GameParameter.PlayerPower);
                foreach (BulletType bulletType in shot.Bullets)
                {
                    Vector2 shotPosition = transform.position;
                    shotPosition.x += bulletType.X;
                    shotPosition.y += bulletType.Y;
                    // ShotPositionの位置/角度で弾を撃つ
                    Instantiate(bullet, shotPosition, Quaternion.Euler(0, 0, bulletType.Z));
                }
                GetComponent<AudioSource>().Play();
            }
            // 次の弾発出までのディレイ
            yield return new WaitForSeconds(playerShotType.GetShotDelay(GameParameter.PlayerPower));
        }
    }

    /// <summary>
    /// 操作可否をセットする
    /// </summary>
    /// <param name="canControl"></param>
    public void SetCanControl(bool canControl)
    {
        this.canControl = canControl;
    }

    /// <summary>
    /// 画面外に移動する
    /// </summary>
    public void MoveOffScreen(float speed = START_SPEED)
    {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update ()
    {
        if (canControl)
        {
            // 右・左
            float x = Input.GetAxisRaw("Horizontal");
            // 上・下
            float y = Input.GetAxisRaw("Vertical");
            // 移動する向きを求める
            Vector2 direction = new Vector2(x, y).normalized;
            Move(direction);
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="direction"></param>
    protected override void Move(Vector2 direction)
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        pos += direction * (GameParameter.PlayerSpeed + 1) * Time.deltaTime;

        // プレイヤーのサイズを取得
        Vector2 size = GetComponent<BoxCollider2D>().size;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x + (size.x / 2), max.x - (size.x / 2));
        pos.y = Mathf.Clamp(pos.y, min.y + (size.y / 2), max.y - (size.y / 2));

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    /// <summary>
    /// ぶつかった瞬間に呼び出される
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerEnter2D(Collider2D c)
    {
        if (canControl == false)
        {
            return;
        }
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名が敵または敵の弾の場合は被弾
        if (layerName == LAYER_ENEMY_BULLET_NAME) {
            // 弾の削除
            Destroy(c.gameObject);
            BeShot();
        } else if (layerName == LAYER_ENEMY_NAME) {
            BeShot();
        } else if (layerName == LAYER_ITEM_NAME) {
            c.gameObject.GetComponent<Item>().UseItem();
        }
    }

    /// <summary>
    /// 被弾
    /// </summary>
    protected override void BeShot(int damage = 0)
    {
        // 爆発する
        Explosion();
        // プレイヤーの削除
        Destroy(gameObject);
    }
}
