using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button skinButton;
    [SerializeField]private GameObject selectionOutline;
    [SerializeField] private Image iconImage;

    public void Configure(Sprite objectIcon)
    {
        iconImage.sprite = objectIcon;
    }

    public Button GetSkinButton()
    {
        return skinButton;
    }
    public void ShowOutline() => selectionOutline.SetActive(true);
    public void HideOutline() => selectionOutline.SetActive(false);
    
}
