using UnityEngine;
using System.Collections;

public class MPCController : MonoBehaviour {

	public float MPCmaxSpeed;
	bool MPCfacingRight=true;
	//public Vector2 a;
	Rigidbody2D MPCRigidBodyOfChar;
	Animator MPCAnimatorOfChar;
	// Use this for initialization
	void Start () {
		MPCRigidBodyOfChar = GetComponent<Rigidbody2D> ();
		MPCAnimatorOfChar = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		MPCAnimatorOfChar.SetFloat("MPCRunning",Mathf.Abs(move));
		MPCRigidBodyOfChar.velocity=new Vector2(move*MPCmaxSpeed,MPCRigidBodyOfChar.velocity.y);
		if (move > 0 && !MPCfacingRight)
			flip ();
		else if (move < 0 && MPCfacingRight)
			flip ();
		
	}
	void flip(){
		Vector3 MPCscale = transform.localScale;
		MPCscale.x *= -1;
		transform.localScale = MPCscale;
		MPCfacingRight = !MPCfacingRight;
	}
}
