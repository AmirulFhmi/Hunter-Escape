using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos : MonoBehaviour
{
	public Transform checkPoint;
	GameObject player;
	PlayerInfo playerInfo;

	private void OnTriggerEnter(Collider col)
	{
		//Debug.Log(col.gameObject);

		if (col.CompareTag("Player"))
		{
			//col.gameObject.GetComponent<CharacterControls>().checkPoint = checkPoint.position;

			player = col.gameObject.transform.parent.gameObject;
			Debug.Log(player.gameObject);
			playerInfo = player.GetComponent<PlayerInfo>();

			playerInfo.UpdateCheckpoint(checkPoint);
			//Debug.Log("Checkpoint updated!");
		}
	}
}
