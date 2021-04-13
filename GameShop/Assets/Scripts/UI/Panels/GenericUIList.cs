using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TestShop;
using TestShop.Models;

namespace TestShop.Panels
{
    public abstract class GenericUIList<T,C> : UIElement
        where T : UIElement
        where C : DataObject, new()
    {
        public T prototype;
        [HideInInspector]
        public C data;
        [HideInInspector] public T selectedElement;
        public List<T> elements = new List<T>();
        //public UnityEngine.UI.Button BackButton;
        public override void Init()
        {
            prototype?.gameObject.SetActive(false);
            //Common.SetActionOnButton(BackButton, ControllUI.PrevPanel);
        }
        public override void Refresh(DataObject data)
        {
        }

        public void Refresh()
        {
        }
        public virtual T AddDefault()
        {
            return Add(prototype, data);
        }
        public T Add(T elementUI, C _obj)
        {
            T newElement = (T)(Instantiate<T>(prototype, prototype.transform.parent) as T);
            newElement.Refresh(_obj);
            newElement.gameObject.SetActive(true);
            //Common.SetActionOnButton(newElement.selfButton, ()=> { SwitchElementsColor(newElement.transform.GetSiblingIndex()); });
            elements.Add(newElement);
            return newElement;
        }
        public T Add<NewC>(T elementUI, NewC _obj) where NewC : DataObject
        {
            T newElement = (T)(Instantiate<T>(prototype, prototype.transform.parent) as T);
            newElement.gameObject.SetActive(true);
            //Common.SetActionOnButton(newElement.selfButton, ()=> { SwitchElementsColor(newElement.transform.GetSiblingIndex()); });
            elements.Add(newElement);
            newElement.Refresh(_obj);
            return newElement;
        }
        public void SwitchElementsColor(int number)
        {
            for (int n = 0; n < elements.Count; n++)
            {
                elements[n].selfImage.color = number-1 == n ?
                    Common.ElementColorAsNotSelected :
                    Common.ElementColorAsSelected;
            }
            selectedElement = elements[number - 1];
        }
        public void Remove(int number)
        {
            elements.RemoveAt(number);
        }
        public void SwitchUp(int number)
        {
            if (number > 1)
            {
                int index = elements[number].transform.GetSiblingIndex();
                elements[number - 1].transform.SetSiblingIndex(index);
                elements[number].transform.SetSiblingIndex(index++);
            }
        }
        public void SwitchDown(int number)
        {
            if (number < elements.Count - 1)
            {
                int index = elements[number].transform.GetSiblingIndex();
                elements[number].transform.SetSiblingIndex(index);
                elements[number + 1].transform.SetSiblingIndex(index--);
            }
        }
    }
}
