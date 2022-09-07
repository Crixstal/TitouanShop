using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float anchorMAxMedium = 0.55329f;
        [SerializeField] private float anchorMAxBig = 0.38579f;
        [SerializeField] private Sprite spriteCounterMedium;
        [SerializeField] private Sprite spriteCounterBig;

        [ContextMenu("IncreaseCounterMedium")]
        private void AugmentationCounterMedium()
        {
            GetComponent<RectTransform>().anchorMax = new Vector2(1, anchorMAxMedium);
            GetComponent<Image>().sprite = spriteCounterMedium;
        }


        [ContextMenu("IncreaseCounterBig")]
        private void AugmentationCounterBig()
        {
            GetComponent<RectTransform>().anchorMax = new Vector2(1, anchorMAxBig);
            GetComponent<Image>().sprite = spriteCounterBig;
        }
    }
}
