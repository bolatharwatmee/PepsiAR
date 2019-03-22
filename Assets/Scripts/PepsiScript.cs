using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepsiScript : MonoBehaviour {
    
	[SerializeField]
	GameObject PepsiParticle;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet" )
        {
			GameManager.Score++;
			Destroy (gameObject);
			GameObject GM =  Instantiate (PepsiParticle, gameObject.transform.position, Quaternion.identity);
			Destroy (GM, 1f);
        }
    }
}
