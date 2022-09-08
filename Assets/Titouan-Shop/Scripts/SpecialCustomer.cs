using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpecialCustomer : MonoBehaviour
    {
        [SerializeField] private GameManager gm;
        [SerializeField] private List<Sprite> specialCustSpriteList = new List<Sprite>();
        
        public GameObject requestedObject;
        public Color color = Color.white;

        private void Start()
        {
            Debug.Log(_Object.numberOfObjectAccepted);

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
            }else if (_Object.numberOfObjectAccepted == 16)
            {
                GetComponent<Image>().sprite = specialCustSpriteList[3];
                requestedObject = GameManager.allObjectAvailable[1];
                color = GameManager.allColorAvailable[0];
            }

            Rect rect = GetComponent<RectTransform>().rect;

            GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);

            //if (gm.newColorDone)
            //{        
            //    GetComponent<Image>().sprite = specialCustSpriteList[gm.indexspecialCustomer];
            //    requestedObject = GameManager.allObjectAvailable[0];
            //    color = GameManager.allColorAvailable[1];
            //}
            //else if (gm.newObjectDone)
            //{        
            //    GetComponent<Image>().sprite = specialCustSpriteList[gm.indexspecialCustomer];
            //    requestedObject = GameManager.allObjectAvailable[1];
            //    color = GameManager.allColorAvailable[0];
            //}            
            //else if (gm.crazyObjDone)
            //{    
            //    GetComponent<Image>().sprite = specialCustSpriteList[gm.indexspecialCustomer];
            //    requestedObject = GameManager.allObjectAvailable[gm.indexCrazyObject];
            //    color = GameManager.allColorAvailable[0];
            //}
            //else
            //{
            //    GetComponent<Image>().sprite = specialCustSpriteList[gm.indexspecialCustomer];
            //    requestedObject = GameManager.allObjectAvailable[0];
            //    color = GameManager.allColorAvailable[0];
            //}
        }
    }
}
