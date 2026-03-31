using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBehaviour : MonoBehaviour
{

    public AudioClip clickSound;

    private AudioSource audioSource;

    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {

            audioSource = gameObject.AddComponent<AudioSource>();
        }


        DontDestroyOnLoad(gameObject);
    }


    public void GoToSelectLevel()
    {
        LoadMySceneWithSound("Select Level");
    }


    public void LoadMySceneWithSound(string sceneName)
    {
        if (clickSound != null)
        {

            audioSource.PlayOneShot(clickSound);

            StartCoroutine(LoadSceneAfterSound(sceneName));
        }
        else
        {

            SceneManager.LoadScene(sceneName);
        }
    }


    public void LoadMySceneWithSound(int sceneNumber)
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
            StartCoroutine(LoadSceneAfterSound(sceneNumber));
        }
        else
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }


    private IEnumerator LoadSceneAfterSound(string sceneName)
    {

        yield return new WaitForSeconds(clickSound.length);

        yield return SceneManager.LoadSceneAsync(sceneName);
    }


    private IEnumerator LoadSceneAfterSound(int sceneNumber)
    {
        yield return new WaitForSeconds(clickSound.length);
        yield return SceneManager.LoadSceneAsync(sceneNumber);
    }


    public void LoadMyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMyScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}