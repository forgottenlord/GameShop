using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestShop.Models;
using UnityEngine;

namespace TestShop.Panels
{
    /// <summary>
    /// Одномерный список предметов.
    /// </summary>
    public class LastItemListUI : ItemListUI
    {
        [SerializeField]
        private PlayerData playerData;
        public override void Refresh(DataObject data)
        {
            base.Refresh(data);
        }
        public new void Refresh()
        {
            int e = 0;
            for (int n = playerData.lastItems.Count-1; e<4 && n>0; n--,e++)
            {
                ItemUI item = (ItemUI)elements[e];
                item.SetItem(playerData.lastItems[n]);
            }
        }
    }
}
