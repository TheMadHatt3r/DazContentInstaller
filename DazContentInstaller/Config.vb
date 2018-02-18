Public Class Config

    'Public Configs
    Public runtimeList As List(Of String)   'List of runtime install locations.
    Public installLocation As String = Application.StartupPath + "\installedRuntime" 'For TESTING
    Public installMoveSucErr As Boolean = True


    Public Sub New(ByVal cfgfile As String)

        runtimeList = New List(Of String)
    End Sub



End Class
