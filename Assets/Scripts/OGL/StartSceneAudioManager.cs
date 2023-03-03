using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class StartSceneAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource bgm;
        [SerializeField] private AudioSource NormalClick;
        [SerializeField] private AudioSource TransitionClick;
        [SerializeField] private AudioSource SliderValueChange;

        public void PlayBGM()
        {
            bgm.Play();
        }
        
        public void PauseBGM()
        {
            bgm.Pause();
        }
        public void PlayNormalClickSound()
        {
            NormalClick.Play();
        }
        
        public void PlayTransitionClickSound()
        {
            TransitionClick.Play();
        }
        
        public void PlaySliderValueChangeSound()
        {
            SliderValueChange.Play();
        }
    }
}