using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

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
            ScoreHandler.Instance.AddScore();
        }

    }
}
