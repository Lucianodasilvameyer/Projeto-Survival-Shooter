using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{    
    public static Game instance { get; private set; }

    [SerializeField]
    public Queue<Inimigo> inimigos = new Queue<Inimigo>();

    [SerializeField]
    Transform[] spawns = new Transform[4];

    public GameObject inimigo;

    [SerializeField]
    public int maxQueue;

    int maxSpawnPoints = 3;

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

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnsGO = GameObject.FindGameObjectsWithTag("spawnPoint");

        for (int i = 0; i < spawnsGO.Length; i++)
        {
            if (i >= spawns.Length)
            {
                break;
            }

            spawns[i] = spawnsGO[i].transform;

            Vector3 pos = spawns[i].position;

            spawns[i].position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    public void spawn()
    {
        if (inimigos.Count > 0)
        {
            respawn();
        }
        else
        {
            int spawnLocation = Random.Range(0, maxSpawnPoints);

            if (!spawns[spawnLocation])
            {
                return;
            }

            Vector3 position = spawns[spawnLocation].position;

            Inimigo i = Instantiate(inimigo, position, Quaternion.identity).GetComponent<Inimigo>();

            i.spawnPoint = spawnLocation;
        }
    }

    public void respawn()
    {
        int spawnLocation = Random.Range(0, maxSpawnPoints);

        Inimigo i = inimigos.Dequeue();

        while (spawnLocation == i.spawnPoint)
        {
            spawnLocation = Random.Range(0, maxSpawnPoints);
        }

        i.spawnPoint = spawnLocation;

        i.transform.position = spawns[i.spawnPoint].position;

        i.GetComponent<BoxCollider2D>().enabled = true;

        i.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void addToPool(Inimigo i)
    {
        if (inimigos.Count < maxQueue)
        {
            i.GetComponent<BoxCollider2D>().enabled = false;

            i.GetComponent<SpriteRenderer>().enabled = false;

            inimigos.Enqueue(i);
        }
        else
        {
            Destroy(i.gameObject);
        }
    }
}
