using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeloMovement : MonoBehaviour
{
    public Rigidbody rb;
	 
    public float lHorizontal;
	public float lVertical;
	public float maxSpeed;
	public float speed = 2f;
	

	//autostabilize after rotating off center
	public float stability;
	public float stabilityspeed;
	 
	//animate rotation with movement
	public float rotatesmooth = 1f;
	public float tiltAngle;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

		rb.AddForce(lHorizontal * speed * (Time.deltaTime * 10000), lVertical * speed * (Time.deltaTime * 10000), 0, ForceMode.Acceleration);
		//rotate helo with movement
		float tiltAroundZ = lHorizontal * tiltAngle;
		Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotatesmooth);

		//cap max speed for helicopter

		if (rb.velocity.magnitude >= maxSpeed)
		{
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}

		//if (lVertical == 0f)
		//{
		//	rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime, 0);
		//}

		//if (lHorizontal == 0f)
		//{
		//	rb.velocity = new Vector3(rb.velocity.x * 0.5f * Time.deltaTime, rb.velocity.y, 0);
		//}

	}

	private void FixedUpdate()
	{
		Vector3 predictedUp = Quaternion.AngleAxis(
		 rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilityspeed,
		 rb.angularVelocity
	 ) * transform.up;

		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rb.AddTorque(torqueVector * stabilityspeed);
	}

	public void Move(InputAction.CallbackContext context)
	{
        lHorizontal = context.ReadValue<Vector2>().x;
		lVertical = context.ReadValue<Vector2>().y;

	}

	//private void StabilizeVertical()
	//{
	//	rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.99f * Time.deltaTime, 0);
	//}

	//private void StabilizeHorizontal()
	//{
	//	rb.velocity = new Vector3(rb.velocity.x * 0.99f * Time.deltaTime, rb.velocity.y, 0);
	//}

}
