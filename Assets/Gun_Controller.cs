using UnityEngine;
using System.Collections;

public class Gun_Controller : MonoBehaviour {
	public GameObject Player;
	public GameObject thisGun;
	public GameObject projectilePrefab;
	public string gunName = "Generic gun";
	public float damage = 1f;
	public float attackSpeed = 0.2f;
	public float projectileSpeed = 800;
	public float fireDistance = 3;
	public bool Equipped = false;
	float cooldown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Equipped) {
			//calculate angle of gun based on mouse position relative to the player
			Vector3 mousePos = Input.mousePosition;
			mousePos.x -= Screen.width / 2;
			mousePos.y -= Screen.height / 2;
			float mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);
			Vector3 mouseHeading = new Vector3(1f * Mathf.Cos(mouseAngle), 0, 1f * Mathf.Sin(mouseAngle));
			//make the gun follow the player and rotate around them following th mouse
			gameObject.transform.position = Player.GetComponent<Transform>().position + mouseHeading;
			gameObject.transform.rotation = Quaternion.Euler(0 , mouseAngle * (-180f/3.1415f), 0);
			//if left mouse is pressed, fire the gun
			if (Time.time >= cooldown && Input.GetMouseButton (0)) {
				Fire (mouseHeading);
				//Debug.Log(Equipped);
				//Debug.Log("Shoot");
				//Debug.Log (cooldown);
			
			}
		}

	}
	void Fire(Vector3 mouseHeading)
	{

		GameObject bPrefab = Instantiate(projectilePrefab, transform.position + mouseHeading * fireDistance, Quaternion.identity) as GameObject;
        bPrefab.GetComponent<projectileStats>().Damage = damage;
		bPrefab.GetComponent<Rigidbody>().AddForce(mouseHeading * projectileSpeed);
		cooldown = Time.time + attackSpeed;
	}
	void OnTriggerEnter(Collider target)
	{
		if (target.tag == "Player") {
			Debug.Log ("Contact");
			Player.GetComponent<Controller> ().equip_gun (thisGun);
			//Equipped = true;
		}
	}
}
