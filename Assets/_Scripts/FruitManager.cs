using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Fruit[] fruitPrefabs;
    [SerializeField] private Fruit[] spawnableFruits;
    [SerializeField] private Transform fruitParent;
    [SerializeField] private LineRenderer spawnFruitLine;
    private Fruit currentFruit;

    [Header(" Settings ")]
    [SerializeField] private float spawnYPosition;
    [SerializeField] private float spawnDelay = 0.5f;
    private bool canControl;
    private bool isControlling;

    [Header(" Next Fruit Settings ")]
    private int nextFruitIndex;

    [Header( "Debug" )]
    [SerializeField] private bool enableGizmos;

    private void Awake()
    {
        
    }

    private void Start()
    {
        MergeManager.onMergeProgressed += MergeProgressCallback;

        canControl = true;
        HideLine();

        SetNextFruitIndex();
    }



    private void Update()
    {
        if ( canControl )
        {
            ManagePlayerInput();
        }
    }

    //=========================================
    //MOUSE INPUT 
    //==========================================
    private void ManagePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
            MouseDownCallBack();
        
        else if (Input.GetMouseButton(0))
        {
            if (isControlling)
            {
                MouseDragCallBack();
            }
            else
                MouseDownCallBack();
        }
        
        else if (Input.GetMouseButtonUp(0) && isControlling)
            MouseUpCallBack();
    }
    private void MouseDownCallBack()
    {
        ShowLine();
        PlaceLineAtClickedPosition();

        SpawnFruit();
        isControlling = true;
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

        StartControlTimer();

        isControlling = false;
    }

    private void StartControlTimer()
    {
        canControl = false;
        Invoke("StopControlTimer", spawnDelay);  
    }

    private void StopControlTimer()
    {
        canControl = true;
    }

    //=========================================
    //SPAWN
    //=========================================
    private void SpawnFruit()
    {
        Vector2 spawnPosition = GetSpawnPosition();

        currentFruit = Instantiate(
            spawnableFruits[nextFruitIndex], 
            spawnPosition, 
            Quaternion.identity, 
            fruitParent);

        SetNextFruitIndex();
    }
    //==========================================
    //SPAWN LINE 
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

    //===========================================
    //MERGE CALLBACK
    //===========================================
    private void MergeProgressCallback(FruitType type, Vector2 position)
    {
        for (int i = 0; i < fruitPrefabs.Length; i++)
        {
            if (fruitPrefabs[i].GetFruitType() == type)
            {
                SpawnMergedFruit(fruitPrefabs[i], position);
                break;
            }
        }
    }

    private void SpawnMergedFruit(Fruit spawnFruit, Vector2 spawnPosition)
    {
        Fruit mergedFruit = Instantiate(spawnFruit, spawnPosition, Quaternion.identity, fruitParent);
        mergedFruit.EnablePhysics();
    }
    //===========================================
    //NEXT FRUIT GET/SET
    //===========================================
    private void SetNextFruitIndex()
    {
        nextFruitIndex = Random.Range(0, spawnableFruits.Length);
    }

    public string GetNextFruitName()
    {
        return spawnableFruits[nextFruitIndex].GetFruitType().ToString();
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
