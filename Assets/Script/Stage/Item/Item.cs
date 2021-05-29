using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    #region インスペクターで設定
    public GameObject se;
    #endregion

    #region 定数
    private const float DEFAULT_SPEED = 1;
    #endregion

    public void Move(float speed = DEFAULT_SPEED)
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed * -1;
    }

    /// <summary>
    /// アイテムを使う
    /// </summary>
    /// <param name="player"></param>
    public abstract void UseItem();
}
