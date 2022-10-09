using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrompts : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    public bool ShowOnce;
    private bool HasShown = false;

    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag=="Player")
        {
            if (ShowOnce && HasShown == false)
            {
                uiObject.SetActive(true);
                HasShown = true;
            }
			else if (ShowOnce == false)
			{
                uiObject.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider player)
    {
        if(player.gameObject.tag=="Player")
        {
            uiObject.SetActive(false);
        }
    }
}
