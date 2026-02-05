using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SoundboardManager SoundboardManager;

    [SerializeField]
    private RobotAvatarManager RobotAvatarManager;

    [SerializeField]
    private GameObject Overlay;

    public static UnityEvent PhysicalTraitChanged;

    public static UnityEvent PersonalityTraitChanged;

    public void Awake() {
        PhysicalTraitChanged = new UnityEvent();
        PersonalityTraitChanged = new UnityEvent();
    }

    public void Update() {
        if (Overlay.activeInHierarchy && Input.anyKeyDown) {
            Overlay.SetActive(false);

            DialogueManager.StartConversation("Enby Convo", null, null);
        }
    }

    public void Reset() {
        SoundboardManager.Reset();
        RobotAvatarManager.Reset();
    }

    public void OnPersonalityAnswer() {
        SoundboardManager.Enable();
    }

    public void OnPhysicalAnswer() {
        RobotAvatarManager.Enable();
    }
}
