Public Class Form1

    'Defined Constants
    Const INSTALLERS_PATH As String = "\insallFiles"
    Const INSTALLED_PATH As String = "\installed"
    Const INSTALLED_SUCCESS_PATH As String = INSTALLED_PATH + "\success"
    Const INSTALLED_FAILED_PATH As String = INSTALLED_PATH + "\failed"

    'Global Objects
    Dim log As New Logging("syslog.txt")



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log.info("Program Started.")
    End Sub

    Private Sub createRequiredDirectories()

    End Sub

End Class
