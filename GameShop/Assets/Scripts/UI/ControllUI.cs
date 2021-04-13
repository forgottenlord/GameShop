using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestShop.Panels;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels
{
    public class ControllUI : MonoBehaviour
    {
        private static ControllUI current;

        private int currentPanelNumber;
        public List<Panel> panels;
        private void Start()
        {
            current = this;
            StartCoroutine(FirstSwitch());
        }
        private IEnumerator FirstSwitch()
        {
            yield return new WaitForEndOfFrame();
            SwitchPanel(0);
        }
        public static void SwitchPanel(int number, DataObject data = null)
        {
            current.currentPanelNumber = number;
            for (int n = 0; n < current.panels.Count; n++)
            {
                current.panels[n].gameObject.SetActive(n == number);
            }
            current.panels[number].Refresh(data);
        }
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchPanel(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchPanel(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchPanel(2);
        }
        /*public static void NextPanel()
        {
            if (current.currentPanelNumber < current.panels.Count)
                SwitchPanel(current.currentPanelNumber++);
        }
        public static void PrevPanel()
        {
            if (current.currentPanelNumber >= 0)
                SwitchPanel(current.currentPanelNumber--);
        }*/
    }
}
