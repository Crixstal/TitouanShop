using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.TitouanShop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public List<Color> allColor = new List<Color>();
        public static List<Color> allColorAvailable = new List<Color>();

        private void Start()
        {
            allColorAvailable.Add(allColor[0]);
            allColorAvailable.Add(allColor[1]);
            allColorAvailable.Add(allColor[2]);
        }
    }
}
