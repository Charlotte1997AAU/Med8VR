using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicLightSource : MonoBehaviour
{
    public Material reveal;
    public Light blacklight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reveal.SetVector("_LightPosition", blacklight.transform.position);
        reveal.SetVector("_LightDirection", -blacklight.transform.forward); //*Forward angle of our light in relation to the worldPos.
       // reveal.SetFloat("_LightAngle", light.spotAngle); //*Only works for spotlights
    }
}
