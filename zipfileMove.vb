﻿Imports System.IO.Compression
Imports System
Imports System.IO
Imports System.IO.File
Imports System.Xml
Imports System.Text
'Imports System.IO.Compression.FileSystem
Module Module1

    Sub main()
        Dim args() As String = System.Environment.GetCommandLineArgs()
        Dim folder As String
        Dim mother_fold As String
        Dim written As Boolean
        Dim CurrentDateTime As String = DateTime.Now.ToString("M/d/yyyy hh:mm:ss tt")
        ' folder = Console.Read()
        Dim j As String
        'For i = 0 To (args.Length - 1)
         '   If args(i) = "-i" Then
          '      folder = args(i + 1)
           ' ElseIf args(i) = "-o" Then
            '    mother_fold = args(i + 1)
            'End If
        'Next i

        Dim times As String
        Dim di As New IO.DirectoryInfo(folder)
        Dim SubDirectories() As IO.DirectoryInfo = di.GetDirectories()
        Dim usedirectory As String()
        Dim dt As String
        Dim dpg As String
        Dim size_time As String

        Dim input_time As String
        written = writeToFile(folder + "\log.csv", "Input folder", "Zip name", "Destination folder", "Timestamp", "File transfer time", ",")
        For Each dr As IO.DirectoryInfo In SubDirectories
            usedirectory = dr.Name.Split("_"c)
            size_time = UBound(usedirectory)
            If size_time > 0 Then
                dt = usedirectory(0)
                dpg = usedirectory(1)
                input_time = Left(dpg, 6)
            End If

            Dim dest_folder As String
            Dim dir As New DirectoryInfo(dr.FullName)
            ' Get a reference to each file in that directory.
            Dim fiArr As FileInfo() = dir.GetFiles()
            ' Display the names of the files.
            Dim fri As FileInfo
            Dim inputzip As String
            Dim usefile As String
            Dim csvf As String()
            Dim snpf As String
            Dim waferid As String
            Dim myLine As String
            Dim snpfile As String
            Dim offs_time As String
            Dim oothree As String
            Dim minus_time As String
            Dim db_offs As String
            Dim snp_timeo As String
            Dim in_time As String
            Dim int_time As String
            'Dim find As Boolean
            Dim snp_time As String
            For Each fri In fiArr


                inputzip = Right(fri.Name, 3)

                If inputzip = "zip" Then
                    Console.SetIn(New StreamReader(Console.OpenStandardInput(8192)))
                    'Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(usefile, "C:\Project")

                    Try
                        Using archive As ZipArchive = ZipFile.OpenRead(dr.FullName + "\" + fri.Name)
                            For Each entry As ZipArchiveEntry In archive.Entries

                                If entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) Then
                                    usefile = dr.FullName + "\" + fri.Name
                                    csvf = entry.FullName.Split("_"c)
                                    waferid = csvf(1)
                                    ZipFile.ExtractToDirectory(usefile, dr.FullName)
                                    'Console.WriteLine(dr.FullName)
                                    Using sr As New StreamReader(dr.FullName + "\" + entry.FullName)

                                        ' Skip the first two lines:
                                        sr.ReadLine()
                                        sr.ReadLine()
                                        myLine = sr.ReadLine()
                                        Dim currentRecord() As String = Split(myLine, ",")
                                        Dim m As String
                                        Dim h As String
                                        Dim z As String
                                        m = currentRecord(1)
                                        h = currentRecord(2)
                                        Dim day() As String = Split(m, " ")
                                        ' Console.WriteLine(day(2))
                                        Dim hour() As String = Split(h, " ")
                                        Dim g() As String = Split(hour(2), ":")
                                        Dim y As String
                                        Dim ru As String
                                        Dim ominus As String
                                        Dim othree As String
                                        'y = day(1) - 2
                                        ominus = g(0) - 1
                                        ru = g(0) + 18
                                        othree = day(2) - 1
                                        'Console.WriteLine(y)
                                        in_time = input_time + day(2) + g(0)
                                        times = day(2) + day(1) + hour(1) + " " + hour(2)
                                        'offs_time = input_time + day(2) + y
                                        minus_time = input_time + day(2) + ominus
                                        'db_offs = input_time + day(2) + ru
                                        oothree = input_time + othree + ru
                                        'Console.WriteLine(in_time)
                                        written = writeToFile(folder + "\file_list.csv", fri.FullName, CurrentDateTime, fri.Name, times, "", ",")
                                    End Using
                                    FileClose(1)

                                    'Dim pp As New IO.DirectoryInfo(fri.FullName)
                                    'Dim SubDd() As IO.DirectoryInfo = pp.GetDirectories()
                                    ' For Each yy As IO.DirectoryInfo In SubDd
                                    ' Next

                                    My.Computer.FileSystem.DeleteFile(dr.FullName + "\" + entry.FullName)
                                    Console.WriteLine(dr.FullName + "\" + entry.FullName)

                                End If
                            Next

                            For Each zip As ZipArchiveEntry In archive.Entries
                                Try
                                    If zip.FullName.EndsWith(".s2p", StringComparison.OrdinalIgnoreCase) Then
                                        ' Console.WriteLine(zip.FullName)
                                        snpfile = dr.FullName + "\" + fri.Name
                                        csvf = zip.FullName.Split("_"c)
                                        waferid = csvf(1)
                                        ZipFile.ExtractToDirectory(snpfile, dr.FullName)
                                        'fileReader As New StreamReader(dr.FullName + "\" + entry.FullName)

                                        Using filereader As New StreamReader(dr.FullName + "\" + zip.FullName)
                                            ' Skip the first two lines:
                                            filereader.ReadLine()
                                            snpf = filereader.ReadLine()
                                            Dim currentsnp() As String = Split(snpf, ",")
                                            Dim x As String
                                            Dim y As String
                                            Dim u As String
                                            x = currentsnp(1)
                                            y = currentsnp(2)
                                            Dim mth() As String = Split(x, " ")
                                            Dim hrs() As String = Split(y, " ")
                                            Dim t() As String = Split(hrs(2), ":")
                                            Dim tt As String
                                            snp_time = input_time + mth(2) + t(0)
                                            tt = t(0) + 1
                                            int_time = mth(2) + mth(1) + hrs(1) + " " + hrs(2)
                                            snp_timeo = input_time + mth(2) + tt
                                            'Console.WriteLine(int_time)
                                        End Using
                                        FileClose(1)
                                        My.Computer.FileSystem.DeleteFile(dr.FullName + "\" + zip.FullName)
                                    End If
                                Catch ex As Exception
                                    Console.WriteLine("Zip S2P file is not found")
                                End Try
                            Next

                            Dim find_fold As String = mother_fold + "\" + waferid
                            'Dim find_fold As String = "Y:\sgdietrace\" + waferid
                            Dim du As New IO.DirectoryInfo(find_fold)
                            Dim SubDirect() As IO.DirectoryInfo = du.GetDirectories()
                            Dim find_dir As String()
                            Dim mother_dest As String
                            Dim arr_find_dir As String
                            Dim timestamp As String
                            Dim path As String

                            For Each dx As IO.DirectoryInfo In SubDirect
                                'Console.WriteLine(dx.FullName)
                                find_dir = dx.Name.Split("_"c)
                                arr_find_dir = UBound(find_dir)
                                'Console.WriteLine(arr_find_dir)
                                If arr_find_dir > 7 Then
                                    If find_dir(4).Length() = 1 And find_dir(7).Length() = 1 Then
                                        timestamp = find_dir(6) + "0" + find_dir(4) + find_dir(5) + "0" + find_dir(7)
                                    ElseIf find_dir(4).Length() = 1 Then
                                        timestamp = find_dir(6) + "0" + find_dir(4) + find_dir(5) + find_dir(7)
                                    ElseIf find_dir(5).Length() = 1 Then
                                        timestamp = find_dir(6) + find_dir(4) + "0" + find_dir(5) + find_dir(7)
                                    ElseIf find_dir(7).Length() = 1 Then
                                        timestamp = find_dir(6) + find_dir(4) + find_dir(5) + "0" + find_dir(7)
                                    ElseIf find_dir(4).Length() = 1 And find_dir(5).Length() = 1 Then
                                        timestamp = find_dir(6) + "0" + find_dir(4) + "0" + find_dir(5) + find_dir(7)
                                    ElseIf find_dir(5).Length() = 1 And find_dir(7).Length() = 1 Then
                                        timestamp = find_dir(6) + find_dir(4) + "0" + find_dir(5) + "0" + find_dir(7)
                                    ElseIf find_dir(4).Length() = 1 And find_dir(5).Length() = 1 And find_dir(7).Length() = 1 Then
                                        timestamp = find_dir(6) + "0" + find_dir(4) + "0" + find_dir(5) + "0" + find_dir(7)
                                    Else
                                        timestamp = find_dir(6) + find_dir(4) + find_dir(5) + find_dir(7)
                                    End If
                                End If

                                If arr_find_dir > 2 Then
                                    mother_dest = find_dir(3)
                                    path = dx.FullName

                                    Dim final_dest As String
                                    final_dest = path + "\" + fri.Name
                                    If mother_dest = dt Then
                                        If timestamp = in_time Then
                                            j = j + 1
                                            written = writeToFile(folder + "\log.csv", usefile, fri.Name, final_dest, times, CurrentDateTime, ",")
                                            My.Computer.FileSystem.MoveFile(usefile, final_dest, True)
                                        End If
                                        'If timestamp = offs_time Then
                                        'j = j + 1
                                        'written = writeToFile(folder + "\log.csv", usefile, fri.Name, final_dest, times, CurrentDateTime, ",")
                                        'My.Computer.FileSystem.CopyFile(usefile, final_dest, True)
                                        'End If
                                        'Dim creationTime As DateTime = Directory.GetCreationTime(path + "\" + fri.Name)
                                        If timestamp = minus_time Then
                                            j = j + 1
                                            written = writeToFile(folder + "\log.csv", usefile, fri.Name, final_dest, times, CurrentDateTime, ",")
                                            My.Computer.FileSystem.MoveFile(usefile, final_dest, True)
                                        End If
                                        'If timestamp = db_offs Then
                                        'j = j + 1
                                        'written = writeToFile(folder + "\log.csv", usefile, fri.Name, final_dest, times, CurrentDateTime, ",")
                                        'My.Computer.FileSystem.CopyFile(usefile, final_dest, True)
                                        'End If

                                        Do While timestamp = oothree
                                            j = j + 1
                                            written = writeToFile(folder + "\log.csv", usefile, fri.Name, final_dest, times, CurrentDateTime, ",")
                                            My.Computer.FileSystem.MoveFile(usefile, final_dest, True)
                                            If timestamp <> oothree Then
                                                Exit Do
                                            End If
                                        Loop

                                        If timestamp = snp_time Then
                                            j = j + 1
                                            'written = writeToFile(mother_fold + "\log.csv", snpfile, fri.Name, final_dest, int_time, CurrentDateTime, ",")
                                            written = writeToFile(folder + "\log.csv", snpfile, fri.Name, final_dest, int_time, CurrentDateTime, ",")
                                            My.Computer.FileSystem.MoveFile(snpfile, final_dest, True)
                                        End If
                                        'If timestamp = snp_timeo Then
                                        'j = j + 1
                                        'written = writeToFile(folder + "\log.csv", snpfile, fri.Name, final_dest, int_time, CurrentDateTime, ",")
                                        'My.Computer.FileSystem.MoveFile(snpfile, final_dest, True)

                                        'End If
                                    End If
                                End If
                            Next
                        End Using


                    Catch ex As Exception
                        Console.WriteLine("Zip csv file is not found")
                    End Try
                End If
            Next fri
        Next
        written = writeToFile(folder + "\log.csv", "Total transferred files are ", j, "", "", "", " ")
        'Console.ReadLine()
    End Sub

    Function writeToFile(ByVal filepath As String, ByVal fieldOne As String, ByVal fieldTwo As String, ByVal fieldThree As String, ByVal fieldFour As String, ByVal fieldFive As String, ByVal delimiter As String) As Boolean
        Try
            Dim fileWriter As New System.IO.StreamWriter(filepath, True)
            Dim record As String = fieldOne + delimiter + fieldTwo + delimiter + fieldThree + delimiter + fieldFour + delimiter + fieldFive
            fileWriter.WriteLine(record)
            fileWriter.Close()
            'Console.WriteLine("Record Written")
        Catch ex As Exception
            Console.WriteLine("Record not written")
        End Try
        Return False
    End Function
End Module
