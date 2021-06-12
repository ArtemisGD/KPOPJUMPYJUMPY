using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Inventory : MonoBehaviour
{
    private int currentCoinAmount = 0;
    public int maxCoinAmount;

    public TextMeshProUGUI coinText;
    

    public void Init()
    {
        UpdateCoinsText();
    }

    public void AddCoins(int _coinValue)
    {

        currentCoinAmount = currentCoinAmount + _coinValue;

        UpdateCoinsText();
    }

    public void SpillCoins()
    {
        currentCoinAmount = currentCoinAmount - 20;

        if (currentCoinAmount <= 0)
            currentCoinAmount = 0;

        UpdateCoinsText();
    }

    void UpdateCoinsText()
    {
         coinText.text = "+ " + currentCoinAmount;
    }


}
