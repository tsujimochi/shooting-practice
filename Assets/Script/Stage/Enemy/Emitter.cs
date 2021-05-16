using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    #region インスペクターで設定
    [Header("Waveプレハブを格納する")] public GameObject[] waves;
    #endregion

    #region プライベート変数
    // Managerコンポーネント
    private Manager manager;
    #endregion

    /// <summary>
    /// Start
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        // Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0) {
            yield break;
        }

        // Managerコンポーネントをシーン内から探して取得する
        manager = FindObjectOfType<Manager>();
        manager.SetWavesCount(waves.Length);

        while (true) {
            while(manager.IsPlaying() == false) {
                yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate (waves[manager.GetWave()], transform.position, Quaternion.identity);
            // WaveをEmmiterの子要素にする
            wave.transform.parent = transform;
            // Waveの子要素のEnemyが全て削除されるまで待機する
            while(true) {
                if (wave.transform.childCount <= 0) {
                    // Waveの削除
                    Destroy(wave);
                    break;
                } else if (manager.IsPlaying() == false) {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }
            manager.AddWave();
            if (manager.IsStageClear())
            {
                break;
            }
        }
    }
}
