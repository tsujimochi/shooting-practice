using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    #region 定数
    private enum MessageId {
        Start,
        GameOver
    };
    #endregion

    #region インスペクターで設定
    [Header("Player Prefab")] public GameObject player;
    [Header("メインメッセージ用のText")] public Text mainMessage;
    #endregion

    #region プライベート変数
    // タイトル
    private GameObject message;
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
        mainMessage.text = GetMessage(MessageId.Start);
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update() 
    {
        // ゲーム中ではなく、xキーが押されたらtrueを返す
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X)) {
            GameStart();
        }
    }

    /// <summary>
    /// ゲーム開始
    /// </summary>
    void GameStart()
    {
        // ゲームスタート時にタイトルを非表示にしてプレイヤーを作成する
        emitter.AllReset();
        score.Initialize();
        isPlaying = true;
        message.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {
        // ゲームオーバー時に、タイトルを表示する
        isPlaying = false;
        mainMessage.text = GetMessage(MessageId.GameOver);
        message.SetActive(true);
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
            case MessageId.Start:
                return "Stage" + stageNumber + " Start";
            case MessageId.GameOver:
                return "Game Over";
            default:
                return "no message";
        }
    }
}
