using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public GameObject projectilePrefab;
    public float attackSpeed = 2f;
    public float projectileSpeed = 800;
    float cooldown;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= cooldown)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
                Debug.Log("Shoot");
            }
        }
    }
    void Fire()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x -= Screen.width / 2;
        mousePos.y -= Screen.height / 2;
        float mouseAngle = Mathf.Atan2(mousePos.y, mousePos.x);   //note: this is reused and might want to redo
        Vector3 mouseHeading = new Vector3(1f * Mathf.Cos(mouseAngle), 0, 1f * Mathf.Sin(mouseAngle));
        GameObject bPrefab = Instantiate(projectilePrefab, transform.position + mouseHeading * 3, Quaternion.identity) as GameObject;
        bPrefab.GetComponent<Rigidbody>().AddForce(mouseHeading * projectileSpeed);
        cooldown = Time.time + attackSpeed;
    }
}
