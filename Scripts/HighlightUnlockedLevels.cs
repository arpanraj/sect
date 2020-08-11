using UnityEngine;
using UnityEngine.UI;
using StaticData;

public class HighlightUnlockedLevels : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey(UnlockedLevels.MaxKeyName))
        {
            PlayerPrefs.SetInt(UnlockedLevels.MaxKeyName, UnlockedLevels.DefaultMax);
        }

        if (PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName) == UnlockedLevels.DefaultMax)
            return;

        Image[] levelIcons = transform.GetComponentsInChildren<Image>();
        int newUnlocks = PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName) + 1;
        int filteredUnlocks = FilterUnlocksByPurchase(newUnlocks);

        for (int iconInd = UnlockedLevels.DefaultMax; iconInd < filteredUnlocks; iconInd++)
        {
            var tempColor = levelIcons[iconInd].color;
            tempColor.a = 1f;
            levelIcons[iconInd].color = tempColor;
        }
    }

    private int FilterUnlocksByPurchase(int newUnlocks)
    {
        if(PurchaseManager.CheckPurchasedLevels())
        {
            return newUnlocks;
        }
        if(newUnlocks < UnlockedLevels.MaxFreeLevel)
        {
            return newUnlocks;
        }
        return UnlockedLevels.MaxFreeLevel;
    }
}
