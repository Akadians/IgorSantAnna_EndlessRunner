// GENERATED AUTOMATICALLY FROM 'Assets/_Project/Scripts/Input/Main_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Main_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Main_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Main_Input"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2d3e20c2-d737-49cb-957c-ba11f4324aa6"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""32b28617-08c8-4be9-95e7-c37fcf035129"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5b2dc94e-82b5-454b-b805-2b9fe42bd3a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchDirection"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad053f9d-63fa-4431-b258-8149ad0ab533"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""04e662d6-c4e0-44b0-9b35-5e87aa79909b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d3bae4bf-62fc-4a0b-9424-59b3c8711bcb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29c0e60c-255a-4f3e-b42a-0137f3033285"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d87ac832-4e71-4658-a9f4-15ecf2e6bef7"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": ""SlowTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd81a13d-fd5c-4cfa-ac4d-3e7b3b26df27"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Left = m_Gameplay.FindAction("Left", throwIfNotFound: true);
        m_Gameplay_Right = m_Gameplay.FindAction("Right", throwIfNotFound: true);
        m_Gameplay_TouchDirection = m_Gameplay.FindAction("TouchDirection", throwIfNotFound: true);
        m_Gameplay_TouchPress = m_Gameplay.FindAction("TouchPress", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Right;
    private readonly InputAction m_Gameplay_TouchDirection;
    private readonly InputAction m_Gameplay_TouchPress;
    public struct GameplayActions
    {
        private @Main_Input m_Wrapper;
        public GameplayActions(@Main_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputAction @TouchDirection => m_Wrapper.m_Gameplay_TouchDirection;
        public InputAction @TouchPress => m_Wrapper.m_Gameplay_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @TouchDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchDirection;
                @TouchDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchDirection;
                @TouchDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchDirection;
                @TouchPress.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @TouchDirection.started += instance.OnTouchDirection;
                @TouchDirection.performed += instance.OnTouchDirection;
                @TouchDirection.canceled += instance.OnTouchDirection;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnTouchDirection(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
