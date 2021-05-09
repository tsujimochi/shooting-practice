using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    /// <summary>
    /// アニメーション終了後に呼び出されるメソッド
    /// </summary>
    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}
