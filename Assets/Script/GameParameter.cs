/// <summary>
/// ゲーム全体で使用する静的変数の集まり
/// </summary>
public class GameParameter {

    /// <summary>
    /// スコア
    /// </summary>
    public static int Score { get; set; } = 0;

    /// <summary>
    /// コンティニュー回数
    /// </summary>
    public static int ContinueCount { get; set; } = 0;

    /// <summary>
    /// プレイヤーのパワー
    /// </summary>
    public static int PlayerPower { get; set; } = 0;

    /// <summary>
    /// プレイヤーのスピード
    /// </summary>
    public static int PlayerSpeed { get; set; } = 1;

    /// <summary>
    /// プレイヤーステータス初期化
    /// </summary>
    public static void InitializePlayerStatus()
    {
        PlayerPower = 0;
        PlayerSpeed = 1;
    }
}
