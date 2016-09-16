using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infragistics.DragDrop;

namespace DragDopTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ValueItemView startView = null;
        ContentControl leftContainer = null;
        public MainWindow ()
        {
            InitializeComponent();
        }
        private void DragSource_Drop (object sender, Infragistics.DragDrop.DropEventArgs e)
        {
            //if(e.DragSource == e.DropTarget)
            //  return;
            // Restart Opacities
            //ContentControl sourceView = e.DragSource as ContentControl;
            //ContentControl targetView = e.DropTarget as ContentControl;
            //this.SwitchContainers(sourceView, targetView);
        }
        private void DragSource_DragStart (object sender, Infragistics.DragDrop.DragDropStartEventArgs e)
        {
            ContentControl sourceView = e.DragSource as ContentControl;
            e.Data = sourceView.Content;            
            e.DragTemplate = this.Resources["DragTemplate"] as DataTemplate;
            e.DragSource.Opacity = 0;

            // Remember item that is being dragged.            
            startView = sourceView.Content as ValueItemView;
            
        }
        private void DragSource_DragEnd (object sender, Infragistics.DragDrop.DragDropEventArgs e)
        {
            if(e.DropTarget != null)
            {
                e.DropTarget.Opacity = 1;
            }
            //if(e.DragSource != null)
            //{
            //    e.DragSource.Opacity = 1;
            //}
            if(leftContainer != null)
            {
                leftContainer.Opacity = 1;
            }
        }        
        private void DragSource_DragEnter (object sender, Infragistics.DragDrop.DragDropCancelEventArgs e)
        {            
            ContentControl targetContainer = e.DropTarget as ContentControl;         
            string targetId = (targetContainer.Content as ValueItemView).ElementName;        
            if(startView.ElementName != targetId)
            {
                var tempContent = targetContainer.Content;

                ValueItemView copyItem = new ValueItemView();
                ValueItemView originalItem = tempContent as ValueItemView;
                copyItem.ElementName = originalItem.ElementName;
                copyItem.ElementBackground = originalItem.ElementBackground;
                copyItem.Height = originalItem.ActualHeight;
                copyItem.Width = originalItem.ActualWidth;                

                // Animate a popUp before replacing the content.
                Popup animatedPopup = new Popup();                
                animatedPopup.Child = copyItem;
                animatedPopup.PlacementTarget = leftContainer;
                animatedPopup.Placement = PlacementMode.Center;                                                                   
                animatedPopup.IsOpen = true;                

                var point = targetContainer.TransformToVisual(leftContainer).Transform(new Point(0,0));
                animatedPopup.HorizontalOffset = point.X;
                animatedPopup.VerticalOffset = point.Y;
                Console.WriteLine("");

                Duration duration = new Duration(TimeSpan.FromSeconds(0.2));
                DoubleAnimation animateX = new DoubleAnimation();
                DoubleAnimation animateY = new DoubleAnimation();
                DoubleAnimation animateO = new DoubleAnimation();
                animateX.Duration = duration;
                animateX.EasingFunction = new ExponentialEase() { Exponent = 2 };
                animateY.Duration = duration;
                animateY.EasingFunction = new ExponentialEase() { Exponent = 2 };
                animateO.Duration = duration;
                animateO.EasingFunction = new ExponentialEase() { Exponent = 2 };

                // Story board for popup movement
                Storyboard sb = new Storyboard();
                sb.Duration = duration;
                sb.Children.Add(animateX);
                sb.Children.Add(animateY);

                Storyboard.SetTarget(animateX, animatedPopup);
                Storyboard.SetTarget(animateY, animatedPopup);
                Storyboard.SetTargetProperty(animateX, new PropertyPath("(HorizontalOffset)"));
                Storyboard.SetTargetProperty(animateY, new PropertyPath("(VerticalOffset)"));

                // Story board for popup opacity
                Storyboard sop = new Storyboard();
                sop.Duration = new Duration(TimeSpan.FromSeconds(0.2));
                sop.Children.Add(animateO);

                Storyboard.SetTarget(animateO, animatedPopup);
                Storyboard.SetTargetProperty(animateO, new PropertyPath("(Opacity)"));

                animateO.From = 1;
                animateO.To = 0;

                animateX.From = animatedPopup.HorizontalOffset;
                animateX.To = 0;
                animateY.From = animatedPopup.VerticalOffset;
                animateY.To = 0;

                targetContainer.Content = startView;
                targetContainer.Opacity = 0;
                //leftContainer.Content = tempContent;
                leftContainer.Opacity = 0;
                ContentControl templeft = leftContainer;                

                sb.Completed += (object sender2, EventArgs e2) =>
                {                   
                    templeft.Content = tempContent;                  
                    templeft.Opacity = 1;
                    sop.Begin();                    
                };

                sop.Completed += (object sender3, EventArgs e3) =>
                {
                    animatedPopup.IsOpen = false;   
                };

                sb.Begin();                                
            }
        }                
        private void DragSource_DragLeave (object sender, Infragistics.DragDrop.DragDropEventArgs e)
        {
            // Save reference to the container that was left so that when entering 
            // a new container this one can be replaced with the new content.
            leftContainer = e.DropTarget as ContentControl;            
        }
        private void DragSource_DragOver (object sender, Infragistics.DragDrop.DragDropMoveEventArgs e)
        {           
            //ContentControl sourceView = e.DragSource as ContentControl;
            //ContentControl targetView = e.DropTarget as ContentControl;
            //string sourceId = (sourceView.Content as ValueItemView).ElementName;
            //string targetId = (targetView.Content as ValueItemView).ElementName;
            ////Console.WriteLine(" drag over event: source " + sourceId + " target " + targetId);

            //if(sourceId != targetId)
            //    SwitchContainers(sourceView, targetView);
        }
    }
}
