# WPF Nested ScrollViewerTest
Testing the ScrollViewer for mouseclick scrolling and touch scrolling


Project Demonstrating Nested ScrollViewer and Scrolling via Mouse click and Touch

Project is Kept simple.

Mainly 2 views are added ParentView and ChildView..

Both Views have a Scroll viewer and Child's scrollviewer is nested insided ParentView.

THe parent Views scroll viewer is filled with List of Integer List. and the inner list is bound to the scroll viewer of childView.

Parent Scroll viewer is enabled with horizontalscrolling and child scroll viewer with vertical scrolling

MouseScrolling:
	It is implemented with Tunneling Routed events.
	PreviewMouseDown,PreviewMouseUp and PreviewMouseMove
	PreviewMouseUp and PreviewMouseDown will enable a flag IsMouseDown and based on the flag, 
	PreviewMouseMove will trigger scrolling  in horizontal axis for parentscrollviewer and in vertical axis for childscrollviewer.

TouchScrolling:
	panning mode is enabled vertical child scrollviewer and horizontal for parent scrollviewer.
	if we try to touch scroll the parent scroll viewer by touching the overlapped child scrollviewer area , 
	only child scrollviewer will be scrolled.
	Here we use Bubble routed event From child scrollviewer to parent scroll viewer and 
	if this routed event event comes from the child scrollviewer, we will trigger the scrolling of the parent scrollviewer.



