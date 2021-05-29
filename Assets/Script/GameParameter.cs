/// <summary>
/// �Q�[���S�̂Ŏg�p����ÓI�ϐ��̏W�܂�
/// </summary>
public class GameParameter {

    /// <summary>
    /// �X�R�A
    /// </summary>
    public static int Score { get; set; } = 0;

    /// <summary>
    /// �R���e�B�j���[��
    /// </summary>
    public static int ContinueCount { get; set; } = 0;

    /// <summary>
    /// �v���C���[�̃p���[
    /// </summary>
    public static int PlayerPower { get; set; } = 0;

    /// <summary>
    /// �v���C���[�̃X�s�[�h
    /// </summary>
    public static int PlayerSpeed { get; set; } = 1;

    /// <summary>
    /// �v���C���[�X�e�[�^�X������
    /// </summary>
    public static void InitializePlayerStatus()
    {
        PlayerPower = 0;
        PlayerSpeed = 1;
    }
}
