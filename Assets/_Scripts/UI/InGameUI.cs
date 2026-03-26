using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image nextFruitImage;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreText(0);
        FruitManager.onNextFruitIndexSet += UpdateNextFruitImage;
        ScoreManager.onScoreCalculated += UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
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
