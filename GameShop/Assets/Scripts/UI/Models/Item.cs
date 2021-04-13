using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestShop.Models
{
    [Serializable]
    public class Item : DataObject
    {
        [HideInInspector]
        public int id;
        public ItemRarity rarity;
        [HideInInspector]
        public ItemCategory category;
        public int cost;
        public bool isLocked;
        public UnityEngine.Sprite sprite;
    }
    public enum ItemRarity
    {
        Common = 0,
        Rare = 1,
        Epic = 2,
    }
}