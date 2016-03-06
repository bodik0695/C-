namespace SmartHouse
{
    public interface IFreezer
    {
        FreezerModes Condition { get; }

        void SetFastFreezeMode();
        void SetFreezingMode();
        void SetStorageMode();
    }
}