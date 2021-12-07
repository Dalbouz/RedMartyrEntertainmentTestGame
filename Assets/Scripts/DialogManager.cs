﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public bool WantToStartDialog = false;
    private void Awake()
    {
        if (this.gameObject.activeInHierarchy) Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDialog()
    {
        WantToStartDialog = false;
    }
}
