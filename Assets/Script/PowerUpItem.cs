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
        GameObject soundObject = (GameObject)Instantiate(se, transform.position, transform.rotation);
        player.shotLevel += power;
        Destroy(soundObject, 3);
        Destroy(gameObject);
    }
}
