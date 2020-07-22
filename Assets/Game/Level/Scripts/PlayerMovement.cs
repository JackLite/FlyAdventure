using UnityEngine;

public class PlayerMovement
{
    private readonly Transform transform;
    private readonly Borders borders;
    public PlayerMovement(Transform playerTransform, Borders borders)
    {
        transform = playerTransform;
        this.borders = borders;
    }

    public void Move(float delta)
    {
        var position = transform.position;
        position.y += delta;
        position.y = Mathf.Clamp(position.y, borders.BottomBorder, borders.TopBorder);
        transform.position = Vector3.Lerp(position, transform.position, 0.5f);
    }
}
