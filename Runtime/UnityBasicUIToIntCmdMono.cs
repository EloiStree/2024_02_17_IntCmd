
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Eloi.IID
{
    public class UnityBasicUIToIntCmdMono : MonoBehaviour
    {

        public IntCmd m_uiState;

        public List<UI2IntCmd.UIF_Slider09> m_slider09;
        public List<UI2IntCmd.UIF_Slider0129> m_slider0129;
        public List<UI2IntCmd.UIF_ToggleBoolean> m_oggleBoolean;
        public List<UI2IntCmd.UIF_ToggleAsDigit> m_oggleAsDigit;

        public void RefreshStateIn()
        {
            RefreshStateIn(m_uiState);
        }
        public void RefreshStateIn(I_IntCmd command)
        {
            if (command == null)
                return;

            //foreach (var item in m_digitToPercent)
            //{
            //    IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            //    item.m_onPercentPushed.Invoke(value / 9f);
            //}
            //foreach (var item in m_digitToPercent0129)
            //{
            //    IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            //    if (value == 0)
            //    {
            //        item.m_onPercentPushed.Invoke(0);
            //    }
            //    else if (value == 1)
            //    {
            //        item.m_onPercentPushed.Invoke(1);
            //    }
            //    else
            //    {
            //        //0 1    0123 4567
            //        //0 1    2345 6789
            //        item.m_onPercentPushed.Invoke((value - 2) / 8);
            //    }
            //}
            //foreach (var item in m_digitToBooleanOverZero)
            //{
            //    IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            //    item.m_onBooleanPushed.Invoke(value > 0);
            //}
            //foreach (var item in m_digitToBooleanEquals)
            //{
            //    IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            //    item.m_onBooleanPushed.Invoke(value == 0);
            //}
            //foreach (var item in m_digitToBooleanBetween)
            //{
            //    IntCmdDigitUtility.GetDigitOf(command, item.m_digit, out byte value);
            //    if (item.m_inclusive)
            //        item.m_onBooleanPushed.Invoke(value >= item.m_valueMin && value <= item.m_valueMax);
            //    else item.m_onBooleanPushed.Invoke(value > item.m_valueMin && value < item.m_valueMax);
            //}
        }




        //[System.Serializable]
        //public class DigitToPercent09 : UIF_DigitFetcher
        //{
        //    public FloatEvent m_onPercentPushed;

        //}
        //[System.Serializable]
        //public class DigitToPercent0129 : UIF_DigitFetcher
        //{
        //    public FloatEvent m_onPercentPushed;
        //}

        //[System.Serializable]
        //public class DigitToBooleanOverZero : UIF_DigitFetcher
        //{
        //    public BoolEvent m_onBooleanPushed;
        //}
        //[System.Serializable]
        //public class DigitToBooleanEqualTo : UIF_DigitFetcher
        //{
        //    public byte m_value = 9;
        //    public BoolEvent m_onBooleanPushed;
        //}
        //[System.Serializable]
        //public class DigitToBooleanBetween : UIF_DigitFetcher
        //{
        //    public byte m_valueMin = 1;
        //    public byte m_valueMax = 9;
        //    public bool m_inclusive = true;
        //    public BoolEvent m_onBooleanPushed;
        //}

    }
}