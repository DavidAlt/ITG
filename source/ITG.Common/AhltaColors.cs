using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DALT.Utility;

namespace ITG.Common
{
    public static class AhltaColors
    {
        public static Dictionary<string, int> CurrentTheme = new Dictionary<string, int>()
        {
            { "ActiveBorder", SystemColors.ActiveBorderColor.ToIntBGR() },
            { "ActiveCaption", SystemColors.ActiveCaptionColor.ToIntBGR() },
            { "ActiveCaptionText", SystemColors.ActiveCaptionTextColor.ToIntBGR() },
            { "AppWorkspace", SystemColors.AppWorkspaceColor.ToIntBGR() },
            { "Control", SystemColors.ControlColor.ToIntBGR() },
            { "ControlDark", SystemColors.ControlDarkColor.ToIntBGR() },
            { "ControlDarkDark", SystemColors.ControlDarkDarkColor.ToIntBGR() },
            { "ControlLight", SystemColors.ControlLightBrush.ToIntBGR() },
            { "ControlLightLight", SystemColors.ControlLightLightColor.ToIntBGR() },
            { "ControlText", SystemColors.ControlTextColor.ToIntBGR() },
            { "Desktop", SystemColors.DesktopColor.ToIntBGR() },
            { "GradientActiveCaption", SystemColors.GradientActiveCaptionColor.ToIntBGR() },
            { "GradientInactiveCaption", SystemColors.GradientInactiveCaptionColor.ToIntBGR() },
            { "GrayText", SystemColors.GrayTextColor.ToIntBGR() },
            { "Highlight", SystemColors.HighlightColor.ToIntBGR() },
            { "HighlightText", SystemColors.HighlightTextColor.ToIntBGR() }, 
            { "HotTrack", SystemColors.HotTrackColor.ToIntBGR() },
            { "InactiveBorder", SystemColors.InactiveBorderColor.ToIntBGR() },
            { "InactiveCaption", SystemColors.InactiveCaptionColor.ToIntBGR() },
            { "InactiveCaptionText", SystemColors.InactiveCaptionTextColor.ToIntBGR() },
            { "Info", SystemColors.InfoColor.ToIntBGR() },
            { "InfoText", SystemColors.InfoTextColor.ToIntBGR() },
            { "Menu", SystemColors.MenuColor.ToIntBGR() },
            { "MenuBar", SystemColors.MenuBarColor.ToIntBGR() },
            { "MenuHighlight", SystemColors.MenuHighlightColor.ToIntBGR() },
            { "MenuText", SystemColors.MenuTextColor.ToIntBGR() },
            { "ScrollBar", SystemColors.ScrollBarColor.ToIntBGR() },
            { "Window", SystemColors.WindowColor.ToIntBGR() },
            { "WindowFrame", SystemColors.WindowFrameColor.ToIntBGR() },
            { "WindowText", SystemColors.WindowTextColor.ToIntBGR() }
        };

        public static Dictionary<string, int> ClassicTheme = new Dictionary<string,int>()
        {
            { "ActiveBorder", "FFD4D0C8".ToIntBGR() },
            { "ActiveCaption", "FF0A246A".ToIntBGR() },
            { "ActiveCaptionText", "FFFFFFFF".ToIntBGR() },
            { "AppWorkspace", "FF808080".ToIntBGR() },
            { "Control", "FFD4D0C8".ToIntBGR() },
            { "ControlDark", "FF808080".ToIntBGR() },
            { "ControlDarkDark", "FF404040".ToIntBGR() },
            { "ControlLight", "FFD4D0C8".ToIntBGR() },
            { "ControlLightLight", "FFFFFFFF".ToIntBGR() },
            { "ControlText", "FF000000".ToIntBGR() },
            { "Desktop", "FF3A6EA5".ToIntBGR() },
            { "GradientActiveCaption", "FFA6CAF0".ToIntBGR() },
            { "GradientInactiveCaption", "FFC0C0C0".ToIntBGR() },
            { "GrayText", "FF808080".ToIntBGR() },
            { "Highlight", "FF0A246A".ToIntBGR() },
            { "HighlightText", "FFFFFFFF".ToIntBGR() }, 
            { "HotTrack", "FF000080".ToIntBGR() },
            { "InactiveBorder", "FFD4D0C8".ToIntBGR() },
            { "InactiveCaption", "FF808080".ToIntBGR() },
            { "InactiveCaptionText", "FFD4D0C8".ToIntBGR() },
            { "Info", "FFFFFFE1".ToIntBGR() },
            { "InfoText", "FF000000".ToIntBGR() },
            { "Menu", "FFD4D0C8".ToIntBGR() },
            { "MenuBar", "FFD4D0C8".ToIntBGR() },
            { "MenuHighlight", "FF0A246A".ToIntBGR() },
            { "MenuText", "FF000000".ToIntBGR() },
            { "ScrollBar", "FFD4D0C8".ToIntBGR() },
            { "Window", "FFFFFFFF".ToIntBGR() },
            { "WindowFrame", "FF000000".ToIntBGR() },
            { "WindowText", "FF000000".ToIntBGR() }
        };


        public static int GetBGRInt(Dictionary<string, int> dict, string key)
        {
            int result;
            dict.TryGetValue(key, out result);
            return result;
        }


    }
}
