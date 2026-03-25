using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() => {
            GameManager.Instance.SetGameState(GameState.InGame);
        });
    }
}
