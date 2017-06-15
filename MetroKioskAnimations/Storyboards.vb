Imports System.Windows.Media.Animation

Public Class Storyboards
    Inherits Control

    Shared Sub New()
        'This OverrideMetadata call tells the system that this element wants to provide a style that is different than its base class.
        'This style is defined in Themes\Generic.xaml
        DefaultStyleKeyProperty.OverrideMetadata(GetType(Storyboards), New FrameworkPropertyMetadata(GetType(Storyboards)))
    End Sub

    ' Here is where the main storyboards start................


    'Welcome screensaver to storage storyboard
    Public ScreenSaveStory As New Storyboard
    Public Sub SetupStories()
        ScreenSaveStory.
    End Sub

End Class
