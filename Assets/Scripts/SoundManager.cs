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
        PhysicalChange,
        ClientANeutral,
        ClientBNeutral,
        ClientCNeutral,
        ClientHappy,
        ClientUpset,
        PlayerSubmit,
        PlayerContinue
    };

    [SerializeField]
    private AudioClip BackgroundMusicClip;

    [SerializeField]
    private AudioSource MusicAudioSource;

    [SerializeField]
    private ClipVariants[] SFXClips = new ClipVariants[2];

    [SerializeField]
    private AudioSource SFXAudioSource;

    [SerializeField]
    private AudioSource ClientAudioSource;

    private Queue<IEnumerator> Queue = new Queue<IEnumerator>();

    public void Start() {
        MusicAudioSource.clip = BackgroundMusicClip;
        MusicAudioSource.Play();

        //StartCoroutine(SFXPlayer());
    }

    public void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void PlayPersonalityEffect() {
        PlayEffect(EFFECT_TYPE.PersonalityChange, SFXAudioSource);
    }

    public void PlayPhysicalEffect() {
        PlayEffect(EFFECT_TYPE.PhysicalChange, SFXAudioSource);
    }

    public void PlayClientANeutralEffect() {
        PlayEffect(EFFECT_TYPE.ClientANeutral, ClientAudioSource);
    }

    public void PlayClientBNeutralEffect() {
        PlayEffect(EFFECT_TYPE.ClientBNeutral, ClientAudioSource);
    }

    public void PlayClientCNeutralEffect() {
        PlayEffect(EFFECT_TYPE.ClientCNeutral, ClientAudioSource);
    }

    public void PlayClientHappyEffect() {
        PlayEffect(EFFECT_TYPE.ClientHappy, ClientAudioSource);
    }

    public void PlayClientUpsetEffect() {
        PlayEffect(EFFECT_TYPE.ClientUpset, ClientAudioSource);
    }

    public void PlaySubmitEffect() {
        PlayEffect(EFFECT_TYPE.PlayerSubmit, SFXAudioSource);
    }

    public void PlayContinueEffect() {
        PlayEffect(EFFECT_TYPE.PlayerContinue, SFXAudioSource);
    }

    private void PlayEffect(EFFECT_TYPE EffectType, AudioSource AudioSource)
    {
        AudioSource.Stop();
        AudioSource.clip = SFXClips[(int)EffectType].GetClip();
        AudioSource.Play();
    }

    //public void PlayEffect(EFFECT_TYPE EffectType, bool Interrupt = false) {
    //    if (Interrupt)
    //    {
    //        while (Queue.Count > 0)
    //        {
    //            StopCoroutine(Queue.Dequeue());
    //            SFXAudioSource.Stop();
    //        }
    //    }

    //    Queue.Enqueue(PlayQueueEffect(SFXClips[(int)EffectType].GetClip()));
    //}

    //public IEnumerator SFXPlayer()
    //{
    //    while (true)
    //    {
    //        while (Queue.Count > 0)
    //        {
    //            yield return StartCoroutine(Queue.Dequeue());
    //        }

    //        yield return null;
    //    }
    //}

    //public IEnumerator PlayQueueEffect(AudioClip Clip)
    //{
    //    SFXAudioSource.clip = Clip;
    //    SFXAudioSource.Play();

    //    yield return new WaitForSeconds(Clip.length);
    //}
}
