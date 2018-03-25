Imports System.IO
Imports SevenZip

Public Class DazUnpack

    Private processedArchivesPath As String = Nothing
    Private installFilesPath As String = Nothing
    Private tempArchiveUnpackPath As String = Nothing
    Private runtimePath As String = Nothing


    Public Sub New()

    End Sub

    ''' <summary>
    ''' Required: Set path for where .zip/.rar files are moved to after processing
    ''' </summary>
    ''' <returns></returns>
    Public Property processedPath
        Set(value)
            processedArchivesPath = value
        End Set
        Get
            Return processedArchivesPath
        End Get
    End Property

    ''' <summary>
    ''' Required: Set path for .zip/.rar files to process
    ''' </summary>
    ''' <returns></returns>
    Public Property archiveFilesPath
        Set(value)
            installFilesPath = value
        End Set
        Get
            Return installFilesPath
        End Get
    End Property

    ''' <summary>
    ''' Required: Set path for .zip/.rar temporary unpack
    ''' </summary>
    ''' <returns></returns>
    Public Property tempUnpackPath
        Set(value)
            tempArchiveUnpackPath = value
        End Set
        Get
            Return tempArchiveUnpackPath
        End Get
    End Property

    ''' <summary>
    ''' Required: Set path for target runtime
    ''' </summary>
    ''' <returns></returns>
    Public Property targetRuntime
        Set(value)
            runtimePath = value
        End Set
        Get
            Return runtimePath
        End Get
    End Property






    Public Function processFiles()
        '1) Get list of .zip/.rar files in directory:
        Dim fileList As List(Of String) = getListOfArchives(installFilesPath)
        For Each file As String In fileList
            '2) Unzip to temp dir
            unzipToTemp(file)

            '3) Search dir for one of valid types (Runtime, data etc.)
            Dim fs As New FinderStruc
            Dim res As String = searchTempForInstallPoint(tempArchiveUnpackPath, fs)
            Main.log.debug(" -Type of runtime found:" + fs.type)

            '4) Copy files from fs.location point to runtime folder of same type.
            Main.log.debug(" -Copy " + fs.location + " To " + runtimePath + "\" + fs.type)
            CopyDirectory(fs.location, runtimePath + "\" + fs.type)


            '5) Copy files/folders at same level as fs.location (minus runtime) to same level in master runtime.
            '   This could ignore some folders if you are >2 levels deep... But slim chance those matter.



            '5) Cleanup \temp
            Main.log.debug(" -Clearing \temp")
            cleanDirectory(tempArchiveUnpackPath)

            '6) Move or Del .zip/.rar
            moveToFinishedLocation(file, processedArchivesPath)

        Next
    End Function





    ''' <summary>
    ''' No recursive function to copy directories in .NET?
    ''' So this will copy a directory and all contents to another.
    ''' </summary>
    ''' <param name="sourcePath"></param>
    ''' <param name="destinationPath"></param>
    Private Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
            System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub


    Private Class FinderStruc
        Public found As Boolean
        Public location As String
        Public type As String
        Sub New()
            found = False
            location = ""
            type = ""
        End Sub
    End Class

    Private Function searchTempForInstallPoint(ByVal searchDir As String, ByRef fs As FinderStruc) As String
        Dim dirList As List(Of String) = Directory.GetDirectories(searchDir).ToList
        'If list is empty, and no exit. Then error since no match to expected file structure.
        If dirList.Count = 0 Then
            Return "NO_STRUC_FOUND"
        Else
            'Else loop through this level looking for match
            For Each tmp In dirList
                Dim d As String = tmp.Split("\")(tmp.Split("\").GetUpperBound(0))
                'DO ALL MATCHING HERE
                If d = "data" Or d = "Runtime" Then
                    fs.found = True
                    fs.location = tmp
                    fs.type = d
                    Return "FOUND"
                End If
            Next
            'If not found at this level, then move to next level...
            For Each tmp In dirList
                Dim res As String = searchTempForInstallPoint(tmp, fs)
                If res = "FOUND" Then
                    Return res
                End If
            Next
            'Finally if no matching structure is ever found...
            Return "NO_STRUC_FOUND"
        End If
    End Function


    Private Function getListOfArchives(ByVal dir As String) As List(Of String)
        '1) Get list of .zip/.rar files in directory:
        Main.log.info("Searching for installers (.zip/.rar) in:" + dir)
        Dim fileList As List(Of String) = Directory.GetFiles(dir).ToList
        Main.log.info("Files Found to Install:" + fileList.Count.ToString)
        Return fileList
    End Function


    Private Sub unzipToTemp(ByVal file As String)
        '2) Unzip to temp dir
        Main.log.info(" -Extracting to temp:" + file)
        Dim uncomp As New SevenZipExtractor(file)
        uncomp.ExtractArchive(tempArchiveUnpackPath)
    End Sub


    Private Sub cleanDirectory(ByVal dir As String)
        For Each item In Directory.GetFiles(dir).ToList
            Try
                IO.File.Delete(item)
            Catch ex As Exception
                Main.log.err(" -Error cleaning \temp", ex)
            End Try
        Next
        For Each item In Directory.GetDirectories(dir).ToList
            Try
                IO.Directory.Delete(item, True)
            Catch ex As Exception
                Main.log.err(" -Error cleaning \temp", ex)
            End Try
        Next
    End Sub

    Private Sub moveToFinishedLocation(ByVal zipFileOrigin As String, ByVal holdDir As String)
        Try
            Dim zipFileInfo As New FileInfo(zipFileOrigin)
            My.Computer.FileSystem.MoveFile(zipFileOrigin, holdDir + "\" + zipFileInfo.Name)
        Catch ex As Exception
            Main.log.err(" -Error moving zip file to processed dir.", ex)
        End Try

    End Sub

End Class
