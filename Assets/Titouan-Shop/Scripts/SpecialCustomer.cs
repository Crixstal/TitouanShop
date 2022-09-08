using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpecialCustomer : MonoBehaviour
    {
        [SerializeField] private List<Sprite> customerSpriteList = new List<Sprite>();
        
        [HideInInspector] public GameObject requestedObject;
        [HideInInspector] public Color color = Color.white;
        
        private void Start()
        {
            Rect rect = GetComponent<RectTransform>().rect;

            GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);

            GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count)];

            requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
            color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];
        }
    }
}
