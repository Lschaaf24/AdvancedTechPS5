
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawning : MonoBehaviour
{
    public static FruitSpawning instance;

    [SerializeField] private List<GameObject> fruitObjectPrefabs;
    private List<GameObject> currentFruit = new List<GameObject>();
    
    [SerializeField] private Transform fruitOrigin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFruit.Count < 2)
        {
            StartCoroutine(Spawning());

        }

    }

    private IEnumerator Spawning()
    {
        if(currentFruit.Count < 1)
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
        fruitRb.AddForce(new Vector3(Random.Range(-2, 2), 4, 0), ForceMode.Impulse);
    }
    
    public void DestroyFruit(GameObject fruitObject)
    {
        if (currentFruit.Contains(fruitObject))
        {
            currentFruit.Remove(fruitObject);
            Destroy(fruitObject);
        }
    }

}
