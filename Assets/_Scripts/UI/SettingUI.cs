using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider pushMagnitudeSlider;
    [SerializeField] private GameObject resetProgressPrompt;
    [SerializeField] private Button resetProgressButton;

    [Header(" Actions ")]
    public static Action<float> onPushMagnitudeChanged;
    public static Action<bool> onToggleValueChanged;

    [Header(" Datas ")]
    [SerializeField] private const string lastPushMagnitudeKey = "lastPushMagnitudeKey";
    [SerializeField] private const string toggleValueKey = "toggleValueKey";
    private bool isLoading;
    private void Awake()
    {
        sfxToggle.onValueChanged.AddListener(SfxToggleCallback);
        resetProgressButton.onClick.AddListener(ResetProgressButtonCallback);
        pushMagnitudeSlider.onValueChanged.AddListener(SliderValueChangedCallback);
        LoadData();

    }

    private void Start()
    {
    }

    private void SliderValueChangedCallback(float newValue)
    {
        onPushMagnitudeChanged?.Invoke(newValue);

        if (isLoading) return;
        
        SaveSliderData();
    }

    private void SfxToggleCallback(bool toggleValue)
    {
        onToggleValueChanged?.Invoke(toggleValue);

        if (isLoading) return;  

        SaveToggleData();
    }

    public void ResetProgressButtonCallback()
    {
        resetProgressPrompt.SetActive(true);
    }

    private void LoadData()
    {
        LoadSliderData();
        LoadToggleData();
        isLoading = false; 
    }

    private void LoadSliderData()
    {
        float pushMagnitudeValue = PlayerPrefs.GetFloat(lastPushMagnitudeKey);
        pushMagnitudeSlider.value = pushMagnitudeValue;
        isLoading = true;
    }

    private void LoadToggleData()
    {
        bool sfxValue = PlayerPrefs.GetInt(toggleValueKey, 1) == 1;
        sfxToggle.isOn = sfxValue;
    }

    private void SaveToggleData()
    {
        PlayerPrefs.SetInt(toggleValueKey, sfxToggle.isOn ? 1 : 0);
    }

    private void SaveSliderData()
    {
        PlayerPrefs.SetFloat(lastPushMagnitudeKey, pushMagnitudeSlider.value);

    }
}
