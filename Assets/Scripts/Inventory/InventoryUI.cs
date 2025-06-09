
using GameStatus;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace Inventory
{

    public class InventoryUI : MonoBehaviour
    {
        public static InventoryUI Instance;
        [SerializeField] private List<InventoryItemUI> _inventoryItemsUI = new List<InventoryItemUI>();

        [SerializeField] private Transform _itemParent;
        private void Awake()
        {
            Instance = this;
        }


        public void UpdateUI(List<InventoryItem> items)
        {
           
            int index = 0;
            foreach (InventoryItem item in items)
            {
                _inventoryItemsUI[index].Initialize(item);
                index++;

            }
        }



    }

}
