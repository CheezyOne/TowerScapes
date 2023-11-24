using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsInOptions : MonoBehaviour
{
    public GameObject CameraToChange,CameraOfDifficulties,CameraOfMainMenu,CanvasOfMainMenu,CanvasOfDifficulties,SoundBox;
    private static bool GoingFromModesToMain = false, GoingFromMainToModes = false, MustPlayButtonSound = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(MustPlayButtonSound)
        {
            MustPlayButtonSound = false;
            SoundBox.GetComponent<AudioSource>().Play();
        }
        if (GoingFromModesToMain)
        {
            NowGoingFromModesToMain();
        }
        else if(GoingFromMainToModes)
        {
            NowGoingFromMainToModes();
        }
    }

    public void StartPlaying()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
        {
            GetComponent<AudioSource>().Play();
        }
        SceneManager.LoadScene("Main");
    }

    public void ButtonFromModesToMain()
    {
        MustPlayButtonSound = true;
        CameraToChange.SetActive(true);
        CameraOfDifficulties.SetActive(false);
        GoingFromModesToMain = true;
        CanvasOfDifficulties.SetActive(false);
        CameraToChange.GetComponent<Animation>().Play("CameraFromDifToMain");
    }

    private void NowGoingFromModesToMain()
    {
        if (!CameraToChange.GetComponent<Animation>().isPlaying)
        {
            CanvasOfDifficulties.SetActive(false);
            CanvasOfMainMenu.SetActive(true);
            CameraToChange.SetActive(false);
            CameraOfMainMenu.SetActive(true);
            GoingFromModesToMain = false;
        }
    }
    public void ButtonFromMainToModes()
    {
        MustPlayButtonSound = true;
        CameraToChange.SetActive(true);
        CameraOfMainMenu.SetActive(false);
        GoingFromMainToModes = true;
        CanvasOfMainMenu.SetActive(false);
        CameraToChange.GetComponent<Animation>().Play("CameraFromMainToDif");
    }
    private void NowGoingFromMainToModes()
    {
        if (!CameraToChange.GetComponent<Animation>().isPlaying)
        {
            CanvasOfMainMenu.SetActive(false);
            CanvasOfDifficulties.SetActive(true);
            CameraToChange.SetActive(false);
            CameraOfDifficulties.SetActive(true);
            GoingFromMainToModes = false;
        }
    }
}
