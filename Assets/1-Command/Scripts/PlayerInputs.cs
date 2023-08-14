//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/1-Command/Scripts/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""2DMovement"",
            ""id"": ""4ff6391a-b4fb-4c59-b3cd-00bdfb3be6fb"",
            ""actions"": [
                {
                    ""name"": ""SkipTurn"",
                    ""type"": ""Button"",
                    ""id"": ""e94b451c-e385-485f-9744-b39b9b9c4b35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""3a6d313f-bf25-4104-bba4-3b8d6f353011"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""38f79203-317c-4366-9af4-709a350c5af5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""75c4972e-89fc-4d04-94f5-adbd5ed6f613"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""7a85358a-6b41-411e-8a2b-9df415b14002"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c473baf-5bf3-4644-acd9-af79f195e5c9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkipTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2882c2a0-6147-45cb-bd0f-89cd8c3f86e2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a44b7571-2ce0-43c6-a821-dcbafdf91c8d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c210e9f6-8212-4f1a-a9f3-0658bd757693"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31512417-89e1-453d-bafd-199d3b3c54b2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // 2DMovement
        m__2DMovement = asset.FindActionMap("2DMovement", throwIfNotFound: true);
        m__2DMovement_SkipTurn = m__2DMovement.FindAction("SkipTurn", throwIfNotFound: true);
        m__2DMovement_MoveUp = m__2DMovement.FindAction("MoveUp", throwIfNotFound: true);
        m__2DMovement_MoveDown = m__2DMovement.FindAction("MoveDown", throwIfNotFound: true);
        m__2DMovement_MoveLeft = m__2DMovement.FindAction("MoveLeft", throwIfNotFound: true);
        m__2DMovement_MoveRight = m__2DMovement.FindAction("MoveRight", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // 2DMovement
    private readonly InputActionMap m__2DMovement;
    private List<I_2DMovementActions> m__2DMovementActionsCallbackInterfaces = new List<I_2DMovementActions>();
    private readonly InputAction m__2DMovement_SkipTurn;
    private readonly InputAction m__2DMovement_MoveUp;
    private readonly InputAction m__2DMovement_MoveDown;
    private readonly InputAction m__2DMovement_MoveLeft;
    private readonly InputAction m__2DMovement_MoveRight;
    public struct _2DMovementActions
    {
        private @PlayerInputs m_Wrapper;
        public _2DMovementActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @SkipTurn => m_Wrapper.m__2DMovement_SkipTurn;
        public InputAction @MoveUp => m_Wrapper.m__2DMovement_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m__2DMovement_MoveDown;
        public InputAction @MoveLeft => m_Wrapper.m__2DMovement_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m__2DMovement_MoveRight;
        public InputActionMap Get() { return m_Wrapper.m__2DMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_2DMovementActions set) { return set.Get(); }
        public void AddCallbacks(I_2DMovementActions instance)
        {
            if (instance == null || m_Wrapper.m__2DMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m__2DMovementActionsCallbackInterfaces.Add(instance);
            @SkipTurn.started += instance.OnSkipTurn;
            @SkipTurn.performed += instance.OnSkipTurn;
            @SkipTurn.canceled += instance.OnSkipTurn;
            @MoveUp.started += instance.OnMoveUp;
            @MoveUp.performed += instance.OnMoveUp;
            @MoveUp.canceled += instance.OnMoveUp;
            @MoveDown.started += instance.OnMoveDown;
            @MoveDown.performed += instance.OnMoveDown;
            @MoveDown.canceled += instance.OnMoveDown;
            @MoveLeft.started += instance.OnMoveLeft;
            @MoveLeft.performed += instance.OnMoveLeft;
            @MoveLeft.canceled += instance.OnMoveLeft;
            @MoveRight.started += instance.OnMoveRight;
            @MoveRight.performed += instance.OnMoveRight;
            @MoveRight.canceled += instance.OnMoveRight;
        }

        private void UnregisterCallbacks(I_2DMovementActions instance)
        {
            @SkipTurn.started -= instance.OnSkipTurn;
            @SkipTurn.performed -= instance.OnSkipTurn;
            @SkipTurn.canceled -= instance.OnSkipTurn;
            @MoveUp.started -= instance.OnMoveUp;
            @MoveUp.performed -= instance.OnMoveUp;
            @MoveUp.canceled -= instance.OnMoveUp;
            @MoveDown.started -= instance.OnMoveDown;
            @MoveDown.performed -= instance.OnMoveDown;
            @MoveDown.canceled -= instance.OnMoveDown;
            @MoveLeft.started -= instance.OnMoveLeft;
            @MoveLeft.performed -= instance.OnMoveLeft;
            @MoveLeft.canceled -= instance.OnMoveLeft;
            @MoveRight.started -= instance.OnMoveRight;
            @MoveRight.performed -= instance.OnMoveRight;
            @MoveRight.canceled -= instance.OnMoveRight;
        }

        public void RemoveCallbacks(I_2DMovementActions instance)
        {
            if (m_Wrapper.m__2DMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(I_2DMovementActions instance)
        {
            foreach (var item in m_Wrapper.m__2DMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m__2DMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public _2DMovementActions @_2DMovement => new _2DMovementActions(this);
    public interface I_2DMovementActions
    {
        void OnSkipTurn(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
    }
}
