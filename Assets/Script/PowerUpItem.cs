using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : Item
{

    #region プライベート変数
    private int power = 1;
    #endregion

    /// <summary>
    /// アイテムを使用する（パワーアップ）
    /// </summary>
    /// <param name="player"></param>
    public override void UseItem(Player player)
    {
        player.shotLevel += power;
        Destroy(gameObject);
    }
}
