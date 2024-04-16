using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    public PlatformGenerator platformGenerator;
    private void OnTriggerEnter(Collider other)
    {
        float posZ = transform.parent.transform.position.z;
        platformGenerator.GeneratePlatform(posZ);
    }
    // Start is called before the first frame update
    void Start()
    {
        platformGenerator = GameObject.FindObjectOfType<PlatformGenerator>();
    }
}
