
using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands {

    [SequencerCommandGroup("Custom")]
    public class SequencerCommandPlayClientSound : SequencerCommand
    {


        public void Awake() {
            string EntryTag = GetParameter(0);
            if (EntryTag != null && EntryTag.Contains("_"))
            {
                GameManager.PlayClientSound(EntryTag.ToString().Split("_")[0]);
            } else if (EntryTag != null && EntryTag.Contains("Submit"))
            {
                GameManager.PlayClientSound("Submit");
            }
            else if (EntryTag != null && EntryTag.Contains("Continue"))
            {
                GameManager.PlayClientSound("Continue");
            }

            Stop();
        }
    }
}