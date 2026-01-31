using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PersonalityTrait {
        Intimacy,
        Social,
        Demeanor
    };

    [System.Serializable]
    private class Client {
        [SerializeField]
        private PersonalityTrait PrimaryTrait;

        [SerializeField]
        private PersonalityTrait SecondaryTrait;

        [SerializeField]
        private PersonalityTrait TertiaryTrait;
    }

    [SerializeField]
    private Client[] Clients;
}
