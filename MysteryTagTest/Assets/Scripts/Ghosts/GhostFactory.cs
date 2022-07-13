using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GhostFactory : MonoBehaviour
{
    public static GhostFactory Instance;

    [SerializeField] private Ghost ghost;

    [HideInInspector] public int currentGhostCount = 0;

    [Space]
    [Header("Game settings")]
    [Tooltip("Max ghosts on the playing field")] public int maxGhostCount = 5;

    [Tooltip("Time between ghost spawns")] public float minSpawnTime = 1f;

    [Tooltip("Time between ghost spawns")] public float maxSpawnTime = 3f;

    [Space]
    [Header("Ghost variables")]
    [Tooltip("Speed of the ghost")] public float speed = 50f;

    [Tooltip("Every next ghost will be that faster")] public float speedIncreaseOverCount = 2f;

    [Tooltip("Scores given for ghost")] public int scoresGiven = 50;

    private float timer;

    private void Start()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (currentGhostCount < maxGhostCount)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
                CreateNewGhost();
            }
        }
    }

    private void CreateNewGhost()
    {
        Vector3 positionToInstantiate = new Vector3(UnityEngine.Random.Range(130f, Screen.width - 130), -150f);
        
        Ghost newGhost = Instantiate(ghost, positionToInstantiate, Quaternion.identity, transform);

        newGhost.Speed = speed;
        newGhost.ScoresGiven = scoresGiven;

        currentGhostCount++;
        speed += speedIncreaseOverCount;
    }
}
