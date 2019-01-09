Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Sockets


Module Connection
    Public Con As New SqlConnection
    Public Cmd As New SqlCommand
    Public Dr As SqlDataReader
    Dim CompName As String = "RELIANCE INDUSTRIES LIMITED,PATALGANGA"
    Dim ServerIP As String = ""
    Dim DBname As String = ""
    Dim DBUserID As String = ""
    Dim DBPassword As String = ""
    Public dTable As New Data.DataTable
    Public SCANNER_IP As String = ""
    Public SCANNER_PORT As String = ""
    Public Receive_data As String = ""
    Public line_no As Integer = 0
    Public Shedule_Time As Integer = 1000

    Public Function SQLConnection() As Boolean
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.ConnectionString = "Data Source=" & ServerIP & ";Initial Catalog=" & DBname & ";User Id=" & DBUserID & ";PWD=" & DBPassword & ";MultipleActiveResultSets=True"
            Con.Open()
            Cmd.Connection = Con
            SQLConnection = True
        Catch ex As Exception
            ' frmReader.lstErrorLog.Items.Add(ex.Message)
            WriteErrorLog("SQL Connection Error " & vbNewLine)
            SQLConnection = False
        End Try

    End Function
    Public Function SQLRecConnection() As Boolean
        Try
            If Con.State = Data.ConnectionState.Closed Then
                Con.ConnectionString = "Data Source=" & ServerIP & ";Initial Catalog=" & DBname & ";User Id=" & DBUserID & ";PWD=" & DBPassword
                Con.Open()
                Cmd.Connection = Con
                SQLRecConnection = True
            Else
                SQLRecConnection = True
            End If
        Catch ex As Exception
            MsgBox("Check Internet Connection or SQL Setup Files...")
            SQLRecConnection = False
        End Try
    End Function

    Public Function ReadServerID() As Boolean
        ReadServerID = False
        Dim path As String = Application.StartupPath & "\Server.txt"

        If IO.File.Exists(path) = False Then
            WriteErrorLog("SQL Connection File Missing (Server.txt)" & vbNewLine)

            Exit Function
        End If
        Dim myreader As System.IO.StreamReader
        myreader = New System.IO.StreamReader(path)
        Dim mindex As Integer = 0
        While myreader.Peek <> -1
            mindex = mindex + 1
            If mindex = 1 Then
                ServerIP = myreader.ReadLine.Trim
            ElseIf mindex = 2 Then
                DBname = myreader.ReadLine.Trim
            ElseIf mindex = 3 Then
                DBUserID = myreader.ReadLine.Trim
            ElseIf mindex = 4 Then
                DBPassword = myreader.ReadLine.Trim
            ElseIf mindex = 5 Then
                SCANNER_IP = myreader.ReadLine.Trim
            ElseIf mindex = 6 Then
                SCANNER_PORT = Integer.Parse(myreader.ReadLine.Trim)
            ElseIf mindex = 7 Then
                line_no = Integer.Parse(myreader.ReadLine.Trim)
            ElseIf mindex = 8 Then
                Shedule_Time = Integer.Parse(myreader.ReadLine.Trim)
            Else
                Exit While
            End If
        End While
        myreader.Close()

        If ServerIP = "" Then
            WriteErrorLog("SQL Connection Error : Invalid Server IP Address" & vbNewLine)
        ElseIf DBname = "" Then
            WriteErrorLog("SQL Connection Error : Invalid  DataBase Name" & vbNewLine)
        ElseIf DBUserID = "" Then
            WriteErrorLog("SQL Connection Error : Invalid  DataBase User ID" & vbNewLine)
        ElseIf DBPassword = "" Then
            WriteErrorLog("SQL Connection Error : Invalid  DataBase User IDPassword " & vbNewLine)
        ElseIf SCANNER_IP = "" Then
            WriteErrorLog("Scanner IP address not maintain in Server file." & vbNewLine)
        ElseIf SCANNER_PORT = "" Then
            WriteErrorLog("Scanner Port number not maintain in Server file." & vbNewLine)
        ElseIf line_no = 0 Or line_no = "" Then
            WriteErrorLog("Production line not maintain in Server file." & vbNewLine)
        ElseIf Shedule_Time = 0 Then
            WriteErrorLog("Schedule time not maintain in Server file." & vbNewLine)
        Else
            ReadServerID = True
        End If
    End Function
    Public Function Replicationcheck(ByVal SQLQuery As String) As Boolean
        Cmd.CommandText = SQLQuery
        DR = Cmd.ExecuteReader
        If DR.Read() = False Then
            Replicationcheck = False
        Else
            Replicationcheck = True
        End If
        DR.Close()
        Return Replicationcheck
    End Function
    Public Sub TimeLog(ByVal Message As String)
        Dim LogFileName As String = Application.StartupPath & "\" & "RFCTIME" & Format(Now(), "ddMMyy") & ".txt"
        Dim LogFileWriter As New StreamWriter(LogFileName, True)
        LogFileWriter.WriteLine("-------------------------------------------------------------------------------------")
        LogFileWriter.WriteLine(Message & " - " & Now())
        LogFileWriter.WriteLine("-------------------------------------------------------------------------------------")
        LogFileWriter.Close()
    End Sub


    Public Sub WriteErrorLog(ByVal Message As String)
        Dim LogFileName As String = Application.StartupPath & "\" & "RFCERROR" & Format(Now(), "ddMMyy") & ".txt"
        Dim LogFileWriter As New StreamWriter(LogFileName, True)
        LogFileWriter.WriteLine("-------------------------------------------------------------------------------------")
        LogFileWriter.WriteLine(Format(Now(), "hh:mm:ss tt") & "|Error Message: " & Message)
        LogFileWriter.WriteLine("-------------------------------------------------------------------------------------")
        LogFileWriter.Close()
        'frmReader.BackColor = Color.Red
    End Sub

    Public Function Scan_CAN(server As [String], message As [String]) As String
        ' On Error Resume Next
        Try
            ' Create a TcpClient.
            ' Note, for this client to work you need to have a TcpServer 
            ' connected to the same address as specified by the server, port
            ' combination.
            '   Dim port As Int32 = 51235
            Dim client As New TcpClient(server, SCANNER_PORT)
            ' Translate the passed message into ASCII and store it as a Byte array.
            'client.ReceiveTimeout = 300
            Receive_data = ""
            Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(message)

            ' Get a client stream for reading and writing.
            '  Stream stream = client.GetStream();
            Dim stream As NetworkStream = client.GetStream()

            data = New [Byte](256) {}

            Dim responseData As [String] = [String].Empty

            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            '  MsgBox("Received: {0}", responseData)

            If responseData = "" Then
                Receive_data = ""
            ElseIf Receive_data = "" Then
            Else
                Receive_data = Trim(responseData)
            End If

            ' Close everything.
            stream.Close()
            client.Close()
            Return Receive_data

        Catch EX As Exception
            WriteErrorLog(EX.ToString)
            ' MsgBox(EX.Message.ToString)
        End Try
        Return Receive_data
    End Function

End Module
