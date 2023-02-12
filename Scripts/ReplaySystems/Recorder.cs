using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
public class Recorder : MonoBehaviour
{
    public Vector3 Finalpos;
    public Quaternion Finalrot;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public float rx = 0;
    public float ry = 0;
    public float rz = 0;
    public float rw = 0;

    public SaveData Savedata = new SaveData();
    public string inputs = "";
    public bool saveRecording = false;
    public bool startRecording = false;
    public Recording recording;
    public Queue<ReplayData> recordingQueue { get; private set; }

    private bool isDoingReplay = false;

    private void Awake()
    {
        recordingQueue = new Queue<ReplayData>();
    }

    public void RecordReplayFrame(ReplayData data)
    {
        if (startRecording)
        {
            recordingQueue.Enqueue(data);
            logger.addLINE("Recorded data" + data.position);
        }
    }
    public void ReadFile()
    {
        string data = File.ReadAllText(Application.dataPath + "/UserData/Replays" + "/" + "Replay1.txt");
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
                ReplayData replay = new ReplayData(Finalpos, Finalrot);
                recordingQueue.Enqueue(replay);
            }
        startReplay();
    }
    public void Savedata2()
    {
        foreach (var element in recordingQueue)
        {
            Vector3 position = element.position;
            Quaternion rotation = element.rotation;
            Savedata.SaveReplayData(position, rotation);
        }
        Savedata.Serialize();
        recordingQueue.Clear();
    }
  

    //public void loadReplay() 
    //{
        /*
        string data = File.ReadAllText(Application.dataPath + "/UserData/Replays" + "/" + "Registrazione1.txt");
        Regex regex = new Regex(@"\((.+?)\)");         // Split on hyphens.
        string[] substrings = regex.Split(data);
        recordingQueue.Clear();
        foreach (string match in substrings)
        {
            if (!match.Contains(",")) continue;
            Vector3 position = StringToVector3(match);
            ReplayData replay = new ReplayData(position);
            recordingQueue.Enqueue(replay);
        }
        startReplay();//or restartResplay(); try it
        */

    //}
    /*
    public void saveReplay() 
    {
        ReplaySaver.SaveReplay(inputs, "Registrazione1.txt") ;
    }
    */
    public void startReplay() 
    {
        isDoingReplay = true;
        //initialating recording
        recording = new Recording(recordingQueue);
        // reset current queue
        recordingQueue.Clear();
        // instanzing replay GO
        recording.InstantiateReplayObject(); 
        // posizionare la camera sul replay obj
    }

    
    private void FixedUpdate() 
    {
        if (!isDoingReplay) 
        {
            return;
        }
    

        bool hasMoreFrames = recording.PlayNextFrame();
        //check if finish

        if (!hasMoreFrames) 
        {
            restartResplay();
        }
        recording.healthLabel.transform.LookAt(((Vector3)(2f * recording.healthLabel.transform.position)) - Camera.main.transform.position);
    }
    public void restartResplay() 
    {
        isDoingReplay = true;
        recording.RestartReplay();
    }

    public void Reset() 
    {
        isDoingReplay = false;
        recordingQueue.Clear();
        recording.DestroyReplayObjectIfExists();
        recording = null;
    }
}

