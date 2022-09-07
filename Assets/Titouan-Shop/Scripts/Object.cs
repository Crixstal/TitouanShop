using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop
{
    public class Object : MonoBehaviour,  IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        private Canvas canvas;
        private RectTransform rectransform;
        private int index = 0;
        private float counterDelayStart = 0;
        private float doDelayStart = 1f;
        private GameObject gameObjectToCheck;
        private Color32 colorToCheck;
        private bool startToDrag = false;

        private const string TAG_CHARACTER = "Character";

        private void Awake()
        {
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            rectransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            counterDelayStart += Time.deltaTime;

            if (counterDelayStart >= doDelayStart)
            {
                Rect rect = gameObject.GetComponent<RectTransform>().rect;

                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(
                    rect.width,
                    rect.height
                );

                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(rect.width / 2, 0);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Object _gameObject = Instantiate(this, transform.parent);
            _gameObject.name = gameObject.name;
            _gameObject.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex());
            gameObject.transform.SetParent(canvas.gameObject.transform);
            startToDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            startToDrag = false;

            Color32 actualColor = gameObject.GetComponent<Image>().color;

            if (gameObject.name.IndexOf(" ") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf(" ")) && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                }
            }
            else if (gameObject.name.IndexOf("(") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf("(")) && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                }
            }else
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                }
            }

            Destroy(gameObject);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!startToDrag)
            {
                List<Color> allColorAvailable = GameManager.allColorAvailable;

                if (allColorAvailable.Count >= 1)
                {
                    index++;

                    if (index >= allColorAvailable.Count)
                    {
                        index = 0;
                    }

                    gameObject.GetComponent<Image>().color = allColorAvailable[index];
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == TAG_CHARACTER)
            {
                gameObjectToCheck = collision.GetComponent<Customer>().requestedObject;
                colorToCheck = collision.GetComponent<Customer>().color;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            gameObjectToCheck = null;
            colorToCheck = default;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}
