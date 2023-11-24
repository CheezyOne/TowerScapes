using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class CanvasButton : MonoBehaviour
{
    private GameObject makingTheButtonDisappear;
    static private int countLoses; 
    public Sprite musicOn, musicOff;
    public GameObject rotator;
    private void Start()
    {
        if (PlayerPrefs.GetString("music") == "No" && gameObject.name=="Music")
        GetComponent<Image>().sprite = musicOff;
    }
    public void RestartGame()
    {
        //GameController.buttonIsPressed = true;
        countLoses++;
        if (countLoses % 3 == 0)
        {
            InterstitialAdd.S.ShowAdd();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//можно просто 0 после loadscene
    }
    public void LoadShop()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
        {
            GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Shop");
    }
    public void StraigthUpDif()
    {
        if(DataHolder.Inst.PlayingMode[1] == false)
        DataHolder.Inst.PlayingMode[1] = true;
        else
            DataHolder.Inst.PlayingMode[1] = false;
    }
    public void LoadOptions()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
        {
            GetComponent<AudioSource>().Play();
        }
        //Debug.Log("asda");
        DataHolder.Inst.OpenOptions = true;
        SceneManager.LoadScene("Options");
    }
    public void CloseShopAndOptions()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
        {
            GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Main");
    }
    public void MusicWork()
    {
        if (PlayerPrefs.GetString("music") == "No")
        {
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetString("music", "Yes");
            GetComponent<Image>().sprite = musicOn;
        }
        else
        {
            PlayerPrefs.SetString("music", "No");
            GetComponent<Image>().sprite = musicOff;
        }
    }
}