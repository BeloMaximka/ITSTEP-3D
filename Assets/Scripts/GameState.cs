﻿using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class GameState
    {
        public static bool IsFpv { get; set; }
        public static float FlashCharge { get; set; }
        public static Dictionary<string, bool> CollectedKeys { get; } = new();
    }
}