using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject originPosition;

    public float power = 10.0f;
    public float radius = 5.0f;
    public float upforce = 5.0f;


	void Start ()

    {
        Invoke("Detonate", 0);
	}
	
    void Detonate ()

    {
        Vector3 explosionPosition = originPosition.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
    }
}
