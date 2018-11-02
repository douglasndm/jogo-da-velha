using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Jogo_da_Velha.Classes
{
    static class Customization
    {
        public static void ChangeTitleBarColor(Color TitleBarBackgroud, Color TitleBarForeground)
        {
            //PC customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.ButtonBackgroundColor = TitleBarBackgroud;
                    titleBar.ButtonForegroundColor = TitleBarForeground;
                    titleBar.BackgroundColor = TitleBarBackgroud;
                    titleBar.ForegroundColor = TitleBarForeground;

                    titleBar.InactiveBackgroundColor = TitleBarBackgroud;
                    titleBar.InactiveForegroundColor = TitleBarForeground;
                    titleBar.ButtonInactiveBackgroundColor = TitleBarBackgroud;
                    titleBar.ButtonInactiveForegroundColor = TitleBarForeground;
                }
            }
        }
    }
}
