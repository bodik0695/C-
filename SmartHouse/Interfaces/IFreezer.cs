namespace SmartHouse
{
    public interface IFreezer : IDevice
    {
        string CurrentFridge { get; set; }
        bool PresenceFridge { get; set; }
        Temperature Temper { get; set; }
        Mode Mod { get; set; }

        void SetFastFreezeMode();
        void SetFreezingMode();
        void SetStorageMode();
        void ConnectFridge(string fridgeName);
        void DisableFrifge(string fridgeName);
        string ToString();
    }
}