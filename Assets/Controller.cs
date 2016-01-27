using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    // Use this for initialization
	public GameObject equip_1;
	public GameObject equip_2;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Start () {
	
	}

    
    void Update()
    {
		//rotate charachter to face mouse
		Vector3 mousePos = Input.mousePosition;
		mousePos.x -= Screen.width / 2;
		mousePos.y -= Screen.height / 2;
		float mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);
		gameObject.transform.rotation = Quaternion.Euler(0 , mouseAngle * (-180f/3.1415f), 0);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			//Debug.Log("untransformed: " + moveDirection.x.ToString() + moveDirection.y.ToString() + moveDirection.z.ToString());
            //moveDirection = transform.TransformDirection(moveDirection);
			//Debug.Log("transformed: " + moveDirection.x.ToString() + moveDirection.y.ToString() + moveDirection.z.ToString());
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		if (Input.GetKeyDown("q") && equip_2 != null) 
		{
			swapWeapons(mouseAngle);	
		}


    }
	public void equip_gun(GameObject gunType)
	{
		if (equip_1 == null) {
			equip_1 = gunType;
			//Debug.Log (gunType.GetComponent<Gun_Controller>().Equipped);
			equip_1.GetComponent<Gun_Controller> ().Equipped = true;
			//Debug.Log (gunType.GetComponent<Gun_Controller>().Equipped);
			Debug.Log ("equip1");
		} else if (equip_2 == null) {
			//gunType.GetComponent<Gun_Controller>().Equipped = true;
			equip_2 = equip_1;
			equip_2.GetComponent<Gun_Controller> ().Equipped = false;
			equip_1 = gunType;
			equip_1.GetComponent<Gun_Controller> ().Equipped = true;
			equip_1.SetActive (true);
			equip_2.SetActive (false);
			Debug.Log ("equip2");
		} 
		else {
			equip_1.GetComponent<Gun_Controller> ().Equipped = false;
			equip_1 = gunType;
			equip_1.GetComponent<Gun_Controller> ().Equipped = true;
		
		}
	}
	void swapWeapons(float mouseAngle)
	{
		GameObject temp = equip_1;
		equip_1 = equip_2;
		equip_2 = temp;

		//reorient gun and reposition before it is enabled
		Vector3 mouseHeading = new Vector3(1f * Mathf.Cos(mouseAngle), 0, 1f * Mathf.Sin(mouseAngle));
		//make the gun follow the player and rotate around them following th mouse
		equip_1.GetComponent<Transform>().position = gameObject.transform.position + mouseHeading;
		equip_1.GetComponent<Transform>().rotation = Quaternion.Euler(0 , mouseAngle * (-180f/3.1415f), 0);

		//enable the gun in slot 1 and disable slot 2
		equip_1.GetComponent<Gun_Controller> ().Equipped = true;
		equip_2.GetComponent<Gun_Controller> ().Equipped = false;
		equip_1.SetActive (true);
		equip_2.SetActive (false);
	}

}