using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{


    [System.Serializable]
    public class IntCmdRelayMono : AbstractIntCmdHolderMono
    {
        public IntCmd m_lastValue = new IntCmd();
        public IntCmdEvent m_onIntCmdEvent;
        public UnityEvent<int> m_onIntEvent;
        public void PushIn(string text)
        {
            if (int.TryParse(text, out int value))
            {
                m_lastValue.SetValue(value);

                m_onIntCmdEvent.Invoke(m_lastValue);
                m_onIntEvent.Invoke(value);
            }
        }
        public void PushIn(int value)
        {
            m_lastValue.SetValue(value);
            m_onIntCmdEvent.Invoke(m_lastValue);
            m_onIntEvent.Invoke(value);
        }
        public void PushIn(IntCmd value)
        {
            m_lastValue.SetValue(value.GetValue());
            m_onIntCmdEvent.Invoke(value);
            m_onIntEvent.Invoke(value.GetValue());
        }

        [ContextMenu("Repush Value In Inspector")]
        public void RepushValueInInspector()
        {
            m_onIntCmdEvent.Invoke(m_lastValue);
            m_onIntEvent.Invoke(m_lastValue.GetValue());
        }

        public override void NotifyChildrenValueChanged()
        {
            m_onIntCmdEvent.Invoke(m_lastValue);
            m_onIntEvent.Invoke(m_lastValue.GetValue());
        }

        public override I_IntCmd GetChildrenIntCmd()
        {
            return m_lastValue;
        }


    }
}

