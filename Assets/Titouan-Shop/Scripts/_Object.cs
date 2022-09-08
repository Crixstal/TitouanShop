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
        private static SpawnerCharacter spawnerCharacter;

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
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
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

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER)
                    {
                        if (numberOfObjectAccepted == 5)
                        {
                            SpawnerCharacter.storyDone = true;
                            GameManager.addItem = true;
                        }

                        Destroy(customerToCheck.GetComponent<SpecialCustomer>().bubble.gameObject);
                    }
                    else
                    {
                        Destroy(customerToCheck.GetComponent<Customer>().bubble.gameObject);
                    }

                    Destroy(customerToCheck);


                    if (numberOfObjectAccepted == 16)
                    {
                        SpawnerCharacter.storyDone = false;
                    }

                    if (numberOfObjectAccepted >= 16 &&
                    SpawnerCharacter.doPhase3 &&
                    ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                    (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                    (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterRaisin();
                    }

                    if (SpawnerCharacter.monsieurLicorne && ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterLicorne();
                    }

                    if (customerToCheck.GetComponent<Image>().sprite.name == "Chara_spe_3_v2")
                    {
                        SpawnerCharacter.storyDone = true;

                    }

                    if (!SpawnerCharacter.monsieurLicorne)
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                    else { 
                        spawnerCharacter = GameObject.Find("Spawner_Character").GetComponent<SpawnerCharacter>();
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                        //SpawnerCharacter.storyDone = true;
                        //SpawnerCharacter.monsieurLicorne = false;

                    }
                }
            }
            else if (gameObject.name.IndexOf("(") > 0)
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name.Substring(0, gameObject.name.IndexOf("(")) && colorToCheck.Equals(actualColor))
                {

                    numberOfObjectAccepted++;

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER)
                    {
                        if (numberOfObjectAccepted == 5)
                        {
                            SpawnerCharacter.storyDone = true;
                            GameManager.addItem = true;
                        }

                        Destroy(customerToCheck.GetComponent<SpecialCustomer>().bubble.gameObject);
                    }
                    else
                    {
                        Destroy(customerToCheck.GetComponent<Customer>().bubble.gameObject);
                    }

                    Destroy(customerToCheck);

                    if (numberOfObjectAccepted == 16)
                    {
                        SpawnerCharacter.storyDone = false;
                    }


                    if (numberOfObjectAccepted >= 16 &&
                    SpawnerCharacter.doPhase3 &&
                    ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                    (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                    (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterRaisin();
                    }

                    if (SpawnerCharacter.monsieurLicorne && ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterLicorne();
                    }

                    if (customerToCheck.GetComponent<Image>().sprite.name == "Chara_spe_3_v2")
                    {
                        SpawnerCharacter.storyDone = true;

                    }


                    if (!SpawnerCharacter.monsieurLicorne)
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                    else
                    {
                        spawnerCharacter = GameObject.Find("Spawner_Character").GetComponent<SpawnerCharacter>();
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                        //SpawnerCharacter.storyDone = true;
                        //SpawnerCharacter.monsieurLicorne = false;

                    }
                }
            }
            else
            {
                if (gameObjectToCheck != null && gameObjectToCheck.name == gameObject.name && colorToCheck.Equals(actualColor))
                {
                    numberOfObjectAccepted++;

                    if (customerToCheck.tag == TAG_SPECIAL_CHARACTER)
                    {
                        if (numberOfObjectAccepted == 5)
                        {
                            SpawnerCharacter.storyDone = true;
                            GameManager.addItem = true;
                        }

                        Destroy(customerToCheck.GetComponent<SpecialCustomer>().bubble.gameObject);
                    }
                    else
                    {
                        Destroy(customerToCheck.GetComponent<Customer>().bubble.gameObject);
                    }

                    Destroy(customerToCheck);


                    if (numberOfObjectAccepted == 16)
                    {
                        SpawnerCharacter.storyDone = false;
                    }

                    if (numberOfObjectAccepted >= 16 &&
                    SpawnerCharacter.doPhase3 &&
                    ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                    (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                    (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterRaisin();
                    }

                    if (SpawnerCharacter.monsieurLicorne && ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                    (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                    (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
                    {
                        spawnerCharacter.addCharacterLicorne();
                    }

                    if (customerToCheck.GetComponent<Image>().sprite.name == "Chara_spe_3_v2")
                    {
                        SpawnerCharacter.storyDone = true;
                    }


                    if (!SpawnerCharacter.monsieurLicorne)
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                    else
                    {
                        spawnerCharacter = GameObject.Find("Spawner_Character").GetComponent<SpawnerCharacter>();
                        spawnerCharacter.ResetTimer(customerToCheck.transform.parent.gameObject);
                        //SpawnerCharacter.storyDone = true;
                        //SpawnerCharacter.monsieurLicorne = false;

                    }
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
                spawnerCharacter = customerToCheck.transform.parent.parent.parent.GetComponent<SpawnerCharacter>();
                gameObjectToCheck = collision.GetComponent<Customer>().requestedObject;
                colorToCheck = collision.GetComponent<Customer>().color;
                exitCustomerCollider = false;
            }

            if (collision.gameObject.tag == TAG_SPECIAL_CHARACTER && exitCustomerCollider)
            {
                customerToCheck = collision.gameObject;
                spawnerCharacter = customerToCheck.transform.parent.parent.parent.GetComponent<SpawnerCharacter>();
                gameObjectToCheck = collision.GetComponent<SpecialCustomer>().requestedObject;
                colorToCheck = collision.GetComponent<SpecialCustomer>().color;
                exitCustomerCollider = false;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == TAG_CHARACTER || collision.gameObject.tag == TAG_SPECIAL_CHARACTER)
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
