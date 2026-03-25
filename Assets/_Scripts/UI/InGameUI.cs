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
        FruitManager.OnNextFruitIndexSet += UpdateNextFruitImage;
    }

    private void UpdateNextFruitImage()
    {
        nextFruitImage.sprite = FruitManager.Instance.GetNextFruitSprite();
    }
}
