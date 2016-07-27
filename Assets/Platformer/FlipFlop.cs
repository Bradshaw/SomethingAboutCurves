using UnityEngine;
using System.Collections;

public class FlipFlop : MonoBehaviour {

	RunDirection direction;
	Run2D run2d;
	// Use this for initialization
	void Start () {
		run2d = GetComponentInParent<Run2D> ();
		direction = run2d.direction;
	}
	
	// Update is called once per frame
	void Update () {
		if (direction != run2d.direction) {
			direction = run2d.direction;
			foreach (Transform t in transform) {
				SpriteRenderer sr = t.GetComponent<SpriteRenderer> ();
				if (sr != null)
					sr.flipX = (direction == RunDirection.LEFT);
			}
		}
	}
}
