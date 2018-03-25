Public Class Config

    'Public Configs
    Public runtimeList As New List(Of String)   'List of runtime install locations.
    Public installLocation As String = Application.StartupPath + "\installedRuntime" 'For TESTING
    Public installMoveSucErr As Boolean = True


    Public Sub New(ByVal cfgfile As String)
        readRuntimeList(Application.StartupPath + "\" + "runtimeList.txt")
    End Sub


    Private Sub readRuntimeList(ByVal runtimefile As String)
        Dim line As String
        runtimeList.Clear()
        Dim reader As IO.StreamReader

        'Create Default
        If Not System.IO.File.Exists(runtimefile) Then
            IO.File.AppendAllText(runtimefile, "# List Runtime Dirs Here Line By Line. Note '#' Makes this line a comment.")
        End If

        'Read in File
        Try
            reader = My.Computer.FileSystem.OpenTextFileReader(runtimefile)
            line = reader.ReadLine
            Do Until line Is Nothing
                'Not Comment
                If Not line.StartsWith("#") Then
                    runtimeList.Add(line)
                End If
                line = reader.ReadLine
            Loop
        Catch ex As Exception
            MsgBox("Error reading in runtime file (" + runtimefile + "). System Exception:" + ex.Message)
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try

    End Sub



End Class
