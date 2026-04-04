using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem : MonoBehaviour
{

	public float spinSpeedX = 0f;
	public float spinSpeedY = 100.0f;
	public float spinSpeedZ = 0f;

	//Can use to spin an object XYZ at any speed
	void Update()

	{
		transform.Rotate(new Vector3(Time.deltaTime * spinSpeedX, Time.deltaTime * spinSpeedY, Time.deltaTime * spinSpeedZ));
	}
}
