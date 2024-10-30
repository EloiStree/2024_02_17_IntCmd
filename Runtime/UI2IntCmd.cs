using UnityEngine;
using UnityEngine.Events;


namespace Eloi.IID
{
    public class UI2IntCmd
    {


        [System.Serializable]
        public class FloatEvent
        {

            public float m_lastValue;
            public UnityEvent<float> m_onPushedPercent;

            public void Invoke(float value) { m_onPushedPercent.Invoke(value); }
        }
        [System.Serializable]
        public class BoolEvent
        {
            public bool m_lastValue;
            public UnityEvent<bool> m_onPushedBoolean;
            public void Invoke(bool value) { m_onPushedBoolean.Invoke(value); }

        }


        public abstract class UIF_DigitFetcher
        {

            [Tooltip("Just reminder of what you created it for")]
            public string m_context;
            public IntCmdDigitEnum m_digit;
        }
        public abstract class UIF_DigitFetcherBoolean : UIF_DigitFetcher
        {
            public bool m_inverseBoolean;

            public abstract bool GetBooleanStateOfUI();
        }
        public abstract class UIF_DigitFetcherByte : UIF_DigitFetcher
        {

            public abstract byte GetBooleanStateOfUI();
        }

        public abstract class UIF_DigitFetcherPercent01 : UIF_DigitFetcher
        {
            public bool m_inversePercent;
            public abstract float GetPercentStateOfUI();
        }
        public abstract class UIF_DigitFetcherPercent0129 : UIF_DigitFetcher
        {
            public bool m_inversePercent;
            public abstract float GetPercentStateOfUI();
        }

        [System.Serializable]
        public class UIF_Slider09 : UIF_DigitFetcherPercent01
        {
            public UnityEngine.UI.Slider m_uiElement;

            public override float GetPercentStateOfUI()
            {
                return m_uiElement.value;
            }
        }
        [System.Serializable]
        public class UIF_Slider0129 : UIF_DigitFetcherPercent0129
        {
            public UnityEngine.UI.Slider m_uiElement;

            public override float GetPercentStateOfUI()
            {
                return m_uiElement.value;
            }
        }
        [System.Serializable]
        public class UIF_ToggleBoolean : UIF_DigitFetcherBoolean
        {
            public UnityEngine.UI.Toggle m_uiElement;

            public override bool GetBooleanStateOfUI()
            {
                return m_uiElement.isOn;
            }
        }


        [System.Serializable]
        public class UIF_ToggleAsDigit : UIF_DigitFetcherByte
        {
            public byte m_falseValue = 0;
            public byte m_trueValue = 9;
            public UnityEngine.UI.Toggle m_uiElement;

            public override byte GetBooleanStateOfUI()
            {
                return m_uiElement.isOn ? m_trueValue : m_falseValue;
            }
        }
    }
}