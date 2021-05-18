using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region 定数
    private enum MessageId {
        Title,
        Start
    };
    #endregion

    #region インスペクターで設定
    [Header("Player Prefab")] public GameObject playerPrefab;
    [Header("BGM Object")] public GameObject bgm;
    [Header("BossHP Object")] public GameObject bossHPBar;
    [Header("メインメッセージ用のText")] public Text mainMessage;
    [Header("パワーステータス用のText")] public Text powerStatus;
    [Header("スピードステータス用のText")] public Text speedStatus;
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
    // ウェーブ番号
    private static int currentWave = 0;
    // 全ウェーブ数
    private static int allWavesCount = 0;
    // コンティニュー回数
    private static int continueCount = 0;
    #endregion

    void Start() 
    {
        // wave初期化
        currentWave = 0;
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
        if (isPlaying)
        {
            if (player == null)
            {
                StartCoroutine(GameOver());
            } 
            else
            {
                UpdateDisplayStatus();
            }
            if (IsStageClear())
            {
                StartCoroutine(StageClear());
            }
            
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
        isPlaying = false;
        bgm.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(4);
        continueCount++;
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator StageClear()
    {
        // 3秒待つ
        yield return new WaitForSeconds(3);
        // フェードアウト
        AudioSource audio = bgm.GetComponent<AudioSource>();
        for (int volume = 100; volume > 0; volume--)
        {
            audio.volume = (float)(volume) / 100;
            yield return new WaitForEndOfFrame();
        }
        isPlaying = false;
        Player playerScript = player.GetComponent<Player>();
        playerScript.SetCanControl(false);
        yield return new WaitForSeconds(2);
        playerScript.MoveOffScreen(10);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StageClear");
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

    /// <summary>
    /// Wave数をセットする
    /// </summary>
    /// <param name="count"></param>
    public void SetWavesCount(int count)
    {
        allWavesCount = count;
    }

    /// <summary>
    /// 現在のWaveを取得する
    /// </summary>
    /// <returns></returns>
    public int GetWave()
    {
        return currentWave;
    }

    /// <summary>
    /// Waveを指定分進ませる
    /// </summary>
    /// <param name="progress">進ませる値。未指定時は1</param>
    public void AddWave(int progress = 1)
    {
        currentWave += progress;
    }

    /// <summary>
    /// ステージクリアしたか判定する
    /// </summary>
    /// <returns></returns>
    public bool IsStageClear()
    {
        return currentWave >= allWavesCount;
    }

    /// <summary>
    /// 画面に表示されている状態を更新する
    /// </summary>
    private void UpdateDisplayStatus()
    {
        Player playerScript = player.GetComponent<Player>();
        powerStatus.text = "Power " + (playerScript.shotLevel + 1) + " / " + playerScript.GetMaxShotLevel();

        int nowSpeed = (int)(Mathf.Floor(playerScript.speed / 2) + 1);
        int maxSpeed = (int)(Mathf.Floor(playerScript.maxSpeed / 2) + 1);
        speedStatus.text = "Speed " + nowSpeed + " / " + maxSpeed;
    }

    private string GetMessage(MessageId messageId)
    {
        switch(messageId) {
            case MessageId.Title:
                return "Stage" + stageNumber;
            case MessageId.Start:
                return "Start";
            default:
                return "no message";
        }
    }

    public int ContinueCount
    {
        get { return continueCount; }
    }
}
