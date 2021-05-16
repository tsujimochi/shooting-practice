using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    #region 定数
    // プレイヤーのレイヤー名
    private const string LAYER_PLAYER_NAME = "Player";
    #endregion


    /// <summary>
    /// 範囲外に出たオブジェクトは全削除
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerExit2D(Collider2D c)
    {
        // レイヤー名がプレイヤーの場合は無視
        if (LayerMask.LayerToName(c.gameObject.layer) == LAYER_PLAYER_NAME)
        {
            return;
        }
        Destroy (c.gameObject);
    }
}
