using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject right;
	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject firstPosition;
	public bool start;
	bool moving = true;
	public static int number = 0;
	public GameObject stack;
	public static GameObject newStack;
	public static GameObject oldStack;
	private bool create = true;
	Vector3 Vector3;
	public enum MyEnum
	{
		righ,
		left,
		down,
		up
	}

	public static MyEnum way;

	// Start is called before the first frame update
	void Start()
	{
		//newStack = Instantiate(stack,firstPosition.transform.position,firstPosition.transform.rotation);
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 = new Vector3(0, (float)0.3 * number, 0);
		move();
		//Debug.Log(newStack.transform.position);
		//Debug.Log(oldStack.transform.position);
	}

	void move()
	{
		if (number % 2 == 1 && Time.timeScale == 1)
		{
			if (create)
			{
				newStack = Instantiate(stack, right.transform.position+Vector3, right.transform.rotation);
				create =false;
				moving = true;
				way = MyEnum.righ;
			}
		}
		if (number % 2 == 0 && Time.timeScale == 1)
		{
			if (create)
			{
				newStack = Instantiate(stack, up.transform.position + Vector3, up.transform.rotation);
				create = false;
				moving = true;
				way = MyEnum.down;
			}
		}
		if (newStack != null && moving)
		{
			switch (way)
			{
				case MyEnum.left:
					newStack.transform.Translate(Vector3.right * Time.deltaTime * 5);
					break;
				case MyEnum.righ:
					newStack.transform.Translate(Vector3.left * Time.deltaTime * 5);
					break;
				case MyEnum.down:
					newStack.transform.Translate(Vector3.back * Time.deltaTime * 5); ;
					break;
				case MyEnum.up:
					newStack.transform.Translate(Vector3.forward * Time.deltaTime * 5);
					break;
			}
		}
		breakCube();
	}
	void breakCube()
	{
		if (!MenuController.menuOpen)
		{
			if (Input.GetMouseButtonDown(0))
			{
				//cut(newStack,oldStack);
				oldStack = newStack;
				oldStack.transform.Translate(Vector3.zero);
				moving = false;
				number++;
				create = true;
				oldStack.GetComponent<Rigidbody>().isKinematic=false;
				oldStack.GetComponent<Rigidbody>().useGravity=true;
				Destroy(oldStack.GetComponent<GameController>());
			}
			
		}
	}

	public static void cut(GameObject newStack,GameObject oldstack)
	{
		Vector3 position = oldstack.transform.position - newStack.transform.position ;
		float scaleZ;
		float scaleX;
		
		if (number%2==1)
		{
			if (oldstack.transform.position.z - newStack.transform.position.z < 0)
			{
				scaleZ = newStack.transform.localScale.z - ((oldstack.transform.position.z - newStack.transform.position.z) * -1);
				//scaleZ = (newStack.transform.localScale.z - newStack.transform.position.z) * -1;
			}
			else
			{
				scaleZ = newStack.transform.localScale.z - (oldstack.transform.position.z - newStack.transform.position.z);
				//scaleZ = (newStack.transform.localScale.z - newStack.transform.position.z) ;
			}

			Vector3 scale = new Vector3(newStack.transform.localScale.x, (float)0.3, scaleZ);
			newStack.transform.localScale=scale;
			//oldstack.transform.localScale = scale;

			Debug.Log("bir");
		}

		if (number % 2 == 0)
		{
			if (oldstack.transform.position.x - newStack.transform.position.x < 0)
			{
				scaleX = newStack.transform.localScale.x - ((oldstack.transform.position.x - newStack.transform.position.x) * -1);
				//scaleX = (newStack.transform.localScale.x - newStack.transform.position.x)*-1;
			}
			else
			{
				scaleX = newStack.transform.localScale.x - (oldstack.transform.position.x - newStack.transform.position.x);
				//scaleX = (newStack.transform.localScale.x - newStack.transform.position.x);
			}

			Vector3 scale = new Vector3(scaleX, (float)0.3, newStack.transform.localScale.z);
			//oldstack.transform.localScale=scale;
			newStack.transform.localScale=scale;
			Debug.Log("iki");
		}
	}
}

