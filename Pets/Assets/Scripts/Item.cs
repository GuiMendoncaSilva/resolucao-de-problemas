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
    [SerializeField] public int index;
    [SerializeField] public TextMeshProUGUI quantityText;

    public void Awake()
    {
        SetQuantity(MainManagement.amountItems[index]);
    }
    public void SetQuantity(int newQuantity)
    {
        MainManagement.amountItems[index] = newQuantity;
        UpdateQuantityText();
    }

    private void UpdateQuantityText()
    {
        if (quantityText != null)
        {
            quantityText.text = MainManagement.amountItems[index].ToString() + "x";
        }
        else
        {
            Debug.LogError("Quantity TextMeshProUGUI component is not assigned!");
        }
    }
}



