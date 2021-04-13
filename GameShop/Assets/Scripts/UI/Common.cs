using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
//using TestShop.Panels.CommonPanels;

namespace TestShop
{
    public static class Common
    {
        public static readonly Color ElementColorAsSelected = Color.white;
        public static readonly Color ElementColorAsNotSelected = Color.green;
        public static readonly string IP = "84.201.131.251";
        public static readonly int port = 32413;
        public static string[] Split(string data)
        {
            return data.Split(new string[] { ";" }, StringSplitOptions.None);
        }
        public static string[] SplitNewLine(string data)
        {
            if (data == null) return null;
            return data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
        
        public static void SetActionOnButton(UnityEngine.UI.Button button, Action action)
        {
            button?.onClick.RemoveAllListeners();
            button?.onClick.AddListener(() => { action(); });
        }
        public static void SetActionOnInputField(UnityEngine.UI.InputField field, Action<string> action)
        {
            field?.onValueChanged.RemoveAllListeners();
            field?.onValueChanged.AddListener((value) => { action(value); });
        }
        /*public static void SetActionOnStringEditorUI(StringEditorUI field, Action<string> action)
        {
            field?.inputField.onValueChanged.RemoveAllListeners();
            field?.inputField.onValueChanged.AddListener((value) => { action(value); });
        }
        public static void SetActionOnStringEditorUI_Lock(StringEditorUI field, Action<bool> action)
        {
            field.OnLockStatusChange += (value) => { action(value); };
        }*/
        public static void SetActionOnDropDownSelect(UnityEngine.UI.Dropdown dropDown, Action<int> action)
        {
            dropDown?.onValueChanged.RemoveAllListeners();
            dropDown?.onValueChanged.AddListener((value) => { action(value); });
        }


        private static readonly Color ButtonUnBlockedColor = new Color(0.11f, 0.55f, 0.371f);
        private static readonly Color ButtonBlockedColor = new Color(0.75f, 0.785f, 0.847f);
        public static void SetBlockStatusToButton(UnityEngine.UI.Button button, bool block)
        {
            if (button != null)
            {
                var image = button.GetComponent<UnityEngine.UI.Image>();
                button.enabled = !block;
                Color c = image.color;
                image.color = block ? ButtonBlockedColor : ButtonUnBlockedColor;

                Transform imageT = button.transform.Find("Image");
                if (imageT != null)
                {
                    var childImage = imageT.GetComponent<UnityEngine.UI.Image>();
                    c = childImage.color;
                    childImage.color =
                        block ?
                        new Color(c.r, c.g, c.b, 0.5f) :
                        new Color(c.r, c.g, c.b, 1f);
                }
            }
        }
    }
}
