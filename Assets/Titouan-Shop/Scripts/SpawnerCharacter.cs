using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private GameObject customer;

        private float customerCounter = 0;
        private Transform spawnRight;
        
        private Transform spawnLeft;
        private Transform spawnMiddle;
        private Transform spawnStory;
        
        private List<Transform> spawnList = new List<Transform>();

        private void Start()
        {
            spawnRight = transform.Find("RightSpawn");
            spawnLeft = transform.Find("LeftSpawn");
            spawnMiddle = transform.Find("MiddleSpawn");
            spawnStory = transform.Find("StorySpawn");
            
            spawnList.Add(spawnRight);
            spawnList.Add(spawnLeft);
            spawnList.Add(spawnMiddle);
        }

        private void Update()
        {
            foreach (var spawner in spawnList)
            {
                if (spawner.childCount == 0)
                    StartCoroutine(WaitCoroutine(spawner));
            }
        }
        
        IEnumerator WaitCoroutine(Transform spawner)
        {
            yield return new WaitForSeconds(1f);

            if (spawner.childCount == 0)
                AddCharacter(spawner);
        }

        private void AddCharacter(Transform spawner)
        {
            Instantiate(customer, spawner);
            ++customerCounter;
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
