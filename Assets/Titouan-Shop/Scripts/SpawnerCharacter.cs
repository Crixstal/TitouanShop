using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.TitouanShop
{
    public class SpawnerCharacter : MonoBehaviour
    {
        [SerializeField] private GameManager gm;
        [SerializeField] private GameObject customer;
        [SerializeField] private GameObject specialCustomer;
        [SerializeField] private GameObject bubble;
        [SerializeField] private float spawnTimer = 0f;
        
        private Transform spawnRight;
        private Transform spawnLeft;
        private Transform spawnMiddle;
        private Transform spawnStory;
        
        private Transform bubbleRight;
        private Transform bubbleMiddle;
        private Transform bubbleLeft;
        
        private List<Transform> spawnList = new List<Transform>();
        [HideInInspector] public int customerCounter = 0;

        private float counter;
        private float counter1;
        private float counter2;

        private bool spawnCustomer = true;
        private bool spawnCustomer1 = true;
        private bool spawnCustomer2 = true;
        
        static public bool storyDone = false;
        public static bool spawn3Customer = false;
        
        private void Start()
        {
            spawnRight = transform.GetChild(0).transform.Find("RightSpawn");
            spawnLeft = transform.GetChild(0).transform.Find("LeftSpawn");
            spawnMiddle = transform.GetChild(0).transform.Find("MiddleSpawn");
            spawnStory = transform.GetChild(1).transform.Find("StorySpawn");
            
            spawnList.Add(spawnRight);
            spawnList.Add(spawnLeft);
            spawnList.Add(spawnMiddle);

            bubbleRight = transform.GetChild(2).transform.Find("RightBubble");
            bubbleLeft = transform.GetChild(2).transform.Find("LeftBubble");
            bubbleMiddle = transform.GetChild(2).transform.Find("MiddleBubble");
            
            CheckPhase();
        }

        private void Update()
        {
            //le repasser a false quand on a atteint le nombre de customer pour faire spawn un character special (d'abord attendre la validation des trois puis faire spawn le special )
            //if (!storyDone)
            //    CheckPhase();
            
            counter += Time.deltaTime;
            counter1 += Time.deltaTime;
            counter2 += Time.deltaTime;

            if (storyDone)
            {
                //foreach (var spawner in spawnList)
                //    spawner.gameObject.SetActive(true);
                
                if (counter >= spawnTimer && spawnCustomer)
                {
                    AddCharacter(spawnLeft,customer);
                    spawnCustomer = false;
                }

                if (counter1 >= spawnTimer && spawnCustomer1)
                {
                    AddCharacter(spawnMiddle,customer);
                    spawnCustomer1 = false;
                }

                if (counter2 >= spawnTimer && spawnCustomer2)
                {
                    AddCharacter(spawnRight,customer);
                    spawnCustomer2 = false;
                }
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

            CheckPhase();
        }

        private void AddCharacter(Transform spawner, GameObject customer)
        {
            Bubble myBubble = null;

            if (spawner.name == "LeftSpawn")
                myBubble = Instantiate(bubble, bubbleLeft).GetComponent<Bubble>();
            
            else if (spawner.name == "MiddleSpawn" || spawner.name == "StorySpawn")
                myBubble = Instantiate(bubble, bubbleMiddle).GetComponent<Bubble>();
            
            else if (spawner.name == "RightSpawn")
                myBubble = Instantiate(bubble, bubbleRight).GetComponent<Bubble>();
            
            if (customer.name == "Customer")
                Instantiate(customer, spawner).GetComponent<Customer>().bubble = myBubble;
            
            if (customer.name == "SpecialCustomer")
                Instantiate(customer, spawner).GetComponent<SpecialCustomer>().bubble = myBubble;
                
            ++customerCounter;
        }

        private void CheckPhase()
        {
            if (_Object.numberOfObjectAccepted == 0)
            {
                AddCharacter(spawnStory,specialCustomer);

            }
            else if (_Object.numberOfObjectAccepted == 1)
            {
                //spawnLeft.gameObject.SetActive(true);
                //spawnRight.gameObject.SetActive(true);

                AddCharacter(spawnLeft,specialCustomer);
                AddCharacter(spawnRight, specialCustomer);
                AddCharacter(spawnMiddle, specialCustomer);
            }else if (_Object.numberOfObjectAccepted == 4)
            {
                AddCharacter(spawnStory, specialCustomer);
            }else if (_Object.numberOfObjectAccepted == 16)
            {
                AddCharacter(spawnStory, specialCustomer);
            }

            //if (Object.numberOfObjectAccepted == gm.tutoColor )
            //{
            //    Debug.Log("TutoCOuleur");

            //    foreach (var spawner in spawnList)
            //        spawner.gameObject.SetActive(false);
                
            //    if (spawnStory.childCount == 0)
            //        Instantiate(specialCustomer, spawnStory);
            //}
            
            //else if (Object.numberOfObjectAccepted == gm.tutoObject)
            //{
            //    foreach (var spawner in spawnList)
            //        spawner.gameObject.SetActive(false);
                
            //    if (spawnStory.childCount == 0)
            //        Instantiate(specialCustomer, spawnStory);
            //}
            
            //else if (gm.crazyObjDone)
            //{
            //    foreach (var spawner in spawnList)
            //        spawner.gameObject.SetActive(false);
    
            //    if (spawnStory.childCount == 0)
            //        Instantiate(specialCustomer, spawnStory);
            //}

            //else
            //{
            //    foreach (var spawner in spawnList)
            //        spawner.gameObject.SetActive(false);

            //    if (spawnStory.childCount == 0)
            //        Instantiate(specialCustomer, spawnStory);
            //}
        }
    }
}
