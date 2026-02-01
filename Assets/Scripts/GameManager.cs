using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

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
    private SoundboardManager SoundboardManager;

    [SerializeField]
    private RobotAvatarManager RobotAvatarManager;

    [SerializeField]
    private GameObject SubmitButton;

    private Client CurrentClient;

    [SerializeField]
    private int CurrentClientIndex = -1;

    [SerializeField]
    private GameObject SendToDialogueMgr;

    public void Awake() {
        NextClient(null);
    }

    public void CompleteConfig() {
        SubmitButton.SetActive(false);

        DialogueManager.instance.conversationEnded -= OnClientIntroEnded;
        DialogueManager.instance.conversationEnded += NextClient;

        bool success = GetClientSuccess();

        if (CurrentClientIndex == 0) {
            DialogueManager.StartConversation("Enby " + (success ? "Success" : "Fail"), null, null);
        } else if (CurrentClientIndex == 1) {
            DialogueManager.StartConversation("Robot " + (success ? "Success" : "Fail"), null, null);
        } else if (CurrentClientIndex == 2) {
            DialogueManager.StartConversation("Alien " + (success ? "Success" : "Fail"), null, null);
        }
    }

    public bool GetClientSuccess() {
        Dictionary<GameManager.PERSONALITY_TRAIT, int> SoundboardSettings = SoundboardManager.GetSettings();
        Dictionary<GameManager.PHYSICAL_TRAIT, int> AvatarSettings = RobotAvatarManager.GetSettings();

        bool PersonalitySuccess = SoundboardSettings[CurrentClient.PrimaryPerTrait] == CurrentClient.PrimaryPerTraitPreferredValue;
        bool PhysicalSuccess = AvatarSettings[CurrentClient.PrimaryPhysTrait] == CurrentClient.PrimaryPhysTraitPreferredValue;

        return PersonalitySuccess && PhysicalSuccess;
    }

    public void OnClientIntroEnded(Transform t) {
        SubmitButton.SetActive(true);
    }

    public void NextClient(Transform t) {
        SoundboardManager.Reset();
        RobotAvatarManager.Reset();

        if (CurrentClientIndex >= 2) {
            Application.Quit();
        }

        ++CurrentClientIndex;
        CurrentClient = Clients[CurrentClientIndex];

        DialogueManager.instance.conversationEnded -= NextClient;
        DialogueManager.instance.conversationEnded += OnClientIntroEnded;

        if (CurrentClientIndex == 0) {
            DialogueManager.StartConversation("Enby Convo", null, null);
        } else if (CurrentClientIndex == 1) {
            DialogueManager.StartConversation("Robot Convo", null, null);
        } else if (CurrentClientIndex == 2) {
            DialogueManager.StartConversation("Alien Convo", null, null);
        } else {
            SubmitButton.SetActive(false);
        }
    }
}
