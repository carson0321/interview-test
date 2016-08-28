using UnityEngine;
using System.Collections;

public class PandaController : MonoBehaviour {
    //panda's run speed and animation
    public Sprite[] playerSprite = new Sprite[4];
    public SpriteRenderer mainRender;
    public float time = 0;
    public int change;
    public float speed = 0.05f;

    public bool isPlaying = false;
    public int jumpCounter = 0;

    private bool inAir = false;
    public bool jumpPress = false;
    private int airJumpNumber = 1;

    private Vector2 moveDirection = Vector2.zero;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        moveAnimation();
        //gameObject.transform.position += new Vector3(speed, 0, 0);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (!inAir && Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > 0.05f)
        {
            inAir = true;
        }
        else if (inAir && this.GetComponent<Rigidbody2D>().velocity.y == 0.00f)
        {
            inAir = false;
            airJumpNumber = 1;
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
        jumpCounter++;
        jumpPress = true;
        if (airJumpNumber == 0) return;
        if (!inAir) this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2900);
        else
        {
            airJumpNumber--;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;

        }
    }
}
