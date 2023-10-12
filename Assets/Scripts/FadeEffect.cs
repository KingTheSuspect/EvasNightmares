using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Animator anims;

    [SerializeField] private float transitionTime = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //LoadNextLevel();
        }

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
}
