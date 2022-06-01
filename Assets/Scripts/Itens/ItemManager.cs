using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
   

    public int coins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        coinsText.text = "X 0";
    }

    public void AddCoins(int amount=1)
    {
        coins += amount;
        coinsText.text = "X "+ coins.ToString();  
    }
}
