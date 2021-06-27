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
                    UI.Label("TBD...".bold());
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