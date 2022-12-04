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

	public float SpawnTime = 0.5f;

	public GameObject objectSpawned;

	public int propsIn;
	private bool SpawnReady = true;

	//public void PropGoIn(Vector3 ObjectVelocity)
	//{
	//	propsIn++;
	//	PropOut();
	//}

	private void Update()
	{
		if (SpawnReady)
		{
			StartCoroutine(SpawnCycle());
		}
	}

	private IEnumerator SpawnCycle()
	{
		PropOut();
		SpawnReady = false;
		yield return new WaitForSeconds(SpawnTime);
		SpawnReady = true;
	}

	public void PropOut()
	{
		alphaOut1pos = alphaOut1.transform.position.x;
		alphaOut2pos = alphaOut2.transform.position.x;

		spawnPosX = new Vector3(Random.Range(alphaOut1pos, alphaOut2pos), alphaOut1.transform.position.y, 2f);
		spawnRot = Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f));
		GameObject NewProp = Instantiate(objectSpawned, spawnPosX, spawnRot);
		//propsIn--;
	}
}
