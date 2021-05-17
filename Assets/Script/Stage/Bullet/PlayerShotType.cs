using System.Collections;
using System.Collections.Generic;

public class PlayerShotType
{
    private List<Shot> shotTypes;
    private List<float> shotDelays;

    public PlayerShotType()
    {
        shotTypes = new List<Shot>();
        shotDelays = new List<float>();
        // レベル0
        shotTypes.Add(new Shot());
        shotTypes[0].AddBullet(new BulletType(0, 0, 0, 1));
        shotDelays.Add(0.5f);
        // レベル1
        shotTypes.Add(new Shot());
        shotTypes[1].AddBullet(new BulletType(0, 0, 0, 1));
        shotDelays.Add(0.3f);
        // レベル2
        shotTypes.Add(new Shot());
        shotTypes[2].AddBullet(new BulletType(0.1f, 0.1f, 0, 1));
        shotTypes[2].AddBullet(new BulletType(0.1f, -0.1f, 0, 1));
        shotDelays.Add(0.3f);
        // レベル3
        shotTypes.Add(new Shot());
        shotTypes[3].AddBullet(new BulletType(0.1f, 0, 10, 1));
        shotTypes[3].AddBullet(new BulletType(0.1f, 0.1f, 0, 1));
        shotTypes[3].AddBullet(new BulletType(0.1f, -0.1f, 0, 1));
        shotTypes[3].AddBullet(new BulletType(0.1f, 0, -10, 1));
        shotDelays.Add(0.3f);
        // レベル4
        shotTypes.Add(new Shot());
        shotTypes[4].AddBullet(new BulletType(0.1f, 0, 20, 1));
        shotTypes[4].AddBullet(new BulletType(0.1f, 0, 10, 1));
        shotTypes[4].AddBullet(new BulletType(0.1f, 0.1f, 0, 1));
        shotTypes[4].AddBullet(new BulletType(0.1f, -0.1f, 0, 1));
        shotTypes[4].AddBullet(new BulletType(0.1f, 0, -10, 1));
        shotTypes[4].AddBullet(new BulletType(0.1f, 0, -20, 1));
        shotDelays.Add(0.3f);
    }

    /// <summary>
    /// 指定したショットレベルのタイプを取得する
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public Shot GetShotType(int level)
    {
        if (level < 0) {
            return shotTypes[0];
        }
        if (level >= shotTypes.Count) {
            return shotTypes[shotTypes.Count - 1];
        }
        return shotTypes[level];
    }


    /// <summary>
    /// 指定したショットレベルのディレイを取得する
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public float GetShotDelay(int level)
    {
        if (level < 0) {
            return shotDelays[0];
        }
        if (level >= shotDelays.Count) {
            return shotDelays[shotDelays.Count - 1];
        }
        return shotDelays[level]; 
    }

    /// <summary>
    /// 最大ショットレベルを取得する
    /// </summary>
    /// <returns></returns>
    public int GetMaxShotLevel()
    {
        return shotTypes.Count;
    }
}
