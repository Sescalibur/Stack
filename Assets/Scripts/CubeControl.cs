using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
	public GameController gameController;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
	    //Debug.Log("sol");
		if (collision.transform.tag == "Right")
	    {
		    GameController.way = GameController.MyEnum.righ;
		    
	    }
	    if (collision.transform.tag == "Left")
	    {
		    GameController.way = GameController.MyEnum.left;
		    
		}
	    if (collision.transform.tag == "Up")
	    {
		    GameController.way = GameController.MyEnum.down;
	    }
	    if (collision.transform.tag == "Down")
	    {
		    GameController.way = GameController.MyEnum.up;
	    }
    }

    void OnCollisionEnter(Collision collision)
    {
	    if (collision.transform.tag == "Cube")
	    {
		    //Destroy(this);
			GameController.cut(GameController.newStack,GameController.oldStack);
		    //Debug.Log("ilk");
		    GameController.oldStack.GetComponent<Rigidbody>().isKinematic = true;
			Destroy(GameController.oldStack.GetComponent<GameController>());
		   
	    }
	}
}
