using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region インスペクターで設定
    [Header("スコアを表示するText")] public Text scoreText;
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
        scoreText.text = (GameParameter.Score + GameParameter.ContinueCount).ToString();
    }

    /// <summary>
    /// ゲーム開始前の状態に戻す
    /// </summary>
    public void Initialize()
    {
        GameParameter.Score = 0;
    }

    /// <summary>
    /// ポイントの追加
    /// </summary>
    /// <param name="point"></param>
    public void AddPoint(int point)
    {
        GameParameter.Score += point;
    }
}
