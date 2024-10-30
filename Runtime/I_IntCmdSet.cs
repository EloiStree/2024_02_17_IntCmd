namespace Eloi.IID
{
    public interface I_IntCmdSet
    {

        public void SetValue(int value);
        public void SetValue(I_IntCmdGet value);
        public void SetPositive();
        public void SetNegative();
    }


}