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

    public float gameSpeed = 100.0f;
    private float outofbounceX;
    private int roadCounter = 0;
    private bool enemyAdded = false;

    // Use this for initialization
    void Start()
    {
        gameLayer = GameObject.Find("gameLayer");
        collectedTiles = GameObject.Find("tmp");

        for (int i = 0; i < 10; i++)
        {
            GameObject tmpRoad = Instantiate(Resources.Load("Road", typeof(GameObject))) as GameObject;
            tmpRoad.transform.parent = collectedTiles.transform.FindChild("tmpRoad").transform;
            tmpRoad.transform.position = Vector2.zero;
            
        }

        for (int i = 0; i < 10; i++)
        {
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
        startUpKillBottomPosY = GameObject.Find("startBottom").transform.position.y;

        tileKillTopPos = GameObject.Find("startTop");
        startUpKillTopPosY = tileKillTopPos.transform.position.y;

        fillScene();
        randomizeEnemy();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void FixedUpdate()
    {
        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - (gameSpeed * Time.deltaTime + 0.02f), -1.96f);

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
        if (gameLayer.transform.childCount < 10)
            fillScene();
        if (roadCounter > 0)
        {
            randomizeEnemy();
            enemyAdded = false;
            roadCounter--;

        }
    }

    private void fillScene()
    {
        setTile("Road");
    }

    private void setTile(string type)
    {
        switch (type)
        {
            case "Road":
                roadCounter++;
                tmpTile = collectedTiles.transform.FindChild("tmpRoad").transform.GetChild(0).gameObject;
                tileWidth = 10.5f;
                tmpTile.transform.parent = gameLayer.transform;
                tmpTile.transform.position = new Vector3(tileRoadPos.transform.position.x + (tileWidth), startUpRoadPosY, 0);
                tileRoadPos = tmpTile;
                break;
        }
    }

    private void randomizeEnemy()
    {
        if (enemyAdded) return;

        GameObject newBottomEnemy = collectedTiles.transform.FindChild("tmpKillBottom").transform.GetChild(0).gameObject;
        newBottomEnemy.transform.parent = gameLayer.transform;
        newBottomEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + tileWidth, startUpKillBottomPosY);

        GameObject newTopEnemy = collectedTiles.transform.FindChild("tmpKillTop").transform.GetChild(0).gameObject;
        newTopEnemy.transform.parent = gameLayer.transform;
        newTopEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + tileWidth, startUpKillTopPosY);
        enemyAdded = true;
    }

}
