using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Game : MonoBehaviour
{
    List<Transform> spawnPoints = new List<Transform>();

    List<Inimigo> listaInimigos = new List<Inimigo>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnPoints.Add(spawn.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnarInimigo()
    {
        if (listaInimigos.Count > 0)
        {
            int index = listaInimigos.Count -1;

            Inimigo P = (Inimigo)listaInimigos[index];

            listaInimigos.RemoveAt(index);

            P.transform.position = spawnPoints[Random.Range(0,2)].position;

            P.SetActive(true);
        }
        else
        {

        }
    }
}
