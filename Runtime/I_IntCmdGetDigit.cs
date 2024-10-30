namespace Eloi.IID
{
    public interface I_IntCmdGetDigit
    {
        public void GetValue(IntCmdDigitEnum index, out byte digit);
        public byte GetValue(IntCmdDigitEnum index);
    }


}