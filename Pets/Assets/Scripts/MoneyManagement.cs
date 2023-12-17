using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI quantityCoinText;
    [SerializeField] public TextMeshProUGUI quantityDiamondText;

    public void Awake()
    {
        SetQuantityCoin(MainManagement.amountCoins);
        SetQuantityDiamond(MainManagement.amountDiamonds);
    }

    public void SetQuantityCoin(int newQuantity)
    {
        MainManagement.amountCoins = newQuantity;
        UpdateQuantityText(quantityCoinText, MainManagement.amountCoins);
    }

    public void SetQuantityDiamond(int newQuantity)
    {
        MainManagement.amountDiamonds = newQuantity;
        UpdateQuantityText(quantityDiamondText, MainManagement.amountDiamonds);
    }

    private void UpdateQuantityText(TextMeshProUGUI text, int value)
    {
        if (text != null)
        {
            text.text = value.ToString();
        }
        else
        {
            Debug.LogError("Quantity TextMeshProUGUI component is not assigned!");
        }
    }

}
