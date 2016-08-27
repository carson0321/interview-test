using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {
    // Use this for initialization
    private GameObject collectedTiles;
    public GameObject tileRoadPos;
    public GameObject tileKillBottomPos;
    public GameObject tileKillTopPos;
    public GameObject tileTree1Pos;
    public GameObject tileTree2Pos;
    public GameObject tileCloud1Pos;
    public GameObject tileCloud2Pos;
    public GameObject tileTreeShadowPos;
    public GameObject tileGrass1Pos;
    public GameObject tileGrass2Pos;

    private GameObject gameLayer;
    private GameObject tmpTile;
    private float startUpRoadPosY;
    private float startUpKillBottomPosY;
    private float startUpKillTopPosY;
    private float startUpTree1PosY;
    private float startUpTree2PosY;
    private float startUpCloud1PosY;
    private float startUpCloud2PosY;
    private float startUpTreeShadowPosY;
    private float startUpGrass1PosY;
    private float startUpGrass2PosY;

    public float gameSpeed = 1.0f;
    private float outofbounceX;
    private int roadCounter = 0;
    private bool enemyAdded = false;
    private bool backgroundAdded = false;
    private float time = 0;
    private int control = 0;

    // Use this for initialization
    void Start()
    {
        gameLayer = GameObject.Find("gameLayer");
        collectedTiles = GameObject.Find("tmp");

        for (int i = 0; i < 20; i++)
        {
            setGameObject("Road");
            setGameObject("KillBottom");
            setGameObject("KillTop");
            setGameObject("Tree1");
            setGameObject("Tree2");
            setGameObject("Cloud1");
            setGameObject("Cloud2");
            setGameObject("TreeShadow");
            setGameObject("Grass1");
            setGameObject("Grass2");
        }

        collectedTiles.transform.position = new Vector2(-60.0f, -20.0f);

        tileRoadPos = GameObject.Find("startRoad");
        startUpRoadPosY = tileRoadPos.transform.position.y;
        outofbounceX = tileRoadPos.transform.position.x - 10.0f;

        tileKillBottomPos = GameObject.Find("startBottom");
        startUpKillBottomPosY = GameObject.Find("startBottom").transform.position.y;

        tileKillTopPos = GameObject.Find("startTop");
        startUpKillTopPosY = tileKillTopPos.transform.position.y;

        tileTree1Pos = GameObject.Find("startTree1");
        startUpTree1PosY = GameObject.Find("startTree1").transform.position.y;

        tileTree2Pos = GameObject.Find("startTree2");
        startUpTree2PosY = GameObject.Find("startTree2").transform.position.y;

        tileCloud1Pos = GameObject.Find("startCloud1");
        startUpCloud1PosY = GameObject.Find("startCloud1").transform.position.y;

        tileCloud2Pos = GameObject.Find("startCloud2");
        startUpCloud2PosY = GameObject.Find("startCloud2").transform.position.y;

        tileTreeShadowPos = GameObject.Find("startTreeShadow");
        startUpTreeShadowPosY = GameObject.Find("startTreeShadow").transform.position.y;

        tileGrass1Pos = GameObject.Find("startGrass1");
        startUpGrass1PosY = GameObject.Find("startGrass1").transform.position.y;

        tileGrass2Pos = GameObject.Find("startGrass2");
        startUpGrass2PosY = GameObject.Find("startGrass2").transform.position.y;


        setTile("Road");
        randomizeEnemy();
    }
	
    private void setGameObject(string type)
    {
        GameObject tmpObject = Instantiate(Resources.Load(type, typeof(GameObject))) as GameObject;
        tmpObject.transform.parent = collectedTiles.transform.FindChild("tmp"+ type).transform;
        tmpObject.transform.position = Vector2.zero;
    }

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= 4)
        {
            time = 0;
            setTile("Road");
        }
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
                    case "KillBottom(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpKillBottom").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpKillBottom").transform;
                        break;
                    case "KillTop(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpKillTop").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpKillTop").transform;
                        break;
                    case "Tree1(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpTree1").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpTree1").transform;
                        break;
                    case "Tree2(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpTree2").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpTree2").transform;
                        break;
                    case "Cloud1(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpCloud1").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpCloud1").transform;
                        break;
                    case "Cloud2(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpCloud2").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpCloud2").transform;
                        break;
                    case "Grass1(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpGrass1").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpGrass1").transform;
                        break;
                    case "Grass2(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpGrass2").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpGrass2").transform;
                        break;
                    case "TreeShadow(Clone)":
                        child.gameObject.transform.position = collectedTiles.transform.FindChild("tmpTreeShadow").transform.position;
                        child.gameObject.transform.parent = collectedTiles.transform.FindChild("tmpTreeShadow").transform;
                        break;
                    default:
                        Destroy(child.gameObject);
                        break;
                }
            }
        }
        if (gameLayer.transform.childCount < 20)
            setTile("Road");
        if (roadCounter > 0)
        {
            randomizeEnemy();
            randomizeBackground();
            enemyAdded = false;
            backgroundAdded = false;
            roadCounter--;
        }
    }
    

    private void setTile(string type)
    {
        float treeDistance = Random.Range(1, 8);
        switch (type)
        {
            case "Road":
                roadCounter++;
                tileRoadPos = set("tmpRoad",tileRoadPos, startUpRoadPosY,10.5f);
                break;
            case "Tree1":
                tileTree1Pos = set("tmpTree1", tileRoadPos, startUpTree1PosY, treeDistance);
                break;
            case "Tree2":
                tileTree2Pos = set("tmpTree2", tileRoadPos, startUpTree2PosY, treeDistance);
                break;
            case "Cloud1":
                tileCloud1Pos = set("tmpCloud1", tileRoadPos, startUpCloud1PosY, Random.Range(1, 8));
                break;
            case "Cloud2":
                tileCloud2Pos = set("tmpCloud2", tileRoadPos, startUpCloud2PosY, Random.Range(1, 8));
                break;
            case "Grass1":
                tileGrass1Pos = set("tmpGrass1", tileRoadPos, startUpGrass1PosY, Random.Range(1, 8));
                break;
            case "Grass2":
                tileGrass2Pos = set("tmpGrass2", tileRoadPos, startUpGrass2PosY, Random.Range(1, 8));
                break;
            case "TreeShadow":
                tileTreeShadowPos = set("tmpTreeShadow", tileRoadPos, startUpTreeShadowPosY, treeDistance);
                break;
        }
    }

    private GameObject set(string type,GameObject gameObjectType, float PosYType,float distance)
    {
        tmpTile = collectedTiles.transform.FindChild(type).transform.GetChild(0).gameObject;
        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector3(gameObjectType.transform.position.x + distance, PosYType, 0);
        return tmpTile;
    }

    private void randomizeEnemy()
    {
        if (enemyAdded) return;

        GameObject newBottomEnemy = collectedTiles.transform.FindChild("tmpKillBottom").transform.GetChild(0).gameObject;
        newBottomEnemy.transform.parent = gameLayer.transform;
        newBottomEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + 5.0f , startUpKillBottomPosY);

        GameObject newTopEnemy = collectedTiles.transform.FindChild("tmpKillTop").transform.GetChild(0).gameObject;
        newTopEnemy.transform.parent = gameLayer.transform;
        newTopEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + 5.0f, startUpKillTopPosY);
        enemyAdded = true;
    }

    private void randomizeBackground()
    {
        if (backgroundAdded) return;

        int control = (int)Random.Range(0, 4);
        if (control == 0)
        {
            setTile("Tree1");setTile("Tree2");
            setTile("Cloud1");setTile("Cloud2");
            setTile("Grass1");setTile("Grass2");
            setTile("TreeShadow");
        }
        else if (control == 1)
        {
            setTile("Tree1");setTile("Cloud1");
            setTile("Grass1");setTile("Grass2");
            setTile("TreeShadow");
        }
        else if (control == 2)
        {
            setTile("Tree2");setTile("Cloud2");
            setTile("Grass1");setTile("Grass2");
            setTile("TreeShadow");
        }
        else if (control == 3)
        {
            setTile("Tree1");setTile("Cloud2");
            setTile("Grass1");setTile("Grass2");
            setTile("TreeShadow");
        }
        else if (control == 4)
        {
            setTile("Tree2");setTile("Cloud1");
            setTile("Grass1");setTile("Grass2");
            setTile("TreeShadow");
        }

        backgroundAdded = true;
    }

}
