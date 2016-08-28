using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

    private PandaController _player;
    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Panda").GetComponent<PandaController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            GameObject tmpPlayer = GameObject.Find("Panda");
            if (_player.isPlaying)
            {
                tmpPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
                tmpPlayer.GetComponent<Collider2D>().enabled = false;
            }
        }


    }
}
