using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using TestShop.Network;
using TMPro;
using TestShop.Models;

namespace TestShop.Panels
{
    public class MainPanel : GenericUIList<ItemUI, Character>
    {
        public UnityEngine.UI.Button ToGumbleButton;
        //public ExcursionEditorPanel Editor;
        public async override void Init()
        {
            base.Init();
            //Common.SetActionOnButton(BackButton, ControllUI.PrevPanel);
            Common.SetActionOnButton(ToGumbleButton, ()=>
            {
                ControllUI.SwitchPanel(1, null);// FtpIO.excursionList.excursions.Count-1);
            });
            /*Common.SetActionOnButton(SaveButton, () =>
            {
            });*/

            //Refresh(Common.Split(await Network.NetClient.GetTextFile("http://84.201.131.251/Patriot_DigitalDemocenter/ExcursionCatalog/ExcursionsB.txt")));
            //Network.NetClient.SendFile("");
            //Network.NetClient.ftpUpload(@"F:\test.txt", "http://84.201.131.251/Patriot_DigitalDemocenter/ExcursionCatalog/test.txt");
            //Network.NetClient.SendFTP(@"F:\test.txt", "http://84.201.131.251/Patriot_DigitalDemocenter/ExcursionCatalog/test.txt");
            //StartCoroutine(Panel.Upload(@"F:\test.txt", "http://84.201.131.251/Patriot_DigitalDemocenter/ExcursionCatalog/test.txt"));
        }
        public override ItemUI AddDefault()
        {
            return base.AddDefault();
        }
        public override void Refresh(DataObject data)
        {
            for (int n = 0; n < elements.Count; n++)
            {
                if (elements[n]!= null)
                Destroy(elements[n]?.gameObject);
            }
            elements.Clear();
            /*for (int n = 0; n < ; n++)
            {
                Add(prototype, );
            }*/
        }
    }
}