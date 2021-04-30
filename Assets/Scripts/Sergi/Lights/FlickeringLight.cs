using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light SpotLight;
    public float minValue;
    public float maxValue;
    // Start is called before the first frame update
    void Start()
    {
        SpotLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minValue, maxValue));
            SpotLight.enabled = !SpotLight.enabled;

        }
    }
}
