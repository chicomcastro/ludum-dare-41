using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (UnityStandardAssets.Vehicles.Car.CarController))]
public class CarUserControl : MonoBehaviour
{
    private UnityStandardAssets.Vehicles.Car.CarController m_Car; // the car controller we want to use

    private float tapsPerSecond;
    private float time;

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
    }

    private void FixedUpdate()
    {
        // pass the input to the car!
        float h = TappingControls.Horizontal();
        float v = tapsPerSecond; //TappingControls.Vertical();
#if !MOBILE_INPUT
        float handbrake = TappingControls.Jump();
        m_Car.Move(h, v, v, handbrake);
#else
        m_Car.Move(h, v, v, 0f);
#endif
        v = 0;
    }

     private void Start()
    {
        time = Time.time;
        tapsPerSecond = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            tapsPerSecond = 1.0f/(Time.time - time);
            time = Time.time;
        }

        if (Input.GetMouseButtonDown(1)) {
            tapsPerSecond = -1.0f/(Time.time - time);
            time = Time.time;
        }

        if (Time.time - time > 0.5f) {
            tapsPerSecond = 0;
        }
    }

    public float GetTPS () {
        return tapsPerSecond;
    }
}

public static class TappingControls {

    public static float Horizontal () {
        float x = (Input.mousePosition.x-Screen.width/2)/(Screen.width/2);
        return Mathf.Sin(x*x*x*Mathf.PI/2);
        //CrossPlatformInputManager.GetAxis("Horizontal");
    }

    public static float Vertical () {
        return CrossPlatformInputManager.GetAxis("Tap");
    }

    public static float Jump () {
        return CrossPlatformInputManager.GetAxis("Jump");
    }
}