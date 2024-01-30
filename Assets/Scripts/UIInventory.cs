using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    private PlayerMovement player;

    [SerializeField] private Transform itemsContainerTransform;

    private void Awake()
    {
        HideAllItems();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnDisable()
    {
        inventory.OnItemListChanged -= Inventory_OnItemListChanged;
    }

    public void SetUpInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged()
    {
        RefreshItems();
    }

    private void HideAllItems()
    {
        foreach(Transform child in itemsContainerTransform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void RefreshItems()
    {
        HideAllItems();

        List<Item> itemsList = inventory.GetItemsList();
        for (int i = 0; i < itemsList.Count; i++)
        {
            Item item = itemsList[i];

            Transform itemSlotTemplate = itemsContainerTransform.GetChild(i);
            itemSlotTemplate.gameObject.SetActive(true);
            
            SetUpItemSlot(item, itemSlotTemplate);
        }
    }

    private void SetUpItemSlot(Item item, Transform itemSlotTemplate)
    {
        Image itemImage = itemSlotTemplate.Find("Item Image").GetComponent<Image>();
        itemImage.sprite = item.GetSprite();
        itemImage.color = item.GetColor();

        TextMeshProUGUI amountText = itemSlotTemplate.Find("Amount Text")
                                                        .GetComponent<TextMeshProUGUI>();
        amountText.text = item.amount > 1 ? item.amount.ToString() : "";

        SetUpItemButtonsAction(item, itemSlotTemplate);
    }

    private void SetUpItemButtonAction(Item item, Transform itemSlotTemplate)
    {
        Button button = itemSlotTemplate.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        
        button.onClick.AddListener(() =>
        {  
            Debug.Log("Click");
            
            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            inventory.RemoveItem(item);
            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        });
    }

    private void SetUpItemButtonsAction(Item item, Transform itemSlotTemplate)
    {
        ClickableObject clickableObject = itemSlotTemplate.GetComponent<ClickableObject>();
        clickableObject.SetUpLeftButtonAction(() => 
        {
            Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            inventory.RemoveItem(item);
            ItemWorld.DropItem(player.GetPosition(), duplicateItem);
        });
        clickableObject.SetUpRightButtonAction(() => Debug.Log("Right"));
    }
}
