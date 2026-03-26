using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    [Header(" Actions ")]
    public static Action<FruitType, Vector2> onMergeProcessed;
    Fruit lastSender;

    private void Start()
    {
        Fruit.onCollisionWithFruit += CollisionBetweenFruitsCallback;
    }

    private void OnDestroy()
    {
        Fruit.onCollisionWithFruit -= CollisionBetweenFruitsCallback;
    }

    private void CollisionBetweenFruitsCallback(Fruit sender, Fruit otherFruit)
    {
        if (lastSender != null)
            return;

        lastSender = sender;
        
        ProgressMerge(sender, otherFruit);

        Debug.Log("Merge Detected: " + sender.GetFruitType().ToString());
    }

    private void ProgressMerge(Fruit sender, Fruit otherFruit)
    {
        FruitType mergeFruitType = sender.GetFruitType();
        mergeFruitType += 1;

        Vector2 mergePosition = (sender.transform.position + otherFruit.transform.position) / 2;

        onMergeProcessed?.Invoke(mergeFruitType, mergePosition);

        sender.Merge();
        otherFruit.Merge();

        StartCoroutine(ResetLastSenderCoroutine());
    }

    IEnumerator ResetLastSenderCoroutine()
    {
        yield return new WaitForEndOfFrame();

        lastSender = null;
    }
}
