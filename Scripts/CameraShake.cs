using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    private Transform camTransform;
    private float shakeDuration = 1f, shakeForce = 0.4f, decreaseFactor = 1.5f;
    private Vector3 originPos;
    private bool stop = false;
    private void Start()
    {
        camTransform = GetComponent<Transform>();
        originPos = camTransform.localPosition;
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originPos + UnityEngine.Random.insideUnitSphere * shakeForce;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else if(!stop)
        {
            stop = true;
            shakeDuration = 0;
            camTransform.localPosition = originPos;
        }
    }
}
