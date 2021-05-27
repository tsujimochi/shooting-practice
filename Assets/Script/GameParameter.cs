using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体で使用する静的変数の集まり
/// </summary>
public class GameParameter {

    /// <summary>
    /// スコア
    /// </summary>
    public static int Score { get; set; } = 0;

    /// <summary>
    /// コンティニュー回数
    /// </summary>
    public static int ContinueCount { get; set; } = 0;
}
