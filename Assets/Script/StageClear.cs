using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    #region インスペクターで設定
    [Header("結果オブジェクト")] public GameObject resultObject;
    [Header("スコアオブジェクト")] public GameObject scoreObject;
    [Header("Tipsオブジェクト")] public GameObject tipsObject;
    #endregion

    #region プライベート変数
    // 次のシーンに行けるか
    private bool canNextScene = false;
    // スコアテキストの表示行数
    private int scoreTextLineCount = 1;
    #endregion

    #region 定数
    // 一回あたりの加算スコア
    private const int ADD_SCORE = 1000;
    // パワーボーナス
    private const int POWER_BONUS = 10000;
    // スピードボーナス
    private const int SPEED_BONUS = 10000;
    #endregion

    IEnumerator Start()
    {
        Text scoreText = scoreObject.GetComponent<Text>();
        Text resultText = resultObject.GetComponent<Text>();
        scoreText.text = GameParameter.Score.ToString();
        AudioSource resultAudio = resultObject.GetComponent<AudioSource>();
        AudioSource scoreAudio = GetComponent<AudioSource>();
        int powerBonus = GameParameter.PlayerPower * POWER_BONUS;
        int speedBonus = GameParameter.PlayerSpeed * SPEED_BONUS;
        while (scoreTextLineCount <= 3)
        {
            yield return new WaitForSeconds(1);
            resultText.text = GetScoreText(powerBonus, speedBonus);
            resultAudio.Play();
            scoreTextLineCount++;
        }
        yield return new WaitForSeconds(2);
        while (powerBonus > 0 || speedBonus > 0)
        {
            if (powerBonus > 0)
            {
                powerBonus -= ADD_SCORE;
                GameParameter.Score += ADD_SCORE;
            }
            else if (speedBonus > 0)
            {
                speedBonus -= ADD_SCORE;
                GameParameter.Score += ADD_SCORE;
            }
            resultText.text = GetScoreText(powerBonus, speedBonus);
            scoreText.text = GameParameter.Score.ToString();
            scoreAudio.Play();
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);
        tipsObject.SetActive(true);
        canNextScene = true;
    }

    private void Update()
    {
        if (canNextScene && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    private string GetScoreText(int powerBonus, int speedBonus)
    {

        string retVal = "Bonus";
        if (scoreTextLineCount > 1)
        {
            retVal += $"\nPowerBonus : {POWER_BONUS} x {GameParameter.PlayerPower} = {powerBonus}";
        }
        if (scoreTextLineCount > 2)
        {
            retVal += $"\nSpeedBonus : {SPEED_BONUS} x {GameParameter.PlayerSpeed} = {speedBonus}";
        }
        return retVal;
    }
}
