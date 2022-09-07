using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] public GameObject requestedObject;
        [SerializeField] public Color color = Color.white;
        [SerializeField] private List<Sprite> customerSpriteList = new List<Sprite>();
        
        private void Start()
        {
            Rect rect = GetComponent<RectTransform>().rect;

            GetComponent<BoxCollider2D>().offset = new Vector2(0,rect.height/4);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width, rect.height/2);
            
            GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count)];
        }
    }
}
