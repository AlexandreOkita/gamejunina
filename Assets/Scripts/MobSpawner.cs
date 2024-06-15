using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private float mobNumber = 10f;
    [SerializeField] private GameObject mob;
    private int mobsSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMobs());
    }

    IEnumerator SpawnMobs()
    {
        yield return new WaitForSeconds(cooldown);

        while (mobsSpawned < mobNumber)
        {
            Instantiate(mob, transform.position, Quaternion.identity);
            mobsSpawned++;

            yield return new WaitForSeconds(cooldown);
        }
    }

}
