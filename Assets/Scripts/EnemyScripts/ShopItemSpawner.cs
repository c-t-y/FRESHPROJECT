using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour
{
    //public bool allowLoot;


    [System.Serializable]
    public class DropItem
    {
        public string name;
        public GameObject item;
        public int dropRarity;
    }

    public List<DropItem> ShopItemPool = new List<DropItem>();
    public float dropChance;


    private void Start()
    {

        int itemWeight = 0;

        for (int i = 0; i < ShopItemPool.Count; i++)
        {
            itemWeight += ShopItemPool[i].dropRarity;
        }

        int randomValue = Random.Range(0, itemWeight);

        for (int j = 0; j < ShopItemPool.Count; j++)
        {
            if (randomValue <= ShopItemPool[j].dropRarity)
            {
                Instantiate(ShopItemPool[j].item, transform.position, Quaternion.identity);
                return;
            }
            randomValue -= ShopItemPool[j].dropRarity;

        }
    }
}
