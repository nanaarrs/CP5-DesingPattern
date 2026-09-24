using UnityEngine;

public class InimigosFactory : MonoBehaviour
{
    [SerializeField] private GameObject rapidoPrefab;
    [SerializeField] private GameObject fortePrefab;

    public enum EnemyType { Rapido, Forte }

    public GameObject CreateEnemy(EnemyType type, Vector3 spawnPosition)
    {
        GameObject newEnemy = null;

        switch (type)
        {
            case EnemyType.Rapido:
                newEnemy = Instantiate(rapidoPrefab, spawnPosition, Quaternion.identity);
                newEnemy.AddComponent<Inimigo1>();
                break;

            case EnemyType.Forte:
                newEnemy = Instantiate(fortePrefab, spawnPosition, Quaternion.identity);
                newEnemy.AddComponent<Inimigo2>();
                break;
        }

        return newEnemy;
    }
}

