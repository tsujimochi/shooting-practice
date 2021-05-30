using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region インスペクターで設定
    [Header("メニュー")] public GameObject menuObject;
    [Header("ゲームオーバーテキスト")] public GameObject gameOverTextObject;
    [Header("Tipsテキスト")] public Text tipsText;
    #endregion 

    IEnumerator Start()
    {
        // スコア初期化
        GameParameter.Score = 0;
        Text text = gameOverTextObject.GetComponent<Text>();
        while(text.color.a < 1)
        {
           text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime);
           yield return new WaitForEndOfFrame();
        }
        menuObject.SetActive(true);
        menuObject.transform.GetChild(0).gameObject.GetComponent<Selectable>().Select();
        tipsText.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            for (int idx = 0; idx < menuObject.transform.childCount; idx ++)
            {
                SelectableMenu menuItem = menuObject.transform.GetChild(idx).GetComponent<SelectableMenu>();
                if (menuItem.IsSelect)
                {
                    menuItem.LoadNextScene();
                    break;
                }
            }
        }
    }
}
