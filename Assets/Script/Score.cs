using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコアを表示するGUIText
    public Text scoreText;
    // スコア
    private int score;
    
    private void Start() 
    {
        Initialize();
    }
    
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
