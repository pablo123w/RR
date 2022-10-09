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
	public float stability = 0.3f;
	public float stabilityspeed = 2.0f;

	//animate rotation with movement
	float rotatesmooth = 1f;
	float tiltAngle = -15f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		rb.AddRelativeForce(lHorizontal * speed, lVertical * speed, 0, ForceMode.Acceleration);

		//rotate helo with movement
		float tiltAroundZ = lHorizontal * tiltAngle;
		Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotatesmooth);

		//cap max speed for helicopter
		//Debug.Log(rb.velocity.magnitude);
		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
		}

		if (lVertical == 0f)
		{
			StabilizeVertical();
		}

		if (lHorizontal == 0f)
		{
			StabilizeHorizontal();
		}

    }

	private void FixedUpdate()
	{
		Vector3 predictedUp = Quaternion.AngleAxis(
		 rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
		 rb.angularVelocity
	 ) * transform.up;

		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rb.AddTorque(torqueVector * speed * speed);
	}

	public void Move(InputAction.CallbackContext context)
	{
        lHorizontal = context.ReadValue<Vector2>().x;
		lVertical = context.ReadValue<Vector2>().y;
	}

	private void StabilizeVertical()
	{
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.99f, 0);
	}

	private void StabilizeHorizontal()
	{
		rb.velocity = new Vector3(rb.velocity.x*0.99f, rb.velocity.y, 0);
	}

}
