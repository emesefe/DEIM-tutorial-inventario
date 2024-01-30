using System;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Sword,
        Shield,
        HealthPotion,
        ManaPotion,
        Coin
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        return itemType switch
        {
            ItemType.Sword => ItemAssets.Instance.swordSprite,
            ItemType.Shield => ItemAssets.Instance.shieldSprite,
            ItemType.HealthPotion => ItemAssets.Instance.healthPotionSprite,
            ItemType.ManaPotion => ItemAssets.Instance.manaPotionSprite,
            ItemType.Coin => ItemAssets.Instance.coinSprite,
            _ => throw new Exception("Non-existent item type")
        };
    }

    public Color GetColor()
    {
        return itemType switch
        {
            ItemType.Sword => Color.black,
            ItemType.Shield => Color.black,
            ItemType.HealthPotion => Color.green,
            ItemType.ManaPotion => Color.blue,
            ItemType.Coin => Color.yellow,
            _ => throw new Exception("Non-existent item type")
        };
    }

    public bool IsStackable()
    {
        return itemType switch
        {
            ItemType.Sword or ItemType.Shield => false,
            ItemType.HealthPotion or ItemType.ManaPotion or ItemType.Coin => true,
            _ => throw new Exception("Non-existent item type")
        };
    }
}
