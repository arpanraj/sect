using UnityEngine;
using StaticData;
public class UnlockLevel : MonoBehaviour
{
    public void UpdateDigit()
    {
        if (PlayerPrefs.HasKey(UnlockedLevels.MaxKeyName))
        {
            int unlockLevel = LevelManagement.GetActiveLevel() + 1;
            Debug.Log(unlockLevel);
            if (unlockLevel > PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName))
            {
                PlayerPrefs.SetInt(UnlockedLevels.MaxKeyName, unlockLevel);
            }
        }
    }
}
