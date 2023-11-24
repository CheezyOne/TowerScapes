using UnityEngine;
using UnityEngine.UI;
public class ChoseDifficulty : MonoBehaviour
{
    public Text EasyButton, MediumButton, HardButton,RandButton,ScoreInDifficulties,ScoreInModes;
    private Color GreenColor = new Color(0.1f, 0.8f, 0.2f);
    private Color NormalColor = new Color(0.8f, 0.8f, 0.3f);
    private void Start ()
    {
        if (DataHolder.Inst.theGameDifficylty[0] == true)
        {
            EasyButton.color = GreenColor;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[0]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[4]);
        }
        else if (DataHolder.Inst.theGameDifficylty[1] == true)
        {
            MediumButton.color = GreenColor;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[1]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[5]);
        }
        else if (DataHolder.Inst.theGameDifficylty[2] == true)
        {
            HardButton.color = GreenColor;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[2]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[6]);
        }
        else if (DataHolder.Inst.theGameDifficylty[3] == true)
        {
            RandButton.color = GreenColor;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[3]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[7]);
        }
        ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
    }
    public void chosenEasy()
    {
        if (DataHolder.Inst.theGameDifficylty[0] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            ChangeAllCubesToBePlacable();
            EasyButton.color = GreenColor;
            RandButton.color = NormalColor;
            MediumButton.color = NormalColor;
            HardButton.color = NormalColor;
            DataHolder.Inst.theGameDifficylty[0] = true;
            DataHolder.Inst.theGameDifficylty[1] = false;
            DataHolder.Inst.theGameDifficylty[3] = false;
            DataHolder.Inst.theGameDifficylty[2] = false;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[0]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[4]);
            ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
            ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        }
    }
    public void chosenMedium()
    {
        if (DataHolder.Inst.theGameDifficylty[1] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            ChangeAllCubesToBePlacable();
            EasyButton.color = NormalColor;
            MediumButton.color = GreenColor;
            RandButton.color = NormalColor;
            HardButton.color = NormalColor;
            DataHolder.Inst.theGameDifficylty[1] = true;
            DataHolder.Inst.theGameDifficylty[0] = false;
            DataHolder.Inst.theGameDifficylty[3] = false;
            DataHolder.Inst.theGameDifficylty[2] = false;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[1]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[5]);
            ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
            ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        }
    }
    public void chosenHard()
    {
        if (DataHolder.Inst.theGameDifficylty[2] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            ChangeAllCubesToBePlacable();
            EasyButton.color = NormalColor;
            MediumButton.color = NormalColor;
            RandButton.color = NormalColor;
            HardButton.color = GreenColor;
            DataHolder.Inst.theGameDifficylty[2] = true;
            DataHolder.Inst.theGameDifficylty[3] = false;
            DataHolder.Inst.theGameDifficylty[0] = false;
            DataHolder.Inst.theGameDifficylty[1] = false;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[2]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[6]);
            ScoreInDifficulties.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
            ScoreInModes.text = "<size=68>Best</size>:" + PlayerPrefs.GetInt("score");
        }
    }
    public void chosenRandom()
    {
        if (DataHolder.Inst.theGameDifficylty[3] == false)
        {
            if (PlayerPrefs.GetString("music") == "Yes")
            {
                GetComponent<AudioSource>().Play();
            }
            ChangeAllCubesToBePlacable();
            EasyButton.color = NormalColor;
            MediumButton.color = NormalColor;
            HardButton.color = NormalColor;
            RandButton.color = GreenColor;
            DataHolder.Inst.theGameDifficylty[3] = true;
            DataHolder.Inst.theGameDifficylty[2] = false;
            DataHolder.Inst.theGameDifficylty[0] = false;
            DataHolder.Inst.theGameDifficylty[1] = false;
            if (DataHolder.Inst.PlayingMode[0] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[3]);
            else if (DataHolder.Inst.PlayingMode[1] == true)
                PlayerPrefs.SetInt("score", DataHolder.Inst.DifferentDifficultiesScore[7]);
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