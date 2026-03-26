using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private AudioSource mergeSound;

    private void Start()
    {
        MergeManager.onMergeProcessed += MergeProcessedCallback;
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcessed -= MergeProcessedCallback;
    }

    private void MergeProcessedCallback(FruitType type, Vector2 vector)
    {
        PlayMergeSound();
    }

    private void PlayMergeSound()
    {
        mergeSound.pitch = Random.Range(0.9f, 1.1f);
        mergeSound.Play();
    }
}
