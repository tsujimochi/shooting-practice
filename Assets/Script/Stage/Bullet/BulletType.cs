using System.Collections;
using System.Collections.Generic;

public class BulletType
{
    #region プライベート変数
    public float X { get; }
    public float Y { get; }
    public float Z { get; }
    public int Power { get; }
    public float Scale { get; }
    #endregion

    public BulletType(float x, float y, float z, int power, float scale = 1)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
        this.Power = power;
        this.Scale = scale;
    }
}
