using UnityEngine;

public class Spawner : MonoBehaviour
{
    private InimigosFactory factory;
    [SerializeField] private float spawnInterval = 3f;

    [Header("Configurações de Distância")]
    [SerializeField] private float distanciaMinima = 5f;
    [SerializeField] private float distanciaMaxima = 12f;

    private Transform playerTransform;

    private void Start()
    {
        factory = GetComponent<InimigosFactory>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }

        InvokeRepeating(nameof(SpawnNextEnemy), 1f, spawnInterval);
    }

    private void SpawnNextEnemy()
    {
        if (playerTransform == null) return;

        InimigosFactory.EnemyType randomType = (Random.value > 0.5f) ?
            InimigosFactory.EnemyType.Rapido : InimigosFactory.EnemyType.Forte;

        Vector2 direcaoAleatoria = Random.insideUnitCircle.normalized;

        float distanciaSorteada = Random.Range(distanciaMinima, distanciaMaxima);

        Vector3 spawnPosition = new Vector3(
            playerTransform.position.x + (direcaoAleatoria.x * distanciaSorteada),
            0.5f,
            playerTransform.position.z + (direcaoAleatoria.y * distanciaSorteada)
        );

        factory.CreateEnemy(randomType, spawnPosition);
    }
}

