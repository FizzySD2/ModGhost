using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Object = UnityEngine.Object;

public class Recording
{
    GameObject replayobj2;
    public GameObject healthLabel = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("UI/LabelNameOverHead"));
    public ReplayObject replayObj { get; private set; }
    private Queue<ReplayData> originalQueue;
    private Queue<ReplayData> replayQueue;

    public Recording(Queue<ReplayData> recordingQueue) 
    {
        this.originalQueue = new Queue<ReplayData>(recordingQueue);
        this.replayQueue = new Queue<ReplayData>(recordingQueue);
    }

    public void RestartReplay() 
    {
        this.replayQueue = new Queue<ReplayData>(originalQueue);
    }

    public bool PlayNextFrame()
    {
        if (replayObj == null) 
        {
            logger.addLINE("You have not instantiated replayGameobject");
        }
        bool hasMoreFrames = false; 
        if (replayQueue.Count != 0) 
        {
            ReplayData data = replayQueue.Dequeue();
            replayObj.SetDataForFrame(data);
            hasMoreFrames = true;
        }
        return hasMoreFrames;
    }


    public void InstantiateReplayObject()
    {
        //GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
        //GameObject gameObject = array[0];
        //GameObject playerReplay = (GameObject)Object.Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        //GameObject.Destroy(playerReplay.GetComponent<IN_GAME_MAIN_CAMERA>());
        replayobj2 = (GameObject)GameObject.Instantiate(Resources.Load("AOTTG_HERO 1") as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
        //GameObject.Destroy(replayobj2.GetComponent<HERO>());
        HERO gameObject = GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().main_object.GetComponent<HERO>();
        if (gameObject != null)
        {
            HERO_SETUP playerReplay = gameObject.GetComponent<HERO_SETUP>();
            HeroCostume hero = playerReplay.myCostume;
            replayobj2.GetComponent<HERO>().GetComponent<HERO_SETUP>().init();
            replayobj2.GetComponent<HERO>().GetComponent<HERO_SETUP>().myCostume = hero;
            replayobj2.GetComponent<HERO>().GetComponent<HERO_SETUP>().myCostume.stat = hero.stat;
            replayobj2.GetComponent<HERO>().GetComponent<HERO_SETUP>().setCharacterComponent();
            replayobj2.GetComponent<HERO>().setStat2();
            replayobj2.GetComponent<HERO>().setSkillHUDPosition2();
            CostumeConeveter.HeroCostumeToPhotonData2(replayobj2.GetComponent<HERO>().GetComponent<HERO_SETUP>().myCostume, PhotonNetwork.player);
            replayobj2.GetComponent<HERO>().hasDied = true;

            healthLabel.name = "LabelNameOverHead";
            healthLabel.transform.localPosition = new Vector3(0f, 5f, 0f);
            healthLabel.transform.localScale = new Vector3(5f, 5f, 5f);
            healthLabel.GetComponent<UILabel>().text = "Ghost";


            //Color newCol = new Color(1,0.45f, 0.4f);
            //replayobj2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //replayobj2.gameObject.GetComponent<Renderer>().material.color = newCol;
            healthLabel.transform.parent = replayobj2.transform;

            healthLabel.transform.parent = replayobj2.transform;

            if (replayQueue.Count != 0)
            {
                ReplayData startingData = replayQueue.Peek();
                //playerReplay.AddComponent<ReplayObject>();

                replayobj2.AddComponent<ReplayObject>();
                replayobj2.AddComponent<Rigidbody>();
                replayobj2.GetComponent<Rigidbody>().isKinematic = true;

                this.replayObj = replayobj2.GetComponent<ReplayObject>();
            }
        }
    }

    public void DestroyReplayObjectIfExists()
    {
        //forse distruggi il 2 e non l'uno
        if (replayObj != null) 
        {
            Object.Destroy(replayObj.gameObject);
            Object.Destroy(replayobj2);
        }
    }
}