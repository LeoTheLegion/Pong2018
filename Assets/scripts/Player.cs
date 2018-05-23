using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {



	// Use this for initialization
	void Start () {
		if (isServer) {
			this.transform.position = GameObject.Find ("Player1_spawn").transform.position;
		} else {
			this.transform.position = GameObject.Find ("Player2_spawn").transform.position;
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			var mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2 (transform.position.x, mouse.y);
		}
	}

	void OnCollisionEnter2D (Collision2D col){	
		if (col.gameObject.GetComponent<Ball> () != null) {
			print ("speeding up");
			col.rigidbody.velocity *= 1.1f;
		}
	}
}
