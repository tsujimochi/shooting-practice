using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    /// <summary>
    /// 範囲外に出たオブジェクトは全削除
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerExit2D(Collider2D c)
    {
        Destroy (c.gameObject);
    }
}
