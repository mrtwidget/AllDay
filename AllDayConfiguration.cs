using Rocket.API;

namespace NEXIS.AllDay
{
    public class AllDayConfiguration : IRocketPluginConfiguration
    {
        public bool SendResetMessage;
        public bool SendPlayerMessage;
        public uint CycleResetTime;
        public uint CycleStartTime;

        public void LoadDefaults()
        {
            SendResetMessage = true;
            SendPlayerMessage = true;
            CycleResetTime = 2300;
            CycleStartTime = 1;
        }
    }
}