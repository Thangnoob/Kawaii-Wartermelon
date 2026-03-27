using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlineDisplay : MonoBehaviour
{
    [SerializeField] private GameObject deadlineFruit;
    [SerializeField] private Transform fruitParent;

    private void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }
    private void GameStateChangedCallback(GameState state)
    {
        if (state == GameState.InGame)
            StartCheckingForNearbyFruit();
        else 
            StopCheckingForNearbyFruit();            
    }

    private void StartCheckingForNearbyFruit()
    {
        StartCoroutine(CheckingForNearbyFruitCoroutine());
    }    

    private void StopCheckingForNearbyFruit()
    {
        HideDeadline();
        StopCoroutine(CheckingForNearbyFruitCoroutine());
    }

    IEnumerator CheckingForNearbyFruitCoroutine()
    {
        while (true)
        {
            bool foundNearbyFruit = false;
            for (int i = 0; i < fruitParent.childCount; i++)
            {
                if (!fruitParent.GetChild(i).GetComponent<Fruit>().HasCollided())
                    continue;

                float distance = Mathf.Abs(
                    fruitParent.GetChild(i).position.y
                    - deadlineFruit.transform.position.y);

                if (distance <= 1)
                {
                    ShowDeadline();
                    foundNearbyFruit = true;
                    break;
                }
            }

            if (!foundNearbyFruit) 
                HideDeadline();

            yield return new WaitForSeconds(1);
        }

    }

    private void ShowDeadline()
    {
        deadlineFruit.SetActive(true);
    }

    private void HideDeadline()
    {
        deadlineFruit.SetActive(false);
    }
}
