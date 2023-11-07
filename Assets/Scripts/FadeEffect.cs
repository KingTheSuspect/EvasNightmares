using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Animator anims;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private int stageInt;

    private void Start()
    {
        Time.timeScale = 1;

    }

    private void Update()
    {

    }

    public void Menus(int episodeId)
    {
        StartCoroutine(LoadLevels(episodeId));
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int levelindex)
    {
        anims.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelindex);

    }

    IEnumerator LoadLevels(int episodeId)
    {
        anims.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(episodeId);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("deðdi");
            Time.timeScale = 0;

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
}
