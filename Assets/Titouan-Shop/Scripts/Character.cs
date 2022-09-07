using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class Character : MonoBehaviour
    {
        [SerializeField] public GameObject requestedObject;
        public Color color = Color.white;

        private float counter;
        private float timeLimit;

        private void Start()
        {
            Rect rect = gameObject.GetComponent<RectTransform>().rect;

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(
                rect.width,
                rect.height
            );
        }
    }
}
