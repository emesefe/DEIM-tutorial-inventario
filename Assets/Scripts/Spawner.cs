using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        ItemWorld.SpawnItemWorld(new Vector3(2, 0, 0), 
                                 new Item {  itemType = Item.ItemType.Sword, 
                                             amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-2, 0, 0), 
                                 new Item {  itemType = Item.ItemType.Shield, 
                                             amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-2, 2, 0), 
                                 new Item {  itemType = Item.ItemType.Shield, 
                                             amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(0, -3, 0), 
                                 new Item {  itemType = Item.ItemType.Coin, 
                                             amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-2, -3, 0), 
                                 new Item {  itemType = Item.ItemType.Coin, 
                                             amount = 10});
    }
}
