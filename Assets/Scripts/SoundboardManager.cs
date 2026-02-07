using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class SoundboardManager : MonoBehaviour
{
    public enum PERSONALITY_TRAIT {
        Intimacy,
        Social,
        Demeanor
    };

    [System.Serializable]
    private class PersonalityTrait {
        [SerializeField]
        private PERSONALITY_TRAIT Trait;

        [SerializeField]
        private int Setting;

        [SerializeField]
        [VariablePopup]
        private string DialogueVariableName;

        [SerializeField]
        private Slider Slider;

        [SerializeField]
        private GameObject SliderHandle;

        public PersonalityTrait() {
            Setting = 0;
        }

        public int GetSetting() {
            return Setting;
        }

        public void LockIn() {
            Slider.interactable = false;
            SliderHandle.SetActive(false);
        }

        public void Init(PERSONALITY_TRAIT trait) {
            Slider.onValueChanged.AddListener(delegate {HandleSettingUpdate();});
        }

        public void Reset() {
            Setting = 0;
            Slider.value = 0;
            Slider.interactable = true;
            SliderHandle.SetActive(true);
        }

        private void HandleSettingUpdate() {
            Setting = (int)Slider.value;
            DialogueLua.SetVariable(DialogueVariableName, Setting);
        }
    }

    [SerializeField]
    private PersonalityTrait Intimacy = new PersonalityTrait();

    [SerializeField]
    private PersonalityTrait Social = new PersonalityTrait();

    [SerializeField]
    private PersonalityTrait Demeanor = new PersonalityTrait();

    [SerializeField]
    private GameObject SoundboardRoot;

    public void Awake() {
        Intimacy.Init(PERSONALITY_TRAIT.Intimacy);
        Social.Init(PERSONALITY_TRAIT.Social);
        Demeanor.Init(PERSONALITY_TRAIT.Demeanor);
    }

    public void LockIn() {
        Intimacy.LockIn();
        Social.LockIn();
        Demeanor.LockIn();
    }

    public void Reset() {
        Intimacy.Reset();
        Social.Reset();
        Demeanor.Reset();

        SoundboardRoot.SetActive(false);
    }

    public Dictionary<PERSONALITY_TRAIT, int> GetSettings() {
        return new Dictionary<PERSONALITY_TRAIT, int>()
        {
            { PERSONALITY_TRAIT.Intimacy, Intimacy.GetSetting() },
            { PERSONALITY_TRAIT.Social, Social.GetSetting() },
            { PERSONALITY_TRAIT.Demeanor, Demeanor.GetSetting() }
        };
    }

    public void Enable() {
        SoundboardRoot.SetActive(true);
    }
}
