using System;
using System.Collections.Generic;
using UnityEngine;
public class ReplayObject : MonoBehaviour
{
    public void SetDataForFrame(ReplayData data) 
    {
        this.transform.position = data.position;
        this.transform.rotation = data.rotation;
    }
}