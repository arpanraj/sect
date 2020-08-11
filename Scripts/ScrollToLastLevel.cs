using UnityEngine;
using UnityEngine.UI;
using StaticData;

public class ScrollToLastLevel : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private ScrollRect scrollRect;
    [SerializeField]
    private RectTransform contentPanel;
#pragma warning restore 0649
    private void Start()
    {
        int newUnlocks = PlayerPrefs.GetInt(UnlockedLevels.MaxKeyName) + 1;
        SnapTo(transform.GetChild(newUnlocks).GetComponent<RectTransform>());
    }
    public void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();
        contentPanel.anchoredPosition =
            (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
            - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
    }
}
