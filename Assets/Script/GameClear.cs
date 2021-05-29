using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    private void Start()
    {
        GameParameter.InitializePlayerStatus();
    }

    /**
     * 次のステージへが押下された時の処理
     */
    public void PressBackButton()
    {
        SceneManager.LoadScene("Top");
    }
}
