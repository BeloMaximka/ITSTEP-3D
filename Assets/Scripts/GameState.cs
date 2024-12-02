using Assets.Scripts.Models;
using System;
using System.Collections.Generic;


namespace Assets.Scripts
{
    public static class GameState
    {
        public static bool IsFpv { get; set; }
        public static float FlashCharge { get; set; } = 1f;
        public static Dictionary<string, KeyInfo> CollectedKeys { get; } = new();

        public static void SetKeyStale(string key, bool value = true)
        {
            if (CollectedKeys.TryGetValue(key, out KeyInfo info))
            {
                info.IsStale = value;
                return;
            }
            CollectedKeys[key] = new KeyInfo { IsStale = value };
        }

        public static void OnKeyPickup(string name)
        {
            if (CollectedKeys.TryGetValue(name, out KeyInfo info))
            {
                info.IsPicked = true;
            }
            else
            {
                info = new KeyInfo { IsPicked = true };
                CollectedKeys[name] = info;
            }

            KeyPicked(new KeyInteractionPayload()
            {
                IsStale = info.IsStale,
                Name = name
            });
        }

        public static event Action<KeyInteractionPayload> KeyPicked;
    }
}
