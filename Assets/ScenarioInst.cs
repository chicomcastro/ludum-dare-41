using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioInst : MonoBehaviour {

	public GameObject wall;

	public float a, b;

	public float intervalo = 0.001f;
	public float flutuation = 0f;

	private void Start()
	{
		StartCoroutine(GenerateScenario());
	}

	IEnumerator GenerateScenario () {
		for (float tetha = 0; tetha < Mathf.PI*2; tetha+=intervalo) {
			float r = a*b/Mathf.Sqrt(a*a*Mathf.Sin(tetha)*Mathf.Sin(tetha) + b*b*Mathf.Cos(tetha)*Mathf.Cos(tetha));
			Vector3 pos = new Vector3 (r*Mathf.Cos(tetha)+Random.Range(-flutuation, flutuation), 0, r*Mathf.Sin(tetha)+Random.Range(-flutuation, flutuation));
			GameObject gamo = Instantiate(wall, pos, Quaternion.identity);
			gamo.transform.LookAt(Vector3.zero);
 		}
		yield return null;
	}
}
