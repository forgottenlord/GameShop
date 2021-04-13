using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TestShop.Models
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "PlayerData", menuName = "CreatePlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        public int money;
        public Character currentCharacter;
        public int gumbleCount;
        public List<Item> lastItems;
    }
}