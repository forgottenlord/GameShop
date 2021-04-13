using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels
{
    public abstract class UIElementEditorPanel : Panel
    {
        private string number;
        public TMPro.TextMeshProUGUI elementName;
        public UnityEngine.UI.Button backButton;
        //public UnityEngine.UI.Button okButton;

        public override void Init()
        {
            Common.SetActionOnButton(backButton, Cancel);
            //Common.SetActionOnButton(okButton, GoEditExcursion);
        }
        public override void Refresh(DataObject data)
        {

        }
        /*public void GoEditExcursion()
        {
            ControllUI.SwitchPanel(1, );
            Hide();
        }*/
        public void Cancel()
        {
            Hide();
        }
    }
}
