using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{

    Vector2 startPos;

    [SerializeField] int moveModifier;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector2 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float pos_x = Mathf.Lerp(transform.position.x, startPos.x + (pz.x * moveModifier), 2f * Time.deltaTime);
        float pos_y = Mathf.Lerp(transform.position.y, startPos.y + (pz.y * moveModifier), 2f * Time.deltaTime);

        transform.position = new Vector3(pos_x, pos_y, 0);
    }
}
