using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class SpecialCustomer : MonoBehaviour
    {
        [SerializeField] private GameManager gm;
        [SerializeField] private List<Sprite> specialCustSpriteList = new List<Sprite>();
        [SerializeField] public Bubble bubble; 

        [SerializeField] public GameObject requestedObject;
        [SerializeField] public Color color = Color.white;

        private void Start()
        {
            if (_Object.numberOfObjectAccepted == 0)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[0];
                requestedObject = GameManager.allObjectAvailable[0];
                color = GameManager.allColorAvailable[0];
            }
            else if (_Object.numberOfObjectAccepted > 0 && _Object.numberOfObjectAccepted < 3)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[1];
                requestedObject = GameManager.allObjectAvailable[0];
                color = GameManager.allColorAvailable[0];

            }else if (_Object.numberOfObjectAccepted == 4)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[2];
                requestedObject = GameManager.allObjectAvailable[0];
                color = GameManager.allColorAvailable[1];
            }else if (_Object.numberOfObjectAccepted >= 16 && _Object.numberOfObjectAccepted <= 19)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[3];
                requestedObject = GameManager.allObjectAvailable[1];
                color = GameManager.allColorAvailable[0];
            }else if (SpawnerCharacter.monsieurLicorne)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[4];
                requestedObject = GameManager.allObjectAvailable[4];
                color = GameManager.allColorAvailable[0];
            }

            Rect rect = GetComponent<RectTransform>().rect;

            GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);

            bubble.requestedObject = requestedObject;
            bubble.color = color;
            bubble.CreateBubble();
        }

        private void OnDestroy()
        {
            if (GetComponent<Image>().sprite.name == "Chara_spe_4_v1")
            {
                SpawnerCharacter.storyDone = true;
                SpawnerCharacter.monsieurLicorne = false;
            }
        }
    }
}
