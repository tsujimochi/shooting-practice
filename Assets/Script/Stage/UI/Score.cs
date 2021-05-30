﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region インスペクターで設定
    [Header("スコアを表示するText")] public Text scoreText;
    #endregion
    
    /// <summary>
    /// Update
    /// </summary>
    private void Update() 
    {
        // スコアを表示する
        scoreText.text = (GameParameter.Score + GameParameter.ContinueCount).ToString();
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
