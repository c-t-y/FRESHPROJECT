using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour
{
    //public bool allowLoot;
    public GameObject shopManager;
    public ShopManager shopManagerScript;

    [System.Serializable]
    public class DropItem
    {
        public string name;
        public GameObject item;
        public int dropRarity;
    }

    public List<DropItem> ShopItemPool = new List<DropItem>();

    private void Start()
    {

        shopManager = GameObject.FindGameObjectWithTag("ShopManager");
        shopManagerScript = shopManager.GetComponent<ShopManager>();
        SpawnItem();
    }
    void SpawnItem()
    {
        int itemWeight = 0;

        for (int i = 0; i < ShopItemPool.Count; i++)
        {
            itemWeight += ShopItemPool[i].dropRarity;
        }

        int randomValue = Random.Range(0, itemWeight);

        for (int i = 0; i < ShopItemPool.Count; i++)
        {
            if (randomValue <= ShopItemPool[i].dropRarity && !shopManagerScript.shopItems.Contains(ShopItemPool[i].item.ToString()))
            {
                Instantiate(ShopItemPool[i].item, transform.position, Quaternion.identity);
                shopManagerScript.shopItems.Add(ShopItemPool[i].item.ToString());
                return;
            }

            randomValue -= ShopItemPool[i].dropRarity;
        }
    }
}

