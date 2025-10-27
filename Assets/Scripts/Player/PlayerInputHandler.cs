using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool IsJumping { get; private set; }

    [Header("Mobile Input (Optional)")]
    [SerializeField] private MobileInputUI mobileUI;
    
    private bool isMobile;

    private void Awake()
    {
#if UNITY_ANDROID || UNITY_IOS
        isMobile = true;
#else
        isMobile = false;
#endif
    }

    private void Update()
    {
        if (isMobile && mobileUI != null)
        {
            // mobil için
            MoveInput = mobileUI.JoystickInput;
            IsJumping = mobileUI.JumpPressed;
        }
        else
        {
#if ENABLE_INPUT_SYSTEM
            // pc için
            if (Keyboard.current != null)
            {
                float horizontal = (Keyboard.current.aKey.isPressed ? -1 : 0) + (Keyboard.current.dKey.isPressed ? 1 : 0);
                float vertical = (Keyboard.current.sKey.isPressed ? -1 : 0) + (Keyboard.current.wKey.isPressed ? 1 : 0);
                MoveInput = new Vector2(horizontal, vertical).normalized;
                IsJumping = Keyboard.current.spaceKey.wasPressedThisFrame;
            }
#else
            // eski sistem
            MoveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            IsJumping = Input.GetButtonDown("Jump");
#endif
        }
    }
}
