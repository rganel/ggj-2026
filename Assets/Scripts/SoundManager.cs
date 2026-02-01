using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    private class ClipVariants {
        [SerializeField]
        private AudioClip[] Clips;

        public AudioClip GetClip() {
            return Clips[Random.Range(0, Clips.Length)];
        }
    }

    public enum EFFECT_TYPE {
        PersonalityChange,
        PhysicalChange
    };

    [SerializeField]
    private AudioClip BackgroundMusicClip;

    [SerializeField]
    private AudioSource MusicAudioSource;

    [SerializeField]
    private ClipVariants[] SFXClips = new ClipVariants[2];

    [SerializeField]
    private ClipVariants PhysicalChangeClips;

    [SerializeField]
    private AudioSource SFXAudioSource;

    void Awake() {
        MusicAudioSource.clip = BackgroundMusicClip;
        MusicAudioSource.Play();
    }

    public void PlayPersonalityEffect() {
        PlayEffect(EFFECT_TYPE.PersonalityChange);
    }

    public void PlayPhysicalEffect() {
        PlayEffect(EFFECT_TYPE.PhysicalChange);
    }

    public void PlayEffect(EFFECT_TYPE EffectType) {
        SFXAudioSource.clip = SFXClips[(int)EffectType].GetClip();
        SFXAudioSource.Play();
    }
}
