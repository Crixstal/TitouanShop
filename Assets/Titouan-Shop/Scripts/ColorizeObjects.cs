using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class ColorizeObjects : MonoBehaviour
    {

        private const string TAG_OBJECT = "Object";
        private static bool doColor = true;

        private void Update()
        {
            ////Set up the new Pointer Event
            //m_PointerEventData = new PointerEventData(m_EventSystem);
            ////Set the Pointer Event Position to that of the game object
            //m_PointerEventData.position = Input.mousePosition;

            ////Create a list of Raycast Results
            //List<RaycastResult> results = new List<RaycastResult>();

            ////Raycast using the Graphics Raycaster and mouse click position
            //m_Raycaster.Raycast(m_PointerEventData, results);


        }
    }
}
