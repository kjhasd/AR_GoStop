using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.parent.GetChild(0).gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
