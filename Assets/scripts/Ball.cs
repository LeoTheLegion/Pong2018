using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public int speed = 100;
	public Vector2 starting_direction = Vector2.up + Vector2.left;
	
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (starting_direction* speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
