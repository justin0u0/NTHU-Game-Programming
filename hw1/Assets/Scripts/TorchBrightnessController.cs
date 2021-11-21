using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBrightnessController : MonoBehaviour
{
    // Start is called before the first frame update
    public float highBrightnessIntensity;
    public float middleBrightnessIntensity;
    public float lowBrightnessIntensity;

    private Light[] lights;

    void Start() {
        lights = gameObject.transform.GetComponentsInChildren<Light>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void SetHighBrightness() {
        foreach (Light light in lights) {
            light.intensity = highBrightnessIntensity;
        }
    }

    public void SetMiddleBrightness() {
        foreach (Light light in lights) {
            light.intensity = middleBrightnessIntensity;
        }
    }

    public void SetLowBrightness() {
        foreach (Light light in lights) {
            light.intensity = lowBrightnessIntensity;
        }
    }
}
