using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FruitManager))]
public class InGameUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI nextFruitText;
    [SerializeField] private Image nextFruitImage;
    private FruitManager fruitManager;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        fruitManager = GetComponent<FruitManager>();

    }

    // Update is called once per frame
    void Update()
    {
        nextFruitText.text = "Next: " + fruitManager.GetNextFruitName();
        nextFruitImage.sprite = fruitManager.GetNextFruitSprite();
    }
}
