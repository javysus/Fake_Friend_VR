using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    private float transitionTime = 3f;
    public GameObject jugador;
    // Update is called once per frame
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        Console.WriteLine("Current Date and time is : " + SceneManager.GetActiveScene().buildIndex);

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime*2);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
