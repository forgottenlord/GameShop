using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TestShop.Models;
using TestShop.Panels.Customizer;

namespace TestShop.Panels
{
    public class ItemUI : UIElement
    {
        public static Color isLockedColor = new Color(.3f, .3f, .3f, .2f);
        public static Color isUnLockedColor = new Color(.8f, .8f, .8f, 1f);
        public UnityEngine.UI.Image imageIsNew;
        public UnityEngine.UI.Image imageCost;
        public UnityEngine.UI.Image itemImage;
        public UnityEngine.UI.Text Cost;
        private Item item;
        public void SetItem(Item _item)
        {
            item = _item;
            Refresh();
            Common.SetActionOnButton(selfButton, () =>
            {
                if (item.isLocked)
                {
                    Player.current.Buy(ref item);

                    Refresh();
                }
                else
                {
                    //CharacterCustomizer.current.SetPart(item.category, item);
                }
            });
        }
        public void Refresh()
        {
            if (item == null)
            {
                gameObject.SetActive(false);
                return;
            }
            imageCost?.gameObject.SetActive(item.isLocked);
            itemImage.sprite = item.sprite;
            itemImage.color = item.isLocked ? isLockedColor : new Color(1, 1, 1, 1);
            selfImage.color = item.isLocked ? isLockedColor : new Color(1, 1, 1, 1);
            if (Cost!=null) Cost.text = item.cost.ToString();
        }
    }
}
