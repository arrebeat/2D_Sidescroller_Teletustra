using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public TextMeshProUGUI TextOnionAmount;
    public int onionsCollected;
    public int onionsConsumed;

    public static ItemManager instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject); 
    }

    public void CollectOnion()
    {
        onionsCollected += 1;
        TextOnionAmount.text = onionsCollected.ToString();
    }

    public void ConsumeOnion()
    {
        onionsConsumed += 1;
    }

}
