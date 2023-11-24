
using UnityEngine.UI;
using UnityEngine;

public class ChoseAGameMode : MonoBehaviour
{
    public Text EndlessText, StraightUpText, ScoreInModes, ScoreInDifficulties;
    private Color GreenColor = new Color(0.1f, 0.8f, 0.2f);
    private Color NormalColor = new Color(0.8f, 0.8f, 0.3f);
    void Start()
    {
        if (DataHolder.Inst.theGameDifficylty[0] == true && DataHolder.Inst.PlayingMode[0] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[0]);
        }
        else if (DataHolder.Inst.theGameDifficylty[0] == true && DataHolder.Inst.PlayingMode[1] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[4]);
        }
        else if (DataHolder.Inst.theGameDifficylty[1] == true && DataHolder.Inst.PlayingMode[0] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[1]);
        }
        else if (DataHolder.Inst.theGameDifficylty[1] == true && DataHolder.Inst.PlayingMode[1] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[5]);
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true && DataHolder.Inst.PlayingMode[0] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[2]);
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true && DataHolder.Inst.PlayingMode[1] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[6]);
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true && DataHolder.Inst.PlayingMode[0] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[3]);
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true && DataHolder.Inst.PlayingMode[1] == true)
        {
            PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[7]);
        }
        if (DataHolder.Inst.PlayingMode[0]==true)
        {
            EndlessText.color = GreenColor;
        }
        else if(DataHolder.Inst.PlayingMode[1] == true)
        {
            StraightUpText.color = GreenColor;
        }
        ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
    }
    public void ChosenEndless()
    {
        if (DataHolder.Inst.PlayingMode[0] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            //ChangeAllCubesToBePlacable();

            EndlessText.color = GreenColor;
            StraightUpText.color = NormalColor;
            if(DataHolder.Inst.theGameDifficylty[0] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[0]);
            }
            else if (DataHolder.Inst.theGameDifficylty[1] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[1]);
            }
            else if (DataHolder.Inst.theGameDifficylty[2] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[2]);
            }
            else if (DataHolder.Inst.theGameDifficylty[3] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[3]);
            }
            DataHolder.Inst.PlayingMode[0] = true;
            DataHolder.Inst.PlayingMode[1] = false;

            ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
            ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        }
    }
    public void ChosenStraightUp()
    {
        if (DataHolder.Inst.PlayingMode[1] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            //ChangeAllCubesToBePlacable();

            StraightUpText.color = GreenColor;
            EndlessText.color = NormalColor;
            if (DataHolder.Inst.theGameDifficylty[0] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[4]);
            }
            else if (DataHolder.Inst.theGameDifficylty[1] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[5]);
            }
            else if (DataHolder.Inst.theGameDifficylty[2] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[6]);
            }
            else if (DataHolder.Inst.theGameDifficylty[3] == true)
            {
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[7]);
            }
            DataHolder.Inst.PlayingMode[1] = true;
            DataHolder.Inst.PlayingMode[0] = false;

            ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
            ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        }
    }
    private void ChangeAllCubesToBePlacable()
    {
        for (int i = 0; i < DataHolder.Inst.SelectedToUseCube.Length; i++)
            DataHolder.Inst.SelectedToUseCube[i] = false;
        DataHolder.Inst.theAmountOfNotSelectedCubes = 0;
    }
}
