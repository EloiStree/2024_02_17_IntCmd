using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IID
{
    public class IntCmdPlayerSingletonMono
    : AbstractIntCmdHolderMono
    {


        public UnityEvent<I_IntCmd> m_onValueChanged;
        public UnityEvent<int> m_onValueChangedInt;
        int m_previousValue;
        int m_currentValue;

        private void Awake()
        {
            m_previousValue = GetChildrenIntCmd().GetValue();
            m_currentValue = GetChildrenIntCmd().GetValue();
        }
        private void Update()
        {
            CheckForChanged();
        }

        private void CheckForChanged()
        {
            m_currentValue = GetChildrenIntCmd().GetValue();
            if (m_currentValue != m_previousValue)
            {
                m_previousValue = m_currentValue;
                m_onValueChanged.Invoke(GetChildrenIntCmd());
                m_onValueChangedInt.Invoke(m_currentValue);
            }
        }

        public override I_IntCmd GetChildrenIntCmd()
        {
            return IntCmdPlayerSingleton.GetPlayer();
        }

        public void NotifyPossibleChanged()
        {
            IntCmdPlayerSingleton.NotifyPossibleChanged();
        }
        //public void SetWith(I_IndexIntCmdGet value) { IntCmdPlayerSingleton.GetPlayer().SetValue(value.GetIndexInt()); }

        public override void NotifyChildrenValueChanged()
        {
            CheckForChanged();

        }
    }


    public class IntCmdPlayerSingleton
    {
        static IntCmd Player = new IntCmd();
        public static I_IntCmd GetPlayer() { return Player; }

        public delegate void PossibleChanged();
        public static PossibleChanged m_onPossibleChanged;

        public static void NotifyPossibleChanged() { if (m_onPossibleChanged != null) m_onPossibleChanged(); }
        public static void AddListener(PossibleChanged listener) { m_onPossibleChanged += listener; }
        public static void RemoveListener(PossibleChanged listener) { m_onPossibleChanged -= listener; }

    }


    public class PushIntCmdToPlayerSingletonMono : MonoBehaviour
    {


        public void PushInteger(int value)
        {

            IntCmdPlayerSingleton.GetPlayer().SetValue(value);
        }
        public void PushInteger(string value)
        {
            if (int.TryParse(value, out int i))
                IntCmdPlayerSingleton.GetPlayer().SetValue(i);
        }
    }
}