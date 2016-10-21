﻿using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	float rev = 0;

	Vector3 velocity = Vector3.zero;


	public void Init (Vector3 vel) {

		velocity = vel;
	}

	void Start () {
		
		GetComponent<SpriteRenderer> ().color = new Color (Random.value, Random.value, Random.value, 1);

		rev = Random.Range (-1.0f, 1.0f);

		Destroy (gameObject, 2.0f);
	}
	
	void Update () {

		velocity *= 0.95f;
		transform.position += velocity;
		transform.rotation = Quaternion.AngleAxis (rev * 50, Vector3.forward) * transform.rotation;
		transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.05f);
	}
}