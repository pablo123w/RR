using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClawStart2 : MonoBehaviour
{
    //reference HeloMovement to get inertia for goober
    private HeloMovement HM;

    public PlayerMain Ply;
    public GameObject Rope;
    private GameObject ObjectAbtInQuestion;
    private GameObject ObjectInQuestion;
    public Animator Animator;
    public Rigidbody ClawRigidbody;
    public GameObject Claw;
    private bool HadParent;
    private bool IsGoober = false;

    private GameObject TempParent;

    private bool CanGrabSomething = false;

	private void Start()
	{
        HM = Ply.gameObject.GetComponent<HeloMovement>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
		{
            CanGrabSomething = true;
            ObjectAbtInQuestion = other.transform.gameObject;
        }
        if (other.CompareTag("C_Goober"))
		{
            CanGrabSomething = true;
            ObjectAbtInQuestion = other.transform.gameObject;
        }
        if (other.CompareTag("Destructible"))
        {
            CanGrabSomething = true;
            ObjectAbtInQuestion = other.transform.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickupable") || other.CompareTag("C_Goober"))
		{
            CanGrabSomething = false;
            ObjectAbtInQuestion = null;
        }
    }

    public void Pickup(InputAction.CallbackContext context)
    {
        if (context.started)
		{
            if (CanGrabSomething)
            {
                {
                    ObjectInQuestion = ObjectAbtInQuestion;

					if (ObjectInQuestion.transform.root.CompareTag("C_Goober"))
					{
                        Debug.Log("Its a goober");
                        IsGoober = true;
					}

                    goobScript GS = ObjectInQuestion.transform.root.GetComponent<goobScript>();
                    if (GS != null)
                    {
                        GS.TellGrabbed();
                    }

                    //check if object has parent or not
                    if(ObjectInQuestion.transform.parent == null)
                    {
                        TempParent = ObjectInQuestion.transform.gameObject;
                        HadParent = false;
                    }
					else
					{
                        TempParent = ObjectInQuestion.transform.parent.gameObject;
                        HadParent = true;
                    }

                    ObjectInQuestion.transform.parent = gameObject.transform;

					//add joint to picked up object
					if (ObjectInQuestion.GetComponent<Rigidbody>() != null && IsGoober == false)
					{
						ObjectInQuestion.AddComponent<ConfigurableJoint>();
						ObjectInQuestion.GetComponent<ConfigurableJoint>().connectedBody = ClawRigidbody;
                        
                        ObjectInQuestion.GetComponent<ConfigurableJoint>().anchor = Vector3.zero;
                        ObjectInQuestion.GetComponent<ConfigurableJoint>().connectedAnchor = Vector3.zero;
                        ObjectInQuestion.GetComponent<ConfigurableJoint>().xMotion = ConfigurableJointMotion.Locked;
                        ObjectInQuestion.GetComponent<ConfigurableJoint>().yMotion = ConfigurableJointMotion.Locked;
                        ObjectInQuestion.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
                        //ObjectInQuestion.GetComponent<CharacterJoint>().connectedAnchor = ClawRigidbody.transform.position;
                        //ObjectInQuestion.GetComponent<CharacterJoint>().anchor = ClawRigidbody.transform.localPosition;
                    }

					//animate
					Animator.SetBool("isClosed", true);

                    Rigidbody rb = ObjectInQuestion.GetComponent<Rigidbody>();
                    rb.velocity = Vector3.zero;
                    rb.useGravity = true;
					if (IsGoober)
					{
                        rb.isKinematic = true;
                    }
                }
            }
            //animate
            Animator.SetBool("isClosed", true);
        }

        else if (context.canceled)
        {
            //animate
            Animator.SetBool("isClosed", false);

            if (ObjectInQuestion == null) return;

            Rigidbody rb = ObjectInQuestion.GetComponent<Rigidbody>();

			if (HadParent)
			{
                ObjectInQuestion.transform.SetParent(TempParent.transform, true);
            }
			else
			{
                ObjectInQuestion.transform.parent = null;
			}
            HadParent = false;

			//delete joint
			if (ObjectInQuestion.GetComponent<ConfigurableJoint>() != null && IsGoober == false)
			{
				Destroy(ObjectInQuestion.GetComponent<ConfigurableJoint>());
			}
            rb.useGravity = true;
            rb.isKinematic = false;

            goobScript GS = ObjectInQuestion.transform.root.GetComponent<goobScript>();
            if (GS != null)
            {
                GS.IsGrabbed = false;
            }

            Rigidbody rootrb = ObjectInQuestion.transform.root.gameObject.GetComponent<Rigidbody>();
            if (rootrb != null)
			{
                ObjectInQuestion.transform.root.gameObject.GetComponent<Rigidbody>().velocity = HM.rb.velocity;
            }
			else
			{
                rb.velocity = HM.rb.velocity;
            }

            ObjectInQuestion = null;
            TempParent = null;
            IsGoober = false;

        }
    }
}

