using UnityEngine;
//using UnityEngine.EventSystems;
public class TurningCamera : MonoBehaviour//, IPointerClickHandler
{
    public GameObject rotator;
    public void TurningLeft()
    {
        rotator.GetComponent<RotateCamera>().speed = 50;
    }
    public void StopTurningLeft()
    {
        rotator.GetComponent<RotateCamera>().speed = 5;
    }
    public void TurningRight()
    {
        rotator.GetComponent<RotateCamera>().speed = -50;
    }
    public void StopTurningRight()
    {
        rotator.GetComponent<RotateCamera>().speed = -5;
    }

    /*/Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }

        //Use this to tell when the user left-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(name + " Game Object Left Clicked!");
        }
    }
    */
}
