using UnityEngine;
using System.Collections;

public class PlayerDied : MonoBehaviour {

	public delegate void EndGame();
	public static event EndGame endGame;

	void PlayerDiedEndGame()
	{
		if (endGame != null) {
			endGame();
		}

		Destroy (gameObject);
	}

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D target) {

		if (target.tag == "Collector") {
			PlayerDiedEndGame();
		}
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D target) {

		if (target.gameObject.tag == "Zombie") {
			PlayerDiedEndGame();
		}
	
	}
}
