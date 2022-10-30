using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawTut : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GoobArrow;
    public GameObject TubeArrow;
    public GameObject RT;
    public GameObject LS;
    public GameObject ReleaseRT;
    public GameObject LSTrigger;
    public GameObject ReleaseRTTrigger;
    public GameObject GoobTrigger;

    void Start()
    {
        RT.SetActive(false);
        ReleaseRT.SetActive(false);
    }

    //turn off LS prompt
    public void TurnOffLSPrompt()
	{
        Debug.Log("setting active");
        LS.SetActive(false);
	}

    //pick up goober prompt

    public void PickUpPromptOn()
	{
        GoobArrow.SetActive(false);
        RT.SetActive(true);
	}

    public void PickUpPromptOff()
	{
        GoobArrow.SetActive(true);
        RT.SetActive(false);
    }

    public void Release()
	{
        ReleaseRT.SetActive(true);
        RT.SetActive(false);
	}


}
