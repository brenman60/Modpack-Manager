using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace brenman60_s_Modpack_Manager.Scripts.Pages
{
    public static class UIItemTemplates
    {
        public static Grid CreateModItem(string modId, string modName, string modVersion, string modDescription)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return null;

            Grid templateModItem = new Grid
            {
                Name = modId + "ModItem",
                Height = 100,
                Width = double.NaN,
                Background = (Brush)mainWindow.FindResource("hoverColor2"),
                Margin = new Thickness(15, 5, 15, 5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
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

        public static Grid CreateModpackItem(string modpackId, string modpackName, string modpackVersion, string modpackDescription, int modAmount)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return null;

            Grid modpack0Item = new Grid
            {
                Name = modpackId + "Item",
                Height = 100,
                Width = double.NaN,
                Background = (Brush)mainWindow.FindResource("hoverColor2"),
                Margin = new Thickness(15, 5, 15, 5),
                Visibility = Visibility.Visible
            };

            modpack0Item.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(173, GridUnitType.Star) });
            modpack0Item.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(45, GridUnitType.Star) });

            TextBlock modpack0ModItemName = new TextBlock
            {
                Name = modpackId + "ModItemName",
                Text = modpackName,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(10, 10, 0, 57),
                FontSize = 22,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 317,
            };
            Grid.SetColumn(modpack0ModItemName, 0);

            TextBlock modpack0ModItemVersion = new TextBlock
            {
                Name = modpackId + "ModItemVersion",
                Text = modpackVersion,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(0, 14, 10, 0),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Right,
                Width = 177,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 24,
            };
            Grid.SetColumn(modpack0ModItemVersion, 0);

            TextBlock modpack0ModItemDescription = new TextBlock
            {
                Name = modpackId + "ModItemDescription",
                Text = modpackDescription,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(10, 43, 10, 10),
                FontSize = 16,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                Width = double.NaN
            };
            Grid.SetColumn(modpack0ModItemDescription, 0);

            Button modpack0Select = new Button
            {
                Name = modpackId + "Select",
                Margin = new Thickness(6, 32, 6, 10),
                Style = (Style)mainWindow.FindResource("basicButton"),
                RenderTransformOrigin = new Point(1, 0.5),
                MinWidth = 120,
                Width = double.NaN,
            };
            Grid.SetColumn(modpack0Select, 1);

            TextBlock modpack0SelectText = new TextBlock
            {
                Name = modpackId + "SelectText",
                Text = "Select",
                Style = (Style)mainWindow.FindResource("basicText"),
                FontSize = 32,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(1, 0.5),
                Width = double.NaN,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(10, 0, 10, 0)
            };

            TextBlock modpack0ModItemModAmount = new TextBlock
            {
                Name = modpackId + "ModItemModAmount",
                Text = "Mods: " + modAmount,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(0, 3, 0, 0),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = 123,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 24,
            };
            Grid.SetColumn(modpack0ModItemModAmount, 1);

            modpack0Select.Click += mainWindow.ChangeModpack;

            modpack0Item.Children.Add(modpack0ModItemName);
            modpack0Item.Children.Add(modpack0ModItemVersion);
            modpack0Item.Children.Add(modpack0ModItemDescription);
            modpack0Item.Children.Add(modpack0ModItemModAmount);
            modpack0Select.Content = modpack0SelectText;
            modpack0Item.Children.Add(modpack0Select);

            return modpack0Item;
        }
    }
}
