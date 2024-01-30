using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string ITEM_TAG = "Item";

    private Inventory inventory;

    [SerializeField] private UIInventory uiInventory;

    private void Awake()
    {
        inventory = new Inventory();
    }

    private void Start()
    {
        uiInventory.SetUpInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ITEM_TAG))
        {
            ItemWorld itemWorld = other.gameObject.GetComponent<ItemWorld>();
            inventory.AddItem(itemWorld.GetItem());
            Destroy(other.gameObject);
        }
    }
}
