using UnityEngine;
using UnityEngine.InputSystem.PS5;

public class TouchPadInput : MonoBehaviour
{
    [SerializeField] private float speed = 300f;

    private Camera cam;
    DualSenseGamepad pad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        pad = DualSenseGamepad.GetBySlotIndex(0);
        if (pad == null) return;

        //Get the positions of the touches - there are always 2 touches reported
        PS5TouchControl touch0 = pad.touches[0];
        PS5TouchControl touch1 = pad.touches[1];

        //Get the phase of the touch
        TouchPhase phase = (TouchPhase)touch0.phase;
        //Touch is not valid when it's state is ended or none and will report position as (-1,-1)
        if (phase == TouchPhase.Ended)
        {
            return;
        }

        int id = touch0.touchId.ReadValue();
        Vector2 position = touch0.position.ReadValue();
        Vector2 delta = touch0.delta;

        Vector3 currentScreenPos = cam.WorldToScreenPoint(transform.position);
        Vector3 targetScreenPos = new Vector3(currentScreenPos.x + delta.x * speed, currentScreenPos.y + delta.y * -speed, currentScreenPos.z);

        transform.position = cam.ScreenToWorldPoint(targetScreenPos);
        //transform.position = new Vector3(position.x * speed, position.y * -speed, 0);

    }
}
