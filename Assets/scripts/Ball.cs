using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce ((Vector2.up + Vector2.left) * 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
