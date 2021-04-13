using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels
{
    public abstract class UIElement : Panel
    {
        public TMPro.TextMeshProUGUI numberText;
        public UnityEngine.UI.Button selfButton;
        public UnityEngine.UI.Image selfImage;

        public override void Init()
        {
            if (selfButton == null) selfButton = GetComponent<UnityEngine.UI.Button>();
            if (selfImage == null) selfImage = GetComponent<UnityEngine.UI.Image>();
            if (numberText != null) numberText.text = transform.GetSiblingIndex().ToString();
        }

        public override void Refresh(DataObject data)
        {
            if (numberText != null) numberText.text = (transform.GetSiblingIndex()-1).ToString();
            //Common.SetActionOnButton(DeleteButton, );
        }
    }
}
