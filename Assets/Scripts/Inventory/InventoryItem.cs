using GameStatus;
using System;
using Unity;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    public class InventoryItem
    {
        [SerializeField] private string name;
        [SerializeField] private bool isPresent;

       
        public bool IsPresent { get => isPresent; set => isPresent = value; }
        public string Name { get => name; set => name = value; }

        public InventoryItem(string name, bool isPresent)
        {
            this.name = name;
            this.isPresent = isPresent;
        }
    }

}
