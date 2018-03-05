using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoin : MonoBehaviour {

    public bool isGameEnd = false;
    public GameObject coin;
	// Use this for initialization
	void Start () {
        StartCoroutine(CreateCoins());
	}

    IEnumerator CreateCoins()
    {
        yield return new WaitForSeconds(1.0f);

        do
        {
            yield return new WaitForSeconds(1.0f);
            if (isGameEnd) { break; }
            Instantiate(coin, transform.position, transform.rotation);
        } while (!isGameEnd);
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GetCoin>().AddScore(100);
        }
       
    }
}
