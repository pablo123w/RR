using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeloTools : MonoBehaviour
{
    private HeloInput playerInputActions;
    Vector2 targetPosition;

    public GameObject harpoon;
    public GameObject gunPivot;
    private GameObject gunEnd;

    void Start()
	{
        playerInputActions = new HeloInput();
        playerInputActions.Enable();
        gunPivot = GameObject.Find("gunPivot");
        gunEnd = GameObject.Find("railgun_placeholder");
	}


    public void Aim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            targetPosition = context.ReadValue<Vector2>();
            if (targetPosition.y < 0)
                gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, targetPosition);
            else if (targetPosition.y > 0 && targetPosition.x < 0)
                gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.left);
            else if (targetPosition.y > 0 && targetPosition.x > 0)
                gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.right);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
	{
        if (context.performed)
		{
            var instance = Instantiate(harpoon, gunEnd.transform.position, gunEnd.transform.rotation);
            instance.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(20, 0, 0), ForceMode.Impulse);
		}
	}
}