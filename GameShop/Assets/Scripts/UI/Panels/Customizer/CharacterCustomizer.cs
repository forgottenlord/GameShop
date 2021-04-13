using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels.Customizer
{
    public class CharacterCustomizer : MonoBehaviour
    {
        public List<UnityEngine.UI.Image> slots;
        public static CharacterCustomizer current;
        public void Start()
        {
            current = this;
        }
        public void SetPart(ItemCategory category, Item item)
        {
            slots[(int)category].sprite = item.sprite;
        }
    }
}
