using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;
using System;

public class SaveData
{
    public string final = "";
        public void SaveReplayData(Vector3 position, Quaternion rotation, string finalAnim, Vector3 LeftHookPos, Vector3 RightHookPos, bool isGhostBoosting)
        {
            final = final + ($"{position.x},{position.y},{position.z}\t{rotation.x},{rotation.y},{rotation.z},{rotation.w}\t{finalAnim}\t{LeftHookPos.x},{LeftHookPos.y},{LeftHookPos.z}\t{RightHookPos.x},{RightHookPos.y},{RightHookPos.z}\t{isGhostBoosting}\n"); 
        }

    public void reset() 
    {
        final = "";
    }
    /*
    public void Serialize2() 
    {
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/UserData/Replays/Replay1.txt"))
        {
            sw.WriteLine(final);
        }
    }
    */
    public void Serialize() 
    {
        byte[] data = Encoding.ASCII.GetBytes(final);
        if (!Directory.Exists(Application.dataPath + "/UserData/Replays"))
            Directory.CreateDirectory(Application.dataPath + "/UserData/Replays");
        File.WriteAllBytes(Application.dataPath + "/UserData/Replays" + "/" + "Replay1.txt", data);
    }
    /*
    public void ReadFile()
    {
        string data = File.ReadAllText(Application.dataPath + "/UserData/Replays" + "/" + "Replay1.txt");

        try
        {
            foreach (string word in data.Split('\n'))
            {
                string[] linesplitted = word.Split('\t');
                if (linesplitted.Length < 2)
                {
                    break;
                }
                string[] commasplitted = linesplitted[0].Split(',');
                string[] rotationcommasplitted = linesplitted[1].Split(',');

                x = float.Parse(commasplitted[0]);
                y = float.Parse(commasplitted[1]);
                z = float.Parse(commasplitted[2]);
                Finalpos = new Vector3(x, y, z);
                rx = float.Parse(rotationcommasplitted[0]);
                ry = float.Parse(rotationcommasplitted[1]);
                rz = float.Parse(rotationcommasplitted[2]);
                rw = float.Parse(rotationcommasplitted[3]);
                Finalrot = new Quaternion(rx, ry, rz, rw);
                ReplayData replay = new ReplayData(Finalpos,Finalrot);
  

                logger.addLINE("Position: " + x.ToString() + y.ToString() + z.ToString() + "Rotation: " + rx.ToString() + ry.ToString() + rz.ToString() + rw.ToString());
            }
        }
        catch (Exception e)
        {
            object[] parameters = new object[]
                  {
                    e.ToString(),
                    ""
                  };
            FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters);
            logger.addLINE(e.ToString());
        }


    }*/
}