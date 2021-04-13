using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TestShop.Models;

namespace TestShop
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerData playerData;
        public static Player current;
        public static Action OnMoneyChanged;
        public static Action<int> OnGumbleChanged;
        public void Awake()
        {
            current = this;
        }
        public int Buy(ref Item item)
        {
            ///вырубаем проверку на количество бабла для тестового задания
            //if (IsEnough(item))
            {
                item.isLocked = false;
                //playerData.money -= item.cost;
                //OnMoneyChanged();
            }
            return playerData.money;
        }
        public void Reward(ref Item item)
        {
            item.isLocked = false;
        }
        public void AddLastItem(Item item)
        {
            playerData.lastItems.Add(item);
        }
        public int Reward(int reward)
        {
            OnMoneyChanged();
            return playerData.money += reward;
        }
        public bool IsEnough(Item item)
        {
            return playerData.money >= item.cost;
        }
        public void ChangeGumble(int diff)
        {
            playerData.gumbleCount += diff;
            OnMoneyChanged();
        }
        public int Money { get { return playerData.money; } }
    }
}
