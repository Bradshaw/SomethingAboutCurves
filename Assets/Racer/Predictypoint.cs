using UnityEngine;
using System.Collections;

public class Predictypoint : MonoBehaviour {

	public Rigidbody2D rig;
	public float velocityFactor = 1;
	public float aheadFactor = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = rig.position.xy_ () + rig.velocity.xy_ ()*velocityFactor + rig.transform.up*aheadFactor;
	}
}
