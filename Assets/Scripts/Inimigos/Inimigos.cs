using UnityEngine;
using System;

public abstract class Inimigos : MonoBehaviour
{
    public static event Action<int> OnEnemyKilled;
    public static event Action OnGameOver;

    [SerializeField] protected int pointsValue = 10;
    [SerializeField] protected float speed = 2f;

    protected Transform player;

    protected virtual void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnMouseDown()
    {
        Die();
    }

    public void Die()
    {
        OnEnemyKilled?.Invoke(pointsValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnGameOver?.Invoke();
        }
    }
}

