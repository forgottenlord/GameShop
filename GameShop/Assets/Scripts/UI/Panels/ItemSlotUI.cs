using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels
{
    /// <summary>
    /// UI-элемент категорию предметов.
    /// </summary>
    public class ItemSlotUI : UIElement
    {
        [SerializeField]
        private bool AutoStart;
        public UnityEngine.UI.Image imageIsNew;
        public UnityEngine.UI.Image Counter;
        public TwoDimListUI twoDimlist;
        public ItemSlot itemSlot;
        public void Start()
        {
            if (itemSlot == null)
            {
                Debug.Log("error: ItemSlotUI " + gameObject.name);
                return;
            }

            if (AutoStart) twoDimlist.Refresh(itemSlot.items);

            Common.SetActionOnButton(selfButton, () =>
            {
                twoDimlist.Refresh(itemSlot.items);
            });
                /*Common.SetActionOnButton(selfButton, () =>
                {
                    for (int n = 0; n < itemsUIs.Count; n++)
                    {
                        itemsUIs[n].gameObject.SetActive(false);
                    }
                    for (int n = 0; n < items.Count; n++)
                    {
                        itemsUIs[n].gameObject.SetActive(true);
                        int rarity = Random.Range(0,3);
                        itemsUIs[n].SetItem(new Item()
                        {
                            id = n,
                            slotNum = itemType,
                            rarity = rarity,
                            cost = (rarity + 1) * 50,
                            sprite = items[n],
                        });
                    }
                });*/
            }
    }
}
