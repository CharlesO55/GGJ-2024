using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_coinPrefab;
    [SerializeField] private List<BoxCollider2D> m_spawnAreas = new();

    [SerializeField] private float m_spawnRate = 4;
    [SerializeField] private float m_spawnTime;
    void LateUpdate()
    {
        m_spawnTime += Time.deltaTime;

        if (m_spawnTime > m_spawnRate)
        {
            this.m_spawnRate -= 0.1f;
            this.m_spawnTime = 0;

            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        int rng = Random.Range(0, m_spawnAreas.Count - 1);

        Vector3 baseArea = m_spawnAreas[rng].bounds.center;

        baseArea.x += Random.Range(-m_spawnAreas[rng].size.x, m_spawnAreas[rng].size.x);
        baseArea.y += Random.Range(-m_spawnAreas[rng].size.y, m_spawnAreas[rng].size.y);

        Instantiate(m_coinPrefab, baseArea, Quaternion.identity, this.transform);
    }
}
