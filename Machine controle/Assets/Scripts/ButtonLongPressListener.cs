
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLongPressListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [Tooltip("Hold duration in seconds")]
    [Range(0f, 5f)] public float holdDuration = 0f;
    public UnityEvent onLongPress;
    public UnityEvent onRelease;

    private bool isPointerDown = false;
    private bool isLongPressed = false;
    private float elapsedTime = 0f;
    private int j = 0;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    private void Update()
    {
        if (isPointerDown && !isLongPressed)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= holdDuration)
            {
                isLongPressed = true;
                elapsedTime = 0f;
                if (button.interactable && !object.ReferenceEquals(onLongPress, null))
                    if (j == 0)
                    {
                        onLongPress.Invoke();
                        j = 1;
                    }
            }
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        isLongPressed = false;
        elapsedTime = 0f;
        j = 0;
        if (isPointerDown == false)
        {
            onRelease.Invoke();
        }
    }
}