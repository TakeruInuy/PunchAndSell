using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    
    private Dictionary<string, ShopItem> shopItems;
    [SerializeField] private MeshRenderer _playerMesh;

    [Header("UI")]
    [SerializeField] private RectTransform _shopPanel;
    [SerializeField] private ShopButton _shopButtonTemplate;

    private void Awake()
    {
        shopItems = new Dictionary<string, ShopItem>();
        var itemsToStore = GetComponentsInChildren<ShopItem>();
        if (itemsToStore != null)
        {
            foreach (var item in itemsToStore)
            {
                shopItems.Add(item.itemName, item);
                var button = Instantiate(_shopButtonTemplate, _shopPanel.transform);
                button.itemButtonImage.sprite = item.icon;
                button.itemButtonText.text = item.itemName;
                button.itemButton.onClick.AddListener(() => ButtonClick(item.itemName));
            }
        } else Debug.LogWarning("No shop items found");       
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
        _playerMesh.material = shopItems[item].material;
    }
}
