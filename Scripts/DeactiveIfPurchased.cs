using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveIfPurchased : MonoBehaviour
{
    void Start()
    {
        if(PurchaseManager.CheckPurchasedLevels())
        {
            gameObject.SetActive(false);
        }
    }
    
}
