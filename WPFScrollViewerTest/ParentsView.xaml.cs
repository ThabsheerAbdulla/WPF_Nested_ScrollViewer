using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFScrollViewerTest
{
    /// <summary>
    /// Interaction logic for TokenObjectView.xaml
    /// </summary>
    public partial class ParentsView : UserControl
    {
        public ParentsView()
        {
            InitializeComponent();
            DataContext = new ParentsViewModel();
        }




        #region Mouse Scrolling


        Point initialMousePoint = new();
        double horizOffset = 1;
        bool isMouseDown = false;

        private void scrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            initialMousePoint = e.GetPosition(ParentscrollViewer);
            horizOffset = ParentscrollViewer.HorizontalOffset;
            isMouseDown = true;
            e.Handled = false;
        }
        private void scrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            e.Handled = false;
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.LeftButton == MouseButtonState.Pressed)
                ParentscrollViewer.ScrollToHorizontalOffset(horizOffset + (initialMousePoint.X - e.GetPosition(ParentscrollViewer).X));
            e.Handled = false;
        }

        #endregion



        #region Touch Scrolling

        private Point LastPoint;
        private DateTime LastPointPeriod = DateTime.Now;

        private void ParentscrollViewer_TouchMove(object sender, TouchEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer eirTokenListScroll && eirTokenListScroll.Name == "ChildscrollViewer")
                if (sender is ScrollViewer myScroller)
                {
                    if ((DateTime.Now - LastPointPeriod).TotalMilliseconds > 250)
                    {
                        horizOffset = myScroller.HorizontalOffset;
                        LastPoint = e.GetTouchPoint(this).Position;

                    }
                    var currentPoint = e.GetTouchPoint(this).Position;
                    LastPointPeriod = DateTime.Now;
                    myScroller.ScrollToHorizontalOffset(horizOffset + (LastPoint.X - currentPoint.X));
                }
            e.Handled = true;
        }

        #endregion
    }
}
