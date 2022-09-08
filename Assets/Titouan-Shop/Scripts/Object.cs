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
        public int index = 0;
        private float counterDelayStart = 0;
        private float doDelayStart = 1f;
        private GameObject gameObjectToCheck;
        private Color32 colorToCheck;
        private bool startToDrag = false;
        private GameObject customerToCheck;
        private bool exitCustomerCollider = true;

        private const string TAG_CHARACTER = "Character";

        private void Awake()
        {
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            rectransform = transform.parent.GetComponent<RectTransform>();
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

                //gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(rect.width / 2, 0);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //GameObject __gameObject = Instantiate(transform.parent.gameObject,transform.parent);
            GameObject _gameObject = Instantiate(gameObject.transform.parent.gameObject, gameObject.transform);
            _gameObject.transform.GetChild(0).gameObject.name = gameObject.name;
            _gameObject.transform.SetParent(gameObject.transform.parent.parent);
            _gameObject.transform.SetSiblingIndex(gameObject.transform.parent.GetSiblingIndex());
            rectransform.localScale = Vector3.one;
            _gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
            _gameObject.transform.GetChild(0).GetComponent<Object>().index = index;
            gameObject.transform.parent.SetParent(canvas.gameObject.transform);
            startToDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            startToDrag = false;

            Color32 actualColor = gameObject.GetComponent<Image>().color;

            Debug.Log(gameObjectToCheck);

            if (gameObject.name.IndexOf(" ") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf(" ")) && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                    Destroy(customerToCheck);
                }
            }
            else if (gameObject.name.IndexOf("(") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf("(")) && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                    Destroy(customerToCheck);
                }
            }
            else
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name && colorToCheck.Equals(actualColor))
                {
                    Debug.Log("Same Object");
                    Destroy(customerToCheck);
                }
            }

            Destroy(gameObject.transform.parent.gameObject);
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

                    Debug.Log(index);

                    if (index >= allColorAvailable.Count)
                    {
                        index = 0;
                    }

                    gameObject.GetComponent<Image>().color = allColorAvailable[index];
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Debug.Log("1 " + collision.gameObject.transform.parent.name);

            if (collision.gameObject.tag == TAG_CHARACTER && exitCustomerCollider)
            {
                customerToCheck = collision.gameObject;
                gameObjectToCheck = collision.GetComponent<Customer>().requestedObject;
                colorToCheck = collision.GetComponent<Customer>().color;
                exitCustomerCollider = false;
                Debug.Log( " 2 " +customerToCheck.transform.parent.name);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == TAG_CHARACTER)
            {
                Debug.Log("ExitColision " + collision.gameObject.transform.parent.name);
                gameObjectToCheck = null;
                colorToCheck = default;
                exitCustomerCollider = true;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}
