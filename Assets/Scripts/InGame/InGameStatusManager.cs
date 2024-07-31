using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace penguin
{
    public enum InGameStatus
    {
        Null,
        StageIntroduction,
        CountDown,
        InGameNormal,
        HurryUp,
        ReachGoal,
        CourseOut,
        TimeUp
    }

    public class InGameStatusManager : MonoBehaviour
    {
        public InGameStatus CurrentStatus;
        
        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(Initialization());
        }
    
        private IEnumerator Initialization()
        {
            if (ParameterManager.gameAnimation) { yield return new WaitForSeconds(1.5f); }
            else { yield return new WaitForSeconds(0.0f); }
            CurrentStatus = InGameStatus.StageIntroduction;
        }   
    }
}
