namespace Cookie.API.Core.Pathmanager
{
    public interface IPathManager
    {
        bool Launched { get; set; }
        IAccount Account { get; set; }
        void Start(string trajet);
        void Stop();
        void DoAction();
    }
}