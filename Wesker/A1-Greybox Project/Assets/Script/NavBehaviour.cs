using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavBehaviour : MonoBehaviour
{
    // 拖拽你的点击音效资源到此处（在Inspector面板中）
    public AudioClip clickSound;
    // 音频源组件，用于播放音效
    private AudioSource audioSource;

    private void Awake()
    {
        // 初始化音频源组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // 如果没有AudioSource组件，自动添加
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
        // 关键：确保播放音效的物体不随场景切换被销毁
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 带音效的场景加载（通过场景名称）
    /// </summary>
    public void LoadMySceneWithSound(string sceneName)
    {
        if (clickSound != null)
        {
            // 播放点击音效
            audioSource.PlayOneShot(clickSound);
            // 等待音效播放完毕后再加载场景
            StartCoroutine(LoadSceneAfterSound(sceneName));
        }
        else
        {
            // 如果没有设置音效，直接加载场景（避免报错）
            SceneManager.LoadScene(sceneName);
        }
    }

    /// <summary>
    /// 带音效的场景加载（通过场景索引）
    /// </summary>
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

    /// <summary>
    /// 协程：等待音效播放完成后加载场景（场景名称）
    /// </summary>
    private IEnumerator LoadSceneAfterSound(string sceneName)
    {
        // 等待音效完整播放时间
        yield return new WaitForSeconds(clickSound.length);
        // 异步加载场景（避免阻塞主线程）
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// 协程：等待音效播放完成后加载场景（场景索引）
    /// </summary>
    private IEnumerator LoadSceneAfterSound(int sceneNumber)
    {
        yield return new WaitForSeconds(clickSound.length);
        yield return SceneManager.LoadSceneAsync(sceneNumber);
    }

    // 保留原有方法（如需保留无音效加载场景的功能）
    public void LoadMyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMyScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}