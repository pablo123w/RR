using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    float speedRot = .1f;
    private void Update()
    {
        transform.LookAt(speedRot * new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
    }

}
