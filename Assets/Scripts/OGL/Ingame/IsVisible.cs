using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

	void Start () 
	{
		targetRenderer = GetComponent<Renderer>();	
	}
	
	void Update () 
	{
		if(targetRenderer.isVisible)
		{
			// 表示されている場合の処理
			this.gameObject.SetActive(true);
		}
		else
		{
			// 表示されていない場合の処理
			this.gameObject.SetActive(false);
		}
	}

}
