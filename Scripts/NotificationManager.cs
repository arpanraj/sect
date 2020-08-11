using UnityEngine;
using UnityEngine.UI;

public enum NotificationType
{
    lockedDueToNotUnlocked,
    lockedDueToNotPurchased,
    PurchaseSucceded,
    PurchaseFailed,
    Rate,
    Share
}

public class NotificationManager : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    GameObject outsideBackground;
    [SerializeField]
    GameObject Background;
    //[SerializeField]
    //GameObject border;
    [SerializeField]
    GameObject icon;
    [SerializeField]
    GameObject text;
    [SerializeField]
    GameObject ok;
    [SerializeField]
    GameObject cancel;

    [SerializeField]
    StringReference okText;
    [SerializeField]
    StringReference cancelText;
    [SerializeField]
    StringReference buyText;
    [SerializeField]
    StringReference retryText;

    [SerializeField]
    Sprite LockedImage;
    [SerializeField]
    Sprite SuccessImage;
    [SerializeField]
    StringReference lockedDueToNotUnlockedText;
    [SerializeField]
    StringReference lockedDueToNotPurchasedText;
    [SerializeField]
    StringReference purchaseSuccededText;
    
#pragma warning restore 0649
    NotificationType notificationType;

    private void SetActive(bool value)
    {
        outsideBackground.SetActive(value);
        Background.SetActive(value);
        //border.SetActive(value);
        icon.SetActive(value);
        text.SetActive(value);
    }

    private void SetActiveOk(bool value)
    {
        SetActive(value);
        ok.SetActive(value);
    }

    private void SetActiveOkAndCancel(bool value)
    {
        SetActiveOk(value);
        cancel.SetActive(value);
    }

    private void SetActiveBuyAndCancel(bool value)
    {
        SetActive(value);
        cancel.SetActive(value);
    }

    private void SetupData(Sprite icon, string text, string okButtonText = "",string cancelButtonText = "",string buyButtonText = "")
    {
        this.icon.GetComponent<Image>().sprite = icon;
        this.text.GetComponent<Text>().text = text;
        ok.GetComponent<Text>().text = okButtonText;
        cancel.GetComponent<Text>().text = cancelButtonText;
    }

    public void okClicked()
    {
        switch(notificationType)
        {
            case NotificationType.lockedDueToNotUnlocked:
                SetActiveOk(false);
                break;
            case NotificationType.PurchaseSucceded:
                SetActiveOk(false);
                break;
            
        }
    }

    public void cancelClicked()
    {
        switch (notificationType)
        {
            case NotificationType.lockedDueToNotUnlocked:
                SetActiveOk(false);
                break;
            case NotificationType.lockedDueToNotPurchased:
            case NotificationType.PurchaseFailed:
                SetActiveBuyAndCancel(false);
                break;
            case NotificationType.PurchaseSucceded:
                SetActiveOk(false);
                break;
            case NotificationType.Share:
            case NotificationType.Rate:
                SetActiveOkAndCancel(false);
                break;
        }
    }

    public void ShowLockedDueToNotUnlocked()
    {
        notificationType = NotificationType.lockedDueToNotUnlocked;
        SetupData(LockedImage,lockedDueToNotUnlockedText,okButtonText:okText);
        SetActiveOk(true);
    }
    

    public void ShowPurchaseSucceded()
    {
        notificationType = NotificationType.PurchaseSucceded;
        SetupData(SuccessImage, purchaseSuccededText, okButtonText: okText);
        SetActiveOk(true);
    }

    
}
