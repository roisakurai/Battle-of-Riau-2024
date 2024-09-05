using UnityEngine;
using UnityEngine.UI;

public class VariableManager : MonoBehaviour
{
    public static VariableManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("EnemyController.cs")]
    public float fallDownSpeed;
    public int addPoints;

    [Header("EnemySpawner.cs")]
    public TMPro.TextMeshProUGUI waveText;
    public WaveInfo[] waves;
    public float waveInterval;
    public float textDelay;
    public float spawnInterval;
    public float spawnPositionX;
    public float spawnPositionY;
    public float spawnPositionZ;
    public float initialDelay;

    [Header("CannonController.cs")]
    public float rotationSpeed;
    public float maxRotationX;
    public float minRotationX;
    public float maxRotationY;
    public float minRotationY;
    public float cannonballForce;
    public float fireCooldown;
    public float cannonballLifetime;

    [Header("Cannonball.cs")]
    public int cannonballDamage;

    [Header("CannonAimProjection.cs")]
    public int lineSegments;

    [Header("CannonballPooler.cs")]
    public GameObject cannonballPrefab;
    public int poolSize;

    [Header("ScoreManager.cs")]
    public TMPro.TextMeshProUGUI scoreText;
}

[System.Serializable]
public class WaveInfo
{
    public GameObject prefab;
    public int count;
}