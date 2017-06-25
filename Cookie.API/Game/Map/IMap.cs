namespace Cookie.API.Game.Map
{
    public interface IMap
    {
        bool ChangeMap(string direction);
        bool MoveToCell(int cellid, bool changemap = false);
        bool MoveToElement(int cellid);

        void LaunchChangeMap(int mapId);

        void ConfirmMove(bool changemap = false);

        void UseElement(int id, int skillId);
    }
}