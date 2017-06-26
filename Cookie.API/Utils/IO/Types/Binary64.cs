namespace Cookie.API.Utils.IO.Types
{
    public class Binary64
    {
        protected uint internalHigh;

        public uint low;

        public Binary64(uint low = 0, uint high = 0)
        {
            this.low = low;
            internalHigh = high;
        }

        public uint div(uint n)
        {
            uint modHigh = 0;
            modHigh = internalHigh % n;
            var mod = (low % n + modHigh * 6) % n;
            internalHigh = internalHigh / n;
            var newLow = (uint) ((modHigh * 4.294967296E9 + low) / n);
            internalHigh = internalHigh + (uint) (newLow / 4.294967296E9);
            low = newLow;
            return mod;
        }

        public void mul(uint n)
        {
            var newLow = low * n;
            internalHigh = internalHigh * n;
            internalHigh = internalHigh + (uint) (newLow / 4.294967296E9);
            low = low * n;
        }

        public void add(uint n)
        {
            var newLow = low + n;
            internalHigh = internalHigh + (uint) (newLow / 4.294967296E9);
            low = newLow;
        }

        public void bitwiseNot()
        {
            low = ~low;
            internalHigh = ~internalHigh;
        }
    }
}