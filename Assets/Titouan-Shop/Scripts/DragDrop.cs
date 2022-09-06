using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler
    {
        [SerializeField] private Canvas canvas;

        private RectTransform rectransform;
        private Vector3 originPosition;

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
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            rectransform.anchoredPosition = originPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
