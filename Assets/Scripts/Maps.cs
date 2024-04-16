using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Maps : MonoBehaviour
{
    public GameObject[] prefabsPipe;
    public player player;
    public float maxHeigh = 6.5f;
    public float minHeigh = 1.5f;

    public float padding = 50f;

    public GameObject parentPipe;
    public int maxPipe = 5;

    public int nbPipe = 0;

    public bool isGameOver = false;

    public GameObject restartButton;
    

    void Update()
    {
        if (!player.isGameOver)
        {
            if (parentPipe.transform.childCount < maxPipe)
            {
                CreatePipe();
            }

            parentPipe.transform.position = new Vector3(parentPipe.transform.position.x - (1.5f * Time.deltaTime), parentPipe.transform.position.y, 0);
        }
    }

    void CreatePipe()
    {
        nbPipe++;
        GameObject newPipe = Instantiate(prefabsPipe[Random.Range(0, prefabsPipe.Length)]);
        newPipe.transform.position = new Vector3(parentPipe.transform.position.x + nbPipe*padding, parentPipe.transform.position.y + Random.Range(minHeigh, maxHeigh), 0);
        newPipe.transform.SetParent(parentPipe.transform);
    }

    
}
