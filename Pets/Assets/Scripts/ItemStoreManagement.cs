using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStoreManagement : MonoBehaviour
{
    [SerializeField] int priceCoin;
    [SerializeField] int priceDiamond;
    [SerializeField] int indexItem;

    private void BuyItem ()
    {
        MainManagement.amountItems[indexItem]++;
    }

    public void BuyItemWithCoin ()
    {
        if (MainManagement.amountCoins >= priceCoin)
        {
            BuyItem();
            MainManagement.amountCoins -= priceCoin;
        }
    }
    public void BuyItemWithDiamond()
    {
        if (MainManagement.amountDiamonds >= priceDiamond)
        {
            BuyItem();
            MainManagement.amountDiamonds -= priceDiamond;
        }
    }

    public void BuyCoin()
    {
        Application.OpenURL("https://laticao.org.br/ajude/");
    }

    public void BuyDiamond()
    {
        Application.OpenURL("https://laticao.org.br/ajude/");
    }

}
