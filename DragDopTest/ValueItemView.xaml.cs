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

namespace DragDopTest
{
    /// <summary>
    /// Interaction logic for ValueItemView.xaml
    /// </summary>
    public partial class ValueItemView : UserControl
    {
        public string ElementName
        {
            get
            {
                return (string)GetValue(ElementNameProperty);
            }
            set
            {
                SetValue(ElementNameProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ElementName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementNameProperty =
            DependencyProperty.Register("ElementName", typeof(string), typeof(ValueItemView), new PropertyMetadata(null));

        public string ElementBackground
        {
            get
            {
                return (string)GetValue(ElementBackgroundProperty);
            }
            set
            {
                SetValue(ElementBackgroundProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ElementBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElementBackgroundProperty =
            DependencyProperty.Register("ElementBackground", typeof(string), typeof(ValueItemView), new PropertyMetadata(null));

        public ValueItemView ()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
