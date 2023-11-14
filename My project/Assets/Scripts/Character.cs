using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{ 
    public string characterName;
    public GameObject prefabToInstantiate;

    private int life = 100;
    public int Life
    {
        get { return life; } 
        set { life = value; }
    }

    
    private int energy = 100;
    public int Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    private int satiation = 100;
    public int Satiation
    {
        get { return satiation; }
        set { satiation = value; }
    }

    private void UpdateLife()
    {
        life = Mathf.RoundToInt((energy + satiation) / 2);
    }

    public void DecrementStatus()
    {
        int tax = 1; 
        if (life > 0)
        {
            if (energy <= 0 || satiation <= 0)
            {
                tax = 2;
                if (energy <= 0)
                {
                    energy = 0;
                    satiation -= 1 + tax;
                } 
                else
                {
                    satiation = 0;
                    energy -= tax;
                }
            } 
            else
            {
                energy--;
                satiation -= 1 + tax;
            }
            UpdateLife();
        }
    }

    public void IncreaseStatus(Item food)
    {
        if (food == null) return;
        IncreaseEnergy(food.energy);
        IncreaseSatiation(food.satiation);
        UpdateLife();
    }

    public void IncreaseEnergy(int en)
    {
        energy += en;
        if(energy > 100) 
        { 
            energy = 100;
        }
    }

    public void IncreaseSatiation(int sat)
    {
        satiation += sat;
        if (satiation > 100)
        {
            satiation = 100;
        }
    }

    public override string ToString()
    {
        return $"Life: {life}, energy: {energy}, Satiation: {satiation}";
    }

}
