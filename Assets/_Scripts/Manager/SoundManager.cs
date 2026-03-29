using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AudioSource mergeSound;

    [Header(" Sounds ")]
    [SerializeField] private AudioClip[] audioClips;
    private void Awake()
    {
        MergeManager.onMergeProcessed += MergeProcessedCallback;
        SettingUI.onToggleValueChanged += ToggleValueChangedCalback;
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcessed -= MergeProcessedCallback;
        SettingUI.onToggleValueChanged -= ToggleValueChangedCalback;
    }
    private void ToggleValueChangedCalback(bool toggleValue)
    {
        mergeSound.mute = !toggleValue;
    }

    private void MergeProcessedCallback(FruitType type, Vector2 vector)
    {
        PlayMergeSound();
    }

    private void PlayMergeSound()
    {
        mergeSound.clip = audioClips[Random.Range(0, audioClips.Length)];
        mergeSound.pitch = Random.Range(0.9f, 1.1f);
        mergeSound.Play();
    }
}
