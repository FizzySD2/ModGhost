using System;
using Photon;
using UnityEngine;

// Token: 0x0200010E RID: 270
public class Portal2 : Photon.MonoBehaviour
{
	// Token: 0x0600089E RID: 2206 RVA: 0x00086CC9 File Offset: 0x00085CC9
	public void OnCollisionEnter()
	{
		GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().main_object.GetComponent<HERO>().teleport(InRoomChat.Portal1GO.transform.position + this.teleportoffset);
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x00086D04 File Offset: 0x00085D04
	private void teleport(PhotonPlayer player)
	{
		Vector3 position = default(Vector3);
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (gameObject.GetComponent<HERO>() != null && gameObject.GetComponent<HERO>().photonView.owner == player)
			{
				position = gameObject.GetComponent<HERO>().transform.position;
				position.y += 2f;
				break;
			}
		}
		HERO component = GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().main_object.GetComponent<HERO>();
		if (component != null)
		{
			component.teleport(position);
			return;
		}
	}

	// Token: 0x04000917 RID: 2327
	public Vector3 teleportoffset = new Vector3(3f, 0f, 0f);
}
