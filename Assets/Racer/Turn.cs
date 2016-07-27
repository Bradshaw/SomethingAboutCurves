using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Turn : MonoBehaviour {

	Rigidbody2D rig;
	public KeyCode left;
	public KeyCode right;
	public float torque;
	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rig.AddTorque(torque * -Input.GetAxis("Horizontal"));

		if (Input.GetKey (left)) {
			rig.AddTorque (torque);
		}
		if (Input.GetKey (right)) {
			rig.AddTorque (-torque);
		}

	}
}
