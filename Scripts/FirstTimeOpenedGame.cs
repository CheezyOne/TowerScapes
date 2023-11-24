using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class FirstTimeOpenedGame : MonoBehaviour
{
    public GameObject CameraForMainMenu, CameraForOptions, CanvasForMainMenu, CanvasForOptions;
    // Start is called before the first frame update
    private void Start()
    {

        if (PlayerPrefs.GetInt("FirstTimePlaying") == 3 || DataHolder.Inst.firstTimeChangedDifficulty == false)
        {
            UnityEngine.Application.targetFrameRate = 90;
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
            if (DataHolder.Inst.PlayingMode[1] == false && DataHolder.Inst.PlayingMode[0] == false)
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
        if (DataHolder.Inst.OpenOptions == true)
        {
            DataHolder.Inst.OpenOptions = false;
            CameraForMainMenu.SetActive(false);
            CameraForOptions.SetActive(true);
            CanvasForMainMenu.SetActive(false);
            CanvasForOptions.SetActive(true);
        }
    }
}
