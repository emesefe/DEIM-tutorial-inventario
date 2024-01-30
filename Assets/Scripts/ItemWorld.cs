using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI amountText;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform itemTransform = Instantiate(ItemAssets.Instance.itemWorldPrefab, position, Quaternion.identity);

        ItemWorld itemWorld = itemTransform.GetComponent<ItemWorld>();
        itemWorld.SetUpItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDirection = new Vector3(0, 2);

        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDirection, item);
        return itemWorld;
    }

    public Item GetItem()
    {
        return item;
    }

    private void SetUpItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        spriteRenderer.color = item.GetColor();
        amountText.text = item.amount > 1 ? item.amount.ToString() : "";
    }
}
