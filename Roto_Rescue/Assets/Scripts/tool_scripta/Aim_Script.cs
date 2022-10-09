using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aim_Script : MonoBehaviour
{
    Vector2 targetPosition;
    public GameObject gunPivot;
    public GameObject gunEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
