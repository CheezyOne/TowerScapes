using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class TheAutomatedGame : MonoBehaviour
{
    private CubePos nowCube = new CubePos(-21, 1, 25);
    public float CubeChangePlaceSpeed = 0.5f;
    private float HelperCubeChangePlaceSpeed;
    public Transform cubeToPlace;
    public GameObject cubeToDestroy;
    public GameObject allCubes, blockPlacedeffect;
    public GameObject[] cubesToCreate;
    private Rigidbody allCubesRB;
    private Color toCameraColor;
    private int DeviderForCubesSpeed;
    public bool TowerIsFalling = false;
    public bool IsLost = false;
    public bool StopIsLost = false;
    private bool SetTimerForOneSecond;
    public bool TowerDestroyed = false;
    public bool ManuallyStartAgain;
    private bool ChechingForSpeedChanging;
    private List<Vector3> allCubesPositions = new List<Vector3>
{
    new Vector3(-21,0,25),
    new Vector3(-21,0,26),
    new Vector3(-21,0,24),
    new Vector3(-21,1,25),
    new Vector3(-22,0,25),
    new Vector3(-22,0,24),
    new Vector3(-22,0,26),
    new Vector3(-23,0,25),
    new Vector3(-23,0,26),
    new Vector3(-23,0,-24),
};
    private Coroutine showCubePlace;
    private Transform mainCAm;
    private int prevCountMaxHor;
    private List<GameObject> possibleCubesToCreate = new List<GameObject>();

    void Start()
    {
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
        allCubesRB = allCubes.GetComponent<Rigidbody>();
        showCubePlace = StartCoroutine(ShowCubePlace());
    }

    void Update()
    {
        if(ManuallyStartAgain==true)
        {
            //while (allCubesPositions.Count > 10)
            //allCubesPositions.Remove(allCubesPositions[allCubesPositions.Count-1]);
           // UnityEngine.Debug.Log(allCubesPositions.Count);
            allCubesRB = allCubes.GetComponent<Rigidbody>();
            showCubePlace = StartCoroutine(ShowCubePlace());
            ManuallyStartAgain = false;
        }
        if (TowerIsFalling && !TowerDestroyed)
        {
            if ((GameObject.Find("All cubes") != null)&&allCubesRB!=null)
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
            if ((allCubesRB.velocity.magnitude > 0.1f) || (IsLost))
            {
                StopIsLost = true;
                if (cubeToPlace != null)
                    Destroy(cubeToPlace.gameObject);
                if (showCubePlace != null)
                    StopCoroutine(showCubePlace);
                TowerIsFalling = true;
            }
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
                cubeToDestroy.transform.position = new Vector3(79, 3, 25);
            }
            else if (GameObject.Find("All cubes").transform.rotation.x < 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(-121, 3, 25);
            }
            else if (GameObject.Find("All cubes").transform.rotation.z < 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(-21, 3, -75);
            }
            else if (GameObject.Find("All cubes").transform.rotation.z > 0)
            {
                HelperForFallingTower = true;
                cubeToDestroy.AddComponent<BoxCollider>();
                cubeToDestroy.transform.position = new Vector3(-21, 3, 125);
            }
        }
    }
    IEnumerator ShowCubePlace()
    {
        while (true)
        {
            SpawnPositions();
            int RandomNumber = UnityEngine.Random.Range(0, 10);
            if(RandomNumber >5)
            {
                GameObject newCube = Instantiate(possibleCubesToCreate[UnityEngine.Random.Range(0, possibleCubesToCreate.Count)], cubeToPlace.position, Quaternion.identity) as GameObject; // ��� �������, ���, ��������(��������)
                newCube.transform.SetParent(allCubes.transform);
                nowCube.setVector(cubeToPlace.position);
                allCubesPositions.Add(nowCube.getVector());
                GameObject newVfx = Instantiate(blockPlacedeffect, cubeToPlace.position, Quaternion.identity) as GameObject;
                Destroy(newVfx, 1.5f);
                allCubesRB.isKinematic = true;
                allCubesRB.isKinematic = false;
                SpawnPositions();
            }
            yield return new WaitForSeconds(CubeChangePlaceSpeed);
        }
    }
    private void SpawnPositions()
    {
        List<Vector3> positions = new List<Vector3>();
        if (IsPositionEmpty(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z)) && nowCube.x + 1 != cubeToPlace.position.x)
        {
            positions.Add(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z)) && nowCube.x - 1 != cubeToPlace.position.x)
        {
            positions.Add(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z)) && nowCube.y + 1 != cubeToPlace.position.y)
        {
            positions.Add(new Vector3(nowCube.x, nowCube.y + 1, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z)) && nowCube.y - 1 != cubeToPlace.position.y)
        {
            positions.Add(new Vector3(nowCube.x, nowCube.y - 1, nowCube.z));
        }
        if (IsPositionEmpty(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1)) && nowCube.z + 1 != cubeToPlace.position.z)
        {
            positions.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1));
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
        else if (Realpositions.Count == 0 && StopIsLost == false)
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
        if (TargetPos.y == 0)
        {
            return false;
        }
        foreach (Vector3 pos in allCubesPositions)
        {
            if (pos.x == TargetPos.x && pos.y == TargetPos.y && pos.z == TargetPos.z)
            {
                return false;
            }
        }
        return true;
    }
    private void AddPossibleCubes(int till)
    {
        for (int i = 0; i < till; i++)
            possibleCubesToCreate.Add(cubesToCreate[i]);
    }
}
