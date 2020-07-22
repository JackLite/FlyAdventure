using UnityEngine;

[RequireComponent(typeof(Sprite))]
public class AvatarInput : MonoBehaviour
{
    private bool isPointerPress;
    private Vector2 pointerPos;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    private readonly Color normalColor = new Color(1, 1, 1, 0);
    private readonly Color hoverColor = new Color(1, 1, 1, 0.2f);

    public bool IsPointerPress { get => isPointerPress; private set => isPointerPress = value; }
    public Vector2 PointerPos { get => pointerPos; private set => pointerPos = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        UpdateView();
    }

    private void UpdateView()
    {
        //spriteRenderer.color = isPointerPress ? hoverColor : normalColor;
    }

    private void Update()
    {
        UpdatePointer();
    }

    private void UpdatePointer()
    {
        for (var i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchPos = Input.GetTouch(i).position;
            var ray = mainCamera.ScreenPointToRay(touchPos);
            var hits = new RaycastHit2D[1];
            int hitCount = Physics2D.RaycastNonAlloc(ray.origin, ray.direction, hits);

            if (hitCount == 0) continue;
            if (hits[0].transform.name == gameObject.name)
            {
                pointerPos = touchPos;
                isPointerPress = true;
                UpdateView();
                return;
            }
        }
        isPointerPress = false;
        UpdateView();
    }
}
