using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAndMode : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);
    private Vector2 tapPosition, SwipeDelta;
    private bool IsMobile;
    private bool IsSwiping;
    private float SwipeRequiredSize = 80;
    void Start()
    {
        IsMobile = Application.isMobilePlatform;
    }
    void Update()
    {
        if (!IsMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsSwiping = true;
                tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
                ResetSwipe();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    IsSwiping = true;
                    tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                    ResetSwipe();
            }
        }
        CheckSwipe();
    }
    void CheckSwipe()
    {
        SwipeDelta = Vector2.zero;
        if (IsSwiping)
        {
            if (IsMobile)
            {
                SwipeDelta = Input.GetTouch(0).position - tapPosition;
            }
            else
            {
                SwipeDelta = (Vector2)Input.mousePosition - tapPosition;
            }
        }
        if (SwipeDelta.magnitude > SwipeRequiredSize)
        {
            if (SwipeEvent != null)
            {
                if (Mathf.Abs(SwipeDelta.x) > Mathf.Abs(SwipeDelta.y))
                {
                    if (SwipeDelta.x > 0)
                    {
                        SwipeEvent(Vector2.right);
                    }
                    else
                        SwipeEvent(Vector2.left);
                }
                else
                {
                    if (SwipeDelta.y > 0)
                    {
                        SwipeEvent(Vector2.up);
                    }
                    else
                        SwipeEvent(Vector2.down);
                }
            }
            ResetSwipe();
        }
    }
    void ResetSwipe()
    {
        IsSwiping = false;
        tapPosition = Vector2.zero;
        SwipeDelta = Vector2.zero;
    }
}