using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private TMP_Text OverlayText;

    private bool GameOver = false;

    private static SoundManager SoundManagerRef;

    public void Awake() {
        SoundManagerRef = SoundManager;
    }

    public static void PlayClientSound(string Speaker) {
        switch (Speaker) {
            case "Enby": SoundManagerRef.PlayClientANeutralEffect(); break;
            case "Robot": SoundManagerRef.PlayClientBNeutralEffect(); break;
            case "Alien": SoundManagerRef.PlayClientCNeutralEffect(); break;
            case "Continue": SoundManagerRef.PlayContinueEffect(); break;
            case "Submit": SoundManagerRef.PlaySubmitEffect(); break;
        };
    }

    public void Update() {
        if (Overlay.activeInHierarchy && Input.anyKeyDown) {
            if (GameOver)
            {
                SceneManager.LoadScene(0);
                return;
            }

            Overlay.SetActive(false);

            SoundManager.PlaySubmitEffect();
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

    public void OnGameOver()
    {
        GameOver = true;
        OverlayText.text = "Game Over!\n(Press any button to restart)";
        Overlay.SetActive(true);
    }
}
