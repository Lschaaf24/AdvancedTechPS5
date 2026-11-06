using UnityEngine;

public class Fruit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slice"))
        {
            FruitSpawning.instance.DestroyFruit(gameObject);

        }
    }
}
