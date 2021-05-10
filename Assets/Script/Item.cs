using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    /// <summary>
    /// アイテムを使う
    /// </summary>
    /// <param name="player"></param>
    public abstract void UseItem(Player player);
}
