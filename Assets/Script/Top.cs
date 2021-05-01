using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Top : MonoBehaviour
{
    private bool firstPush = false; 

    /**
     * スタートボタンが押下された時の処理
     */
    public void PressStartButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("Stage1");
    }

    /**
     * HowToボタンが押下された時の処理
     */
    public void PressHowToButton()
    {
        if (firstPush) {
            return;
        }
        firstPush = true;
        SceneManager.LoadScene("HowToPlay");  
    }
}
