using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundboard : MonoBehaviour
{
    [System.Serializable]
    private class PersonalityTrait {
        [SerializeField]
        private int Setting;

        [SerializeField]
        private Slider Slider;

        public PersonalityTrait() {
            Setting = 0;
        }

        public void Init() {
            Slider.onValueChanged.AddListener(delegate {HandleSettingUpdate();});
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

    public void Awake() {
        Intimacy.Init();
        Social.Init();
        Demeanor.Init();
    }
}
