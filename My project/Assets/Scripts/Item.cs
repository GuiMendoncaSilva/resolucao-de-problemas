using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public int energy;
    [SerializeField] public int satiation;
    [SerializeField] public int price;
    [SerializeField] public int quantity;
    [SerializeField] public TextMeshProUGUI quantityText;

    public void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        UpdateQuantityText();
    }

    private void UpdateQuantityText()
    {
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString() + "x";
        }
        else
        {
            Debug.LogError("Quantity TextMeshProUGUI component is not assigned!");
        }
    }
}



