using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    public Text ScoreText;
    private int Score = 0;
    private float displayTime = 0;
    private bool display = false;
    public static ScoreHandler Instance;


    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (display)
        {
            if (displayTime > 1)
            {
                displayTime = 0;
                ScoreText.gameObject.SetActive(false);
                display = false;
            }
            displayTime += Time.deltaTime;
        }
    }
    public void AddScore()
    {
        Score += 1;
        ScoreText.text = System.Convert.ToString(Score);
        ScoreText.gameObject.SetActive(true);
        display = true;
    }
}
