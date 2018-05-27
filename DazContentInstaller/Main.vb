Imports System.IO



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
    Dim daz As New DazUnpack()



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log.info("Program Started.")
        createRequiredDirectories()

        'Set Version
        Me.Text = "Daz Archive Installer | Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString

        'Unpack 7zip DLLs
        unpackDlls()

        'Set proper SevenZip dll location
        If Environment.Is64BitOperatingSystem Then
            log.debug("System Arch: x64, Setting 7-Zip DLL = 7z-x64.dll")
            daz.sevenZipDllPath = Application.StartupPath + "\7z-x64.dll"
        Else
            log.debug("System Arch: x86, Setting 7-Zip DLL = 7z-x86.dll")
            daz.sevenZipDllPath = Application.StartupPath + "\7z-x86.dll"
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




    Private Async Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click

        If Me.runtimes_txt.SelectedIndex = -1 Then
            MsgBox("Please select a runtime and try again.")
            Exit Sub
        End If

        btn_install.Text = "Running..."

        daz.moveArchiveOnComplete = Me.cb_moveOnInstall.Checked
        daz.processedPath = Application.StartupPath + INSTALLED_PATH
        daz.archiveFilesPath = Application.StartupPath + INSTALLERS_PATH
        daz.tempUnpackPath = Application.StartupPath + TEMP_UNPACK
        daz.targetRuntime = Me.runtimes_txt.SelectedItem
        log.debug("Path for finished files:" + Application.StartupPath + INSTALLED_PATH)
        log.debug("Path for install files to process:" + Application.StartupPath + INSTALLERS_PATH)
        log.debug("Target Runtime:" + Me.runtimes_txt.SelectedItem)

        'Get list of archives to install
        Dim fileList As List(Of String) = getListOfArchives(daz.archiveFilesPath)
        For Each file As String In fileList
            Await Task.Run(Function() daz.installArchiveFileAsync(file))
            Me.pb_install.Value = (daz.installSuccessCount + daz.installFailCount) / fileList.Count * 100
            Me.lbl_success.Text = "Success:" + daz.installSuccessCount.ToString
        Next




        Me.lbl_fail.Text = "Failures:" + daz.installFailCount.ToString
        Me.lbl_success.Text = "Success:" + daz.installSuccessCount.ToString

        btn_install.Text = "Run Installer"


    End Sub

    Private Function getListOfArchives(ByVal dir As String) As List(Of String)
        '1) Get list of .zip/.rar files in directory:
        Me.log.info("Searching for installers (.zip/.rar) in:" + dir)
        Dim fileList As List(Of String) = Directory.GetFiles(dir).ToList
        Me.log.info("Files Found to Install:" + fileList.Count.ToString)
        Return fileList
    End Function



    ''' <summary>
    ''' Unpacks 7-Zip DLLs. Selects proper library link based on system arch type.
    ''' </summary>
    Private Sub unpackDlls()
        Try
            IO.File.WriteAllBytes(Application.StartupPath + "\7z-x86.dll", My.Resources._7z)
            IO.File.WriteAllBytes(Application.StartupPath + "\7z-x64.dll", My.Resources._7z64)
            'IO.File.WriteAllBytes(Application.StartupPath + "\SevenZipExtractor.dll", My.Resources.SevenZipExtractor)
        Catch ex As Exception
            MsgBox("Error exctracting 7-Zip libraries." +
                   ". Am I installed or placed in a read/write folder? Try moving the exacutable and running again." +
                   " System Exception:" + ex.Message)
        End Try
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
