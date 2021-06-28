using UnityModManagerNet;
using ModKit;

namespace SolastaLevel20.Viewers
{
    public class HelpViewer : IMenuSelectablePage
    {
        public string Name => "Help";

        public int Priority => 0;

        private static void DisplayHelp()
        {
            UI.Label("Welcome to Level 20 with Multi Class".yellow().bold());
            UI.Div();

            using (UI.HorizontalScope())
            {
                using (UI.VerticalScope())
                {
                    UI.Label("Multi Class (ALPHA VERSION):".bold());
                    UI.Label(". deity selection is forced on all new characters to avoid issues with clerics or paladins");
                    UI.Label(". character inspection UI needs a lot of tweaks [planned]");
                    UI.Label(". need to rework the spell system for multi-class");
                    UI.Label(". need to test channel divinity, unarmored defense and other multi-class rules");
                }
            }
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Main.Mod == null) return;

            DisplayHelp();
        }
    }
}