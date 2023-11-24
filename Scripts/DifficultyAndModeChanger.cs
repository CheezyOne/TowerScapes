
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Diagnostics;
using System.Threading;

public class DifficultyAndModeChanger : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector2 dir=Vector2.zero;
    public GameObject MenuBackgroundForDif, MenuBackgroundForModes, targetForLeftSideForDif, targetForLeftSideForModes, targetForRigthSideForDif, targetForRigthSideForModes, ScrollBarForDifficulties, ScrollBarForModes;
    private Scrollbar ScrollbarForDifficulties, ScrollbarForModes;
    void Start()
    {
        ScrollbarForModes= ScrollBarForModes.GetComponent<Scrollbar>();
        ScrollbarForDifficulties = ScrollBarForDifficulties.GetComponent<Scrollbar>();
        SwipeDetector.SwipeEvent += OnSwipe;
    }
    private void OnSwipe(Vector2 direction)
    {
        if ((direction == Vector2.left) || (direction == Vector2.right))
        {
            dir = direction;
        }
    }
    void Update()
    { 
        if (dir == Vector2.right)
        {
            MenuBackgroundForDif.transform.position = Vector3.Lerp(MenuBackgroundForDif.transform.position, targetForRigthSideForDif.transform.position, 10 * Time.deltaTime);
            ScrollbarForDifficulties.GetComponent<Scrollbar>().interactable = false;
            if (Mathf.Abs(MenuBackgroundForModes.transform.position.x - targetForRigthSideForModes.transform.position.x) > 0.005)
            {
                MenuBackgroundForModes.transform.position = Vector3.Lerp(MenuBackgroundForModes.transform.position, targetForRigthSideForModes.transform.position, 10 * Time.deltaTime);
                if (ScrollbarForModes.value <= 1)
                {
                    ScrollbarForModes.value += 5 * Time.deltaTime;
                }
            }
            ScrollbarForModes.GetComponent<Scrollbar>().interactable = true;
        }
        else if (dir == Vector2.left)
        {
            MenuBackgroundForModes.transform.position = Vector3.Lerp(MenuBackgroundForModes.transform.position, targetForLeftSideForModes.transform.position, 10 * Time.deltaTime);
            ScrollbarForModes.GetComponent<Scrollbar>().interactable = false;
            if (Mathf.Abs(MenuBackgroundForDif.transform.position.x - targetForLeftSideForDif.transform.position.x) > 0.005)
            {
                MenuBackgroundForDif.transform.position = Vector3.Lerp(MenuBackgroundForDif.transform.position, targetForLeftSideForDif.transform.position, 10 * Time.deltaTime);
                if (ScrollbarForDifficulties.value <= 1)
                {
                    ScrollbarForDifficulties.value += 5 * Time.deltaTime;
                }
            }
            ScrollbarForDifficulties.GetComponent<Scrollbar>().interactable = true;
        }
    }
}
