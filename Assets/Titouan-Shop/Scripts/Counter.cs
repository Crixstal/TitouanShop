using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float anchorMAxMedium = 0.55329f;
        [SerializeField] private float anchorMAxBig = 0.38579f;
        [SerializeField] private Sprite spriteCounterMedium;
        [SerializeField] private Sprite spriteCounterBig;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameObject row;

        private GameObject actualRow;
        private float counterAddNewRow = 0f;
        private int index = 0;

        private void Start()
        {
            actualRow = transform.GetChild(0).gameObject;
        }

        private void AugmentationCounterMedium()
        {
            GetComponent<RectTransform>().anchorMax = new Vector2(1, anchorMAxMedium);
            GetComponent<Image>().sprite = spriteCounterMedium;
        }

        private void AugmentationCounterBig()
        {
            GetComponent<RectTransform>().anchorMax = new Vector2(1, anchorMAxBig);
            GetComponent<Image>().sprite = spriteCounterBig;
        }

        [ContextMenu("AddObject")]
        public void AddObject(GameObject _object)
        {
            if (transform.GetChild(index).childCount == 4)
            {
                actualRow = Instantiate(row, transform);

                index++;
                counterAddNewRow++;

                if (counterAddNewRow == 1)
                    AugmentationCounterMedium();

                else if (counterAddNewRow == 2)
                    AugmentationCounterBig();
            }

            if (GameManager.indexObject == 12)
            {
                ResizeObject(new Vector2(160f, 220f));
            }
            else if (GameManager.indexObject == 16)
            {
                ResizeObject(new Vector2(120f, 220f));
            }


            Instantiate(_object, actualRow.transform);
        }

        private void ResizeObject(Vector2 taille)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                for (int j = 0; j < transform.GetChild(i).childCount; j++)
                {
                    transform.GetChild(i).GetChild(j).GetComponent<RectTransform>().sizeDelta = taille;
                }
            }

        }
    }
}
