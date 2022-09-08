using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class Bubble : MonoBehaviour
    {
        public GameObject requestedObject;
        public Color color = Color.white;

        void Start()
        {
            Rect rect = GetComponent<RectTransform>().rect;

            // GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width, rect.height);
        }

        public void CreateBubble()
        {
            Instantiate(requestedObject, transform).transform.GetChild(0).GetComponentInChildren<Image>().color = color;
        }
    }
}
