using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollows : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;

	public float startingY;

	// Use this for initialization
	void Start()
	{
		startingY = transform.position.y;
		
		   
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

			targetPos.y = startingY;

			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
			
		}
	}


}