using System.Windows;

namespace ContentManager.UI.Utils;

public static class FocusUtils
{
    public static void AutoFocus(UIElement uiElement)
    {
        uiElement.IsVisibleChanged += (_, args) =>
        {
            if (args.NewValue is true)
                uiElement.Focus();
        };
    }
}