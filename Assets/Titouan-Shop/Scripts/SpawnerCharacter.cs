using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allObjects = new List<GameObject>();
        [SerializeField] private float nbCharacter = 3;
        
        private List<GameObject> listObjectRequested = new List<GameObject>();

        void Start()
        {
            if (allObjects.Count > 0)
            {
                for (int i = 0; i < nbCharacter; i++)
                {
                    listObjectRequested.Add(allObjects[Random.Range(0, allObjects.Count - 1)]);
                }
            }
        }

        private void addCharacter(GameObject gameObject)
        {

        }
    }
}
