using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region インスペクターで設定
    [Header("スコアを表示するText")] public Text scoreText;
    #endregion

    #region プライベート変数
    // スコア
    private int score = 0;
    #endregion
    
    /// <summary>
    /// Start
    /// </summary>
    private void Start() 
    {
        Initialize();
    }
    
    /// <summary>
    /// Update
    /// </summary>
    private void Update() 
    {
        // スコアを表示する
        scoreText.text = score.ToString();
    }

    /// <summary>
    /// ゲーム開始前の状態に戻す
    /// </summary>
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
    }

    /// <summary>
    /// ポイントの追加
    /// </summary>
    /// <param name="point"></param>
    public void AddPoint(int point)
    {
        score += point;
    }
}
