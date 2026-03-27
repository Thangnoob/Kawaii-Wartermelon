using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetProgressPrompt : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private void Awake()
    {
        yesButton.onClick.AddListener(OnYesButtonCallback);
        noButton.onClick.AddListener(OnNoButtonCallback);
    }

    private void OnYesButtonCallback()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    private void OnNoButtonCallback()
    {
        gameObject.SetActive(false);
    }
}
