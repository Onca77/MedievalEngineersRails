﻿using System;
using VRage.Game;
using VRage.Library.Logging;

namespace Equinox76561198048419394.RailSystem.Util
{
    public static class Assert
    {
        public static void True(bool val, string msg)
        {
            if (!val)
                MyLog.Default.Warning("ASSERT: " + msg);
        }

        public static void False(bool val, string msg)
        {
            True(!val, msg);
        }

        public static void Equals<T>(T expected, T actual, string msg) where T : IEquatable<T>
        {
            if (!actual.Equals(expected))
                MyLog.Default.Warning("ASSERT: " + msg + " expected " + expected + ", got " + actual);
        }

        public static void NotEqual<T>(T a, T b, string msg) where T : IEquatable<T>
        {
            if (a.Equals(b))
                MyLog.Default.Warning("ASSERT: " + msg + " " + a + " == " + b);
        }

        public static T Definition<T>(MyDefinitionId definition, string msg) where T : MyDefinitionBase
        {
            var res = MyDefinitionManager.Get<T>(definition);
            if (res == null)
                MyLog.Default.Warning($"ASSERT: Failed to find {definition}.  {msg}");
            return res;
        }

        public static void NotEqualObj(object a, object b, string msg)
        {
            if (Equals(a, b))
                MyLog.Default.Warning("ASSERT: " + msg + " " + a + " == " + b);
        }
    }
}