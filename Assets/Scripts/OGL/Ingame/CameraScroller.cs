using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class CameraScroller : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;

        [SerializeField] private GameManager _gameManager;

        private Vector3 _cameraProgressPerFrame;
        // Start is called before the first frame update
        void Start()
        {
            _cameraProgressPerFrame = new Vector3(0, 0.3f, 0);
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameManager.gameStart)
            {
                Debug.Log("start");
                _camera.GetComponent<Transform>().position -= _cameraProgressPerFrame;
            }
        }
    }
}