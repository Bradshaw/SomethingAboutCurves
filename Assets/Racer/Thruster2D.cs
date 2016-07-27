using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Thruster2D : MonoBehaviour {

	Rigidbody2D rig;

	public float maxThrust;
	public float minThrust;
	public float maxSpeed;
	public AnimationCurve thrustProfile;
	[Range(0,1)]
	public float tpCursor;

	public KeyCode thrustButton;

	public float currentThrust;
	public float currentVelocity;
	public float thrusting;



	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vel = rig.velocity;
		float r = rig.rotation*Mathf.Deg2Rad;
		float cs = Mathf.Cos (-r);
		float sn = Mathf.Sin (-r);
		vel = new Vector2 (
			vel.x * cs - vel.y * sn,
			vel.x * sn + vel.y * cs
		);
		Debug.DrawRay (transform.position+(transform.right*0.1f), transform.up * vel.y * 0.2f,Color.red);
		Debug.DrawRay (transform.position, transform.up * Mathf.Lerp(minThrust, maxThrust, thrustProfile.Evaluate (vel.y / maxSpeed)) * 0.3f,Color.cyan*0.5f);
		if (Input.GetKey (thrustButton)) {


			Debug.DrawRay (transform.position, transform.up * Mathf.Lerp (minThrust, maxThrust, thrustProfile.Evaluate (vel.y / maxSpeed)) * 0.3f, Color.cyan);
			rig.AddForce (transform.up * Mathf.Lerp (minThrust, maxThrust, thrustProfile.Evaluate (vel.y / maxSpeed)));
			thrusting = thrustProfile.Evaluate (vel.y / maxSpeed);
		} else {
			thrusting = 0;
		}
		tpCursor = rig.velocity.magnitude / maxSpeed;
		currentThrust = Mathf.Lerp (minThrust, maxThrust, thrustProfile.Evaluate (vel.y / maxSpeed));
		currentVelocity = vel.y;
	}
}
