using UnityEngine;

public class PipeSpawner : ObjectPool
{
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _timeBetweenSpawn;

    private float _passedTime;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        _passedTime += Time.deltaTime;
        if (_passedTime >= _timeBetweenSpawn)
            SpawnPipe();
    }

    private void SpawnPipe()
    {
        if (TryGetElement(out GameObject activePipe))
        {
            _passedTime = 0;
            PlacePipe(activePipe);
            DisableObjectAbroadScreen();
        }
    }

    private void PlacePipe(GameObject pipe)
    {
        var spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
        var spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        pipe.transform.position = spawnPoint;
        pipe.SetActive(true);
    }
}
