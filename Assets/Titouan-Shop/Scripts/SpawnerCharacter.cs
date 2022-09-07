using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private List<GameObject> allObjects = new List<GameObject>();
        [SerializeField] private GameObject customer;
        [SerializeField] private Button myButton;

        private Transform spawnRight;
        private Transform spawnLeft;
        private Transform spawnMiddle;
        private Transform spawnFull;
        
        private List<GameObject> selectObject = new List<GameObject>();
        private List<Transform> spawnList = new List<Transform>();

        private float counter = 0;

        private void Start()
        {
            spawnRight = transform.Find("RightSpawn");
            spawnLeft = transform.Find("LeftSpawn");
            spawnMiddle = transform.Find("MiddleSpawn");
            spawnFull = transform.Find("FullSpawn");
            
            //spawnList = Add<>

            ++counter;

            Tuto();
        }

        private void Update()
        {
            myButton.onClick.AddListener(AddCharacter);
        }

        private void AddCharacter()
        {
            if (canInstantiate())
                Instantiate(customer, spawnFull);
        }

        private bool canInstantiate()
        {
            if (transform.childCount > 0)
                return false;
            
            return true;
        }
        
        private void Tuto()
        {
            // right - left / banane
            // middle / banane / color
            // full / banane / all colors
            // middle / new obj
            // full
            // nawak
        }
    }
}
