using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	private bool menuIsOpen = true;
	public GameController gameController;
	public GameObject menu;
	public static bool menuOpen = true;
	// Start is called before the first frame update

	
	private void Awake()
	{
		Time.timeScale = 0;
	}
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (menuIsOpen)
		{
			if (Input.GetMouseButtonUp(0))
			{
				Time.timeScale = 1;
				menuOpen = false;
				GameController.number++;
				gameController.start = true;
				menuIsOpen = false;
				Debug.Log("gel");
				menu.SetActive(false);
			}
		}
	}

}
