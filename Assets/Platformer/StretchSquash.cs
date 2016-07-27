using UnityEngine;
using System.Collections;

public class StretchSquash : MonoBehaviour {

	public float squishScale = 1;
	public float spring = 10;
	public float damp = 1;

	float dheight;
	float dvel;


	// Use this for initialization
	void Start () {
		dvel = 0;
		dheight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float diff = transform.position.y - dheight;
		dvel += diff * Time.deltaTime * spring - dvel * Time.deltaTime * damp;
		dheight += dvel * Time.deltaTime;
		transform.localScale = Vector3.one + Vector3.up * Mathf.Max(-1,(dheight - transform.position.y)*squishScale);
	}
}
