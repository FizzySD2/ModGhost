using System;
using Photon;
using UnityEngine;

// Token: 0x0200010F RID: 271
public class Portal : Photon.MonoBehaviour
{
	// Token: 0x060008A1 RID: 2209 RVA: 0x00086DCB File Offset: 0x00085DCB
	public void OnCollisionEnter()
	{
		GameObject.Find("MainCamera").GetComponent<IN_GAME_MAIN_CAMERA>().main_object.GetComponent<HERO>().teleport(InRoomChat.Portal2GO.transform.position + this.teleportoffset);
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x00086E08 File Offset: 0x00085E08
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

	// Token: 0x04000918 RID: 2328
	public Vector3 teleportoffset = new Vector3(3f, 10f, 0f);
}
