using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Настройки")]
    public float rotateSpeed = 100f; // Скорость вращения монетки

    void Update()
    {
        // Вращаем монетку вокруг вертикальной оси Y (или Z, в зависимости от модели)
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что в триггер вошёл именно игрок с тегом "Player"
        if (other.CompareTag("Player"))
        {
            // Передаём +1 очко в наш GameManager (если он есть на сцене)
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
            }

            // Уничтожаем монетку после сбора
            Destroy(gameObject);
        }
    }
}