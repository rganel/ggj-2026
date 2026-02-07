using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SoundboardManager SoundboardManager;

    [SerializeField]
    private RobotAvatarManager RobotAvatarManager;

    [SerializeField]
    private SoundManager SoundManager;

    [SerializeField]
    private GameObject Overlay;

    [SerializeField]
    private TMP_Text CurrentMoneyText;

    private static SoundManager SoundManagerRef;

    public void Awake() {
        SoundManagerRef = SoundManager;
    }

    public static void PlayClientSound(string Speaker) {
        switch (Speaker) {
            case "Enby": SoundManagerRef.PlayEffect(SoundManager.EFFECT_TYPE.ClientANeutral); break;
            case "Robot": SoundManagerRef.PlayEffect(SoundManager.EFFECT_TYPE.ClientBNeutral); break;
            case "Alien": SoundManagerRef.PlayEffect(SoundManager.EFFECT_TYPE.ClientCNeutral); break;
        };
    }

    public void Update() {
        if (Overlay.activeInHierarchy && Input.anyKeyDown) {
            Overlay.SetActive(false);

            DialogueManager.StartConversation("Intro", null, null);
        }
    }

    public void Reset() {
        SoundboardManager.Reset();
        RobotAvatarManager.Reset();

        DialogueManager.MasterDatabase.GetActor("Cassbot").spritePortrait = RobotAvatarManager.GetLastUsedSprite();
    }

    public void OnPersonalityAnswer() {
        SoundboardManager.Enable();
    }

    public void OnPhysicalAnswer() {
        RobotAvatarManager.Enable();
    }

    public void OnMoneyUpdated() {
        CurrentMoneyText.text = DialogueLua.GetVariable("Money").asInt.ToString();
    }
}
