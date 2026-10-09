using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Настройки")]
    public float rotateSpeed = 100f; 

    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Передаём +1 очко в ваш GameManager (если он есть на сцене)
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
            }

            // Передаем +1 монетку в наш HUDManager
            if (HUDManager.Instance != null)
            {
                HUDManager.Instance.AddCoin(1);
            }

            Destroy(gameObject);
        }
    }
}