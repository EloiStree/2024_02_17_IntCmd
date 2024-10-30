using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{
    public class IntCmdMono : AbstractIntCmdHolderMono
    {
        public IntCmd m_intCmdValue;

        public override I_IntCmd GetChildrenIntCmd()
        {
            return m_intCmdValue;
        }

        public override void NotifyChildrenValueChanged()
        { }
    }



    [System.Serializable]
    public class IntCmd : I_IntCmd
    {
        [SerializeField] int m_intCmdValue;

        public IntCmd(int intCmdValue)
        {
            m_intCmdValue = intCmdValue;
        }
        public IntCmd()
        {
            m_intCmdValue = 0;
        }

        public int GetValue() { return m_intCmdValue; }
        public void GetValue(out int value) { value = m_intCmdValue; }

        public void SetValue(int value)
        {
            m_intCmdValue = value;
        }

        public void SetValue(I_IntCmdGet value)
        {
            if (value != null)
                m_intCmdValue = value.GetValue();
        }

        public void SetPositive()
        {
            if (Math.Sign(m_intCmdValue) < 0)
                m_intCmdValue *= -1;
        }

        public void SetNegative()
        {
            if (Math.Sign(m_intCmdValue) > 0)
                m_intCmdValue *= -1;
        }
    }

    [System.Serializable]
    public class IntCmdEvent : UnityEvent<IntCmd> { }

    [System.Serializable]
    public class IntCmdDigitsEvent : UnityEvent<IntCmdDigits> { }


}