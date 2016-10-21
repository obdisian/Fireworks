using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

	float rev = 0;

	Vector3 velocity = Vector3.zero;

	Color alpha0 = new Color (1, 1, 1, 0);

	public void Init (Vector3 vel) {

		velocity = vel;
	}

	void Start () {
		
		GetComponent<SpriteRenderer> ().color = new Color (Random.value, Random.value, Random.value, 1);
		alpha0 = GetComponent<SpriteRenderer> ().color;
		alpha0.a = 0;

		rev = Random.Range (-1.0f, 1.0f);

		Destroy (gameObject, 2.0f);
	}
	
	void Update () {

		velocity *= 0.95f;
		transform.position += velocity;
		transform.rotation = Quaternion.AngleAxis (rev * 50, Vector3.forward) * transform.rotation;
//		transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.05f);

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.Lerp (sr.color, alpha0, 0.05f);
	}
}
