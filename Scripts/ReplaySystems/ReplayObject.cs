using CustomSkins;
using System;
using System.Collections.Generic;
using UnityEngine;
public class ReplayObject : Photon.MonoBehaviour
{
    GameObject lineRenderer = new GameObject();
    GameObject lineRenderer1 = new GameObject();

    public void Awake() 
    {
        Material mat = new Material(Shader.Find("Specular"));
        lineRenderer.AddComponent<LineRenderer>();
        lineRenderer.GetComponent<LineRenderer>().SetWidth(0.2f,0.2f);
        lineRenderer.GetComponent<LineRenderer>().material = mat;
        lineRenderer.GetComponent<LineRenderer>().material.color = Color.cyan;
        lineRenderer.GetComponent<LineRenderer>().SetColors(Color.blue, Color.blue);
        lineRenderer.GetComponent<LineRenderer>().SetVertexCount(2);

        lineRenderer1.AddComponent<LineRenderer>();
        lineRenderer1.GetComponent<LineRenderer>().SetWidth(0.2f, 0.2f);
        lineRenderer1.GetComponent<LineRenderer>().material = mat;
        lineRenderer1.GetComponent<LineRenderer>().material.color = Color.cyan;
        lineRenderer1.GetComponent<LineRenderer>().SetColors(Color.blue, Color.blue);
        lineRenderer1.GetComponent<LineRenderer>().SetVertexCount(2);


    }
    public void SetDataForFrame(ReplayData data) 
    {
        this.transform.position = data.position;
        this.transform.rotation = data.rotation;
        this.GetComponent<HERO>().animation.Play(data.animId);
        if (data.LeftHookPos != new Vector3(0, 0, 0))
        {
            lineRenderer.GetComponent<LineRenderer>().enabled = true;
            lineRenderer.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            lineRenderer.GetComponent<LineRenderer>().SetPosition(1, data.LeftHookPos);
        }
        else 
        {
            lineRenderer.GetComponent<LineRenderer>().enabled = false;
        }

        if (data.RightHookPos != new Vector3(0, 0, 0))
        {
            lineRenderer1.GetComponent<LineRenderer>().enabled = true;
            lineRenderer1.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            lineRenderer1.GetComponent<LineRenderer>().SetPosition(1, data.RightHookPos);
        }
        else
        {
            lineRenderer1.GetComponent<LineRenderer>().enabled = false;
        }

        if (data.isGhostBoosting)
        {
            GetComponent<HERO>().SetGhostSmoke(1);
        }
        else 
        {
            GetComponent<HERO>().SetGhostSmoke(0);
        }
    }
}