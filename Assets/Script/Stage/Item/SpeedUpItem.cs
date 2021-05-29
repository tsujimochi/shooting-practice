using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : Item
{
    #region プライベート変数
    // 上昇値
    private int speed = 2;
    // 使用したか
    private bool isUsed = false;
    #endregion

    /// <summary>
    /// アイテムを使用する（スピードアップ）
    /// </summary>
    /// <param name="player"></param>
    public override void UseItem()
    {
        if (isUsed)
        {
            return;
        }
        isUsed = true;
        GameObject soundObject = (GameObject)Instantiate(se, transform.position, transform.rotation);
        GameParameter.PlayerSpeed += speed;
        if (GameParameter.PlayerSpeed > GameConst.MAX_PLAYER_SPEED) {
            GameParameter.PlayerSpeed = GameConst.MAX_PLAYER_SPEED;
        }
        Destroy(soundObject, 3);
        Destroy(gameObject);
    }
}
