﻿using System;
using System.Collections.Generic;
using UnityEngine;
public class ReplayData
{
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }
    public string animId { get; private set; }

    //public Quaternion rotation;
    public ReplayData(Vector3 position, Quaternion rotation, string anim) 
    {
       // this.rotation = rotation;
        this.position = position;
        this.rotation = rotation;
        this.animId = anim;
    }
}
