using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollactableCoin : ItemCollactableBase
{    
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
}
