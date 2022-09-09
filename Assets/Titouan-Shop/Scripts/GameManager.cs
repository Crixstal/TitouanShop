using System.Collections;
using System.Collections.Generic;
using Com.IsartDigital.TitouanShop.TitouanShop;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public Counter counter;
        
        [SerializeField] public List<Color> allColor = new List<Color>();
        [SerializeField] public List<GameObject> allObject = new List<GameObject>();
        [SerializeField] public Counter _counter;

        public static List<Color> allColorAvailable = new List<Color>();
        public static List<GameObject> allObjectAvailable = new List<GameObject>();

        [SerializeField] public int tutoColor, tutoObject;

        public int indexColor = 0;
        public int indexObject = 0;
        [HideInInspector] public bool newColorDone = false;
        [HideInInspector] public bool newObjectDone = false;
        [HideInInspector] public int indexspecialCustomer = 0;

        public static bool addItem = false;
        
        static public EventInstance music;
        [SerializeField] private GameObject canvas;
        private float timer = 0f;
        
        private void Start()
        {
            allColorAvailable.Add(allColor[indexColor]);
            allObjectAvailable.Add(allObject[indexObject]);
            _counter.AddObject(allObject[indexObject]);
            
            music = RuntimeManager.CreateInstance("event:/Music/Music 2");
            music.start();
            music.setParameterByName("MusicPhases", 0);        
        }

        private void Update()
        {
            if (Com.IsartDigital.TitouanShop._Object.numberOfObjectAccepted == tutoColor && !newColorDone) // tuto new color
            {
                NewColor();
                newColorDone = true;
                addItem = false;
            }
                
            else if (Com.IsartDigital.TitouanShop._Object.numberOfObjectAccepted == tutoObject && !newObjectDone) // tuto new object    
            {
                newObjectDone = true;
                addItem = false;
            }

            if (_counter.transform.GetChild(0).childCount > 23)
            {
                timer += Time.deltaTime;
                music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                EndGame();
            }
        }

        public void AddRaisin()
        {
            NewObject();
        }

        public void NewColor()
        {
            allColorAvailable.Add(allColor[++indexColor]);
        }
        
        public void NewObject()
        {
            allObjectAvailable.Add(allObject[++indexObject]);
            ++indexspecialCustomer;
            //addSur l'etagere
            counter.AddObject(allObject[indexObject]);

            if (indexspecialCustomer == 3)
            {
                SpawnerCharacter.storyDone = false;
                SpawnerCharacter.monsieurLicorne = true;
            }
        }

        private void EndGame()
        {
            canvas.transform.GetChild(1).gameObject.SetActive(false);
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            canvas.transform.GetChild(3).gameObject.SetActive(false);

            if (timer >= 2f)
            {
                canvas.transform.GetChild(6).gameObject.SetActive(true);
                canvas.transform.GetChild(0).gameObject.SetActive(false);
            }
            if (timer >= 4f)
                canvas.transform.GetChild(7).gameObject.SetActive(true);
        }
    }
}
