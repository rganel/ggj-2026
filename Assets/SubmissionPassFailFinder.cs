using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubmissionPassFailFinder : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;
    //I hate the way I set this up but whatever it's a game jam. it would look up children game objects by tag if I gave a fuqqq
    [SerializeField]
    public DialogueSystemTrigger AlienPass;
    [SerializeField]
    public DialogueSystemTrigger AlienFail;
    [SerializeField]
    public DialogueSystemTrigger EnbyPass;
    [SerializeField]
    public DialogueSystemTrigger EnbyFail;
    [SerializeField]
    public DialogueSystemTrigger RobotPass;
    [SerializeField]
    public DialogueSystemTrigger RobotFail;
    public void PassOrFail()
    {
//        if (gameManager.GetCurrentClientName() == "Alien")
//        {
//            if (gameManager.GetClientSuccess() == true)
//            {
//                AlienPass.OnUse();
//            }
//            else
//            {
//                AlienFail.OnUse();
//            }
//        }
//        else if (gameManager.GetCurrentClientName() == "Enby")
//        {
//            if (gameManager.GetClientSuccess() == true)
//            {
//                EnbyPass.OnUse();
//            }
//            else
//            {
//                EnbyFail.OnUse();
//            }
//        }
//        else if (gameManager.GetCurrentClientName() == "Robot")
//        {
//            if (gameManager.GetClientSuccess() == true)
//            {
//                RobotPass.OnUse();
//            }
//            else
//            {
//                RobotFail.OnUse();
//            }
//        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
