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
            Rect rect = gameObject.GetComponent<RectTransform>().rect;

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width, rect.height);
            
            GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count)];
        }
    }
}
