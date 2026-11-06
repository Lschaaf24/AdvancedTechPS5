
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawning : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruitObjectPrefabs;
    private List<GameObject> currentFruit;
    
    [SerializeField] private Transform fruitOrigin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        if(currentFruit.Count < 2)
        {
            SpawnFruit(GetRandomFruit());

            yield return new WaitForSeconds(2f);
        }


        yield return null;
    }

    private GameObject GetRandomFruit()
    {
        int randomFruit = Random.Range(0, fruitObjectPrefabs.Count);

        return fruitObjectPrefabs[randomFruit];
    }


    private void SpawnFruit(GameObject fruitObject)
    {
        GameObject newFruitObject = Instantiate(fruitObject, fruitOrigin);
        currentFruit.Add(newFruitObject);
        Rigidbody fruitRb = newFruitObject.GetComponent<Rigidbody>();
        fruitRb.AddForce(new Vector3(0, 4, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
