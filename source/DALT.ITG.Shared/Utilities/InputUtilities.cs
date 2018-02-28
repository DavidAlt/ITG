using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DALT.ITG.Shared.Utilities
{
    public static class InputUtilities
    {
        /// <summary>
        /// Returns true if any key is currently pressed
        /// </summary>
        /// <returns>bool</returns>
        public static bool IsAnyKeyPressed()
        {
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                if (key != Key.None)
                    if (Keyboard.IsKeyDown((Key)key))
                        return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a list of keys that are currently pressed
        /// </summary>
        /// <returns>IEnumerable<System.Windows.Input.Key></returns>
        public static IEnumerable<Key> KeysDown()
        {
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                if (Keyboard.IsKeyDown(key))
                    yield return key;
            }
        }
    }
}
