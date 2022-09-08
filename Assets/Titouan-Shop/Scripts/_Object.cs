using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class _Object : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
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
        private const string TAG_SPECIAL_CHARACTER = "SpecialCharacter";

        public static int numberOfObjectAccepted = 0;

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
            _gameObject.transform.GetChild(0).GetComponent<_Object>().index = index;
            gameObject.transform.parent.SetParent(canvas.gameObject.transform);
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
                    numberOfObjectAccepted++;

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER && (numberOfObjectAccepted == 5 || numberOfObjectAccepted == 19))
                    {
                        SpawnerCharacter.storyDone = true;
                        GameManager.addItem = true;
                    }


                    customerToCheck.transform.parent.parent.parent.GetComponent<SpawnerCharacter>().ResetTimer(customerToCheck.transform.parent.gameObject);

                    Destroy(customerToCheck);
                }
            }
            else if (gameObject.name.IndexOf("(") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf("(")) && colorToCheck.Equals(actualColor))
                {
                  

                    numberOfObjectAccepted++;

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER && (numberOfObjectAccepted == 5 || numberOfObjectAccepted == 19))
                    {
                        SpawnerCharacter.storyDone = true;
                        GameManager.addItem = true;
                    }

                    customerToCheck.transform.parent.parent.parent.GetComponent<SpawnerCharacter>().ResetTimer(customerToCheck.transform.parent.gameObject);

                    Destroy(customerToCheck);
                }
            }
            else
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name && colorToCheck.Equals(actualColor))
                {
                    numberOfObjectAccepted++;

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER && (numberOfObjectAccepted == 5 || numberOfObjectAccepted == 19))
                    {
                        SpawnerCharacter.storyDone = true;
                        GameManager.addItem = true;
                    }


                    customerToCheck.transform.parent.parent.parent.GetComponent<SpawnerCharacter>().ResetTimer(customerToCheck.transform.parent.gameObject);

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

                    if (index >= allColorAvailable.Count)
                        index = 0;

                    gameObject.GetComponent<Image>().color = allColorAvailable[index];
                }
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == TAG_CHARACTER && exitCustomerCollider)
            {
                customerToCheck = collision.gameObject;
                gameObjectToCheck = collision.GetComponent<Customer>().requestedObject;
                colorToCheck = collision.GetComponent<Customer>().color;
                exitCustomerCollider = false;
            }

            if (collision.gameObject.tag == TAG_SPECIAL_CHARACTER && exitCustomerCollider)
            {
                customerToCheck = collision.gameObject;
                gameObjectToCheck = collision.GetComponent<SpecialCustomer>().requestedObject;
                colorToCheck = collision.GetComponent<SpecialCustomer>().color;
                exitCustomerCollider = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == TAG_CHARACTER)
            {
                gameObjectToCheck = null;
                colorToCheck = default;
                exitCustomerCollider = true;
            }

            if (collision.gameObject.tag == TAG_SPECIAL_CHARACTER)
            {
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
