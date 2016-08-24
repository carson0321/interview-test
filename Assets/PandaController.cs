using UnityEngine;
using System.Collections;

public class PandaController : MonoBehaviour {
    //panda's run speed and animation
    public Sprite[] playerSprite = new Sprite[4];
    public SpriteRenderer mainRender;
    public float time = 0;
    public int change;
    public float speed = 0.05f;


    private bool inAir = false;
    public bool jumpPress = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveAnimation();
        gameObject.transform.position += new Vector3(speed, 0, 0);
        if (!inAir && Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > 0.05f)  inAir = true;
        else if (inAir && this.GetComponent<Rigidbody2D>().velocity.y == 0.00f)
        {
            inAir = false;
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (jumpPress) jump();
        }
    }

    private void moveAnimation()
    {
        if (time > 4) time = 0;
        time += 10 * Time.deltaTime;
        change = (int)time;
        mainRender.sprite = playerSprite[change];
    }

    public void jump()
    {
        jumpPress = true;
        if (inAir) return;
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
    }
}
