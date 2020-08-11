using UnityEngine;
using StaticData;
using UnityEngine.SceneManagement;

public class PurchaseManager : MonoBehaviour
{
    public void PurchasedLevels()
    {
        PlayerPrefs.SetString(AppPurchase.LevelPurchaseKey, AppPurchase.LevelsPurchased);
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
    public static bool CheckPurchasedLevels()
    {
        if(!PlayerPrefs.HasKey(AppPurchase.LevelPurchaseKey))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
