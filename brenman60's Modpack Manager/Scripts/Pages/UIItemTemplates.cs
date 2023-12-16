using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public static class UIItemTemplates
    {
        public static Grid CreateModItem(string modId, string modName, string modVersion, string modDescription)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            Grid templateModItem = new Grid
            {
                Name = modId + "ModItem",
                Height = 100,
                Width = double.NaN,
                Background = (Brush)mainWindow.FindResource("hoverColor2"),
                Margin = new Thickness(15)
            };

            TextBlock templateModItemName = new TextBlock
            {
                Name = modId + "ModItemName",
                Text = modName,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(10, 10, 0, 34),
                FontSize = 36,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 269
            };

            TextBlock templateModItemVersion = new TextBlock
            {
                Name = modId + "ModItemVersion",
                Text = modVersion,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(10, 66, 0, 10),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 148
            };

            TextBlock templateModItemDescription = new TextBlock
            {
                Name = modId + "ModItemDescription",
                Text = modDescription.Replace('"'.ToString(), string.Empty),
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(317, 10, 15, 10),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(1, 0.5),
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            templateModItem.Children.Add(templateModItemName);
            templateModItem.Children.Add(templateModItemVersion);
            templateModItem.Children.Add(templateModItemDescription);

            return templateModItem;
        }
    }
}
