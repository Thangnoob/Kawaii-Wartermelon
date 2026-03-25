using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image nextFruitImage;


    private void Start()
    {
        FruitManager.onNextFruitIndexSet += UpdateNextFruitImage;
    }

    private void OnDestroy()
    {
        FruitManager.onNextFruitIndexSet -= UpdateNextFruitImage;
    }

    private void UpdateNextFruitImage()
    {
        nextFruitImage.sprite = FruitManager.Instance.GetNextFruitSprite();
    }
}
