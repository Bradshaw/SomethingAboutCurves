using UnityEngine;
using System.Collections;

public class ScaleByThrust : MonoBehaviour {

	public Thruster2D thruster;
	public float minScale;
	public float maxScale;
	[Range(0,1)]
	public float randomness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one * Mathf.Sqrt(Mathf.Lerp (minScale, maxScale, thruster.thrusting)*Mathf.Lerp(1-randomness, 1, Random.value));
	}
}
