using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFruitEffect : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private float pushRadius;
    [SerializeField] private float pushMagnitude;
    private Vector2 pushPosition;

    [Header(" Debug ")]
    [SerializeField] private bool enableGizmos;
    private void Start()
    {
        MergeManager.onMergeProcessed += MergeProcessedCallback;
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcessed -= MergeProcessedCallback;
    }

    private void MergeProcessedCallback(FruitType type, Vector2 mergePosition)
    {
        pushPosition = mergePosition;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mergePosition, pushRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Fruit fruit))
            {
                Vector2 force = ((Vector2)fruit.transform.position - mergePosition).normalized;
                force *= pushMagnitude;
                
                fruit.GetComponent<Rigidbody2D>().AddForce(force);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!enableGizmos) 
            return;
         
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pushPosition, pushRadius);
    }
#endif
}
