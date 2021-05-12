using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : Item
{
    #region プライベート変数
    private int speed = 2;
    #endregion

    /// <summary>
    /// アイテムを使用する（スピードアップ）
    /// </summary>
    /// <param name="player"></param>
    public override void UseItem(Player player)
    {
        GameObject soundObject = (GameObject)Instantiate(se, transform.position, transform.rotation);
        player.speed += speed;
        if (player.speed > player.maxSpeed) {
            player.speed = player.maxSpeed;
        }
        Destroy(soundObject, 3);
        Destroy(gameObject);
    }
}
