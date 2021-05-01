using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private bool firstPush = false; 

    /**
     * 次のステージへが押下された時の処理
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
