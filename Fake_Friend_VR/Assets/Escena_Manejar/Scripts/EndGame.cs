using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(5);

        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(3f * 2);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
