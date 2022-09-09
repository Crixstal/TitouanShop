using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
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

        public Animator animator;

        [HideInInspector] public GameObject requestedObject;
        [HideInInspector] public Color color = Color.white;

        public SpawnerCharacter spwanerCharacter;

        private float timer = 0f;

        private void Start()
        {
            animator = GetComponent<Animator>();

            if (SpawnerCharacter.doPhase3)
            {

                float random = Random.value;

                if (random >= 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, 4)];
                }
                else if (random < 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(4, 8)];
                }
            }
            else if (!SpawnerCharacter.doPhase3 && !SpecialCustomer.afterLicorne)
            {
                float random = Random.value;

                if (random >= 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, 4)];
                }
                else if (random < 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(4, 9)];
                }
            }
            else if (SpecialCustomer.afterLicorne)
            {
                GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count)];
                float random = Random.value;

                if (random >= 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(0, customerSpriteList.Count / 2)];
                }
                else if (random < 0.5f)
                {
                    GetComponent<Image>().sprite = customerSpriteList[Random.Range(customerSpriteList.Count / 2, customerSpriteList.Count)];
                }

            }
        

            if (!SpawnerCharacter.ajoutObject && !SpawnerCharacter.ajoutColor)
            {
                requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
                color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];
            }
            else if (SpawnerCharacter.ajoutColor)
            {
                requestedObject = GameManager.allObjectAvailable[Random.Range(0, GameManager.allObjectAvailable.Count)];
                color = GameManager.allColorAvailable[GameManager.allColorAvailable.Count - 1];

                SpawnerCharacter.ajoutColor = false;

            }
            else if (SpawnerCharacter.ajoutObject)
            {
                requestedObject = GameManager.allObjectAvailable[GameManager.allObjectAvailable.Count - 1];
                color = GameManager.allColorAvailable[Random.Range(0, GameManager.allColorAvailable.Count)];

                SpawnerCharacter.ajoutObject = false;
            }

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
                animator.SetBool("angry", true);
            }
        }

        public void LaunchEventSound(EventReference eventSound)
        {
            EventInstance event_Sound = RuntimeManager.CreateInstance(eventSound);
            event_Sound.start();
            event_Sound.release();
        }

        public void DoDestroy()
        {
            animator.SetBool("happy", true);
        }

        public void StartAnimDespawn()
        {
            animator.SetBool("despawn", true);
        }

        public void _Destroy()
        {
            if (_Object.numberOfObjectAccepted >= 16 &&
                     SpawnerCharacter.doPhase3 &&
                     ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                     (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                     (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
            {
                _Object.spawnerCharacter.addCharacterRaisin();
                GameManager.music.setParameterByName("MusicPhases", 1);
            }

            if (SpawnerCharacter.monsieurLicorne && ((SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 1) ||
                       (SpawnerCharacter.spawnLeft.childCount == 1 && SpawnerCharacter.spawnMiddle.childCount == 0 && SpawnerCharacter.spawnRight.childCount == 0) ||
                       (SpawnerCharacter.spawnLeft.childCount == 0 && SpawnerCharacter.spawnMiddle.childCount == 1 && SpawnerCharacter.spawnRight.childCount == 0)))
            {
                _Object.spawnerCharacter.addCharacterLicorne();
                GameManager.music.setParameterByName("MusicPhases", 2);
            }

            Destroy(gameObject);
        }
    }
}
