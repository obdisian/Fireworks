using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {


	Vector3 vel = Vector3.zero;
	Quaternion quat = Quaternion.identity;
	Color alpha0 = new Color (1, 1, 1, 0);
	SpriteRenderer sr;


	public void Init (Vector3 vel, Quaternion quat, Color color) {

		this.vel = vel;
		this.quat = quat;

		sr = GetComponent<SpriteRenderer> ();
		sr.color = color;
		alpha0 = new Color (color.r, color.g, color.b, 0);
	}


	public void Move () {

		vel *= 0.95f;
		transform.position += vel;
		transform.rotation = quat * transform.rotation;
		//		transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.05f);

		sr.color = Color.Lerp (sr.color, alpha0, 0.05f);
	}


	public void Kill () {

		Destroy (gameObject);
	}
}
