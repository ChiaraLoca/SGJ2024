using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField] private Image _shadow;
        [SerializeField] private Image _full;
        internal void Initialize(InventoryItem item)
        {
            Debug.Log("Initialize: " + item.Name +" "+item.IsPresent);

            if (item.IsPresent)
            {
                _full.gameObject.SetActive(true);
                _shadow.gameObject.SetActive(false);
            }
            else 
            {
                _full.gameObject.SetActive(false);
                _shadow.gameObject.SetActive(true);
            }
        }
    }

}
