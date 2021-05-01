using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    private bool firstPush = false; 

    /**
     * 戻るボタンが押下された時の処理
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
