using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticle : MonoBehaviour {

	public GameObject[] objectsToInstantiate, objectsToInstantiate_break;
	public GameObject reference;
	private void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		Camera c = Camera.main;
		Vector3 point = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane*1.1f));

		if (Input.GetMouseButtonDown(0)){

			foreach (GameObject g in objectsToInstantiate) {
				GameObject gamo = Instantiate(g, point, Quaternion.identity, reference.transform);
				gamo.transform.LookAt(c.transform.position);
				Destroy(gamo, 1f);
			}
		}

		if (Input.GetMouseButtonDown(1)){

			foreach (GameObject g in objectsToInstantiate_break) {
				GameObject gamo = Instantiate(g, point, Quaternion.identity, reference.transform);
				gamo.transform.LookAt(c.transform.position);
				Destroy(gamo, 1f);
			}
		}
	}
}
