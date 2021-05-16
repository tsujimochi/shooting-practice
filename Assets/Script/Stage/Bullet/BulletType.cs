using System.Collections;
using System.Collections.Generic;

public class BulletType
{
    #region プライベート変数
    private float x;
    private float y;
    private float z;
    private int power;    
    #endregion

    public BulletType(float x, float y, float z, int power)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.power = power;
    }

    public float GetX() 
    {
        return x;
    }

    public float GetY()
    {
        return y;
    }

    public float GetZ()
    {
        return z;
    }

    public int GetPower()
    {
        return power;
    }
}
