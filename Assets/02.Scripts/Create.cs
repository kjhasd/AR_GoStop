using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {
    public GameObject cube;
    public GameObject position;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddOne()
    {
        GameObject temp = Instantiate(cube, position.transform);
        temp.transform.Translate(transform.forward * Random.Range(-3, 3));
        temp.transform.Translate(transform.right * Random.Range(-3, 3));
    }
}
