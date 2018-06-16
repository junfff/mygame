using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotFixControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnUpdateBtn()
    {
        Debug.LogErrorFormat("OnUpdateBtn !!");

        GameRoot.instance.OnUpdateBtn();
    }
}
