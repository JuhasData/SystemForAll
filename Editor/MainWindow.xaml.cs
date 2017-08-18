using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml;
using SystemForAll.Global;

namespace SystemForAll.Editor
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        private string _dataToShow = string.Empty;
        private Control _ctrlToExamine = null;

        public MainWindow()
        {
            InitializeComponent();
            // Be in Ink mode by default.
            PopulateDocument();
            EnableAnnotations();

            SetBindings();
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
            this.MouseDown += MyVisualHost_MouseDown;

            // Fill the list box with all the Button
            // styles.
            lstStyles.Items.Add("GrowingButtonStyle");
            lstStyles.Items.Add("TiltButton");
            lstStyles.Items.Add("BigGreenButton");
            lstStyles.Items.Add("BasicControlStyle");

        // Rig up some Click handlers for the save/load of the flow doc.
        btnSaveDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open(
                  "documentData.xaml", FileMode.Create))
                {
                    XamlWriter.Save(this.myDocumentReader.Document, fStream);
                }
            };

            btnLoadDoc.Click += (o, s) =>
            {
                using (FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
                {
                    try
                    {
                        FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
                        this.myDocumentReader.Document = doc;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Error Loading Doc!"); }
                }
            };
        }

        void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Figure out where the user clicked.
            Point pt = e.GetPosition((UIElement)sender);
            // Call helper function via delegate to see if we clicked on a visual.
            VisualTreeHelper.HitTest(this, null,
            new HitTestResultCallback(myCallback), new PointHitTestParameters(pt));
        }

        public HitTestResultBehavior myCallback(HitTestResult result)
        {
            // Toggle between a skewed rendering and normal rendering,
            // if a visual was clicked.
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Transform == null)
                {
                    ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(7, 7);
                }
                else
                {
                    ((DrawingVisual)result.VisualHit).Transform = null;
                }
            }
            // Tell HitTest() to stop drilling into the visual tree.
            return HitTestResultBehavior.Stop;
        }


        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            // Based on which button sent the event, place the InkCanvas in a unique
            // mode of operation.
            switch ((sender as RadioButton)?.Content.ToString())
            {
                // These strings must be the same as the Content values for each
                // RadioButton.
                case "Ink Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case "Erase Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;
                case "Select Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
            }
        }

        //ColorChange ink
        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected value in the combo box.
            string colorToUse =
            (this.comboColors.SelectedItem as StackPanel).Tag.ToString();
            // Change the color used to render the strokes.
            this.myInkCanvas.DefaultDrawingAttributes.Color =
            (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        //SavveData ink
        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Save all data on the InkCanvas to a local file.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.myInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        //LoadData ink
        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Fill StrokeCollection from file.
            using (FileStream fs = new FileStream("StrokeData.bin",
            FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.myInkCanvas.Strokes = strokes;
            }
        }

        //Clear ink
        private void Clear(object sender, RoutedEventArgs e)
        {
            // Clear all strokes.
            this.myInkCanvas.Strokes.Clear();
        }


        //DocumentTab Loaded
        private void EnableAnnotations()
        {
            // Create the AnnotationService object that works
            // with our FlowDocumentReader.
            AnnotationService anoService = new AnnotationService(myDocumentReader);
            // Create a MemoryStream that will hold the annotations.
            MemoryStream anoStream = new MemoryStream();
            // Now, create an XML-based store based on the MemoryStream.
            // You could use this object to programmatically add, delete,
            // or find annotations.
            AnnotationStore store = new XmlStreamStore(anoStream);
            // Enable the annotation services.
            anoService.Enable(store);
        }


        private void PopulateDocument()
        {
            // Add some data to the List item.
            this.listOfFunFacts.FontSize = 14;
            this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.listOfFunFacts.ListItems.Add(new ListItem(new
            Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
            new Paragraph(new Run("The API supports tables and embedded figures!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
            new Paragraph(new Run("Flow documents are read only!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run
            ("BlockUIContainer allows you to embed WPF controls in the document!")
            )));
            // Now add some data to the Paragraph.
            // First part of sentence.
            Run prefix = new Run("This paragraph was generated ");

            // Middle of paragraph.
            Bold b = new Bold();
            Run infix = new Run("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);
            // Last part of paragraph.
            Run suffix = new Run(" at runtime!");
            // Now add each piece to the collection of inline elements
            // of the Paragraph.
            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }

        private void EnableAnnotations(object sender, RoutedEventArgs e)
        {
            // Create the AnnotationService object that works
            // with our FlowDocumentReader.
            AnnotationService anoService = new AnnotationService(myDocumentReader);
            // Create a MemoryStream that will hold the annotations.
            MemoryStream anoStream = new MemoryStream();
            // Now, create an XML-based store based on the MemoryStream.
            // You could use this object to programmatically add, delete,
            // or find annotations.
            AnnotationStore store = new XmlStreamStore(anoStream);
            // Enable the annotation services.
            anoService.Enable(store);
        }

        private void SetBindings()
        {
            // Create a Binding object.
            Binding b = new Binding();
            // Register the converter, source, and path.
            b.Converter = new MyDoubleConverter();
            b.Source = this.mySB;
            b.Path = new PropertyPath("Value");
            // Call the SetBinding method on the Label.
            this.labelSBThumb.SetBinding(Label.ContentProperty, b);
        }

        private void SkewButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.LayoutTransform = new SkewTransform(0, -20);
        }

        private void RotateButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.LayoutTransform = new RotateTransform(180);
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.LayoutTransform = new ScaleTransform(-1, 1);
        }

        private void myTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            const int TextFontSize = 15;
            // Make a System.Windows.Media.FormattedText object.
            FormattedText text = new FormattedText("Hello Visual Layer!",
                                 new System.Globalization.CultureInfo("en-us"),
                                 FlowDirection.LeftToRight,
                                 new Typeface(this.FontFamily,
                                 FontStyles.Italic,
                                 FontWeights.DemiBold,
                                 FontStretches.UltraExpanded),
                                 TextFontSize,
                                 Brushes.Green);

            // Create a DrawingVisual, and obtain the DrawingContext.
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Now, call any of the methods of DrawingContext to render data.
                drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5),
                new Rect(5, 5, 450, 100), 20, 20);
                drawingContext.DrawText(text, new Point(20, 20));
            }
            // Dynamically make a bitmap, using the data in the DrawingVisual.
            RenderTargetBitmap bmp = new RenderTargetBitmap(500, 100, 100, 90,
            PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);
            // Set the source of the Image control!
            myImage.Source = bmp;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            // Put a totally new brush into the myBrush slot.
            myGrid.Resources["myBrush"] = new SolidColorBrush(Colors.Green);
            btnOK.Content = "OK";
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            myGrid.Resources["myBrush"] = new SolidColorBrush(Colors.DarkRed);
            btnOK.Content = "Cancelled";
        }

        private bool _isSpinning = false;
        private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_isSpinning)
            {
                _isSpinning = true;
                // Make a double animation object, and register
                // with the Completed event.
                var dblAnim = new DoubleAnimation()
                {
                    From = 1.0,
                    To = 0.5
                };
                dblAnim.Completed += (o, s) => { _isSpinning = false; };
                // Set the start value and end value.
                dblAnim.From = 0;
                dblAnim.To = 360;
                // Now, create a RotateTransform object, and set
                // it to the RenderTransform property of our
                // button.
                var rt = new RotateTransform();
                btnOK.RenderTransform = rt;
                // Reverse when done.
                dblAnim.AutoReverse = true;
                // Now, animation the RotateTransform object.
                rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
                rt.BeginAnimation(Button.OpacityProperty, dblAnim);

            }
            else
            {
                _isSpinning = false;
            }
        }
        private void comboStyles_Changed(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected style name from the list box.
            var currStyle = (Style)TryFindResource(lstStyles.SelectedValue);
            if (currStyle == null) return;
            // Set the style of the button type.
            btnOK.Style = currStyle;
        }

        private void btnShowLogicalTree_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            BuildLogicalTree(0, this);
            txtDisplayArea.Text = _dataToShow;
        }
        void BuildLogicalTree(int depth, object obj)
        {
            // Add the type name to the dataToShow member variable.
            _dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // If an item is not a DependencyObject, skip it.
            if (!(obj is DependencyObject))
                return;
            // Make a recursive call for each logical child.
            foreach (var child in LogicalTreeHelper.GetChildren(
            (DependencyObject)obj))
            {
                BuildLogicalTree(depth + 5, child);
            }
        }

        private void btnShowVisualTree_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            BuildVisualTree(0, this);
            txtDisplayArea.Text = _dataToShow;
        }
        void BuildVisualTree(int depth, DependencyObject obj)
        {
            // Add the type name to the dataToShow member variable.
            _dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
            // Make a recursive call for each visual child.
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
            }
        }


        // Plug in a new template for the button to use.
        Button myBtn = new Button();
        ControlTemplate customTemplate = new ControlTemplate();

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            _dataToShow = "";
            ShowTemplate();
            txtDisplayArea.Text = _dataToShow;
        }

        private void ShowTemplate()
        {
            // Remove the control that is currently in the preview area.
            if (_ctrlToExamine != null)
                stackTemplatePanel.Children.Remove(_ctrlToExamine);
            try
            {
                // Load PresentationFramework, and create an instance of the
                // specified control. Give it a size for display purposes, then add to the
                // empty StackPanel.
                Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0," +
                "Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                _ctrlToExamine = (Control)asm.CreateInstance(txtFullName.Text);
                _ctrlToExamine.Height = 200;
                _ctrlToExamine.Width = 200;
                _ctrlToExamine.Margin = new Thickness(5);
                stackTemplatePanel.Children.Add(_ctrlToExamine);

                // Define some XML settings to preserve indentation.
                var xmlSettings = new XmlWriterSettings { Indent = true };
                // Create a StringBuilder to hold the XAML.
                var strBuilder = new StringBuilder();
                // Create an XmlWriter based on our settings.
                var xWriter = XmlWriter.Create(strBuilder, xmlSettings);
                // Now save the XAML into the XmlWriter object based on the ControlTemplate.
                XamlWriter.Save(_ctrlToExamine.Template, xWriter);
                // Display XAML in the text box.
                _dataToShow = strBuilder.ToString();
            }
            catch (Exception ex)
            {
                _dataToShow = ex.Message;
            }
        }

        //// Assume this method adds all the code for a star template.
        //MakeStarTemplate(customTemplate);
        //myBtn.Template = customTemplate;

        //private void ConfigureGrid()
        //{
        //    using (var repo = new SystemForAll())
        //    {
        //        // Build a LINQ query that gets back some data from the Inventory table.
        //        gridInventory.ItemsSource =
        //        repo.WorldSystems.FindAsync().Status.Select(x => new { x.CarId, x.Make, x.Color, x.PetName });
        //    }
        //}
    }
}
