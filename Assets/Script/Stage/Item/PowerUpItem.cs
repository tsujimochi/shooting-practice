using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : Item
{
    #region プライベート変数
    // 上昇値
    private int power = 1;
    // 使用したか
    private bool isUsed = false;
    #endregion

    /// <summary>
    /// アイテムを使用する（パワーアップ）
    /// </summary>
    /// <param name="player"></param>
    public override void UseItem(Player player)
    {
        if (isUsed)
        {
            return;
        }
        isUsed = true;
        GameObject soundObject = (GameObject)Instantiate(se, transform.position, transform.rotation);
        if (player.shotLevel + 1 < player.GetMaxShotLevel())
        {
            player.shotLevel += power;
        }
        Destroy(soundObject, 3);
        Destroy(gameObject);
    }
}
