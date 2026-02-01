using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RobotAvatarManager : MonoBehaviour
{
    [System.Serializable]
    private class PhysicalTrait {
        [SerializeField]
        private GameManager.PHYSICAL_TRAIT Trait;

        [SerializeField]
        private int Setting;

        public PhysicalTrait() {
            Setting = 0;
        }

        public int GetSetting() {
            return Setting;
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

    private int CurrentBody;
    private int CurrentStyle;
    private int CurrentSprite;

    public Dictionary<GameManager.PHYSICAL_TRAIT, int> GetSettings() {
        return new Dictionary<GameManager.PHYSICAL_TRAIT, int>()
        {
            { GameManager.PHYSICAL_TRAIT.Appearance, Appearance.GetSetting() },
            { GameManager.PHYSICAL_TRAIT.Height, Height.GetSetting() },
            { GameManager.PHYSICAL_TRAIT.Style, Style.GetSetting() }
        };
    }

    public void NextBodyType() {
        CurrentBody++;
        if (CurrentBody > 2) {
            CurrentBody = 0;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void NextStyle() {
        CurrentStyle++;
        if (CurrentStyle > 2) {
            CurrentStyle = 0;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void NextHeight() {
        // TODO

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void LastBodyType() {
        CurrentBody--;
        if (CurrentBody < 0) {
            CurrentBody = 2;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void LastStyle() {
        CurrentStyle--;
        if (CurrentStyle < 0) {
            CurrentStyle = 2;
        }

        CurrentSprite = CurrentStyle + (CurrentBody * 3);

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void LastHeight() {
        // TODO

        RobotImage.sprite = Sprites[CurrentSprite];
    }
}
