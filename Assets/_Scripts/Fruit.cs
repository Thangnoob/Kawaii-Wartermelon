using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header(" Data ")]
    [SerializeField] private FruitType fruiType;

    [Header(" Actions ")]
    public static Action<Fruit, Fruit> onCollisionWithFruit;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void MoveToPosition(Vector2 newPosition)
    {
        this.transform.position = newPosition;
    }

    public void EnablePhysics()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Fruit>(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruiType)
                return;

            onCollisionWithFruit?.Invoke(this, otherFruit);
        }
    }

    public FruitType GetFruitType()
    {
        return this.fruiType;
    }
}
