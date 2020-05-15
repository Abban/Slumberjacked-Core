// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Settings/Level/LevelControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BBX.Main.Level
{
    public class @LevelControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @LevelControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""LevelControls"",
    ""maps"": [
        {
            ""name"": ""Level"",
            ""id"": ""ba3f65b1-e14b-4ac9-9a1d-eab4ab5812a2"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ea1cb62c-2da9-440f-b84a-0e9c416d0f28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""a1defa2f-4c2a-449c-ba3a-728399304791"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b9d64a7-969c-4261-8045-a0c33d1fbb75"",
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
                    ""id"": ""0a48c2f7-7abf-4537-a247-940c22c81383"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Level
            m_Level = asset.FindActionMap("Level", throwIfNotFound: true);
            m_Level_Pause = m_Level.FindAction("Pause", throwIfNotFound: true);
            m_Level_Reset = m_Level.FindAction("Reset", throwIfNotFound: true);
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

        // Level
        private readonly InputActionMap m_Level;
        private ILevelActions m_LevelActionsCallbackInterface;
        private readonly InputAction m_Level_Pause;
        private readonly InputAction m_Level_Reset;
        public struct LevelActions
        {
            private @LevelControls m_Wrapper;
            public LevelActions(@LevelControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_Level_Pause;
            public InputAction @Reset => m_Wrapper.m_Level_Reset;
            public InputActionMap Get() { return m_Wrapper.m_Level; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
            public void SetCallbacks(ILevelActions instance)
            {
                if (m_Wrapper.m_LevelActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnPause;
                    @Reset.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnReset;
                    @Reset.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnReset;
                    @Reset.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnReset;
                }
                m_Wrapper.m_LevelActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @Reset.started += instance.OnReset;
                    @Reset.performed += instance.OnReset;
                    @Reset.canceled += instance.OnReset;
                }
            }
        }
        public LevelActions @Level => new LevelActions(this);
        public interface ILevelActions
        {
            void OnPause(InputAction.CallbackContext context);
            void OnReset(InputAction.CallbackContext context);
        }
    }
}
