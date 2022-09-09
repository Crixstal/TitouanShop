using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Com.IsartDigital.TitouanShop.TitouanShop;
using UnityEngine.Pool;
using FMOD.Studio;
using FMODUnity;

namespace Com.IsartDigital.TitouanShop
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private List<Sprite> customerSpriteList = new List<Sprite>();
        [SerializeField] public Bubble bubble; 
        [SerializeField] private EventReference angry = default;
        [SerializeField] private float angryTimer = 0f;
        
        [HideInInspector] public GameObject requestedObject;
        [HideInInspector] public Color color = Color.white;
        
        private float timer = 0f;
        
        private void Start()
        {
            if(SpawnerCharacter.doPhase3)
                GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, 8)];
            else if (!SpawnerCharacter.doPhase3 && !SpecialCustomer.afterLicorne)
                GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, 9)];
            else if (SpecialCustomer.afterLicorne)
            {
                Debug.Log("aniamux");
                GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count)];
            }

            if (!SpawnerCharacter.ajoutObject && !SpawnerCharacter.ajoutColor)
            {
                requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
                color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];
            }
            else if (SpawnerCharacter.ajoutColor)
            {
                requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
                color = GameManager.allColorAvailable[GameManager.allColorAvailable.Count-1];

                SpawnerCharacter.ajoutColor = false;

            }
            else if (SpawnerCharacter.ajoutObject)
            {
                requestedObject = GameManager.allObjectAvailable[GameManager.allObjectAvailable.Count - 1];
                color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];

                SpawnerCharacter.ajoutObject = false;
            }

            //Rect rect = GetComponent<RectTransform>().rect;

            //GetComponent<BoxCollider2D>().offset = new Vector2(0, rect.height / 3);
            //gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.width - 100f, rect.height / 2);

            bubble.requestedObject = requestedObject;
            bubble.color = color;
            bubble.CreateBubble();
        }
        
        private void Update()
        {
            timer += Time.deltaTime;

            if (timer >= angryTimer)
            {
                timer = 0f;
                LaunchEventSound(angry);
            }
        }
        
        public void LaunchEventSound(EventReference eventSound)
        {
            EventInstance event_Sound = RuntimeManager.CreateInstance(eventSound);
            event_Sound.start();
            event_Sound.release();
        }
    }
}
