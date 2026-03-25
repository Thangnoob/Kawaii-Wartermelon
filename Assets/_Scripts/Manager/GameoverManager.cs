using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform fruitParentTransfrom;
    [SerializeField] private GameObject fruitDeadline;

    [Header(" Timer ")]
    [SerializeField] private float threshHold;
    private float timer;
    private bool timeOn;
    private bool isGameover;

    private void Update()
    {
        if (!isGameover)
        {
            ManageGameover();
        }
    }

    private void ManageGameover()
    {
        if (timeOn)
        {
            ManagerTimerOn();
        }
        else
        {
            if (IsFruitAboveLine())
            {
                StartTimer();
            }
        }
    }

    private void ManagerTimerOn()
    {
        timer += Time.deltaTime;
        Debug.Log("Game over countdown: " + timer);
        if (!IsFruitAboveLine())
        {
            StopTimer();
        }

        if (timer >= threshHold)
        {
            TriggerGameOver();
        }
    }

    private bool IsFruitAboveLine()
    {
        for (int i = 0; i < fruitParentTransfrom.childCount; i++)
        {
            Fruit fruit = fruitParentTransfrom.GetChild(i).GetComponent<Fruit>();

            if (!fruit.HasCollided())
                continue;

            if (IsFruitAboveLine(fruit))
                return true;
        }
        return false;
    }

    private bool IsFruitAboveLine(Fruit fruit)
    {
        if (fruit.transform.position.y > fruitDeadline.transform.position.y)
            return true;
        return false;
    }

    private void StartTimer()
    {
        timer = 0f;
        timeOn = true;
    }

    private void StopTimer()
    {
        timeOn = false;
    }

    private void TriggerGameOver()
    {
        isGameover = true;
        Debug.Log("Game Over");

        GameManager.Instance.SetGameState(GameState.Gameover);
    }
}
