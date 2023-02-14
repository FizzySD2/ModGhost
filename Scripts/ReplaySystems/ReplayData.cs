using System;
using System.Collections.Generic;
using UnityEngine;
public class ReplayData
{
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }
    public string animId { get; private set; }
    public bool isGhostBoosting { get; private set; }

    public Vector3 LeftHookPos { get; private set; }
    public Vector3 RightHookPos { get; private set; }

    //public Quaternion rotation;
    public ReplayData(Vector3 position, Quaternion rotation, string anim, Vector3 LeftHookPos , Vector3 RightHookPos , bool isGhostBoosting) 
    {
       // this.rotation = rotation;
        this.position = position;
        this.rotation = rotation;
        this.animId = anim;
        this.LeftHookPos = LeftHookPos;
        this.RightHookPos = RightHookPos;
        this.isGhostBoosting = isGhostBoosting;
    }
}
