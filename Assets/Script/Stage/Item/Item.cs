using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    #region インスペクターで設定
    public GameObject se;
    #endregion
    
    public void Move(Vector2 direction,  float speed = 0)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed * -1;
    }

    /// <summary>
    /// アイテムを使う
    /// </summary>
    /// <param name="player"></param>
    public abstract void UseItem(Player player);
}
