
using GameStatus;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager instance;

        [SerializeField] private List<InventoryItem> _inventoryItems = new List<InventoryItem>();



        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _inventoryItems.Add(new InventoryItem("Stool", false));
            _inventoryItems.Add(new InventoryItem("Remote",false));
            _inventoryItems.Add(new InventoryItem("Lighter",false));

            UpdateUI(_inventoryItems);

        }

        public void UpdateUI(List<InventoryItem> inventoryItems)
        {
            InventoryUI.Instance.UpdateUI(_inventoryItems);
        }

        public void AddItem(string name)
        {
            foreach (InventoryItem item in _inventoryItems)
            {
                if (item.Name.Equals(name))
                    item.IsPresent = true;
            }
            UpdateUI(_inventoryItems);
        }
        
        public void RemoveItem(string name)
        {
            foreach (InventoryItem item in _inventoryItems)
            {
                if (item.Name.Equals(name))
                     item.IsPresent= false;
            }
            UpdateUI(_inventoryItems);
        }

        public bool IsPresent(string name)
        {
            foreach (InventoryItem item in _inventoryItems)
            {
                if (item.Name.Equals(name))
                    return item.IsPresent;
            }
            return false;
        }

    }

}
