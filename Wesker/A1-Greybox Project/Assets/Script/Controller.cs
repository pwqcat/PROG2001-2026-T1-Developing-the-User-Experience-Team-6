using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform player;

    public float moveStep = 1f;

    public float rotateStep = 15f;

    public float scaleStep = 0.1f;

    public float minScale = 0.2f;
    public float maxScale = 3f;

    private Vector3 defaultPosition;
    private Quaternion defaultRotation;
    private Vector3 defaultScale;

    private void Start()
    {
        if (player != null)
        {
            defaultPosition = player.position;
            defaultRotation = player.rotation;
            defaultScale = player.localScale;
        }
    }

    public void MoveForward()
    {
        if (player == null) return;
        player.position += Vector3.forward * moveStep;
    }

    public void MoveBackward()
    {
        if (player == null) return;
        player.position += Vector3.back * moveStep;
    }

    public void MoveLeft()
    {
        if (player == null) return;
        player.position += Vector3.left * moveStep;
    }

    public void MoveRight()
    {
        if (player == null) return;
        player.position += Vector3.right * moveStep;
    }

    public void RotateLeft()
    {
        if (player == null) return;
        player.Rotate(Vector3.up, -rotateStep);
    }

    public void RotateRight()
    {
        if (player == null) return;
        player.Rotate(Vector3.up, rotateStep);
    }

    public void ScaleUp()
    {
        if (player == null) return;

        Vector3 newScale = player.localScale + Vector3.one * scaleStep;
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        player.localScale = newScale;
    }

    public void ScaleDown()
    {
        if (player == null) return;

        Vector3 newScale = player.localScale - Vector3.one * scaleStep;
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        player.localScale = newScale;
    }

    public void ResetTransform()
    {
        if (player == null) return;

        player.position = defaultPosition;
        player.rotation = defaultRotation;
        player.localScale = defaultScale;
    }
}