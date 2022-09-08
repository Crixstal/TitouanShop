using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Com.IsartDigital.TitouanShop.TitouanShop;
using UnityEngine.Pool;

namespace Com.IsartDigital.TitouanShop
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private List<Sprite> customerSpriteList = new List<Sprite>();
        [SerializeField] public Bubble bubble; 
        
        [HideInInspector] public GameObject requestedObject;
        [HideInInspector] public Color color = Color.white;
        
        private void Start()
        {
            GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count - 1)];

            requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
            color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];

            Rect rect = GetComponent<RectTransform>().rect;

            GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);

            bubble.requestedObject = requestedObject;
            bubble.color = color;
            bubble.CreateBubble();
        }
    }
}
