using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmos_Sphere : MonoBehaviour {

	public float explosionRadius = 5.0F;
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
