using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SkinButton skinButton;
    [SerializeField] private Transform buttonSpawnArea;
    [SerializeField] private Button purchaseButton;

    [Header(" Datas ")]
    [SerializeField] private SkinDataSO[] skinDataSOs;
    [SerializeField] private bool[] unlockSkinState;

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        purchaseButton.gameObject.SetActive(false);

        for (int i = 0; i < skinDataSOs.Length; i++)
        {
            SkinButton skinButtonInstance = Instantiate(skinButton, buttonSpawnArea);
            skinButtonInstance.Configure(
                skinDataSOs[i].GetSpawnablePrefabs()[0].GetComponent<Fruit>().GetFruitSprite());

            if (i == 0)
            {
                skinButtonInstance.ShowOutline();
            }

            int j = i;
            skinButtonInstance.GetSkinButton().onClick.AddListener(() => SkinButtonClickedCallback(j));
        }
    }

    private void SkinButtonClickedCallback(int skinButtonIndex)
    {
        Debug.Log("Skin Index is" + skinButtonIndex);
        for (int i = 0;i < buttonSpawnArea.childCount; i++)
        {
            SkinButton currenSkinButton = buttonSpawnArea.GetChild(i).GetComponent<SkinButton>();
            if (i != skinButtonIndex)
                currenSkinButton.HideOutline();
            else
                currenSkinButton.ShowOutline();
        }
        ManagePurchaseButtonVisibility(skinButtonIndex);
    }

    private void ManagePurchaseButtonVisibility(int skinButtonIndex)
    {
        purchaseButton.gameObject.SetActive(!unlockSkinState[skinButtonIndex]);
    }

    private void LoadData()
    {
        unlockSkinState = new bool[skinDataSOs.Length];

        for (int i = 0; i < unlockSkinState.Length; i++)
        {
            int stateValue = PlayerPrefs.GetInt("SkinButton_" + i);

            if (i == 0)
            {
                stateValue = 1;
            }

            if (stateValue == 0)
                unlockSkinState[i] = false;
            else
                unlockSkinState[i] = true;
        }
    }
}
