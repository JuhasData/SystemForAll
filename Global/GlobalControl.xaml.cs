using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemForAll.Entity;
using SystemForAll.Point;

namespace SystemForAll.Global
{
    /// <summary>
    /// Interaction logic for GlobalControl.xaml
    /// </summary>
    public partial class GlobalControl : UserControl
    {
        public GlobalControl nextGlobal;
        public Entity entity;

        public GlobalControl()
        {
            InitializeComponent();
        }

    }
}