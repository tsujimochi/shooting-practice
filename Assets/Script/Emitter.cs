﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    #region インスペクターで設定
    [Header("Waveプレハブを格納する")] public GameObject[] waves;
    #endregion

    #region プライベート変数
    // 現在のWave
    private int currentWave;
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

        while(true) {
            while(manager.IsPlaying() == false) {
                yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate (waves[currentWave], transform.position, Quaternion.identity);
            // WaveをEmmiterの子要素にする
            wave.transform.parent = transform;
            // Waveの子要素のEnemyが全て削除されるまで待機する
            while(wave.transform.childCount != 0) {
                yield return new WaitForEndOfFrame();
            }
            // Waveの削除
            Destroy(wave);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする (最初から -> ループ)
            if (waves.Length <= ++currentWave) {
                currentWave = 0;
            }
        }
    }
}
