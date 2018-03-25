Imports System.IO
Imports SevenZipExtractor



Public Class Main

    'Defined Constants
    Const INSTALLERS_PATH As String = "\installFiles"
    Const INSTALLED_PATH As String = "\processed"
    Const INSTALLED_SUCCESS_PATH As String = INSTALLED_PATH + "\success"
    Const INSTALLED_FAILED_PATH As String = INSTALLED_PATH + "\failed"
    Const TEMP_UNPACK As String = "\temp"

    'Global Objects
    Public log As New Logging("syslog.txt")
    Public cfg As New Config("config.txt")



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log.info("Program Started.")
        createRequiredDirectories()
        'unpackDlls()
        'Set proper SevenZip dll location
        If Environment.Is64BitOperatingSystem Then
            log.debug("System Arch: x64, Setting 7-Zip DLL = 7z64.dll")
            'SevenZipBase.SetLibraryPath(Application.StartupPath + "\7z64.dll")
        Else
            log.debug("System Arch: x86, Setting 7-Zip DLL = 7z.dll")
            'SevenZipBase.SetLibraryPath(Application.StartupPath + "\7z.dll")
        End If
        'Once config Obj is created, It reads in runtimes. So populate UI
        Me.runtimes_txt.Items.Clear()
        For Each line As String In cfg.runtimeList
            Me.runtimes_txt.Items.Add(line)
        Next

    End Sub




    ''' <summary>
    ''' Creates default directories at startup.
    ''' </summary>
    Private Sub createRequiredDirectories()
        Try
            'Create directory for user to put .zips in to install
            Directory.CreateDirectory(Application.StartupPath + INSTALLERS_PATH)
            'Create directory to unzip temporary
            Directory.CreateDirectory(Application.StartupPath + TEMP_UNPACK)
            'Create directory to move installed .zips to
            Directory.CreateDirectory(Application.StartupPath + INSTALLED_PATH)
            'Create Success and Fail directorys for install .zips
            If (cfg.installMoveSucErr) Then
                Directory.CreateDirectory(Application.StartupPath + INSTALLED_SUCCESS_PATH)
                Directory.CreateDirectory(Application.StartupPath + INSTALLED_FAILED_PATH)
            End If
        Catch ex As Exception
            MsgBox("Error creating one or more default directories at startup. " +
                   ". Am I installed or placed in a read/write folder? Try moving the exacutable and running again." +
                   " System Exception:" + ex.Message)
        End Try

    End Sub




    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        Dim daz As New DazUnpack()
        daz.moveArchiveOnComplete = Me.cb_moveOnInstall.Checked
        daz.processedPath = Application.StartupPath + INSTALLED_PATH
        daz.archiveFilesPath = Application.StartupPath + INSTALLERS_PATH
        daz.tempUnpackPath = Application.StartupPath + TEMP_UNPACK
        daz.targetRuntime = Application.StartupPath + "\runtime"        '''DEBUG
        daz.processFiles()

        Me.lbl_fail.Text = "Failures:" + daz.installFailCount.ToString
        Me.lbl_success.Text = "Success:" + daz.installSuccessCount.ToString


    End Sub

    ' TOOL STRIP ACTIONS
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about = New AboutHelp()
        about.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
