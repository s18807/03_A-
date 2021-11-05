// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""BasicMovement"",
            ""id"": ""067c13fc-d333-48e6-ba44-e1b00aa3ded1"",
            ""actions"": [
                {
                    ""name"": ""MovementVector"",
                    ""type"": ""Value"",
                    ""id"": ""e6318668-0d97-4bd0-ac00-7a648015b56a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.1)""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86e5931f-07da-4336-ae42-0510df68be17"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""970ba905-31ca-4184-87bb-5738e8f313b3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVector"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fd0e3208-0842-4c98-bd6c-0caef376782b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""493e0226-a7eb-473f-a311-573fcc4c0a1e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a9b15020-4771-4932-b0f4-72c0072f217f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""775bc2a3-7801-43b2-a0c9-c44c0da3f195"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MovementVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bdb3e792-e3b4-4a3a-99c1-c9e684a08d38"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicMovement
        m_BasicMovement = asset.FindActionMap("BasicMovement", throwIfNotFound: true);
        m_BasicMovement_MovementVector = m_BasicMovement.FindAction("MovementVector", throwIfNotFound: true);
        m_BasicMovement_Attack = m_BasicMovement.FindAction("Attack", throwIfNotFound: true);
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

    // BasicMovement
    private readonly InputActionMap m_BasicMovement;
    private IBasicMovementActions m_BasicMovementActionsCallbackInterface;
    private readonly InputAction m_BasicMovement_MovementVector;
    private readonly InputAction m_BasicMovement_Attack;
    public struct BasicMovementActions
    {
        private @PlayerControlls m_Wrapper;
        public BasicMovementActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementVector => m_Wrapper.m_BasicMovement_MovementVector;
        public InputAction @Attack => m_Wrapper.m_BasicMovement_Attack;
        public InputActionMap Get() { return m_Wrapper.m_BasicMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicMovementActions set) { return set.Get(); }
        public void SetCallbacks(IBasicMovementActions instance)
        {
            if (m_Wrapper.m_BasicMovementActionsCallbackInterface != null)
            {
                @MovementVector.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovementVector;
                @MovementVector.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovementVector;
                @MovementVector.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnMovementVector;
                @Attack.started -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_BasicMovementActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_BasicMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementVector.started += instance.OnMovementVector;
                @MovementVector.performed += instance.OnMovementVector;
                @MovementVector.canceled += instance.OnMovementVector;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public BasicMovementActions @BasicMovement => new BasicMovementActions(this);
    public interface IBasicMovementActions
    {
        void OnMovementVector(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
