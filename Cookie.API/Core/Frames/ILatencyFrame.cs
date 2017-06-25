namespace Cookie.API.Core.Frames
{
    public interface ILatencyFrame
    {
        int Sequence { get; set; }

        void LowSend();

        void UpdateLatency();

        int GetLatencyAvg();

        int GetSamplesCount();

        int GetSamplesMax();
    }
}