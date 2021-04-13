using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TestShop.Models;

namespace TestShop.Panels.Customizer
{
    public class Gumble : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Button button;
        [SerializeField]
        private Transform roll;
        [SerializeField]
        private List<ItemSlot> slots = new List<ItemSlot>();
        [SerializeField]
        private Sprite MoneySprite;
        [SerializeField]
        private Sprite SpineSprite;

        [SerializeField]
        private GameObject rewardGo;
        [SerializeField]
        private UnityEngine.UI.Image rewardImage;
        [SerializeField]
        private LastItemListUI lastItems;
        public void Start()
        {
            rewardGo.SetActive(false);
            Common.SetActionOnButton(button, Roll);
            lastItems.Refresh();
            /*for (int n = 0; n < 360; n += 5)
            {
                GumbleResult(n);
            }*/
        }
        public void Roll()
        {
            int angle = Random.Range(250, 350);
            StartCoroutine(Rotate(angle));
        }
        public IEnumerator Rotate(int angle)
        {
            for (; angle > 0; angle--)
            {
                float stepTime = angle>30? .01f : .01f * 30- angle;
                yield return new WaitForSeconds(stepTime);
                roll.localEulerAngles -= new Vector3(0,0, 2);
            }
            GumbleResult(roll.localEulerAngles.z);
        }
        float percentToGrad = 3.6f;
        float GradToPercent = 0.27777777777f;
        public void GumbleResult(float angle)
        {
            float value = angle > 0 ?
                (angle) * GradToPercent :
                (angle + 90) * GradToPercent;
            if (isBetween(value, 0, 5)) Debug.Log("reward extra gumble"); else
            if (isBetween(value, 5, 20)) Debug.Log("reward Money"); else
            if (isBetween(value, 20, 30)) Debug.Log("reward BackGround"); else
            if (isBetween(value, 30, 45)) Debug.Log("reward Skin"); else

            if (isBetween(value, 45, 50)) Debug.Log("reward Pet"); else
            if (isBetween(value, 50, 80)) Debug.Log("reward Hat"); else
            if (isBetween(value, 80, 85)) Debug.Log("reward Costume"); else
            if (isBetween(value, 85, 100)) Debug.Log("reward Color");

            if (isBetween(value, 0, 5)) 
            {
                StartCoroutine(ShowReward(new Item()
                {
                    sprite = MoneySprite
                }));
                Player.current.ChangeGumble(+3);
            }
            else
            if (isBetween(value, 5, 20))
            {
                StartCoroutine(ShowReward(new Item()
                {
                    sprite = MoneySprite
                }));
                Player.current.Reward(Random.Range(100, 200));
            }
            else
            if (isBetween(value, 20, 30)) RandomRewardFromCategory(ItemCategory.BackGround);
            else
            if (isBetween(value, 30, 45)) RandomRewardFromCategory(ItemCategory.Skin);
            else

            if (isBetween(value, 45, 50)) RandomRewardFromCategory(ItemCategory.Pet);
            else
            if (isBetween(value, 50, 80)) RandomRewardFromCategory(ItemCategory.Hat);
            else
            /*if (isBetween(value, 80, 85)) RandomRewardFromCategory(ItemCategory.Costume);
            else*/
            if (isBetween(value, 85, 100)) RandomRewardFromCategory(ItemCategory.CharacterColor);
        }
        public bool isBetween(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
        float t;
        /*public void Update()
        {
            t += Time.deltaTime;
            if (t > 5)
            {
                t = 0;
                GumbleResult(transform.localEulerAngles.z);
            }
        }*/
        public void RandomRewardFromCategory(ItemCategory category)
        {
            ItemSlot slot = slots.Find(s => s.category == category);
            StartCoroutine(ShowReward(UnlockItemByRarity(GetRewardRarity(slot), slot)));
        }
        private Item UnlockItemByRarity(ItemRarity rar, ItemSlot slot)
        {
            Item item = slot.items.Find(i => i.rarity == ItemRarity.Epic && i.isLocked);
            if (item == null) item = slot.items.Find(i => i.rarity == ItemRarity.Rare && i.isLocked);
            if (item == null) item = slot.items.Find(i => i.rarity == ItemRarity.Common && i.isLocked);
            if (item == null)
            {
                if (rar == ItemRarity.Epic)
                {
                    Player.current.Reward(slot.epicCost);
                    return new Item() { sprite = MoneySprite };
                }
                if (rar == ItemRarity.Rare)
                {
                    Player.current.Reward(slot.rareCost);
                    return new Item() { sprite = MoneySprite };
                }
                if (rar == ItemRarity.Common)
                {
                    Player.current.Reward(slot.commonCost);
                    return new Item() { sprite = MoneySprite };
                }
            }
            Player.current.Reward(ref item);
            Player.current.AddLastItem(item);
            lastItems.Refresh();
            return item;
        }
        private ItemRarity GetRewardRarity(ItemSlot slot)
        {
            float lucky = Random.Range(0f, 1f);
            if (slot.epicPercent > lucky) return ItemRarity.Epic;
            else
            if (slot.epicPercent + slot.rarePercent > lucky) return ItemRarity.Rare;
            else
                return ItemRarity.Common;
        }
        private IEnumerator ShowReward(Item item)
        {
            rewardGo.SetActive(true);
            rewardImage.sprite = item.sprite;
            yield return new WaitForSeconds(3f);
            rewardGo.SetActive(false);
        }
    }
}
