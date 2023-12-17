using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int[] characters;
    public int amountCoins;
    public int amountDiamonds;
    public int[] amountItems = new int[12];
    public GameData()
    {
    }

    public GameData(GameData data)
    {
        characters = data.characters;
        amountCoins = data.amountCoins;
        amountDiamonds = data.amountDiamonds;
        amountItems = data.amountItems;
    }
}
