using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Soundboard : MonoBehaviour
{
    [System.Serializable]
    private class PersonalityTrait {
        [SerializeField]
        private GameManager.PERSONALITY_TRAIT Trait;

        [SerializeField]
        private int Setting;

        [SerializeField]
        private Slider Slider;

        public PersonalityTrait() {
            Setting = 0;
        }

        public int GetSetting() {
            return Setting;
        }

        public void Init(GameManager.PERSONALITY_TRAIT trait, UnityEvent SettingChangedEvent) {
            Slider.onValueChanged.AddListener(delegate {HandleSettingUpdate(); SettingChangedEvent.Invoke();});
        }

        private void HandleSettingUpdate() {
            Setting = (int)Slider.value;
        }
    }

    [SerializeField]
    private PersonalityTrait Intimacy = new PersonalityTrait();

    [SerializeField]
    private PersonalityTrait Social = new PersonalityTrait();

    [SerializeField]
    private PersonalityTrait Demeanor = new PersonalityTrait();

    public UnityEvent PersonalityChanged;

    public void Awake() {
        Intimacy.Init(GameManager.PERSONALITY_TRAIT.Intimacy, PersonalityChanged);
        Social.Init(GameManager.PERSONALITY_TRAIT.Social, PersonalityChanged);
        Demeanor.Init(GameManager.PERSONALITY_TRAIT.Demeanor, PersonalityChanged);
    }

    public Dictionary<GameManager.PERSONALITY_TRAIT, int> GetSettings() {
        return new Dictionary<GameManager.PERSONALITY_TRAIT, int>()
        {
            { GameManager.PERSONALITY_TRAIT.Intimacy, Intimacy.GetSetting() },
            { GameManager.PERSONALITY_TRAIT.Social, Social.GetSetting() },
            { GameManager.PERSONALITY_TRAIT.Demeanor, Demeanor.GetSetting() }
        };
    }
}
