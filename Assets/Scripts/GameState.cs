using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class GameState
    {
        public static bool IsFpv { get; set; }
        public static float FlashCharge { get; set; } = 1f;
        public static Dictionary<string, KeyInfo> CollectedKeys { get; } = new();

        public static void SetKeyPicked(string key, bool value = true)
        {
            if (CollectedKeys.TryGetValue(key, out KeyInfo info))
            {
                info.IsPicked = value;
                return;
            }
            CollectedKeys[key] = new KeyInfo { IsPicked = value };
        }

        public static void SetKeyStale(string key, bool value = true)
        {
            if (CollectedKeys.TryGetValue(key, out KeyInfo info))
            {
                info.IsStale = value;
                return;
            }
            CollectedKeys[key] = new KeyInfo { IsStale = value };
        }
    }
}
