using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flash : MonoBehaviour
{
    [SerializeField]
    private float FlashSpeed;

    [SerializeField]
    private TMP_Text Text;


    void Update() {
        Color NewColor = Text.color;
        NewColor.a = Mathf.PingPong(Time.time, 1.0f) * FlashSpeed;
        Text.color = NewColor;
    }
}
