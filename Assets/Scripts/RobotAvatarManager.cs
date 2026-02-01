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

    private int CurrentSprite;

    public Dictionary<GameManager.PHYSICAL_TRAIT, int> GetSettings() {
        return new Dictionary<GameManager.PHYSICAL_TRAIT, int>()
        {
            { GameManager.PHYSICAL_TRAIT.Appearance, Appearance.GetSetting() },
            { GameManager.PHYSICAL_TRAIT.Height, Height.GetSetting() },
            { GameManager.PHYSICAL_TRAIT.Style, Style.GetSetting() }
        };
    }

    public void SetNextSprite() {
        ++CurrentSprite;
        WrapCurrentSprite();

        RobotImage.sprite = Sprites[CurrentSprite];
    }

    public void SetLastSprite() {
            --CurrentSprite;
            WrapCurrentSprite();

            RobotImage.sprite = Sprites[CurrentSprite];
        }

    private void WrapCurrentSprite() {
        if (CurrentSprite < 0) {
            CurrentSprite = Sprites.Length + CurrentSprite;
        }

        CurrentSprite = (CurrentSprite % Sprites.Length);
    }
}
