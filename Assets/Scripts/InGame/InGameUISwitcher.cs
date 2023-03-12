using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class InGameUISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject remainingTimeUI;

        [SerializeField] private GameObject ItemUI;

        [SerializeField] private GameObject timeUPUI;
        
        // Start is called before the first frame update
        void Start()
        {
            remainingTimeUI.SetActive(false);
            ItemUI.SetActive(false);
            timeUPUI.SetActive(false);
        }

        public void ActivateInGameUI()
        {
            remainingTimeUI.SetActive(true);
            ItemUI.SetActive(true);
        }
        
        public void UnActivateInGameUI()
        {
            remainingTimeUI.SetActive(false);
            ItemUI.SetActive(false);
        }

        public void ActivateTimeUpUI()
        {
            timeUPUI.SetActive(true);
        }
    }

}

