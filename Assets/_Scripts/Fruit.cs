using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fruit : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SpriteRenderer fruitSprite;

    [Header(" Data ")]
    [SerializeField] private FruitType fruiType;
    private bool hasCollided;
    private bool canBeMerged;

    [Header(" Actions ")]
    public static Action<Fruit, Fruit> onCollisionWithFruit;

    [Header(" Effects ")]
    [SerializeField] private ParticleSystem mergeParticle;
    private void Start()
    {
        Invoke("AllowMerge", 0.25f);
    }

    private void AllowMerge()
    {
        canBeMerged = true;
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
        ManageCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ManageCollision(collision);
    }

    private void ManageCollision(Collision2D collision)
    {
        hasCollided = true;

        if (!canBeMerged)
            return;

        if (collision.collider.TryGetComponent<Fruit>(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruiType)
                return;

            if (!otherFruit.CanBeMerged())
                return;

            onCollisionWithFruit?.Invoke(this, otherFruit);
        }
    }

    public void Merge()
    {
        if (mergeParticle != null)
        {
            mergeParticle.transform.SetParent(null);
            mergeParticle.Play();
        }

        Destroy(gameObject);
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

    public bool CanBeMerged()
    {
        return canBeMerged;
    }
}
