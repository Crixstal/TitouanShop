using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop
{
    public class Object : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private GraphicRaycaster m_Raycaster;
        [SerializeField] private EventSystem m_EventSystem;
        [SerializeField] private RectTransform canvasRect;

        private RectTransform rectransform;
        private Vector3 originPosition;
        private int index = 0;

        private void Awake()
        {
            rectransform = GetComponent<RectTransform>();
            originPosition = rectransform.anchoredPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
 
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Instantiate(this, transform.parent).name = gameObject.name;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Destroy(gameObject);
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnPointerUp(PointerEventData eventData)
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
}
