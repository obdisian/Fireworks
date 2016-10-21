using UnityEngine;
using System.Collections;

public class FireworksManager : MonoBehaviour {

	public static void CreateFireWorks (GameObject emitter, Vector3 pos, string[] fire) {

		GameObject obj = Instantiate (emitter, pos, Quaternion.identity) as GameObject;
		obj.GetComponent<Emitter> ().Init (60, 0.1f, fire);
	}
}
