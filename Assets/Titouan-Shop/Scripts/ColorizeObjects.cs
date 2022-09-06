using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class ColorizeObjects : MonoBehaviour
    {
        [SerializeField] private GraphicRaycaster m_Raycaster;
        [SerializeField] private EventSystem m_EventSystem;
        [SerializeField] private RectTransform canvasRect;

        private PointerEventData m_PointerEventData;

        private const string TAG_BUCKET = "Bucket";
        private const string TAG_OBJECT = "Object";
        private Color selectedColor = Color.white;

        private void Update()
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the game object
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results.Count > 0 && results[0].gameObject.tag == TAG_BUCKET) {
                selectedColor = results[0].gameObject.GetComponent<Image>().color;
            }
            
            if (results.Count > 0 && results[0].gameObject.tag == TAG_OBJECT)
            {
                results[0].gameObject.GetComponent<Image>().color = selectedColor;
            }
        }
    }
}
