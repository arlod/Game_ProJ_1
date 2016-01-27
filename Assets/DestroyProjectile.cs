using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag != "Weapon" && collision.gameObject.tag != "Projectile") {
            Destroy(gameObject);
        }
    }
}
