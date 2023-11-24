using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Collections;
public class DeleteUnlockConditions: MonoBehaviour//, IPointerClickHandler
{
    public GameObject text;
    public int needToUnlock;
    private void Start()
    {
        if (PlayerPrefs.GetInt("score") >= needToUnlock)
            Destroy(text);
    }
}
