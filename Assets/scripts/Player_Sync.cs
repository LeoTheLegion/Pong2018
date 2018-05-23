using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

[NetworkSettings (channel = 0, sendInterval = 0.05f)]
public class Player_Sync : NetworkBehaviour {


	[SyncVar (hook = "SyncPositionValues")]
	public Vector2 syncPos;

	private float threshold = 1f;
	private float rubberbandDistance = 0.00001f;
	private float lerpRate = 16f;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMotion ();
		RubberbandPostion ();
		//ShowLatency ();
	}

	void FixedUpdate (){
		TransmitPosition ();
	}

	[Client]
	void SyncPositionValues (Vector2 latestPos){
		syncPos = latestPos;
	}

	[ClientCallback]
	void TransmitPosition (){
		if(isLocalPlayer && Vector2.Distance(this.transform.position, syncPos) > threshold)
		{
			CmdProvidePositionToServer(this.transform.position);
		}
	}

	[Command]
	void CmdProvidePositionToServer (Vector2 pos){
		syncPos = pos;
	}

	void UpdateMotion(){
		

	}
	void RubberbandPostion(){
		if (!isLocalPlayer) {
			if (Vector2.Distance (this.transform.position, syncPos) > rubberbandDistance) {
				this.transform.position = Vector2.Lerp(this.transform.position, syncPos, Time.deltaTime * lerpRate);
				print ("Lerping");
			}
		}
	}
}
