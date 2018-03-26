Public Class Splash


    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        unpackDlls()
    End Sub



    ''' <summary>
    ''' Unpacks 7-Zip DLLs. Selects proper library link based on system arch type.
    ''' </summary>
    Private Sub unpackDlls()
        Try
            IO.File.WriteAllBytes(Application.StartupPath + "\7z-x86.dll", My.Resources._7z)
            IO.File.WriteAllBytes(Application.StartupPath + "\7z-x64.dll", My.Resources._7z64)
            'IO.File.WriteAllBytes(Application.StartupPath + "\SevenZipSharp.dll", My.Resources.SevenZipSharp)
            IO.File.WriteAllBytes(Application.StartupPath + "\SevenZipExtractor.dll", My.Resources.SevenZipExtractor)
        Catch ex As Exception
            MsgBox("Error exctracting 7-Zip libraries." +
                   ". Am I installed or placed in a read/write folder? Try moving the exacutable and running again." +
                   " System Exception:" + ex.Message)
        End Try

    End Sub


End Class