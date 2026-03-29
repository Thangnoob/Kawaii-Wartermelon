using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [Header(" Datas ")]
    [SerializeField] private int blastPrice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlastPowerupCallback()
    {
        Fruit[] smallFruits = FruitManager.Instance.GetSmallFruitForBlast();
        
        for (int i = 0;  i < smallFruits.Length; i++)
        {
            smallFruits[i].Merge();
        }
    }
}
