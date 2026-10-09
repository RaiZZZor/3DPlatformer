using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector3 respawnPoint = new Vector3(-3.38f, 1.5f, -0.22f);

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что телепортируем именно игрока
        if (other.CompareTag("Player") || other.GetComponent<PlayerMovement>() != null || other.name == "Player")
        {
            // Сбрасываем накопившуюся скорость падения, чтобы игрок не летал и не падал сквозь пол
            if (other.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Телепортируем на спавн
            other.transform.position = respawnPoint;
        }
    }
}