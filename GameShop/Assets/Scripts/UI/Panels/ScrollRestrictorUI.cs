using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TestShop.Panels
{
    public class ScrollRestrictorUI : MonoBehaviour
    {
        public float heightFactor = 0;
        public void Start()
        {
            ScrollRect scroll = gameObject.GetComponent<ScrollRect>();
            if (scroll != null) scroll.movementType = ScrollRect.MovementType.Unrestricted;
        }
        void Update()
        {
            if (transform.hasChanged)
            {
                float elementsTotalHeight = 0;// ((RectTransform)transform.GetChild(transform.childCount-1)).localPosition.y;
                float screenHeight = ((RectTransform)transform).sizeDelta.y;
                
                for (int n=0; n<transform.childCount;n++)
                {
                    RectTransform childTR = (RectTransform)transform.GetChild(n);
                    elementsTotalHeight += childTR.sizeDelta.y;
                }
                if (elementsTotalHeight > screenHeight)
                {
                    transform.localPosition =
                        new Vector3(transform.localPosition.x,
                        Mathf.Clamp(transform.localPosition.y, 0, elementsTotalHeight - screenHeight + heightFactor),
                        transform.localPosition.z);
                }
                else
                {
                    transform.localPosition =
                        new Vector3(transform.localPosition.x,
                        0,
                        transform.localPosition.z);
                }
            }
        }
    }
}
