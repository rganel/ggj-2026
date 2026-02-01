using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PERSONALITY_TRAIT {
        Intimacy,
        Social,
        Demeanor
    };

    public enum PHYSICAL_TRAIT {
        Appearance,
        Height,
        Style
    };

    [System.Serializable]
    private class Client {
        [SerializeField]
        public string Name;

        [SerializeField]
        public PERSONALITY_TRAIT PrimaryPerTrait;

        [SerializeField]
        public int PrimaryPerTraitPreferredValue;

        [SerializeField]
        public PERSONALITY_TRAIT SecondaryPerTrait;

        [SerializeField]
        public int SecondaryPerTraitPreferredValue;

        [SerializeField]
        public PERSONALITY_TRAIT TertiaryPerTrait;

        [SerializeField]
        public int TertiaryPerTraitPreferredValue;

        [SerializeField]
        public PHYSICAL_TRAIT PrimaryPhysTrait;

        [SerializeField]
        public int PrimaryPhysTraitPreferredValue;

        [SerializeField]
        public PHYSICAL_TRAIT SecondaryPhysTrait;

        [SerializeField]
        public int SecondaryPhysTraitPreferredValue;

        [SerializeField]
        public PHYSICAL_TRAIT TertiaryPhysTrait;

        [SerializeField]
        public int TertiaryPhysTraitPreferredValue;
    }

    [SerializeField]
    private Client[] Clients;

    [SerializeField]
    private Soundboard Soundboard;

//    [SerializeField]
    private Client CurrentClient;

    [SerializeField]
    private int DEBUG_CurrentClient = -1;

    [SerializeField]
    private int DEBUG_PrimaryPhysicalTraitSetting = -1;

    public void FixedUpdate() {
        if (DEBUG_CurrentClient >= 0) {
            CurrentClient = Clients[DEBUG_CurrentClient];
        }
    }

    public bool GetClientSuccess() {
        Dictionary<GameManager.PERSONALITY_TRAIT, int> SoundboardSettings = Soundboard.GetSettings();

        bool PersonalitySuccess = SoundboardSettings[CurrentClient.PrimaryPerTrait] == CurrentClient.PrimaryPerTraitPreferredValue;
        bool PhysicalSuccess = DEBUG_PrimaryPhysicalTraitSetting == CurrentClient.PrimaryPhysTraitPreferredValue;

        return PersonalitySuccess && PhysicalSuccess;
    }

    public void DEBUG_CheckSubmission() {
        Debug.Log("Success: " + (GetClientSuccess() ? "true" : "false"));
    }
    public string GetCurrentClientName()
    {
        return CurrentClient.Name;
    }
}
