using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    [SerializeField] public int quantityCoin;
    [SerializeField] public int quantityDiamond;
    [SerializeField] public TextMeshProUGUI quantityCoinText;
    [SerializeField] public TextMeshProUGUI quantityDiamondText;

    public void Awake()
    {
        SetQuantityCoin(quantityCoin);
        SetQuantityDiamond(quantityDiamond);
    }

    public void SetQuantityCoin(int newQuantity)
    {
        quantityCoin = newQuantity;
        UpdateQuantityText(quantityCoinText, quantityCoin);
    }

    public void SetQuantityDiamond(int newQuantity)
    {
        quantityDiamond = newQuantity;
        UpdateQuantityText(quantityDiamondText, quantityDiamond);
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
