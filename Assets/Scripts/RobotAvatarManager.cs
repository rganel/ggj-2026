using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class RobotAvatarManager : MonoBehaviour
{
    public enum PHYSICAL_TRAIT {
        Appearance,
        Height,
        Style
    };

    [System.Serializable]
    private class PhysicalTrait {
        [SerializeField]
        private PHYSICAL_TRAIT Trait;

        [SerializeField]
        private int Setting;

        [SerializeField]
        [VariablePopup]
        private string DialogueVariableName;

        public int GetSetting() {
            return Setting;
        }

        public void SetSetting(int Setting) {
            this.Setting = Setting;
            DialogueLua.SetVariable(DialogueVariableName, Setting);

            GameManager.PhysicalTraitChanged.Invoke();
        }
    }

    [SerializeField]
    private PhysicalTrait Appearance = new PhysicalTrait();

    [SerializeField]
    private PhysicalTrait Height = new PhysicalTrait();

    [SerializeField]
    private PhysicalTrait Style = new PhysicalTrait();

    [SerializeField]
    private Sprite[] Sprites;

    [SerializeField]
    private Image RobotImage;

    [SerializeField]
    private GameObject RobotPreviewRoot;

    private int CurrentBody;
    private int CurrentStyle;
    private int CurrentSprite;

    public Dictionary<PHYSICAL_TRAIT, int> GetSettings() {
        return new Dictionary<PHYSICAL_TRAIT, int>()
        {
            { PHYSICAL_TRAIT.Appearance, Appearance.GetSetting() },
            { PHYSICAL_TRAIT.Height, Height.GetSetting() },
            { PHYSICAL_TRAIT.Style, Style.GetSetting() }
        };
    }

    public void Reset() {
        Appearance.SetSetting(0);
        Style.SetSetting(0);
        Height.SetSetting(0);
        CurrentSprite = 0;
        CurrentStyle = 0;
        CurrentBody = 0;
        RobotImage.sprite = Sprites[CurrentSprite];

        RobotPreviewRoot.SetActive(false);
    }

    public void Enable() {
        RobotPreviewRoot.SetActive(true);
    }

    public void NextBodyType() {
        CurrentBody++;
        if (CurrentBody > 2) {
            CurrentBody = 0;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];

        UpdateSetting(Appearance, 1);
    }

    public void NextStyle() {
        CurrentStyle++;
        if (CurrentStyle > 2) {
            CurrentStyle = 0;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];

        UpdateSetting(Style, 1);
    }

    public void NextHeight() {
        UpdateSetting(Height, 1);

        float scaleFactor = GetHeightScaleFactor();
        RobotImage.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);
    }

    public void LastBodyType() {
        CurrentBody--;
        if (CurrentBody < 0) {
            CurrentBody = 2;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];

        UpdateSetting(Appearance, -1);
    }

    public void LastStyle() {
        CurrentStyle--;
        if (CurrentStyle < 0) {
            CurrentStyle = 2;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];

        UpdateSetting(Style, -1);
    }

    public void LastHeight() {
        UpdateSetting(Height, -1);

        float scaleFactor = GetHeightScaleFactor();
        RobotImage.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);
    }

    private void UpdateSetting(PhysicalTrait Trait, int Delta) {
        int NewSetting = Trait.GetSetting() + Delta;
        if (NewSetting > 2) {
            NewSetting = 0;
        } else if (NewSetting < 0) {
            NewSetting = 2;
        }

        Trait.SetSetting(NewSetting);
    }

    private float GetHeightScaleFactor() {
        return 0.8f + (Height.GetSetting() * 0.1f);
    }
}
