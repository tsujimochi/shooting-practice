using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    #region インスペクターで設定
    [Header("Player Prefab")] public GameObject player;
    #endregion

    #region プライベート変数
    // タイトル
    private GameObject title;
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    void Start() 
    {
        // Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find("Title");
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
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {
        // ゲームオーバー時に、タイトルを表示する
        title.SetActive(true);
    }

    /// <summary>
    /// プレイ中かチェック
    /// </summary>
    /// <returns></returns>
    public bool IsPlaying()
    {
        // ゲーム中かどうかはタイトルの表示/非表示で判断する
        return title.activeSelf == false;
    }
}
