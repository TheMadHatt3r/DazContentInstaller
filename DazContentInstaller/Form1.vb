Imports System.IO
Imports SevenZip



Public Class Form1

    'Defined Constants
    Const INSTALLERS_PATH As String = "\installFiles"
    Const INSTALLED_PATH As String = "\installed"
    Const INSTALLED_SUCCESS_PATH As String = INSTALLED_PATH + "\success"
    Const INSTALLED_FAILED_PATH As String = INSTALLED_PATH + "\failed"
    Const TEMP_UNPACK As String = "\temp"

    'Global Objects
    Dim log As New Logging("syslog.txt")
    Dim cfg As New Config("config.txt")



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        log.info("Program Started.")
        createRequiredDirectories()
        unpackDlls()
        'Set proper SevenZip dll location
        If Environment.Is64BitOperatingSystem Then
            log.debug("System Arch: x64, Setting 7-Zip DLL = 7z64.dll")
            SevenZipBase.SetLibraryPath(Application.StartupPath + "\7z64.dll")
        Else
            log.debug("System Arch: x86, Setting 7-Zip DLL = 7z.dll")
            SevenZipBase.SetLibraryPath(Application.StartupPath + "\7z.dll")
        End If
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

    ''' <summary>
    ''' Unpacks 7-Zip DLLs. Selects proper library link based on system arch type.
    ''' </summary>
    Private Sub unpackDlls()
        Try
            File.WriteAllBytes(Application.StartupPath + "\7z.dll", My.Resources._7z)
            File.WriteAllBytes(Application.StartupPath + "\7z64.dll", My.Resources._7z64)
        Catch ex As Exception
            MsgBox("Error exctracting 7-Zip libraries." +
                   ". Am I installed or placed in a read/write folder? Try moving the exacutable and running again." +
                   " System Exception:" + ex.Message)
        End Try

    End Sub


    Private Sub btn_install_Click(sender As Object, e As EventArgs) Handles btn_install.Click
        '1) Get list of .zip/.rar files in directory:
        log.debug("Searching for installers (.zip/.rar) in:" + Application.StartupPath + INSTALLED_SUCCESS_PATH)
        Dim fileList As List(Of String) = Directory.GetFiles(Application.StartupPath + INSTALLERS_PATH).ToList
        log.debug("Files Found to Install:" + fileList.Count.ToString)

        '2) Unzip to temp dir
        For Each file As String In fileList
            log.debug(" -Extracting to temp:" + file)
            Dim uncomp As New SevenZipExtractor(file)
            uncomp.ExtractArchive(Application.StartupPath + TEMP_UNPACK)
        Next


    End Sub
End Class
