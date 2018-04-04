using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    private bool isMobile = true;
    private PandaController _player;
    public GameObject board;
    public GameObject tapToJump;

    // Use this for initialization
    void Start()
    {
        if (Application.isEditor)
            isMobile = false;
        _player = GameObject.Find("Panda").GetComponent<PandaController>();

    }

    // Update is called once per frame
    void Update () {
        if (isMobile)
        {
            int tmp = Input.touchCount;
            tmp--;

            if (Input.GetTouch(tmp).phase == TouchPhase.Began) handleInteraction(true);
            if (Input.GetTouch(tmp).phase == TouchPhase.Ended) handleInteraction(false);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                handleInteraction(true);
                _player.isPlaying = true;
                board.SetActive(false);
                tapToJump.SetActive(false);
            }
            if (Input.GetMouseButtonUp(0)) handleInteraction(false);
        }
    }

    void handleInteraction(bool starting)
    {
        if (starting) _player.jump();
        else _player.jumpPress = false;
    }
}
