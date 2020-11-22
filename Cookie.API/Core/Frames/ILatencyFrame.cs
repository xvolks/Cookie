namespace Cookie.API.Core.Frames
{
    public interface ILatencyFrame
    {
        /// <summary>
        ///     The sequence to send to the server
        /// </summary>
        int Sequence { get; set; }

        void LowSend();

        void UpdateLatency();

        int GetLatencyAvg();

        int GetSamplesCount();

        int GetSamplesMax();
    }
}