using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin Data", menuName = "Scriptable Object/Skin Data", order = 0)]
public class SkinDataSO : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private int price;
    [SerializeField] private Fruit[] objectPrefabs;
    [SerializeField] private Fruit[] spawnablePrefabs;
    public Fruit[] GetObjectPrefabs() { return objectPrefabs; }
    public Fruit[] GetSpawnablePrefabs() { return spawnablePrefabs; }
    public string GetName() { return name; }
    public int GetPrice() { return price; }
}
