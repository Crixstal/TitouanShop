using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop.TitouanShop {
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private GameManager gm;
        [SerializeField] private GameObject customer;
        [SerializeField] private GameObject specialCustomer;
        [SerializeField] private float spawnTimer = 0f;
        
        private Transform spawnRight;
        private Transform spawnLeft;
        private Transform spawnMiddle;
        private Transform spawnStory;
        
        private List<Transform> spawnList = new List<Transform>();
        [HideInInspector] public int customerCounter = 0;

        private float counter;
        private float counter1;
        private float counter2;


        private bool spawnCustomer = true;
        private bool spawnCustomer1 = true;
        private bool spawnCustomer2 = true;

        private void Start()
        {
            spawnRight = transform.GetChild(0).transform.Find("RightSpawn");
            spawnLeft = transform.GetChild(0).transform.Find("LeftSpawn");
            spawnMiddle = transform.GetChild(0).transform.Find("MiddleSpawn");
            spawnStory = transform.Find("StorySpawn");
            
            spawnList.Add(spawnRight);
            spawnList.Add(spawnLeft);
            spawnList.Add(spawnMiddle);
        }

        private void Update()
        {
            CheckPhase();

            counter += Time.deltaTime;
            counter1 += Time.deltaTime;
            counter2 += Time.deltaTime;
            
            //foreach (var spawner in spawnList)
            //{
            //    if (spawner.childCount == 0)
            //    {
            //        AddCharacter(spawner);
            //    }
            //}

            if (counter >= spawnTimer && spawnCustomer)
            {
                AddCharacter(spawnLeft);
                spawnCustomer = false;
            }

            if (counter1 >= spawnTimer && spawnCustomer1)
            {
                AddCharacter(spawnMiddle);
                spawnCustomer1 = false;
            }

            if (counter2 >= spawnTimer && spawnCustomer2)
            {
                AddCharacter(spawnRight);
                spawnCustomer2 = false;
            }
        }

        public void ResetTimer(GameObject spawner)
        {

            if (spawner.name == spawnLeft.name)
            {
                counter = 0f;
                spawnCustomer = true;
            }
            else if (spawner.name == spawnMiddle.name)
            {
                counter1 = 0f;
                spawnCustomer1 = true;
            }
            else if (spawner.name == spawnRight.name)
            {
                counter2 = 0f;
                spawnCustomer2 = true;
            }
        }
        
        //IEnumerator WaitCoroutine(Transform spawner)
        //{
        //    yield return new WaitForSeconds(spawnTimer);

        //    if (spawner.childCount == 0)
        //        AddCharacter(spawner);
        //}

        private void AddCharacter(Transform spawner)
        {
            Instantiate(customer, spawner);
            ++customerCounter;
        }

        private void CheckPhase()
        {
            if (customerCounter == gm.tutoColor)
            {
                foreach (var spawner in spawnList)
                    spawner.gameObject.SetActive(false);
                
                Instantiate(specialCustomer, spawnStory);
            }
            
            else if (customerCounter == gm.tutoObject)
            {
                //foreach (var spawner in spawnList)
                //    spawner.gameObject.SetActive(false);
            }
            
            else if (gm.crazyObjDone)
            {
                //foreach (var spawner in spawnList)
                //    spawner.gameObject.SetActive(false);
            }
            
            else if (customerCounter >= gm.endgame)
            {
                //foreach (var spawner in spawnList)
                //    spawner.gameObject.SetActive(false);
            }
        }
    }
}
