using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class StartSceneAudio : MonoBehaviour
    {
        public AudioSource bgm;
        public AudioSource NormalClick;
        public AudioSource TransitionClick;
        public AudioSource SliderValueChange;
        

        private void Start()
        {
            StartCoroutine(PlayBGM());
        }
        
        private IEnumerator PlayBGM()
        {
            yield return new WaitForSeconds(1.0f);
            bgm.Play();
        }
        
    }
}