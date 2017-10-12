using System;
using Rocket.Unturned;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using Rocket.API.Collections;
using SDG.Unturned;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace NEXIS.AllDay
{
    public class AllDay : RocketPlugin<AllDayConfiguration>
    {
        #region Fields

        public static AllDay Instance;

        #endregion

        #region Overrides

        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            Logger.Log("AllDay plug-in loaded", ConsoleColor.Green);
        }

        protected override void Unload()
        {
            Logger.Log("AllDay plug-in unloaded", ConsoleColor.Green);
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList() {
                    {"allday_reset_message", "Skipping night... Time has been reset to Day!"},
                    {"allday_player_connect", "This server uses the [AllDay] plugin to maintain Daytime all the time!"}
                };
            }
        }

        #endregion

        #region Events

        public void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            UnturnedChat.Say(player, AllDay.Instance.Translations.Instance.Translate("allday_player_connect"), Color.yellow);
        }

        #endregion

        public void FixedUpdate()
        {
            if (LightingManager.time >= AllDay.Instance.Configuration.Instance.CycleResetTime)
            {
                UnturnedChat.Say(AllDay.Instance.Translations.Instance.Translate("allday_reset_message"), Color.green);
                LightingManager.time = AllDay.Instance.Configuration.Instance.CycleStartTime;
            }
        }
    }
}