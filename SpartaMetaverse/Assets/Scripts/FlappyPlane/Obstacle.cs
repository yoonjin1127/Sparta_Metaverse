using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    MiniGameManager miniGameManager;

    private void Start()
    {
        miniGameManager = MiniGameManager.Instance;
    }

    public Vector2 SetRandomPlace(Vector2 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector2(0, halfHoleSize);
        bottomObject.localPosition = new Vector2(0, -halfHoleSize);

        Vector2 placePosition = lastPosition + new Vector2(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         Plane plane = collision.GetComponent<Plane>();

        if (plane != null)
            miniGameManager.AddScore(1);
    }
}
