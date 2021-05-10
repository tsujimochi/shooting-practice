using System.Collections;
using System.Collections.Generic;

public class Shot
{
    private List<BulletType> bullets;

    public Shot()
    {
        bullets = new List<BulletType>();
    }

    public void AddBullet(BulletType bullet) 
    {
        bullets.Add(bullet);
    }

    public List<BulletType> GetBullets()
    {
        return bullets;
    }
}
