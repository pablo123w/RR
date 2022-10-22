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
    public ConfigurableJoint GrabPos;
    private bool IsGoober = false;
    private GameObject TempParent;
    private bool CanGrabSomething = false;

    //lights
    public GameObject ClawLight;
    public Material RedLight;
    public Material GreenLight;
    public Material YellowLight;

    private void Start()
	{
        HM = Ply.gameObject.GetComponent<HeloMovement>();
        GrabPos = GetComponent<ConfigurableJoint>();
        ClawLight.GetComponent<MeshRenderer>().material = RedLight;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
		{
            CanGrabSomething = true;
            ClawLight.GetComponent<MeshRenderer>().material = GreenLight;
            ObjectAbtInQuestion = other.transform.gameObject;
        }
        if (other.CompareTag("C_Goober"))
		{
            CanGrabSomething = true;
            ClawLight.GetComponent<MeshRenderer>().material = YellowLight;
            ObjectAbtInQuestion = other.transform.gameObject;
        }
        if (other.CompareTag("Destructible"))
        {
            CanGrabSomething = false;
            ObjectAbtInQuestion = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickupable") || other.CompareTag("C_Goober"))
		{
            CanGrabSomething = false;
            ClawLight.GetComponent<MeshRenderer>().material = RedLight;

            ObjectAbtInQuestion = null;
        }
    }

    public void Pickup(InputAction.CallbackContext context)
    {
        if (context.performed)
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
                    Debug.Log(ObjectInQuestion.transform.parent);
                    if(ObjectInQuestion.transform.parent == null)
                    {
                        TempParent = null;
                    }
					else
					{
                        TempParent = ObjectInQuestion.transform.parent.gameObject;
                    }

                    //SET THE MF PARENT FINALLY
                    ObjectInQuestion.transform.parent = gameObject.transform;
                    Rigidbody rb = ObjectInQuestion.GetComponent<Rigidbody>();

					//add joint to picked up object
					if (rb != null && !IsGoober)
					{
                        GrabPos.connectedBody = rb;
                        GrabPos.anchor = Vector3.zero;
                        GrabPos.connectedAnchor = Vector3.zero;
                    }

					//animate
					Animator.SetBool("isClosed", true);

                    rb.velocity = Vector3.zero;
                    rb.useGravity = true;

                    //set goober to kinematic
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
            ClawLight.GetComponent<MeshRenderer>().material = RedLight;

            if (ObjectInQuestion == null) return;

            Rigidbody rb = ObjectInQuestion.GetComponent<Rigidbody>();

            if(TempParent == null)
			{
                Debug.Log("iss null");
                ObjectInQuestion.transform.SetParent(null, true);
            }
			else
			{
                Debug.Log("not null :)");
                ObjectInQuestion.transform.SetParent(TempParent.transform, true);
            }
            

			//delete joint
			if (!IsGoober)
			{
                GrabPos.connectedBody = null;
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

