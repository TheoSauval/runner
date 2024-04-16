using System.Collections;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private gamemanager gm;
    public GameObject platformPrefab;
    public Vector3 startSpawnPoint;
    public int numberOfPlatforms = 10;
    public float platformLength = -37.90008f;
    public float distanceBetweenPlatforms = 0f;
    public float platformWidth = 2.090333f;
    private Vector3 spawnPoint;
    private bool canGenerate = true; // Contrôle la génération
    public float generationCooldown = 2f; // Temps d'attente avant de pouvoir générer à nouveau

    void Start()
    {
        spawnPoint = startSpawnPoint;
        //GenerateInitialPlatforms();
        gm = GameObject.FindObjectOfType<gamemanager>();
    }

    //void GenerateInitialPlatforms()
    //{
    //    for (int i = 0; i < numberOfPlatforms; i++)
    //    {
    //        GeneratePlatform();
    //    }
    //}

    public void GeneratePlatform(float posZ)
    {   
        spawnPoint.z += platformLength + posZ;
        GameObject platformInstance = Instantiate(platformPrefab, spawnPoint, Quaternion.identity);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform == gm.player.transform && canGenerate)
    //    {
    //        GeneratePlatform();
    //        StartCoroutine(PlatformGenerationCooldown());
    //    }
    //}

    //private IEnumerator PlatformGenerationCooldown()
    //{
    //    canGenerate = false;
    //    yield return new WaitForSeconds(generationCooldown);
    //    canGenerate = true;
    //}
}
