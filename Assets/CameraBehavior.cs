using UnityEngine;
using System.Collections;



public class CameraBehavior : MonoBehaviour {
    public GameObject PlayerPos;
    public float FracLag = 0.2F;
    private Vector3 CameraPos;
    private Vector3 Player;


    //We do the actual interpolation in FixedUpdate(), since we're dealing with a rigidbody
    void Update()
    {
        CameraPos = new Vector3(gameObject.GetComponent<Transform>().position.x, 10, gameObject.GetComponent<Transform>().position.z);
        Player = new Vector3(PlayerPos.GetComponent<Transform>().position.x, 10, PlayerPos.GetComponent<Transform>().position.z);
            //to start another lerp)
            gameObject.GetComponent<Transform>().position = Vector3.Lerp(CameraPos, Player, FracLag);

    }
    /*
    public float FracLag = 0.2F;
    private float xPos;
    private float zPos;
    private float yPos = 10;
    private float currentXPos;
    private float currentYPos;
    private float currentZPos;
    
    // Use this for initialization
    void Start () {
	    new Vector3 test = new Vector3.Lerp()
	}
	
	// Update is called once per frame
	void Update () {
        
        xPos = PlayerPos.GetComponent<Transform>().position.x;
        zPos = PlayerPos.GetComponent<Transform>().position.z;
        currentXPos = gameObject.GetComponent<Transform>().position.x;
        currentZPos = gameObject.GetComponent<Transform>().position.z;
        //Debug.Log("xPos: " + xPos.ToString() + " zPos: " + zPos.ToString());
        


        }
        gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.GetComponent<Transform>().position,  PlayerPos.GetComponent<Transform>().position, FracLag);
       
    }*/

}
