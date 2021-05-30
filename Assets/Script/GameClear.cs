using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    #region インスペクターで設定
    [Header("タイトルテキスト")] public Text titleText;
    [Header("スコアテキスト")] public Text scoreText;
    [Header("メッセージテキスト")] public Text messageText;
    [Header("スタッフテキスト")] public Text staffText;
    [Header("Tipsテキスト")] public Text tipsText;
    #endregion

    #region プライベート変数
    // 次のシーンに行けるか
    private bool canNextScene = false;
    // SE
    private AudioSource seAudio;
    #endregion

    #region 定数
    private const string TITLE = "Game Clear";
    #endregion

    IEnumerator Start()
    {
        seAudio = GetComponent<AudioSource>();
        yield return StartCoroutine(DisplayText(titleText, TITLE));
        yield return new WaitForSeconds(0.5f);
        messageText.enabled = true;
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DisplayText(scoreText, $"Score\n{GameParameter.Score}"));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(DisplayText(staffText, "制作\ntsujimochi\nh2ty"));
        yield return new WaitForSeconds(1);
        tipsText.enabled = true;
        canNextScene = true;
        GameParameter.ContinueCount = 0;
        GameParameter.InitializePlayerStatus();
    }
    private IEnumerator DisplayText(Text text, string textStr)
    {
        for (int idx = 0; idx < textStr.Length; idx++)
        {
            text.text += textStr[idx];
            seAudio.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        if (canNextScene && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Top");
        }
    }
}
