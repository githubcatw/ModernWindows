using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ModernWindows.Notepad {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private async void CommandBarButton(object sender, RoutedEventArgs e) {
            var button = sender as AppBarButton;
            if (button.Name == "NewFile") {
                
            } else if (button.Name == "OpenFile") {
                // Open a text file.
                Windows.Storage.Pickers.FileOpenPicker open =
                    new Windows.Storage.Pickers.FileOpenPicker();
                open.SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                open.FileTypeFilter.Add(".rtf");
                open.FileTypeFilter.Add(".txt");

                Windows.Storage.StorageFile file = await open.PickSingleFileAsync();

                if (file != null) {
                    using (Windows.Storage.Streams.IRandomAccessStream randAccStream =
                        await file.OpenAsync(Windows.Storage.FileAccessMode.Read)) {
                        // Load the file into the Document property of the RichEditBox.
                        var format = Windows.UI.Text.TextSetOptions.FormatRtf;
                        if (file.Name.EndsWith(".txt"))
                            format = Windows.UI.Text.TextSetOptions.None;
                        EditPane.Document.LoadFromStream(format, randAccStream);
                    }
                }

            }
        }
    }
}
