using UnityEngine;
using System.Collections;

public class Mob_Generic : MonoBehaviour {
    public float mobHealth = 100;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (mobHealth <= 0)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter(Collider target) {
        if (target.tag == "Projectile") {
            mobHealth -= target.gameObject.GetComponent<projectileStats>().Damage;

        }
    }
}
