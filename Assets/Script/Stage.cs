using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    private bool firstPush = false; 

    /**
     * ステージクリアボタンが押下された時の処理
     */
    public void PressStageClearButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("StageClear");
    }

    /**
     * ゲームオーバーボタンが押下された時の処理
     */
    public void PressGameOverButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("GameOver");  
    }

    /**
     * Topへ戻るボタンが押下された時の処理
     */
    public void PressBackButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("Top");  
    }
}
