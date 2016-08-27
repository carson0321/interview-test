using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {
    // Use this for initialization
    private GameObject collectedTiles;
    private float tileWidth = 10.5f;
    public GameObject tileRoadPos;
    public GameObject tileKillBottomPos;
    public GameObject tileKillTopPos;

    private GameObject gameLayer;
    private GameObject tmpTile;
    private float startUpRoadPosY;
    private float startUpKillBottomPosY;
    private float startUpKillTopPosY;

    public float gameSpeed = 2.0f;
    private float outofbounceX;

    // Use this for initialization
    void Start()
    {
        gameLayer = GameObject.Find("gameLayer");
        collectedTiles = GameObject.Find("tmp");

        for (int i = 0; i < 30; i++)
        {
            GameObject tmpRoad = Instantiate(Resources.Load("Road", typeof(GameObject))) as GameObject;
            tmpRoad.transform.parent = collectedTiles.transform.FindChild("tmpRoad").transform;
            tmpRoad.transform.position = Vector2.zero;

            GameObject tmpKillBottom = Instantiate(Resources.Load("killBottom", typeof(GameObject))) as GameObject;
            tmpKillBottom.transform.parent = collectedTiles.transform.FindChild("tmpKillBottom").transform;
            tmpKillBottom.transform.position = Vector2.zero;

            GameObject tmpKillTop = Instantiate(Resources.Load("killTop", typeof(GameObject))) as GameObject;
            tmpKillTop.transform.parent = collectedTiles.transform.FindChild("tmpKillTop").transform;
            tmpKillTop.transform.position = Vector2.zero;
        }

        collectedTiles.transform.position = new Vector2(-60.0f, -20.0f);

        tileRoadPos = GameObject.Find("startRoad");
        startUpRoadPosY = tileRoadPos.transform.position.y;
        outofbounceX = tileRoadPos.transform.position.x - 10.0f;

        tileKillBottomPos = GameObject.Find("startBottom");
        startUpKillBottomPosY = tileRoadPos.transform.position.y;

        tileKillTopPos = GameObject.Find("startTop");
        startUpKillTopPosY = tileRoadPos.transform.position.y;

        fillScene();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void FixedUpdate()
    {
        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - gameSpeed * Time.deltaTime, -1.96f);

        foreach (Transform child in gameLayer.transform)
        {
            if (child.position.x < outofbounceX)
            {
                switch (child.gameObject.name)
                {
                    case "Road(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpRoad").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpRoad").transform;
                        break;
                    case "killBottom(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpKillBottom").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpKillBottom").transform;
                        break;
                    case "killTop(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpKillTop").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpKillTop").transform;
                        break;
                    default:
                        Destroy(child.gameObject);
                        break;
                }
            }
        }
        if (gameLayer.transform.childCount < 25)
            fillScene();
    }

    private void fillScene()
    {
        for (int i = 0; i < 15; i++)
        {
            setTile("Road");
            setTile("killBottom");
            setTile("killTop");
        }
    }

    private void setTile(string type)
    {
        switch (type)
        {
            case "Road":
                tmpTile = collectedTiles.transform.FindChild("tmpRoad").transform.GetChild(0).gameObject;
                tileWidth = 10.5f;
                tmpTile.transform.parent = gameLayer.transform;
                tmpTile.transform.position = new Vector3(tileRoadPos.transform.position.x + (tileWidth), startUpRoadPosY, 0);
                tileRoadPos = tmpTile;
                break;
            case "killBottom":
                tmpTile = collectedTiles.transform.FindChild("tmpKillBottom").transform.GetChild(0).gameObject;
                tileWidth = 5f;
                tmpTile.transform.parent = gameLayer.transform;
                tmpTile.transform.position = new Vector3(tileKillBottomPos.transform.position.x + (tileWidth), startUpKillBottomPosY, 0);
                break;
            case "killTop":
                tmpTile = collectedTiles.transform.FindChild("tmpKillTop").transform.GetChild(0).gameObject;
                tileWidth = 5f;
                tmpTile.transform.parent = gameLayer.transform;
                tmpTile.transform.position = new Vector3(tileKillTopPos.transform.position.x + (tileWidth), startUpKillTopPosY, 0);
                break;
        }
    }

}
