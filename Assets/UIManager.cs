using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text tps;
	public Text velocity;
	public Image speedometer;

	public GameObject car;
	private CarUserControl carUserControl;
	private Rigidbody rigidbody;
		
	private void Start()
	{
		carUserControl = car.GetComponent<CarUserControl>();
		rigidbody = car.GetComponent<Rigidbody>();
		StartCoroutine(AttUI());
	}

	private IEnumerator AttUI () {
		while (true) {
			tps.text = "Clicks/second: " + Mathf.Abs(carUserControl.GetTPS()).ToString("F2");
			velocity.text = "Velocity: " + (rigidbody.velocity.magnitude*2).ToString("F2");
			speedometer.transform.rotation = Quaternion.Euler (
				speedometer.transform.rotation.eulerAngles.x,
				speedometer.transform.rotation.eulerAngles.y, 
				225-rigidbody.velocity.magnitude*2);
			yield return new WaitForSeconds(0.5f);
		}
	}
}
