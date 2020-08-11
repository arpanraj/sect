using UnityEngine;
using UnityEngine.Events;
using StaticData;

public class LockFilter : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    UnityEvent OnLockedDueToMaxUnlockedLevel;
    [SerializeField]
    UnityEvent OnLockedDueToNotPurchased;
    [SerializeField]
    UnityEvent OnUnLocked;
#pragma warning restore 0649

    public void CheckUnlocked(IntVariable levelNumber)
    {
        CheckUnlocked(levelNumber.Value);
    }

    public void CheckUnlocked(int levelNumber)
    {
        if(!IsLessThenMaxUnlockedLevel(levelNumber))
        {
            OnLockedDueToMaxUnlockedLevel.Invoke();
            return;
        }
        if(!IsLevelPurchased(levelNumber))
        {
            OnLockedDueToNotPurchased.Invoke();
            return;
        }
        OnUnLocked.Invoke();
    }

    private bool IsLessThenMaxUnlockedLevel(int levelNumber)
    {
        if (!PlayerPrefs.HasKey(UnlockedLevels.MaxKeyName))
        {

            Debug.Log("MaxkeyName not created");
            return false;
        }
        if(PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName) >= levelNumber)
        {
            return true;
        }
        return false;
    }

    private bool IsLevelPurchased(int levelNumber)
    {
        if(levelNumber < UnlockedLevels.MaxFreeLevel)
        {
            return true;
        }
        if(PurchaseManager.CheckPurchasedLevels())
        {
            return true;
        }
        return false;
    }

    public void FilterCurrentLevel()
    {
        int level = LevelManagement.GetActiveLevel();
        CheckUnlocked(level);
    }
}
