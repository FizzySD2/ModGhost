using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.IO;
using System.Text;

public class ReplaySaver : MonoBehaviour
{ 
    public static void SaveReplay(string text, string fileName)
    {
        byte[] data = Encoding.ASCII.GetBytes(text);
        if (!Directory.Exists(Application.dataPath + "/UserData/Replays"))
            Directory.CreateDirectory(Application.dataPath + "/UserData/Replays");
        File.WriteAllBytes(Application.dataPath + "/UserData/Replays" + "/" + fileName, data);
    }
}
