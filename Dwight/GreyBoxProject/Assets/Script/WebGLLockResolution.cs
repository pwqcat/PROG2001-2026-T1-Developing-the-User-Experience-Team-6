using UnityEngine;

public class WebGLLockResolution : MonoBehaviour
{
    void Start()
    {
        // 强制设置为 Game 视图的固定分辨率
        Screen.SetResolution(1280, 760, false);
        Debug.Log($"WebGL 强制分辨率: {Screen.width} × {Screen.height}");
    }
}