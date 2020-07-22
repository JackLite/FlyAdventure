using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleData data;

    private void OnEnable()
    {
        if (data == null) return;
        if (data.direction == ObstacleDirection.right) transform.rotation = Quaternion.Euler(0, 0, -90);
        else transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    void Update()
    {
        var delta = data.speed * Time.deltaTime;
        var deltaVector = new Vector3(delta, 0);

        if (data.direction == ObstacleDirection.right)
        {
            transform.position += deltaVector;
        }
        else
        {
            transform.position -= deltaVector;
        }
        if (Math.Abs(transform.position.x) > 40) gameObject.SetActive(false);
    }
}
