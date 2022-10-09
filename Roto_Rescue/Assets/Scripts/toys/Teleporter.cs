using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
	public GameObject alphaIn;
	public GameObject alphaOut1;
	public GameObject alphaOut2;
	private float alphaOut1pos;
	private float alphaOut2pos;
	private Vector3 spawnPosX;
	private Quaternion spawnRot;

	public GameObject objectSpawned;

	public int propsIn;

	public void PropGoIn()
	{
		propsIn++;
		PropOut();
	}

	public void PropOut()
	{
		alphaOut1pos = alphaOut1.transform.position.x;
		alphaOut2pos = alphaOut2.transform.position.x;

		spawnPosX = new Vector3(Random.Range(alphaOut1pos, alphaOut2pos), alphaOut1.transform.position.y, 0f);
		spawnRot = Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f));
		Instantiate(objectSpawned, spawnPosX, spawnRot);
		propsIn--;
	}
}
