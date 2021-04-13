using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestShop.Models
{
    [CreateAssetMenu(fileName = "Data", menuName = "CreateItemSet", order = 2)]
    public class ItemSlot : ScriptableObject
    {
        /// <summary>
        /// Тип предмета.
        /// </summary>
        public ItemCategory category;
        /// <summary>
        /// Цена покупки в магазине за обычный.
        /// </summary>
        [Range(0, 999)]
        public int commonCost;
        /// <summary>
        /// Цена покупки в магазине за редкий.
        /// </summary>
        [Range(0,999)]
        public int rareCost;
        /// <summary>
        /// Цена покупки в магазине за эпический.
        /// </summary>
        [Range(0, 999)]
        public int epicCost;
        /// <summary>
        /// Цена покупки в магазине за редкий.
        /// </summary>
        [Range(0, 1f)]
        public float rarePercent;
        /// <summary>
        /// Цена покупки в магазине за эпический.
        /// </summary>
        [Range(0, 1f)]
        public float epicPercent;
        /// <summary>
        /// Список всех предметов в данной категории.
        /// </summary>
        public List<Item> items;
        void OnValidate()
        {
            for (int n = 0; n < items.Count; n++)
            {
                items[n].category = category;
                items[n].id = n;
                if (items[n].rarity == ItemRarity.Epic)
                    items[n].cost = epicCost;
                else
                if (items[n].rarity == ItemRarity.Rare)
                    items[n].cost = rareCost;
                else
                    items[n].cost = commonCost;
            }
        }
    }
}