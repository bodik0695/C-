namespace SmartHouse
{
    public interface IFreezer1
    {
        FreezerModes Condition { get; }

        void SetFastFreezeMode();
        void SetFreezingMode();
        void SetStorageMode();
    }
}