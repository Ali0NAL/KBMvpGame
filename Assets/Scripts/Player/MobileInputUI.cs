using UnityEngine;
using UnityEngine.UI;


public class MobileInputUI : MonoBehaviour
{
    public Vector2 JoystickInput { get; private set; }
    public bool JumpPressed { get; private set; }

    [SerializeField] private Joystick joystick;
    [SerializeField] private Button jumpButton;

    private void Awake()
    {
        jumpButton.onClick.AddListener(() => JumpPressed = true);
    }

    private void Update()
    {
        JoystickInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (JumpPressed) JumpPressed = false; // Tek tıklama mantığı
    }
}
