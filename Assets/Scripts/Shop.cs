using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    private Dictionary<string, ShopItem> shopItems;
    [SerializeField] private MeshRenderer playerMesh;

    private void Awake()
    {
        shopItems = new Dictionary<string, ShopItem>();
        var itemsToStore = GetComponentsInChildren<ShopItem>();
        if (itemsToStore != null)
        {
            foreach (var item in itemsToStore)
            {
                shopItems.Add(item.itemName, item);
                Debug.Log(item.itemName + " added");
            }
        } else Debug.Log("No items found");
       
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick(string item)
    {
        if(shopItems.ContainsKey(item))
        {
            if (!shopItems[item].isUnlocked)
            {
                UnlockItem(item);
            }
            else
            {
                EquipItem(item);
            }            
        }    
    }

    private void UnlockItem(string item)
    {
        if(ResourceManager.Instance.resource >= shopItems[item].price)
        {
            shopItems[item].isUnlocked = true;
            ResourceManager.Instance.RemoveResource(shopItems[item].price);
        }
        
    }

    private void EquipItem(string item)
    {
        playerMesh.material = shopItems[item].material;
    }
}
