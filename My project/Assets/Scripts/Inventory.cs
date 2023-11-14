using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item[] item;

    public int itemCount
    {
        get
        {
            return item.Length;
        }
    }

    public Item Getitem(int index)
    {
        return item[index];
    }
}
