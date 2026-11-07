using UnityEngine;

public class Fruit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slice"))
        {
            FruitSpawning.instance.DestroyFruit(gameObject);
            GameManager.instance.AddScore(1);
        }
        if (other.gameObject.CompareTag("DeathBox"))
        {
            FruitSpawning.instance.DestroyFruit(gameObject);
        }
        
    }
}
