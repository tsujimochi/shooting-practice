using System.Collections;
using System.Collections.Generic;

public class Shot
{
    public List<BulletType> Bullets { get; }
    public float ShotDelay { get; set; }

    public Shot()
    {
        Bullets = new List<BulletType>();
        ShotDelay = float.MaxValue;
    }

    public void AddBullet(BulletType bullet) 
    {
        Bullets.Add(bullet);
    }
}
