Public Class Logging

    Private filename As String

    ''' <summary>
    ''' Constructor for logging class. Creates log local to .exe.
    ''' </summary>
    ''' <param name="filename">log filename.</param>
    Public Sub New(ByVal filename As String)
        Me.filename = filename
    End Sub

    ''' <summary>
    ''' Log error and exception.
    ''' </summary>
    ''' <param name="msg">Message to Log</param>
    ''' <param name="ex">Exception Object</param>
    Public Sub err(ByVal msg As String, ByVal ex As Exception)
        msg = "[ERROR] | " + msg + " System Exception:" + ex.Message
        writeToLog(msg)
    End Sub

    ''' <summary>
    ''' Log error.
    ''' </summary>
    ''' <param name="msg">Message to Log</param>
    Public Sub err(ByVal msg As String)
        msg = "[ERROR] | " + msg
        writeToLog(msg)
    End Sub

    ''' <summary>
    ''' Log info.
    ''' </summary>
    ''' <param name="msg">Message to Log</param>
    Public Sub info(ByVal msg As String)
        msg = "[INFO ] | " + msg
        writeToLog(msg)
    End Sub

    ''' <summary>
    ''' Log debug.
    ''' </summary>
    ''' <param name="msg">Message to Log</param>
    Public Sub debug(ByVal msg As String)
        msg = "[DEBUG] | " + msg
        writeToLog(msg)
    End Sub

    ''' <summary>
    ''' Low level funtion to write to file.
    ''' </summary>
    ''' <param name="msg"></param>
    Private Sub writeToLog(ByVal msg As String)
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        msg = timestamp + " | " + msg
        Dim sw As New System.IO.StreamWriter(Application.StartupPath + "\" + filename)
        sw.WriteLine(msg)
        sw.Close()
    End Sub



End Class
