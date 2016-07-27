using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		StartCoroutine (Destroy (time));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Destroy(float t){
		yield return new WaitForSeconds (t);
		GameObject.Destroy (this.gameObject);
	}
}
