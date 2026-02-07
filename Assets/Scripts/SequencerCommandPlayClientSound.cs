
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
                GameManager.PlayClientSound(GetParameter(0).ToString().Split("_")[0]);
            }


            Stop();
        }
    }
}