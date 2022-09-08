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
        public static List<Color> allColorAvailable = new List<Color>();
        
        [SerializeField] private List<GameObject> allObject = new List<GameObject>();
        public static List<GameObject> allObjectAvailable = new List<GameObject>();

        [SerializeField] public int tutoColor, tutoObject, endgame;
        [SerializeField] private int randomTimer;
        [SerializeField] private int indexCrazyObject;

        private int indexColor = 0;
        private int indexObject = 0;
        [HideInInspector] public bool crazyObjDone = false;
        
        private void Start()
        {
            allColorAvailable.Add(allColor[indexColor]);
            allObjectAvailable.Add(allObject[indexObject]);
        }

        private void Update()
        {
            if (counter.customerCounter == tutoColor) // tuto new color
                NewColor();
                
            else if (counter.customerCounter == tutoObject) // tuto new object    
                NewObject();
                
            else if (counter.customerCounter > tutoObject && crazyObjDone == false) // random
                StartCoroutine(WaitCoroutine());
                
            else if (indexObject == indexCrazyObject) // introduce crazy object    
            {
                NewObject();
                crazyObjDone = true;
            }
            
            else if (crazyObjDone && counter.customerCounter < endgame) // random
                StartCoroutine(WaitCoroutine());
                
            else if (counter.customerCounter >= endgame) // end game
                allObjectAvailable.Add(allObject[++indexObject]);
        }
        
        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(randomTimer);
            RandomAdd();
        }
        
        private void NewColor()
        {
            allColorAvailable.Add(allColor[++indexColor]);
        }
        
        private void NewObject()
        {
            allObjectAvailable.Add(allObject[++indexObject]);
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
                    allColorAvailable.Add(allColor[++indexColor]);
                    break;
                case 1:
                    allObjectAvailable.Add(allObject[++indexObject]);
                    break;
                default:
                    break;
            }
        }
    }
}
