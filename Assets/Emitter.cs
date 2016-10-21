using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Emitter : MonoBehaviour {


	public GameObject particle;
	public GameObject trail;


	int timer = 0;
	int limitTime = 0;

	float speed = 1;

	List<string> fireworks = new List<string> ();


	public void Init (int limitTime, float speed, string[] fireworks) {

		this.limitTime = limitTime;
		this.speed = speed;

		for (int i = 0; i < fireworks.Length; i++) {
			this.fireworks.Add (fireworks [i]);
		}
	}

	void Start () {
	
	}
	
	void Update () {

		timer++;
		if (limitTime < timer) {

			CreateParticle ();
			Destroy (gameObject);
			return;
		}

		transform.position = transform.position + Vector3.up * speed;
		if (timer % 3 == 0) {
			Instantiate (trail, transform.position, Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward));
		}
	}


	void CreateParticle () {

		if (fireworks.Count == 0) {

			int num = 36;
			for (int i = 0; i < num; i++) {

				float speed = 0.3f;

				const float Pi2 = Mathf.PI * 2;
				Vector3 vel = new Vector3 (Mathf.Cos (Pi2 / num * i), Mathf.Sin (Pi2 / num * i), 0) * speed;

				GameObject obj = Instantiate (particle, transform.position, Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward)) as GameObject;
				obj.GetComponent<Particle> ().Init (vel);
			}
		}
		else {

			float width = fireworks [0].Length;
			float height = fireworks.Count;

			Vector3 center = new Vector3 (width / 2, -height / 2, 0);

			for (int y = 0; y < fireworks.Count; y++) {
				for (int x = 0; x < fireworks [0].Length; x++) {

					float speed = 0.05f;
					Vector3 vel = (new Vector3 (x, -y, 0) - center) * speed;

					switch (fireworks [y] [x]) {
					case '#':
						GameObject obj = Instantiate (particle, transform.position, Quaternion.AngleAxis (Random.Range (0, 360), Vector3.forward)) as GameObject;
						obj.GetComponent<Particle> ().Init (vel);
						break;
					default: break;
					}
				}
			}
		}
	}
}
