using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFScrollViewerTest
{
    /// <summary>
    /// Interaction logic for TokensView.xaml
    /// </summary>
    public partial class ChildrenView : UserControl
    {
        public ChildrenView()
        {
            InitializeComponent();
        }




        #region Mouse Scrolling 

        Point initialMousePoint = new();
        double vertOffset = 1;
        bool isMouseDown = false;

        private void scrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            initialMousePoint = e.GetPosition(ChildscrollViewer);
            vertOffset = ChildscrollViewer.VerticalOffset;
            isMouseDown = true;
            e.Handled = true;
        }
        private void scrollViewer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            e.Handled = true;
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && e.LeftButton == MouseButtonState.Pressed)
                ChildscrollViewer.ScrollToVerticalOffset(vertOffset + (initialMousePoint.Y - e.GetPosition(ChildscrollViewer).Y));
            e.Handled = true;
        }

        #endregion








        #region Touch Scrolling

        private void ChildscrollViewer_TouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = false;
        }

        #endregion


    }
}
