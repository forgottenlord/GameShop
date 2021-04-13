using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TestShop.Models;
using TestShop;

namespace TestShop.Panels
{
    public class MoneyCounter : UIElement
    {
        [SerializeField]
        private UnityEngine.UI.Text text;
        public void Start()
        {
            Refresh();
            Player.OnMoneyChanged+=Refresh;
        }
        public void Refresh()
        {
            text.text = Player.current.Money.ToString();
        }
    }
}
