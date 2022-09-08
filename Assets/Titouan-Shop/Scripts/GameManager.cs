using System.Collections;
using System.Collections.Generic;
using Com.IsartDigital.TitouanShop.TitouanShop;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SpawnerCharacter counter;
        
        [SerializeField] private List<Color> allColor = new List<Color>();
        [SerializeField] private List<GameObject> allObject = new List<GameObject>();
        
        public static List<Color> allColorAvailable = new List<Color>();
        public static List<GameObject> allObjectAvailable = new List<GameObject>();

        [SerializeField] public int tutoColor, tutoObject;
        [SerializeField] private int randomTimer;
        [SerializeField] public int indexCrazyObject;

        private bool endgame = false;
        private int indexColor = 0;
        private int indexObject = 0;
        [HideInInspector] public bool newColorDone = false;
        [HideInInspector] public bool newObjectDone = false;
        [HideInInspector] public bool crazyObjDone = false;
        [HideInInspector] public int indexspecialCustomer = 0;
        
        private float timer = 0f;

        private void Start()
        {
            allColorAvailable.Add(allColor[indexColor]);
            allObjectAvailable.Add(allObject[indexObject]);
        }

        private void Update()
        {
            if (counter.customerCounter == tutoColor) // tuto new color
            {
                NewColor();
                newColorDone = true;
            }
                
            else if (counter.customerCounter == tutoObject) // tuto new object    
            {
                NewObject();
                newObjectDone = true;
            }
                
            else if (counter.customerCounter > tutoObject && crazyObjDone == false) // random
            {
                timer += Time.deltaTime;
                if (timer >= randomTimer)
                    RandomAdd();
            }
                
            else if (indexObject == indexCrazyObject) // introduce crazy object    
            {
                NewObject();
                crazyObjDone = true;
            }
            
            else if (crazyObjDone && endgame == false) // random
            {
                timer += Time.deltaTime;
                if (timer >= randomTimer)
                    RandomAdd();            
            }
        }

        private void NewColor()
        {
            allColorAvailable.Add(allColor[++indexColor]);
            ++indexspecialCustomer;
        }
        
        private void NewObject()
        {
            allObjectAvailable.Add(allObject[++indexObject]);
            ++indexspecialCustomer;
        }
        
        private void RandomAdd()
        {
            int randomNb = 0;
            float rand = Random.value;
            
            if (rand >= 0f && rand < 0.25f)
                randomNb = 0;
            else if (rand >= 0.25f && rand < 0.5f)
                randomNb = 1;
            else if (rand >= 0.5f)
                randomNb = 2;
            
            switch (randomNb)
            {
                case 0:
                    if (indexColor < allColorAvailable.Count - 1)
                    {
                        allColorAvailable.Add(allColor[++indexColor]);
                        timer = 0f;
                    }
                    break;
                case 1:
                    if (indexObject < allObjectAvailable.Count - 1)
                    {
                        allObjectAvailable.Add(allObject[++indexObject]);
                        timer = 0f;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
