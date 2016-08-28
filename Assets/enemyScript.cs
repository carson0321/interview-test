using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            GameObject tmpPlayer = GameObject.Find("Panda");
            tmpPlayer.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            tmpPlayer.GetComponent<Collider2D>().enabled = false;
        }


    }
}
