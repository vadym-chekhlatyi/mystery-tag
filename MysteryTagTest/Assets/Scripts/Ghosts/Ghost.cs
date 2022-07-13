using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

public class Ghost : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animation anim;

    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    private int scoresGiven;
    public int ScoresGiven
    {
        get
        {
            return scoresGiven;
        }
        set
        {
            scoresGiven = value;
        }
    }

    private bool isDestroyed;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if(transform.position.y > Screen.height + 130f)
        {
            Destroy(gameObject);
            GhostFactory.Instance.currentGhostCount--;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            AddScores();
            DestroyGhost();
        }
    }

    private void AddScores()
    {
        ScoresController.Instance.AddScores(scoresGiven);
    }

    private void DestroyGhost()
    {
        GhostFactory.Instance.currentGhostCount--;

        if (anim != null)
        {
            anim.Play("Explotion");
            speed = 0f;

            Destroy(gameObject, .75f);
        }
        else
            Destroy(gameObject);
    }
}
