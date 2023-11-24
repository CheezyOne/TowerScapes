using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private CubePos nowCube = new CubePos(0, 1, 0);
    public float CubeChangePlaceSpeed = 0.5f;
    private float HelperCubeChangePlaceSpeed;
    public Transform cubeToPlace;
    public GameObject cubeToDestroy;
    public GameObject allCubes, blockPlacedeffect, newSkinUnlocked;
    public GameObject[] canvasstartpage;
    public Text scoreText;
    public GameObject[] cubesToCreate;
    private Rigidbody allCubesRB;
    public Color[] BGcolors;
    public GameObject TurningToTheLeftButton, TurningToTheRightButton;
    private Color toCameraColor;
    private int counterOfClicksPerSecond = 0;
    private int DeviderForCubesSpeed;
    private bool TowerIsFalling = false;
    private bool IsLose = false;
    private bool IsLost=false;
    private bool StopClickingTooFase = false;
    private bool PlayingStraightUp = false;
    private bool StopIsLost=false;
    private bool SetTimerForOneSecond = false;
    private bool colorChanged = false;
    private bool DeleteNewSkinUnlockedText = false;
    private bool TowerDestroyed = false;
    private bool firstcube = false;
    private bool ChechingForSpeedChanging;
    private float camMoveToYPosition = 0;
    private float timerForOneSecond = 1;
    private float distanceBetweenCubes = 0;
    private float camMoveSpeed = 2f;
    private float timerForOneSecondForClicks = 1f;
    private List<Vector3> allCubesPositions = new List<Vector3>
{
    new Vector3(0,0,0),
    new Vector3(1,0,0),
    new Vector3(-1,0,0),
    new Vector3(0,1,0),
    new Vector3(0,0,-1),
    new Vector3(0,0,1),
    new Vector3(1,0,1),
    new Vector3(1,0,-1),
    new Vector3(-1,0,1),
    new Vector3(-1,0,-1),
};
    private Coroutine showCubePlace;
    private Transform mainCAm;
    private int prevCountMaxHor;
    private List<GameObject> possibleCubesToCreate = new List<GameObject>();
    private void Start()
    {
        // DataHolder.Inst.firstTimeChangedDifficulty = true;
        //PlayerPrefs.SetInt("FirstTimePlaying", 1);
        if (DataHolder.Inst.PlayingMode[1] == true)
            PlayingStraightUp = true;
        //PlayerPrefs.SetInt("Easyscore", 1);
        //PlayerPrefs.SetInt("FirstTimePlaying", 1);
        //PlayerPrefs.SetInt("Normalscore", 1);
        //PlayerPrefs.SetInt("Hardscore", 1);
        if (PlayerPrefs.GetInt("FirstTimePlaying") == 3 || DataHolder.Inst.firstTimeChangedDifficulty == false)
        {
            DataHolder.Inst.DifferentDifficultiesScore[0] = PlayerPrefs.GetInt("Easyscore");
            DataHolder.Inst.DifferentDifficultiesScore[1] = PlayerPrefs.GetInt("Normalscore");
            DataHolder.Inst.DifferentDifficultiesScore[2] = PlayerPrefs.GetInt("Hardscore");
            DataHolder.Inst.DifferentDifficultiesScore[3] = PlayerPrefs.GetInt("Randscore");
            DataHolder.Inst.DifferentDifficultiesScore[4] = PlayerPrefs.GetInt("EasyscoreUp");
            DataHolder.Inst.DifferentDifficultiesScore[5] = PlayerPrefs.GetInt("NormalscoreUp");
            DataHolder.Inst.DifferentDifficultiesScore[6] = PlayerPrefs.GetInt("HardscoreUp");
            DataHolder.Inst.DifferentDifficultiesScore[7] = PlayerPrefs.GetInt("RandscoreUp");
            //DataHolder.Inst.firstTimeChangedDifficulty = false;
            if (DataHolder.Inst.theGameDifficylty[2] == false && DataHolder.Inst.theGameDifficylty[0] == false && DataHolder.Inst.theGameDifficylty[3] == false)
            {
                DataHolder.Inst.theGameDifficylty[1] = true;
            }
            if (DataHolder.Inst.PlayingMode[1] == false && DataHolder.Inst.PlayingMode[0] == false )
            {
                DataHolder.Inst.PlayingMode[0] = true;
            }
        }
        else if (DataHolder.Inst.firstTimeChangedDifficulty == true)
        {
            //Debug.Log("asda");
            //DataHolder.Inst.DifferentDifficultiesScore[0] = PlayerPrefs.GetInt("Easyscore");
            //DataHolder.Inst.DifferentDifficultiesScore[1] = PlayerPrefs.GetInt("Normalscore");
            //DataHolder.Inst.DifferentDifficultiesScore[2] = PlayerPrefs.GetInt("Hardscore");
            PlayerPrefs.SetInt("FirstTimePlaying", 3);
            DataHolder.Inst.firstTimeChangedDifficulty = false;
            DataHolder.Inst.theGameDifficylty[1] = true;
            DataHolder.Inst.PlayingMode[0] = true;
            DataHolder.Inst.DifferentDifficultiesScore[0] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[3] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[2] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[1] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[4] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[5] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[6] = 0;
            DataHolder.Inst.DifferentDifficultiesScore[7] = 0;
        }
        //PlayerPrefs.SetInt("score", 1);
        if (DataHolder.Inst.theGameDifficylty[0] == true)
        {
            DeviderForCubesSpeed = 500;
            HelperCubeChangePlaceSpeed = 0.7f;
            if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("EasyscoreUp"));
            else
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("Easyscore"));
        }
        else if (DataHolder.Inst.theGameDifficylty[1] == true)
        {
            HelperCubeChangePlaceSpeed = 0.5f;
            DeviderForCubesSpeed = 600;
            if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("NormalscoreUp"));
            else 
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("Normalscore"));
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true)
        {
            HelperCubeChangePlaceSpeed = 0.4f;
            DeviderForCubesSpeed = 750;
            if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("HardscoreUp"));
            else
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("Hardscore"));
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true)
        {
            if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("RandscoreUp"));
            else
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("Randscore"));
            System.Random rand = new System.Random(PlayerPrefs.GetInt("Randscore"));
            System.Random rand1 = new System.Random(rand.Next(0,99));
            int NumberRand=rand1.Next(0,100);
            if (NumberRand <= 15)
            {
                System.Random rand2 = new System.Random();
                DeviderForCubesSpeed = rand2.Next(300, 450);
                HelperCubeChangePlaceSpeed = (float)rand2.NextDouble();
            }
            else if (NumberRand > 15 && NumberRand <= 85)
            {
                System.Random rand2 = new System.Random();
                DeviderForCubesSpeed = rand2.Next(500, 700);
                HelperCubeChangePlaceSpeed = (float)rand2.NextDouble();
            }
            else if (NumberRand > 85)
            {
                System.Random rand2 = new System.Random();
                DeviderForCubesSpeed = rand2.Next(800, 1000);
                HelperCubeChangePlaceSpeed = (float)rand2.NextDouble();
            }
        }
        //UnityEngine.Debug.Log(DeviderForCubesSpeed);
        //UnityEngine.Debug.Log(HelperCubeChangePlaceSpeed);                            Console Debug Line
        //Debug.Log("One Place Left");  
        if (PlayerPrefs.GetInt("score") < 5)
            possibleCubesToCreate.Add(cubesToCreate[0]);
        else if (PlayerPrefs.GetInt("score") < 10)
        {
            AddPossibleCubes(2);
        }
        else if (PlayerPrefs.GetInt("score") < 15)
        {
            AddPossibleCubes(3);
        }
        else if (PlayerPrefs.GetInt("score") < 20)
        {
            AddPossibleCubes(4);
        }
        else if (PlayerPrefs.GetInt("score") < 25)
        {
            AddPossibleCubes(5);
        }
        else if (PlayerPrefs.GetInt("score") < 35)
        {
            AddPossibleCubes(6);
        }
        else if (PlayerPrefs.GetInt("score") < 50)
        {
            AddPossibleCubes(7);
        }
        else if (PlayerPrefs.GetInt("score") < 75)
        {
            AddPossibleCubes(8);
        }
        else if (PlayerPrefs.GetInt("score") < 100)
        {
            AddPossibleCubes(9);
        }
        else
            AddPossibleCubes(10);
        RemovingNotSelectedCubesFromTheList();
        scoreText.text = "<size=38>Best</size>:" + PlayerPrefs.GetInt("score") + "\n<size=30>Now</size>:" + 1;//
        toCameraColor = Camera.main.backgroundColor;
        mainCAm = Camera.main.transform;
        camMoveToYPosition = 5.9f + nowCube.y - 1f;
        allCubesRB = allCubes.GetComponent<Rigidbody>();
        showCubePlace = StartCoroutine(ShowCubePlace());

        //CheckClickingSpeed = StartCoroutine(DoCheck());
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && cubeToPlace != null && !(EventSystem.current.currentSelectedGameObject) && !StopClickingTooFase) //allcubes!=null
        {
#if !UNITY_EDITOR
            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;
#endif
            if (!firstcube)
            {
                firstcube = true;
                foreach (GameObject obj in canvasstartpage)
                {
                    Destroy(obj);
                }
                TurningToTheRightButton.SetActive(true);
                TurningToTheLeftButton.SetActive(true);
            }

            GameObject newCube = Instantiate(possibleCubesToCreate[UnityEngine.Random.Range(0, possibleCubesToCreate.Count)], cubeToPlace.position, Quaternion.identity) as GameObject; // ��� �������, ���, ��������(��������)
            newCube.transform.SetParent(allCubes.transform);
            nowCube.setVector(cubeToPlace.position);
            allCubesPositions.Add(nowCube.getVector());
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            GameObject newVfx = Instantiate(blockPlacedeffect, cubeToPlace.position, Quaternion.identity) as GameObject;
            Destroy(newVfx, 1.5f);
            SpawnPositions();
            MoveCameraChangeBg();
            counterOfClicksPerSecond++;
            allCubesRB.isKinematic = true;
            allCubesRB.isKinematic = false;
            distanceBetweenCubes = Vector3.Distance(cubeToPlace.localPosition, newCube.transform.localPosition);
            if (PlayingStraightUp)
            {
                if (newCube.transform.position.x > 0.1 || newCube.transform.position.z > 0.1 || newCube.transform.position.x < -0.1 || newCube.transform.position.z < -0.1)
                    TowerIsFalling = true;
            }
        }

        if (TowerIsFalling && !TowerDestroyed)
        {
            if ((GameObject.Find("All cubes") != null))
            {
                if ((allCubesRB.velocity.magnitude <= 0.02f))
                {
                    if (cubeToDestroy != null)
                    {
                        CheckWhereIsTheTowerFalling();
                    }
                    TowerDestroyed = true;
                }
            }
        }

        if (allCubesRB != null)
        {
            if ((!IsLose && allCubesRB.velocity.magnitude > 0.1f && distanceBetweenCubes < 1.1) || (IsLost))
            {
                StopIsLost = true;
                if (cubeToPlace != null)
                    Destroy(cubeToPlace.gameObject);
                IsLose = true;
                if (showCubePlace != null)
                    StopCoroutine(showCubePlace);
                TowerIsFalling = true;
            }
            else
            {
                mainCAm.localPosition = Vector3.MoveTowards(mainCAm.localPosition, new Vector3(mainCAm.localPosition.x, camMoveToYPosition, mainCAm.localPosition.z), camMoveSpeed * Time.deltaTime);
            }
        }
        if ((TowerIsFalling || TowerDestroyed || allCubes ==null)&& camMoveToYPosition>12)
        {
            mainCAm.position = Vector3.MoveTowards(mainCAm.position, new Vector3(0, camMoveToYPosition+5, 0), 3*camMoveSpeed * Time.deltaTime);
            if (mainCAm.eulerAngles.x < 80)
            {
                mainCAm.Rotate(Time.deltaTime * 30, 0, 0);
            }
            Debug.Log(mainCAm.eulerAngles.x);
        }
        if (Camera.main.backgroundColor != toCameraColor)
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, toCameraColor, Time.deltaTime/2);

        TimerForASecondForClicks();

        if (SetTimerForOneSecond==true)
        {
            timerForASecond();
        }
    }
    void CheckWhereIsTheTowerFalling()
    {
        bool HelperForFallingTower = false;
        if (HelperForFallingTower == false)
        {
            if (GameObject.Find("All cubes").transform.rotation.x > 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position =new Vector3(100, 3, 0);
            }
            else if (GameObject.Find("All cubes").transform.rotation.x < 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(-100, 3, 0);
            }
            else if (GameObject.Find("All cubes").transform.rotation.z < 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(0, 3, -100);
            }
            else if (GameObject.Find("All cubes").transform.rotation.z > 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(0, 3, 100);
            }
        }
    }
    IEnumerator ShowCubePlace()
    {
        while (true)
        {
            SpawnPositions();
            yield return new WaitForSeconds(CubeChangePlaceSpeed);
        }
    }
    private void SpawnPositions ()
{
        List<Vector3> positions = new List<Vector3>();
        if(IsPositionEmpty(new Vector3(nowCube.x+1,nowCube.y,nowCube.z)) && nowCube.x+1!= cubeToPlace.position.x)
    {
        positions.Add(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z));
    }
     if (IsPositionEmpty(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z)) && nowCube.x - 1 != cubeToPlace.position.x)
    {
        positions.Add(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z));
    }
     if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y+1, nowCube.z)) && nowCube.y + 1 != cubeToPlace.position.y)
    {
        positions.Add(new Vector3(nowCube.x, nowCube.y+1, nowCube.z));
    }
    if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z)) && nowCube.y - 1 != cubeToPlace.position.y)
    {
        positions.Add(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z));
    }
    if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z+1)) && nowCube.z + 1 != cubeToPlace.position.z)
    {
        positions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z+1));
    }
     if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1)) && nowCube.z - 1 != cubeToPlace.position.z)
    {
        positions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1));
    }
    List<Vector3> Realpositions = new List<Vector3>();
        if (IsPositionEmpty(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z)))// && nowCube.x+1!= cubeToPlace.position.x)
        {
            Realpositions.Add(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z)))// && nowCube.x - 1 != cubeToPlace.position.x)
        {
            Realpositions.Add(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z)))// && nowCube.y + 1 != cubeToPlace.position.y)
        {
            Realpositions.Add(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z)))// && nowCube.y - 1 != cubeToPlace.position.y)
        {
            Realpositions.Add(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1)))// && nowCube.z + 1 != cubeToPlace.position.z)
        {
            Realpositions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1)))// && nowCube.z - 1 != cubeToPlace.position.z)
        {
            Realpositions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z - 1));
        }
        if (Realpositions.Count > 1)
        {
            cubeToPlace.position = positions[UnityEngine.Random.Range(0, positions.Count)];
            //Debug.Log(Realpositions.Count);
        }
        else if (Realpositions.Count == 0 && StopIsLost==false)
        {
            IsLost = true;
            //Debug.Log("SoftLock");
        }
        else
        {
            //Debug.Log("One Place Left");
            cubeToPlace.position = Realpositions[0];
        }
}
    private bool IsPositionEmpty(Vector3 TargetPos)
    {
        if (TargetPos.y==0)
    {
        return false;
    }
        foreach (Vector3 pos in allCubesPositions)
        {
            if(pos.x==TargetPos.x && pos.y == TargetPos.y && pos.z == TargetPos.z )
        {
            return false;
        }
        }
    return true;
    }
    private void MoveCameraChangeBg()
    {
        int maxX = 0, maxY = 0, maxZ = 0, maxHor;
        foreach (Vector3 pos in allCubesPositions)
        {
            if (Mathf.Abs(Convert.ToInt32(pos.x)) > maxX)
            {
                maxX = (Mathf.Abs(Convert.ToInt32(pos.x)));
            }
            if (Convert.ToInt32(pos.y) > maxY)
            {
                maxY = (Convert.ToInt32(pos.y));
            }
            if (Mathf.Abs(Convert.ToInt32(pos.z)) > maxZ)
            {
                maxZ = (Mathf.Abs(Convert.ToInt32(pos.z)));
            }
        }
        float Changer = (float)maxY;
        CubeChangePlaceSpeed = HelperCubeChangePlaceSpeed - Changer/ DeviderForCubesSpeed;
        if (((maxY == 6) || (maxY == 11) || (maxY == 16) || (maxY == 21) || (maxY == 26) || (maxY == 36) || (maxY == 51) || (maxY == 76)))
        {
            DeleteNewSkinUnlockedText = false;
        }
        if (!(DeleteNewSkinUnlockedText)&&(PlayerPrefs.GetInt("score") < maxY) && ((maxY == 5) || (maxY == 10) || (maxY == 15) || (maxY == 20) || (maxY == 25) || (maxY == 35) || (maxY == 50) || (maxY == 75) || (maxY == 100)))
        {
            newSkinUnlocked.SetActive(true);
            SetTimerForOneSecond = true;
        }
        else
        {
            newSkinUnlocked.SetActive(false);
        }
        if (DataHolder.Inst.theGameDifficylty[1] == true && PlayingStraightUp == false)
        {
            if(DataHolder.Inst.DifferentDifficultiesScore[1]<maxY )
            {
                DataHolder.Inst.DifferentDifficultiesScore[1] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[1]);
                PlayerPrefs.SetInt("Normalscore", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[1] == true && PlayingStraightUp == true)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[5] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[5] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[5]);
                PlayerPrefs.SetInt("NormalscoreUp", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[0] == true && PlayingStraightUp==true)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[4] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[4] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[4]);
                PlayerPrefs.SetInt("EasyscoreUp", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[0] == true && PlayingStraightUp == false)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[0] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[0] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[0]);
                PlayerPrefs.SetInt("Easyscore", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true && PlayingStraightUp == false)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[2] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[2] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[2]);
                PlayerPrefs.SetInt("Hardscore", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true && PlayingStraightUp == true)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[6] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[6] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[6]);
                PlayerPrefs.SetInt("HardscoreUp", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true && PlayingStraightUp == false)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[3] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[3] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[3]);
                PlayerPrefs.SetInt("Randscore", maxY);
            }
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true && PlayingStraightUp == true)
        {
            if (DataHolder.Inst.DifferentDifficultiesScore[7] < maxY)
            {
                DataHolder.Inst.DifferentDifficultiesScore[7] = maxY;
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[7]);
                PlayerPrefs.SetInt("RandscoreUp", maxY);
            }
        }
        if (PlayerPrefs.GetInt("score") < maxY)
            PlayerPrefs.SetInt("score", maxY);
        scoreText.text = "<size=38>Best</size>:" + PlayerPrefs.GetInt("score")+"\n<size=30>Now</size>:"+maxY;//
        camMoveToYPosition = 5.9f + nowCube.y - 1f;
        if (maxX > maxZ)
        {
            maxHor = maxX;
        }
        else maxHor = maxZ;
        if(maxHor%2==0 && prevCountMaxHor!=maxHor)
        {
            prevCountMaxHor = maxHor;
            mainCAm.localPosition -= new Vector3 (0,0,3.5f);
        }
        if (maxY % 3 == 1)
            colorChanged = false;
        if((maxY%3==0)&& (colorChanged==false))
        {
            colorChanged = true;
            toCameraColor = BGcolors[UnityEngine.Random.Range(0, 5)]; // здесь меняется цвет заднего фона
        }
    }
    private void AddPossibleCubes(int till)
    {
        for (int i = 0; i < till; i++)
            possibleCubesToCreate.Add(cubesToCreate[i]);
    }
    private void RemovingNotSelectedCubesFromTheList()
    {
        for (int i=9;i>=0;i--)
        {
            if (DataHolder.Inst.SelectedToUseCube[i] == true)
                possibleCubesToCreate.Remove(cubesToCreate[i]);
        }
    }
    private void timerForASecond()
    {
        if (timerForOneSecond > 0)
        {
            timerForOneSecond -= Time.deltaTime;
        }
        else
        {
            DeleteNewSkinUnlockedText = false;
            newSkinUnlocked.SetActive(false);
            timerForOneSecond = 1;
            SetTimerForOneSecond = false;
        }
    }
    private void TimerForASecondForClicks()
    {
        if(timerForOneSecondForClicks>0)
        {
            timerForOneSecondForClicks-=Time.deltaTime;
            if (counterOfClicksPerSecond > 3)
                StopClickingTooFase = true;
        }
        else
        {
            counterOfClicksPerSecond = 0;
            timerForOneSecondForClicks = 1;
            StopClickingTooFase = false;
        }
    }
}
struct CubePos
{
    public int x, y, z;
    public CubePos(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3 getVector()
    {
        return new Vector3(x, y, z);
    }
    public void setVector (Vector3 pos)
    {
        x = Convert.ToInt32(pos.x);
        y = Convert.ToInt32(pos.y);
        z = Convert.ToInt32(pos.z);
    }
}