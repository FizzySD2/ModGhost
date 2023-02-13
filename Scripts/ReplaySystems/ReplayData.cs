using System;
using System.Collections.Generic;
using UnityEngine;
public class ReplayData
{
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }
    public string animId { get; private set; }
    public bool RightHookState { get; private set; }
    public bool LeftHookState { get; private set; }
    public Vector3 RightHookPos { get; private set; }
    public Vector3 LeftHookPos { get; private set; }

    //public Quaternion rotation;
    public ReplayData(Vector3 position, Quaternion rotation, string anim, bool RightHookState,bool LeftHookState, Vector3 RightHookPos, Vector3 LeftHookPos) 
    {
       // this.rotation = rotation;
        this.position = position;
        this.rotation = rotation;
        this.animId = anim;
        this.RightHookState = RightHookState;
        this.LeftHookState = LeftHookState;
        this.RightHookPos = RightHookPos;
        this.LeftHookPos = LeftHookPos;
    }
}
