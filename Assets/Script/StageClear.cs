using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    private bool firstPush = false; 

    /**
     * 次のステージへが押下された時の処理
     */
    public void PressNextStageButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("Stage1");
    }

    /**
     * ゲームクリアが押下された時の処理
     */
    public void PressGameClearButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("GameClear");  
    }
}
