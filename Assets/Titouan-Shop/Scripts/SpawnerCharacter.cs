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
        [SerializeField] public GameObject specialCustomer;
        [SerializeField] private GameObject bubble;
        [SerializeField] private float spawnTimer = 0f;
        [SerializeField] public Transform pourMonsieurLicorne;

        public static Transform spawnRight;
        public static Transform spawnLeft;
        public static Transform spawnMiddle;
        public static Transform spawnStory;

        public static bool doPhase3 = true;

        private Transform bubbleRight;
        private Transform bubbleMiddle;
        private Transform bubbleLeft;
        
        private List<Transform> spawnList = new List<Transform>();

        public static float counter;
        public static float counter1;
        public static float counter2;

        private bool spawnCustomer = true;
        private bool spawnCustomer1 = true;
        private bool spawnCustomer2 = true;

        static public bool storyDone = false;
        static public bool monsieurLicorne = false;

        private float timer = 0f;
        private float limitTimer;
        private bool setLimitTimer = true;

        public static bool ajoutObject = false;
        public static bool ajoutColor = false;

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
            counter += Time.deltaTime;
            counter1 += Time.deltaTime;
            counter2 += Time.deltaTime;

            if (storyDone)
            {
                float percentage = 0.10f;

                float randomLimitmin = 0f;
                float randomLimitmax = 0f;

                if (SpecialCustomer.afterLicorne)
                {
                    randomLimitmin = 2f;
                    randomLimitmax = 4f;
                }
                else
                {
                    randomLimitmin = 6f;
                    randomLimitmax = 10f;
                }

                if (counter >= spawnTimer && spawnCustomer)
                {
                    timer++;

                    if (!doPhase3)
                    {
                        if (setLimitTimer)
                            limitTimer = Random.Range(randomLimitmin, randomLimitmax);

                        if (timer >= limitTimer)
                        {
                            float random = Random.value;

                            if (gm.indexColor <= gm.allColor.Count - 1)
                            {
                                if (random >= percentage)
                                {
                                    gm.NewObject();

                                    ajoutObject = true;
                                }
                                else if (random < percentage)
                                {
                                    gm.NewColor();
                                    ajoutColor = true;
                                }
                            }
                            else
                            {
                                gm.NewObject();

                                ajoutObject = true;
                            }

                            timer = 0f;
                        }
                    }

                    AddCharacter(spawnLeft, customer);
                    spawnCustomer = false;
                }

                if (counter1 >= spawnTimer && spawnCustomer1)
                {
                    timer++;

                    if (!doPhase3)
                    {
                        if (setLimitTimer)
                            limitTimer = Random.Range(randomLimitmin, randomLimitmax);

                        if (timer >= limitTimer)
                        {
                            float random = Random.value;

                            if (gm.indexColor <= gm.allColor.Count - 1)
                            {
                                if (random >= percentage)
                                {
                                    gm.NewObject();

                                    ajoutObject = true;
                                }
                                else if (random < percentage)
                                {
                                    gm.NewColor();

                                    ajoutColor = true;
                                }
                            }
                            else
                            {
                                gm.NewObject();

                                ajoutObject = true;
                            }

                            timer = 0f;
                        }
                    }
                    AddCharacter(spawnMiddle, customer);
                    spawnCustomer1 = false;
                }

                if (counter2 >= spawnTimer && spawnCustomer2)
                {
                    timer++;

                    if (!doPhase3)
                    {
                        if (setLimitTimer)
                            limitTimer = Random.Range(randomLimitmin, randomLimitmax);

                        if (timer >= limitTimer)
                        {
                            float random = Random.value;

                            if (gm.indexColor <= gm.allColor.Count - 1)
                            {
                                if (random >= percentage)
                                {
                                    gm.NewObject();

                                    ajoutObject = true;
                                }
                                else if (random < percentage)
                                {
                                    gm.NewColor();

                                    ajoutColor = true;
                                }
                            }
                            else
                            {
                                gm.NewObject();

                                ajoutObject = true;
                            }

                            timer = 0f;
                        }
                    }

                    AddCharacter(spawnRight, customer);
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

        public void AddCharacter(Transform spawner, GameObject customer)
        {
            Bubble myBubble = null;

            if (spawner.name == "LeftSpawn")
                myBubble = Instantiate(bubble, bubbleLeft).GetComponent<Bubble>();
            
            else if (spawner.name == "MiddleSpawn" || spawner.name == "StorySpawn" || spawner.name == "PourMonsieurLicorne")
                myBubble = Instantiate(bubble, bubbleMiddle).GetComponent<Bubble>();
            
            else if (spawner.name == "RightSpawn")
                myBubble = Instantiate(bubble, bubbleRight).GetComponent<Bubble>();

            if (customer.name == "Customer")
                Instantiate(customer, spawner).GetComponent<Customer>().bubble = myBubble;
            
            if (customer.name == "SpecialCustomer")
                Instantiate(customer, spawner).GetComponent<SpecialCustomer>().bubble = myBubble;
        }

        private void CheckPhase()
        {
            if (_Object.numberOfObjectAccepted == 0)
                AddCharacter(spawnStory,specialCustomer);

          
        }

        public void addCharacterRaisin()
        {
            gm.AddRaisin();
            AddCharacter(spawnStory, specialCustomer);
            doPhase3 = false;
        }

        public void addCharacterLicorne()
        {
            gm.AddRaisin();
            AddCharacter(pourMonsieurLicorne, specialCustomer);
            doPhase3 = false;
        }
    }
}
