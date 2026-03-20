using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Fruit fruitPrefab;
    [SerializeField] private LineRenderer spawnFruitLine;
    private Fruit currentFruit;

    [Header(" Settings ")]
    [SerializeField] private float spawnYPosition;

    [Header( "Debug" )]
    [SerializeField] private bool enableGizmos;

    private void Start()
    {
        HideLine(); 
    }

    private void Update()
    {
        ManagePlayerInput();
    }

    //=========================================
    //MOUSE INPUT 
    //==========================================
    private void ManagePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
            MouseDownCallBack();
        else if (Input.GetMouseButton(0))
            MouseDragCallBack();
        else if (Input.GetMouseButtonUp(0))
            MouseUpCallBack();
    }
    private void MouseDownCallBack()
    {
        ShowLine();
        PlaceLineAtClickedPosition();

        SpawnFruit();
    }

    private void MouseDragCallBack()
    {
        PlaceLineAtClickedPosition();
        currentFruit.MoveToPosition(GetSpawnPosition());
    }

    private void MouseUpCallBack()
    {
        HideLine();

        currentFruit.EnablePhysics();
    }

    //=========================================
    //SPAWN
    //=========================================
    private void SpawnFruit()
    {
        Vector2 spawnPosition = GetSpawnPosition();

        currentFruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
    }
    //==========================================
    //LINE 
    //==========================================
    private void HideLine()
    {
        spawnFruitLine.enabled = false;
    }

    private void ShowLine()
    {
        spawnFruitLine.enabled = true;
    }

    private void PlaceLineAtClickedPosition()
    {
        spawnFruitLine.SetPosition(0, GetSpawnPosition());
        spawnFruitLine.SetPosition(1, GetSpawnPosition() + Vector2.down * 15);
    }

    //==========================================
    // POSITION 
    //==========================================


    private Vector2 GetClickedPositionInput()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 worldClickedPosition = GetClickedPositionInput();
        worldClickedPosition.y = spawnYPosition;
        return worldClickedPosition;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!enableGizmos) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(-50, spawnYPosition, 0), new Vector3(50, spawnYPosition, 0));
    }
#endif
}
