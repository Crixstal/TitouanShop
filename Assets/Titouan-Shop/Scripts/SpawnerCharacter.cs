using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allObjects = new List<GameObject>();
        [SerializeField] private GameObject character;

        private List<GameObject> selectObject = new List<GameObject>();
        private float counter;

        private void Start()
        {
        }

        private void Update()
        {
            //if (counter > 3)
            //{
            //    int random = Random.Range(0, color.Count - 1);

            //    allColorAvailable.Add(color[random]);
            //    color.RemoveAt(random);
            //}
        }

        private void addCharacter(GameObject gameObject)
        {

        }
    }
}
