//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/PlayerControlls.inputactions
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

public partial class @PlayerControlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""KeyBoard"",
            ""id"": ""32771b47-950b-41f4-bfc1-b6ebbbf4a0cc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""efd3a413-50fe-4fe1-b67f-80ff21fbc065"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""d459fb52-ec19-4359-877c-a846b8b27cb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ba1b66ff-0ec6-4a47-9402-242c63636642"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TestKey"",
                    ""type"": ""Button"",
                    ""id"": ""b4d2f688-8738-4b5b-9925-c9db3a149447"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""0dfb173e-fa11-47ec-8c68-6d7a78750ecd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""96f78891-d53b-4fb5-8486-063473133c81"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f22949ca-c18a-432e-a7cd-6f94ea22f945"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""954021e5-a1a8-4750-9457-a051f49e7eb4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""32fcd694-5391-43ad-82c5-b892c558b1a2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b372a0c9-7736-4c5d-804e-d6b90e4a466e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5ec5c811-5992-4431-8ab2-56dc769f800b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bec69614-b1f4-4e49-acc0-e900a952e91b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ac8e9ba-0dcd-4662-aafd-722a81487441"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc8eee4b-e229-49ae-a837-d34b67d54d55"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyBoard
        m_KeyBoard = asset.FindActionMap("KeyBoard", throwIfNotFound: true);
        m_KeyBoard_Move = m_KeyBoard.FindAction("Move", throwIfNotFound: true);
        m_KeyBoard_Launch = m_KeyBoard.FindAction("Launch", throwIfNotFound: true);
        m_KeyBoard_Pause = m_KeyBoard.FindAction("Pause", throwIfNotFound: true);
        m_KeyBoard_TestKey = m_KeyBoard.FindAction("TestKey", throwIfNotFound: true);
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

    // KeyBoard
    private readonly InputActionMap m_KeyBoard;
    private IKeyBoardActions m_KeyBoardActionsCallbackInterface;
    private readonly InputAction m_KeyBoard_Move;
    private readonly InputAction m_KeyBoard_Launch;
    private readonly InputAction m_KeyBoard_Pause;
    private readonly InputAction m_KeyBoard_TestKey;
    public struct KeyBoardActions
    {
        private @PlayerControlls m_Wrapper;
        public KeyBoardActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeyBoard_Move;
        public InputAction @Launch => m_Wrapper.m_KeyBoard_Launch;
        public InputAction @Pause => m_Wrapper.m_KeyBoard_Pause;
        public InputAction @TestKey => m_Wrapper.m_KeyBoard_TestKey;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyBoardActions instance)
        {
            if (m_Wrapper.m_KeyBoardActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnMove;
                @Launch.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnLaunch;
                @Pause.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnPause;
                @TestKey.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnTestKey;
                @TestKey.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnTestKey;
                @TestKey.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnTestKey;
            }
            m_Wrapper.m_KeyBoardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @TestKey.started += instance.OnTestKey;
                @TestKey.performed += instance.OnTestKey;
                @TestKey.canceled += instance.OnTestKey;
            }
        }
    }
    public KeyBoardActions @KeyBoard => new KeyBoardActions(this);
    public interface IKeyBoardActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnTestKey(InputAction.CallbackContext context);
    }
}
