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
            yield return new WaitForSeconds(1.5f);
            CurrentStatus = InGameStatus.StageIntroduction;
        }
        
    }

}
