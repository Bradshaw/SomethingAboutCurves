using UnityEngine;
using System.Collections;

public class Jump2D : MonoBehaviour {

	public GameObject firstJumpPuff;
	public GameObject multiJumpPuff;
	public GameObject landingPuff;
	public float minHeight;
	public float maxHeight;
	public float jumpTime;
	public float boostTime;
	public AnimationCurve jumpCurve;
	public AnimationCurve boostCurve;
	public int maxJumpLevel;

	public Vector2 size;

	float jumpingTime = 0;
	float boostingTime = 0;
	[HideInInspector]
	public bool jumping = false;
	int jumpLevel;
	float boost = 0;
	float startHeight = 0;
	float velocity;


	float dropSpeed {
		get {
			float pt1 = jumpCurve.Evaluate (0.99f);
			float pt2 = jumpCurve.Evaluate (1);
			return (pt2 - pt1) * 100;
		}
	}

	float slopeStart {
		get {
			float start = 1;
			float val = -1;
			while (val < jumpCurve.Evaluate (start)) {
				//Debug.Log ("Descending: " + val);
				val = jumpCurve.Evaluate (start);
				start -= 0.01f;
			}
			return start;
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (jumping) {
			//float boostAmount = 
			float jumpValue = (Time.time - jumpingTime) / jumpTime;
			float height = startHeight + maxHeight * jumpCurve.Evaluate (jumpValue);

			Vector2 nextpos;
			new Vector2 (transform.position.x, height);
			if (jumpValue <= 1) {
				velocity = (height - transform.position.y) / Time.deltaTime;
				nextpos = new Vector2 (transform.position.x, height);
			} else {
				nextpos = new Vector2 (transform.position.x, transform.position.y + ((dropSpeed * maxHeight) / jumpTime) * Time.deltaTime);
			}
				
			Collider2D other = Physics2D.OverlapArea (nextpos - Vector2.right * size.x / 2, nextpos + Vector2.up * size.y + Vector2.right * size.x / 2);

			if (other != null) {
				Debug.Log ("Oops");
				if (nextpos.y > transform.position.y) {
					startHeight -= nextpos.y - transform.position.y;
					nextpos.y = other.bounds.min.y - size.y - 0.1f;
					jumpingTime = Time.time - (slopeStart * jumpTime);
				} else {
					nextpos = new Vector2 (transform.position.x, other.bounds.max.y);
					GameObject puff = GameObject.Instantiate (landingPuff);
					puff.transform.position = nextpos;
					jumping = false;
					jumpLevel = 0;
				}
			}
			transform.position = nextpos;
		} else {
			Collider2D other = Physics2D.OverlapArea (transform.position.xy() - Vector2.right * size.x / 2, transform.position.xy() + Vector2.down * 0.1f + Vector2.right * size.x / 2);
			if (other == null) {
				jumping = true;
				jumpingTime = Time.time - (slopeStart * jumpTime);
				startHeight = transform.position.y - maxHeight;
			}
		}
		if (jumpLevel<maxJumpLevel && Input.GetKeyDown(KeyCode.Space)){
			
			GameObject puff;
			if (jumpLevel==0)
				puff = GameObject.Instantiate (firstJumpPuff);
			else
				puff = GameObject.Instantiate (multiJumpPuff);
			puff.transform.position = transform.position;
			triggerJump();
		}
	}

	public void triggerJump(){
		jumpLevel++;
		jumping = true;
		jumpingTime = Time.time;
		boost = 0;
		startHeight = transform.position.y;
	}

}
