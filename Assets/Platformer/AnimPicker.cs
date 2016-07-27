using UnityEngine;
using System.Collections;

public class AnimPicker : MonoBehaviour {

	public GameObject stepPuff;
	public Jump2D jump2d;
	public Run2D run2d;

	public GameObject idle;
	public GameObject jump;
	public GameObject walk1;
	public GameObject walk2;

	bool leftstep = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (jump2d.jumping) {
			idle.SetActive (false);
			jump.SetActive (true);
			walk1.SetActive (false);
			walk2.SetActive (false);
		} else if (Mathf.Abs(run2d.xvel) < 0.1) {
			idle.SetActive (true);
			jump.SetActive (false);
			walk1.SetActive (false);
			walk2.SetActive (false);
		} else {
			bool frame = ((Time.time*10) % 2 > 1);
			idle.SetActive (false);
			jump.SetActive (false);
			walk1.SetActive (frame);
			walk2.SetActive (!frame);
			if (frame != leftstep) {
				GameObject puff = GameObject.Instantiate (stepPuff);
				puff.transform.position = transform.position;
				leftstep = frame;
			}
		}
	}
}
