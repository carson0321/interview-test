using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour
{
    // Use this for initialization
    private GameObject collectedTiles;
    public GameObject tileRoadPos;
    private GameObject _player;
    public GameObject tileKillBottomPos;
    public GameObject tileKillTopPos;
    public GameObject tileScorePos;
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
    private float startUpScorePosY;
    private float startUpTree1PosY;
    private float startUpTree2PosY;
    private float startUpCloud1PosY;
    private float startUpCloud2PosY;
    private float startUpTreeShadowPosY;
    private float startUpGrass1PosY;
    private float startUpGrass2PosY;

    private float outOfBounceX;
    private float outOfPlayBounceY;
    private int roadCounter = 0;
    private bool enemyAdded = false;
    private bool isMobile = true;
    private float time = 0;
    private float gameSpeed = 3.5f;
    private bool playerDead = false;

    public Text ResultScoreText;
    public GameObject Result;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Use this for initialization
    void Start()
    {
        gameLayer = GameObject.Find("gameLayer");
        collectedTiles = GameObject.Find("tmp");
        if (Application.isEditor) isMobile = false;
        for (int i = 0; i < 50; i++)
        {
            setGameObject("Road");
            setGameObject("KillBottom");
            setGameObject("KillTop");
            setGameObject("Score");
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
        outOfBounceX = tileRoadPos.transform.position.x - 9.5f;
        outOfPlayBounceY = startUpRoadPosY - 3.0f;

        _player = GameObject.Find("Panda");

        tileKillBottomPos = GameObject.Find("startBottom");
        startUpKillBottomPosY = GameObject.Find("startBottom").transform.position.y;

        tileScorePos = GameObject.Find("startScore");
        startUpScorePosY = GameObject.Find("startScore").transform.position.y;

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

        fillScene(roadCounter);
        randomizeEnemy();
    }

    private void setGameObject(string type)
    {
        GameObject tmpObject = Instantiate(Resources.Load(type, typeof(GameObject))) as GameObject;
        tmpObject.transform.parent = collectedTiles.transform.FindChild("tmp" + type).transform;
        tmpObject.transform.position = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead)
        {
            ResultScoreText.gameObject.SetActive(true);
            Result.SetActive(true);
            if (isMobile)
            {
                int tmp = Input.touchCount;
                tmp--;
                if (Input.GetTouch(tmp).phase == TouchPhase.Began) Application.LoadLevel("Scene0");
            }
            else if (Input.GetMouseButtonDown(0)) Application.LoadLevel("Scene0");
        }
    }

    void FixedUpdate()
    {
        gameLayer.transform.position = new Vector2(gameLayer.transform.position.x - (gameSpeed * Time.deltaTime ), -1.96f);

        foreach (Transform child in gameLayer.transform)
        {
            if (child.position.x < outOfBounceX)
            {
                switch (child.gameObject.name)
                {
                    case "Road(Clone)":
                        if (roadCounter < 1) setTmpToScene(child, "Road");
                        else Destroy(child.gameObject);
                        break;
                    case "KillBottom(Clone)":
                        if (roadCounter < 1) setTmpToScene(child, "KillBottom");
                        else Destroy(child.gameObject);
                        break;
                    case "KillTop(Clone)":
                        if (roadCounter < 1) setTmpToScene(child, "KillTop");
                        else Destroy(child.gameObject);
                        break;
                    case "Score(Clone)":
                        if (roadCounter < 1) setTmpToScene(child, "Score");
                        else Destroy(child.gameObject);
                        break;
                    case "Tree1(Clone)":
                        setTmpToScene(child, "Tree1");
                        break;
                    case "Tree2(Clone)":
                        setTmpToScene(child, "Tree2");
                        break;
                    case "Cloud1(Clone)":
                        setTmpToScene(child, "Cloud1");
                        break;
                    case "Cloud2(Clone)":
                        setTmpToScene(child, "Cloud2");
                        break;
                    case "Grass1(Clone)":
                        setTmpToScene(child, "Grass1");
                        break;
                    case "Grass2(Clone)":
                        setTmpToScene(child, "Grass2");
                        break;
                    case "TreeShadow(Clone)":
                        setTmpToScene(child, "TreeShadow");
                        break;
                    default:
                        Destroy(child.gameObject);
                        break;
                }
            }
        }
        if (gameLayer.transform.childCount < 50)
            fillScene(roadCounter);
        if (roadCounter > 0)
        {
            randomizeEnemy();
            enemyAdded = false;
            roadCounter--;
        }
        if (_player.transform.position.y < outOfPlayBounceY)
            killPlayer();
    }

    private void setTmpToScene(Transform tmp,string type)
    {
        tmp.gameObject.transform.position = collectedTiles.transform.FindChild("tmp"+ type).transform.position;
        tmp.gameObject.transform.parent = collectedTiles.transform.FindChild("tmp" + type).transform;
    }

    private void fillScene(int roadNumber)
    {
        if(roadNumber<1) setTile("Road");
        setTile("Tree1"); setTile("Tree2");
        setTile("Cloud1"); setTile("Cloud2");
        setTile("Grass1"); setTile("Grass2");
        setTile("TreeShadow");
    }

    private void setTile(string type)
    {
        switch (type)
        {
            case "Road":
                tileRoadPos = setTmp("tmpRoad", tileRoadPos, startUpRoadPosY, 9.5f);
                roadCounter++;
                break;
            case "Tree1":
                tileTree1Pos = setTmp("tmpTree1", tileTree1Pos, startUpTree1PosY, 9f);
                break;
            case "Tree2":
                tileTree2Pos = setTmp("tmpTree2", tileTree2Pos, startUpTree2PosY, 9f);
                break;
            case "Cloud1":
                tileCloud1Pos = setTmp("tmpCloud1", tileCloud1Pos, startUpCloud1PosY, 9f);
                break;
            case "Cloud2":
                tileCloud2Pos = setTmp("tmpCloud2", tileCloud2Pos, startUpCloud2PosY, 9f);
                break;
            case "Grass1":
                tileGrass1Pos = setTmp("tmpGrass1", tileGrass1Pos, startUpGrass1PosY, 9f);
                break;
            case "Grass2":
                tileGrass2Pos = setTmp("tmpGrass2", tileGrass2Pos, startUpGrass2PosY, 9f);
                break;
            case "TreeShadow":
                tileTreeShadowPos = setTmp("tmpTreeShadow", tileTreeShadowPos, startUpTreeShadowPosY, 9f);
                break;
        }
    }

    private GameObject setTmp(string type, GameObject gameObjectType, float PosYType, float distance)
    {
        tmpTile = collectedTiles.transform.FindChild(type).transform.GetChild(0).gameObject;
        tmpTile.transform.parent = gameLayer.transform;
        tmpTile.transform.position = new Vector3(gameObjectType.transform.position.x + distance, PosYType, 0);
        return tmpTile;
    }

    private void randomizeEnemy()
    {
        if (enemyAdded) return;
        int distance = (int)Random.Range(0, 2);
        GameObject newBottomEnemy = collectedTiles.transform.FindChild("tmpKillBottom").transform.GetChild(0).gameObject;
        newBottomEnemy.transform.parent = gameLayer.transform;
        newBottomEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + 5.0f, startUpKillBottomPosY + distance);

        GameObject newTopEnemy = collectedTiles.transform.FindChild("tmpKillTop").transform.GetChild(0).gameObject;
        newTopEnemy.transform.parent = gameLayer.transform;
        newTopEnemy.transform.position = new Vector2(tileRoadPos.transform.position.x + 5.0f, startUpKillTopPosY + distance);
        enemyAdded = true;

        GameObject newScore = collectedTiles.transform.FindChild("tmpScore").transform.GetChild(0).gameObject;
        newScore.transform.parent = gameLayer.transform;
        newScore.transform.position = new Vector2(tileRoadPos.transform.position.x + 5.0f, startUpScorePosY + distance);
    }

    private void killPlayer()
    {
        if (playerDead) return;
        playerDead = true;
    }

}
