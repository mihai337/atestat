using UnityEngine;

public class CameraPrototip : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;
    public Vector3 offset;
    public float xMin = 0f;
    Vector3 velocity = Vector3.zero;

    public bool goodPosition = false;

    private void Start()
    {
        goodPosition = false;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            goodPosition = false;
            transform.position = new Vector3(11.6f, 1.9f, -10f);
            target = FindPlayer();
            return;
        }

        if (target.position.x >= 0f)
            goodPosition = true;

        if (goodPosition)
        {
            Vector3 targetPos = target.position + offset;
            Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
            Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, smoothSpeed * Time.fixedDeltaTime);

            transform.position = smoothPos;
        }
    }

    private Transform FindPlayer()
    {
        Transform searchResult = GameObject.FindGameObjectWithTag("Player").transform;

        if (searchResult == null)
            return null;

        else
            return searchResult;
    }
}
