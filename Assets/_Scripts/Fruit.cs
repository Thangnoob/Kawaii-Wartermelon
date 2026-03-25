using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SpriteRenderer fruitSprite;

    [Header(" Data ")]
    [SerializeField] private FruitType fruiType;
    private bool hasCollided;

    [Header(" Actions ")]
    public static Action<Fruit, Fruit> onCollisionWithFruit;

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
        hasCollided = true;

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

    public Sprite GetFruitSprite()
    {
        return fruitSprite.sprite;
    }

    public bool HasCollided()
    {
        return hasCollided;
    }
}
