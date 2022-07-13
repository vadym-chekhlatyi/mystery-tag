using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("Best Score", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    } 
}
