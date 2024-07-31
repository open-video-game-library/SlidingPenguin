using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトの数を取得
        int childCount = transform.childCount;

        // 子オブジェクトを順に取得する
        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = transform.GetChild(i);
            GameObject childObject = childTransform.gameObject;

            childObject.SetActive(ParameterManager.fish);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
