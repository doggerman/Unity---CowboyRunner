using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private float speed = -3f;

	private Rigidbody2D myBody;

	void Awake()
	{
		myBody = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myBody.velocity = new Vector2 (speed, 0f);
	
	}
}
