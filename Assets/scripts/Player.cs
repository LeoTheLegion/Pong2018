using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector2(transform.position.x, mouse.y);
	}
}
