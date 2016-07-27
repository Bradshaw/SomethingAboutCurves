using UnityEngine;
using System.Collections;

public class Follow2D : MonoBehaviour {

	public Transform follow;
	Vector2 vel;
	public float smoothTime;
	float z;

	// Use this for initialization
	void Start () {
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = transform.position.xy ();
		pos = Vector2.SmoothDamp (pos, follow.position.xy (), ref vel, smoothTime);
		transform.position = pos.xy_ (z);
	}
}
