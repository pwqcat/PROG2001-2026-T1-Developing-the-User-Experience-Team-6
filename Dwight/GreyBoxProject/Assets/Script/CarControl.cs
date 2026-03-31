using UnityEngine;

public class CarControl : MonoBehaviour
{

    public float moveSpeed = 2f;

    public float rotateSpeed = 30f;

    public float scaleSpeed = 0.1f;


    private Vector3 initPos;
    private Quaternion initRot;
    private Vector3 initScale;


    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
        initScale = transform.localScale;
    }


    public void MoveForward()
    {
        transform.Translate(0, 0, moveSpeed);
    }


    public void MoveBack()
    {
        transform.Translate(0, 0, -moveSpeed);
    }


    public void MoveLeft()
    {
        transform.Translate(-moveSpeed, 0, 0);
    }


    public void MoveRight()
    {
        transform.Translate(moveSpeed, 0, 0);
    }


    public void RotateLeft()
    {
        transform.Rotate(0, -rotateSpeed, 0);
    }


    public void RotateRight()
    {
        transform.Rotate(0, rotateSpeed, 0);
    }


    public void ScaleUp()
    {
        transform.localScale += Vector3.one * scaleSpeed;
    }

    public void ScaleDown()
    {
        if (transform.localScale.x > 0.2f)
        {
            transform.localScale -= Vector3.one * scaleSpeed;
        }
    }

    public void ResetCar()
    {
        transform.position = initPos;
        transform.rotation = initRot;
        transform.localScale = initScale;
    }
}