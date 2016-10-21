using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

	float rev = 0;

	void Start () {

		GetComponent<SpriteRenderer> ().color = new Color (Random.value, Random.value, Random.value, 1);

		rev = Random.Range (-1.0f, 1.0f);

		Destroy (gameObject, 2.0f);
	}
	
	void Update () {

		transform.rotation = Quaternion.AngleAxis (rev * 20, Vector3.forward) * transform.rotation;
		transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
	}
}
