using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class AnisoDrag2D : MonoBehaviour {

	Rigidbody2D rig;
	public float maxResponse;
	public float xDragFactor;
	public AnimationCurve xDragResponse;
	public float yDragFactor;
	public AnimationCurve yDragResponse;
	public KeyCode brakeButton;


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
		vel.x = vel.x * xDragFactor * xDragResponse.Evaluate(Mathf.Abs(vel.x/maxResponse));
		vel.y = vel.y * yDragFactor * yDragResponse.Evaluate(Mathf.Abs(vel.y/maxResponse))*(Input.GetKey(brakeButton)?5:1);
		cs = Mathf.Cos (r);
		sn = Mathf.Sin (r);
		vel = new Vector2 (
			vel.x * cs - vel.y * sn,
			vel.x * sn + vel.y * cs
		);
		Debug.DrawRay (rig.position, -vel.xy_ ()/5, Color.cyan);
		Debug.DrawRay (rig.position, rig.velocity.xy_()/5, Color.red);
		rig.AddForce (-vel);
	}
}
