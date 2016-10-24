using UnityEngine;
using System.Collections;

public class TestObj : MonoBehaviour {

	public GameObject emitter;

	void Start () {
	
	}
	
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			FireworksManager.CreateFireWorks (emitter, Vector3.right * Random.Range (-6.0f, 6) + Vector3.down * 4, Fireworks.A);
		}
	}
}
