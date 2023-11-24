using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatedCollisionWithGround : MonoBehaviour
{
    private bool SetTimerForOneSecond = true;
    private float timerForOneSecond = 3;
    public GameObject cubeToDestroy, explosion, AutomatedGame;
    private int AmountOfCubicks = 0;
    private bool CollisionSet = false;
    public float Force = 300.0f;
    private GameObject[] AllCubicks = new GameObject[500];
    private void Update()
    {
        if (CollisionSet == true)
        {
            if (SetTimerForOneSecond)
            {
                timerForSomeSeconds();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        SetTimerForOneSecond = true;
        if (((collision.gameObject.tag == "Cube") && (!CollisionSet)))
        {
            AmountOfCubicks = collision.transform.childCount - 1;
            for (int i = collision.transform.childCount - 1; i >= 0; i--)
            {
                Transform child = collision.transform.GetChild(i);
                AllCubicks[i] = collision.transform.GetChild(i).gameObject;
                child.gameObject.AddComponent<Rigidbody>();
                Vector3 ExpPos= transform.position;
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Force, ExpPos, 10);//Вектор 3
                //child.SetParent(AutomatedGame.transform);
            }
            Destroy(cubeToDestroy);

            if (ItMustBeCubeToDestroy())
            {
                GameObject newVfx = Instantiate(explosion, new Vector3(-21, 0, 25), Quaternion.identity) as GameObject;
                Destroy(newVfx, 1.5f);
            }
            else
            {
                GameObject newVfx = Instantiate(explosion, new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y, collision.contacts[0].point.z), Quaternion.identity) as GameObject;
                Destroy(newVfx, 1.5f);
            }
            //Destroy(collision.gameObject);
            CollisionSet = true;
            //DeleteAndCreateAgain();
        }
    }
    private void timerForSomeSeconds()
    {
        if (timerForOneSecond > 0)
        {
            //UnityEngine.Debug.Log(timerForOneSecond);
            //Debug.Log(timerForOneSecond + " kdrgjkdjk");
            timerForOneSecond -= Time.deltaTime;
        }
        else
        {
            //Debug.Log("jhsefaefbjhsefjh");
            //DeleteNewSkinUnlockedText = false;
            //newSkinUnlocked.SetActive(false);
            DeleteAndCreateAgain();
            CollisionSet = false;
            timerForOneSecond = 3;
            SetTimerForOneSecond = false;
        }
    }
    private void DeleteAndCreateAgain()
    {
        for (int i = AmountOfCubicks; i >= 0; i--)
        { 
            Destroy(AllCubicks[i]);
        }
        //if(AutomatedGame is GameObject)
            //DestroyImmediate(AutomatedGame,true);
        GameObject NewAutomatedGame = Instantiate(AutomatedGame, new Vector3(-25.36902f, 6.766842f, 20.83444f), Quaternion.identity) as GameObject;
        cubeToDestroy = NewAutomatedGame.transform.GetChild(0).transform.GetChild(1).gameObject;//.transform.GetChild(1);
    }
    private bool ItMustBeCubeToDestroy()
    {
        if (cubeToDestroy.transform.position.x < -11 && cubeToDestroy.transform.position.x > -31)
            return false;
        else
            return true;
    }
}
