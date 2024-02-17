using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                Background = (Brush)mainWindow.FindResource("baseButtonColor"),
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

            Border border1 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("borderBaseColor"),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumnSpan(border1, 2);

            templateModItem.Children.Add(templateModItemName);
            templateModItem.Children.Add(templateModItemVersion);
            templateModItem.Children.Add(templateModItemDescription);
            templateModItem.Children.Add(border1);

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
                Background = (Brush)mainWindow.FindResource("hoverButtonColor"),
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
                Style = (Style)mainWindow.FindResource("tabButton"),
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

            Border border1 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("tabBorderBaseColor"),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumnSpan(border1, 2);

            Border border2 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("secondaryBorderBaseColor"),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumnSpan(border2, 1);
            Grid.SetColumn(border2, 2);

            Border border3 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("borderBaseColor"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(5, 32, 5, 10),
            };
            Grid.SetColumnSpan(border3, 1);
            Grid.SetColumn(border3, 2);

            modpack0Select.Click += mainWindow.ChangeModpack;

            modpack0Item.Children.Add(modpack0ModItemName);
            modpack0Item.Children.Add(modpack0ModItemVersion);
            modpack0Item.Children.Add(modpack0ModItemDescription);
            modpack0Item.Children.Add(modpack0ModItemModAmount);
            modpack0Item.Children.Add(border1);
            modpack0Item.Children.Add(border2);
            modpack0Item.Children.Add(border3);
            modpack0Select.Content = modpack0SelectText;
            modpack0Item.Children.Add(modpack0Select);

            return modpack0Item;
        }

        public static Grid CreateModSettingItem(string modId, string modName, string modFile, bool isOn)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return null;

            Grid modSettings0Item = new Grid
            {
                Name = modId + "Item",
                Height = 60,
                Width = double.NaN,
                Background = (Brush)mainWindow.FindResource("hoverButtonColor"),
                Margin = new Thickness(15, 5, 15, 5),
                Visibility = Visibility.Visible
            };

            modSettings0Item.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(173, GridUnitType.Star) });
            modSettings0Item.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });

            TextBlock modSettings0ModItemName = new TextBlock
            {
                Name = modId + "ItemName",
                Text = modName,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(4, 3, 3, 0),
                FontSize = 25,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                VerticalAlignment = VerticalAlignment.Top,
                Width = double.NaN,
                Height = 34
            };

            TextBlock modSettings0ModItemFile = new TextBlock
            {
                Name = modId + "ItemFile",
                Text = modFile,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(4, 37, 3, 0),
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                VerticalAlignment = VerticalAlignment.Top,
                Width = double.NaN,
                Height = 20
            };

            Button modSettings0Check = new Button
            {
                Name = modId + "Check",
                Margin = new Thickness(0, 5, 0, 5),
                Style = (Style)mainWindow.FindResource("tabButton"),
                RenderTransformOrigin = new Point(1, 0.5),
                Width = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetColumn(modSettings0Check, 1);

            Image modSettings0Checkmark = new Image
            {
                Name = modId + "Checkmark",
                Visibility = isOn ? Visibility.Visible : Visibility.Hidden,
                Source = new BitmapImage(new Uri("/img/CheckmarkDarkGray.png", UriKind.Relative)),
                Margin = new Thickness(10, 10, 10, 10),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            modSettings0Check.Content = modSettings0Checkmark;

            Border border1 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("selectedButtonColor"),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumnSpan(border1, 2);

            Border border2 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("selectedButtonColor"),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumn(border2, 2);
            Grid.SetColumnSpan(border2, 1);

            Border border3 = new Border
            {
                BorderBrush = (Brush)mainWindow.FindResource("tabBorderBaseColor"),
                Margin = new Thickness(5, 5, 5, 5),
                BorderThickness = new Thickness(1),
            };
            Grid.SetColumn(border3, 2);
            Grid.SetColumnSpan(border3, 1);

            modSettings0Check.Click += mainWindow.ToggleModSetting;

            modSettings0Item.Children.Add(modSettings0ModItemName);
            modSettings0Item.Children.Add(modSettings0ModItemFile);
            modSettings0Item.Children.Add(modSettings0Check);
            modSettings0Item.Children.Add(border1);
            modSettings0Item.Children.Add(border2);
            modSettings0Item.Children.Add(border3);

            return modSettings0Item;
        }

        public static TextBlock CreateModCategoryText(string categoryId, string modCategory)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow == null) return null;

            TextBlock modCategoryName = new TextBlock
            {
                Name = categoryId + "CategoryName",
                Text = modCategory,
                Style = (Style)mainWindow.FindResource("basicText"),
                Margin = new Thickness(4, 3, 3, 0),
                FontSize = 45,
                TextWrapping = TextWrapping.Wrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
                RenderTransformOrigin = new Point(0, 0.5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Width = double.NaN,
                Height = double.NaN
            };

            return modCategoryName;
        }
    }
}
