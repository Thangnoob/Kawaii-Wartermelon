using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button resetProgressButton;
    [SerializeField] private GameObject resetProgressPrompt;
    [SerializeField] private Slider pushMagnitudeSlider;

    [Header(" Actions ")]
    public static Action<float> onPushMagnitudeChanged;

    [Header(" Datas ")]
    [SerializeField] private const string lastPushMagnitudeKey = "lastPushMagnitudeKey";
    private void Awake()
    {
        resetProgressButton.onClick.AddListener(ResetProgressButtonCallback);
        pushMagnitudeSlider.onValueChanged.AddListener(SliderValueChangedCallback);
    }

    private void Start()
    {
        LoadData();
    }
    private void SliderValueChangedCallback(float newValue)
    {
        onPushMagnitudeChanged?.Invoke(newValue);

        SaveData();
    }

    public void ResetProgressButtonCallback()
    {
        resetProgressPrompt.SetActive(true);
    }

    private void LoadData()
    {
        float pushMagnitudeValue = PlayerPrefs.GetFloat(lastPushMagnitudeKey);
        pushMagnitudeSlider.value = pushMagnitudeValue;
        //onPushMagnitudeChanged?.Invoke(pushMagnitudeValue);
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat(lastPushMagnitudeKey, pushMagnitudeSlider.value);
    }
}
