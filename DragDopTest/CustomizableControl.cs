using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DragDopTest
{
    [TemplatePart(Name = "PART_HeaderContentPresenter", Type = typeof(ContentPresenter))]
    [TemplatePart(Name = "PART_MainContentPresenter", Type = typeof(ContentPresenter))]
    public class CustomizableControl : Control 
    {       

        #region Dependency Properties
        public object HeaderContent
        {
            get
            {
                return (object)GetValue(HeaderContentProperty);
            }
            set
            {
                SetValue(HeaderContentProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for HeaderContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderContentProperty =
            DependencyProperty.Register("HeaderContent", typeof(object), typeof(CustomizableControl), new PropertyMetadata(null));
        public object MainContent
        {
            get
            {
                return (object)GetValue(MainContentProperty);
            }
            set
            {
                SetValue(MainContentProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for MainContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainContentProperty =
            DependencyProperty.Register("MainContent", typeof(object), typeof(CustomizableControl), new PropertyMetadata(null));



        #endregion Dependency Properties

        static CustomizableControl ()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(CustomizableControl),
                new FrameworkPropertyMetadata(typeof(CustomizableControl)));
        }

        public override void OnApplyTemplate ()
        {
            base.OnApplyTemplate();
        }
    }
}
