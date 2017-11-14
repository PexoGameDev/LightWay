using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [System.Serializable]
    public struct Bounds
    {
        public float min, max;

        public Bounds(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public Bounds waveSize = new Bounds(1, 4);
    public int spawnAltitude;
    public GameObject enemyObject;
    public Bounds xBounds;
    public Bounds zBounds;
    public float spawnDelay = 2f;

    private int enemies = 0;

    void Start()
    {
        InvokeRepeating("Spawn", 0, spawnDelay);
    }

    void Spawn ()
    {
        if (enemies < waveSize.max)
        {
            int enemyCount = Random.Range((int)waveSize.min, (int)waveSize.max - enemies);

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = Instantiate(enemyObject, GetPosition(), Quaternion.identity, transform);
                enemies++;
            }
        }
	}

    private Vector3 GetPosition()
    {
        Vector3 position = new Vector3(spawnAltitude, Random.Range(xBounds.min, xBounds.max), Random.Range(zBounds.min, zBounds.max));

        if(!Physics.CheckBox(position, new Vector3(2.5f, 2.5f, 2.5f)))
        {
            return position;
        }

        Debug.Log("Spawn position not clear");
        return GetPosition();
    }
}
