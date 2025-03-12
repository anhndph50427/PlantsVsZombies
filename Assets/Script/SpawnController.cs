using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject sun_preFabs;
    void Start()
    {
        Invoke("delayStartCoroutine", 3);
    }
    

    void delayStartCoroutine()
    {
        StartCoroutine(SpawSun());
    }

    IEnumerator SpawSun()
    {
        while (true)
        {
            GameObject newSun =  Instantiate(sun_preFabs , new Vector3(Random.Range(-6f,9) , 6.5f , transform.position.z ), Quaternion.identity);
            newSun.GetComponent<Sun>().stopPos = Random.Range(-4,5);
            yield return new WaitForSeconds(8);
        }
    }
}
