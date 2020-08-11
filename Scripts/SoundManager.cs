
using UnityEngine;
using StaticData;

public class SoundManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    GameObject UISound;
    [SerializeField]
    GameObject BGSound;
    [SerializeField]
    IntVariable uiIndex;
    [SerializeField]
    IntVariable bgIndex;
#pragma warning restore 0649
    bool BGSoundBool;
    bool UISoundBool;

    private void Start()
    {
        BGSoundBool = true;
        UISoundBool = true;
        uiIndex.Value = 0;
        bgIndex.Value = 0;
    }

    public void SwitchBGSound(IntVariable value)
    {
        BGSoundBool = !BGSoundBool;
        BoolToImageArrInd(value, BGSoundBool);
        BGSound.SetActive(BGSoundBool);
    }

    public void SwitchUISound(IntVariable value)
    {
        UISoundBool = !UISoundBool;
        BoolToImageArrInd(value, UISoundBool);
        UISound.SetActive(UISoundBool);
    }

    private void BoolToImageArrInd(IntVariable value,bool active)
    {
        if(active)
        {
            value.Value = 0;
        }
        else
        {
            value.Value = 1;
        }
    }
}
