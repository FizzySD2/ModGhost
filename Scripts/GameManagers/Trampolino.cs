using System;
using Photon;
using UnityEngine;

// Token: 0x0200010E RID: 270
public class Trampolino : Photon.MonoBehaviour
{
    int a = 0;
    void OnCollisionEnter(Collision collision)
    {
        if(a < 120) 
        {
        if(collider.gameObject.name == "Titan" || collider.gameObject.name == "Aberrant")
            collision.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1000, gameObject.transform.position.z);
        a++;
        }
    }
}