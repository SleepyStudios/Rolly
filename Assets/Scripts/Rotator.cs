using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	void Update() {
		float speed = 30;

		transform.Rotate(new Vector3(speed, speed*2, speed*3) * Time.deltaTime);
    }
}
