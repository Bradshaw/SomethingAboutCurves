using UnityEngine;
using System.Collections;

public enum RunDirection{
	LEFT,
	RIGHT
}

[RequireComponent(typeof(Jump2D))]
public class Run2D : MonoBehaviour {

	public float floorAccel;
	public float floorDamp;
	public float airAccel;
	public float airDamp;
	public float epsilon;

	[HideInInspector]
	public RunDirection direction = RunDirection.RIGHT;
	[HideInInspector]
	public float xvel = 0;
	Jump2D jump2d;

	public Vector2 size;

	// Use this for initialization
	void Start () {
		jump2d = GetComponent<Jump2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (jump2d.jumping) {
			xvel += (Input.GetAxis ("Horizontal") * airAccel - xvel * airDamp) * Time.deltaTime;
		} else {
			xvel += (Input.GetAxis ("Horizontal") * floorAccel - xvel * floorDamp) * Time.deltaTime;
		}

		Vector2 nextpos = transform.position.xy() + Vector2.right * xvel * Time.deltaTime;

		Collider2D other = Physics2D.OverlapArea(nextpos - Vector2.right*size.x/2+ Vector2.up*0.1f, nextpos + Vector2.up * size.y + Vector2.right*size.x/2);
		if (other == null) {
			transform.SetX (transform.position.x + xvel * Time.deltaTime);
		}

		//transform.SetX (transform.position.x + xvel * Time.deltaTime);
		if (Input.GetAxis ("Horizontal") > 0.1) {
			direction = RunDirection.RIGHT;
		} else if (Input.GetAxis ("Horizontal") < -0.1) {
			direction = RunDirection.LEFT;
		}
	}
}
