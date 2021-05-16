using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    #region 定数
    private enum MessageId {
        Title,
        Start,
        GameOver
    };
    #endregion

    #region インスペクターで設定
    [Header("Player Prefab")] public GameObject playerPrefab;
    [Header("BGM Object")] public GameObject bgm;
    [Header("メインメッセージ用のText")] public Text mainMessage;
    #endregion

    #region プライベート変数
    // タイトル
    private GameObject message;
    // プレイヤー
    private GameObject player;
    // 敵の管理
    private Emitter emitter;
    // スコア
    private Score score;
    #endregion

    #region static変数
    // プレイ中かどうか
    private static bool isPlaying = false;
    // ステージ番号
    private static int stageNumber = 1;
    #endregion

    void Start() 
    {
        // Titleゲームオブジェクトを検索し取得する
        message = GameObject.Find("Message");
        // Emitterゲームオブジェクトを検索し取得する
        emitter = FindObjectOfType<Emitter>();
        // Scoreゲームオブジェクトを検索し取得する
        score = FindObjectOfType<Score>();
        // ゲーム開始
        StartCoroutine(GameStart());
    }

    private void Update()
    {
        // プレイ中にプレイヤーが画面内からいなくなったらゲームオーバー
        if (isPlaying && player == null)
        {
            StartCoroutine(GameOver());
        }
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    private IEnumerator GameStart()
    {
        // BGMスタート
        bgm.GetComponent<AudioSource>().Play();
        // ゲームスタート時にタイトルを非表示にしてプレイヤーを作成する
        emitter.AllReset();
        score.Initialize();

        // 一定時間ステージ名を表示した後、ゲームを開始する
        mainMessage.text = GetMessage(MessageId.Title);
        yield return new WaitForSeconds(2);
        mainMessage.text = GetMessage(MessageId.Start);
        player = (GameObject)Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        isPlaying = true;

        yield return new WaitForSeconds(2);
        message.SetActive(false);        
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    private IEnumerator GameOver()
    {
        // BGM停止
        bgm.GetComponent<AudioSource>().Stop();
        // ゲームオーバー時に、タイトルを表示する
        isPlaying = false;
        mainMessage.text = GetMessage(MessageId.GameOver);
        message.SetActive(true);
        yield return null;
    }

    /// <summary>
    /// プレイ中かチェック
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        return isPlaying;
    }

    private string GetMessage(MessageId messageId)
    {
        switch(messageId) {
            case MessageId.Title:
                return "Stage" + stageNumber;
            case MessageId.Start:
                return "Start";
            case MessageId.GameOver:
                return "Game Over";
            default:
                return "no message";
        }
    }
}
