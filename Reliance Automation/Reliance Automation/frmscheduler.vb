Imports System.Data.SqlClient

Public Class frmscheduler
    Dim OLD_CAN_NO As Integer = 0

    Private Sub frmscheduler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ReadServerID() = True Then
            If SQLConnection() = False Then
                Application.Exit()
            End If
        End If
        tmrCAN.Interval = Shedule_Time
        tmrCAN.Enabled = True
    End Sub

    Private Sub tmrCAN_Tick(sender As Object, e As EventArgs) Handles tmrCAN.Tick
        Try
            SQLRecConnection()
            lblprdline.Text = line_no

            Dim CAN_NO As Integer = 0
            Me.BackColor = Color.Red
            CAN_NO = Integer.Parse(Scan_CAN(SCANNER_IP, SCANNER_PORT))

            lblCanNo.Text = CAN_NO

            If CAN_NO <> 0 Then
                'Application startup logic
                If OLD_CAN_NO = 0 Then
                    Dim dTable As New Data.DataTable
                    dTable.Clear()
                    Dim dAdpt As New SqlDataAdapter("select top 1 * from tbl_CAN_PROC where LI_NO=" & line_no & " and  CAN_ST=2  order by SNE_DT desc", Con)
                    dAdpt.Fill(dTable)
                    If dTable.Rows.Count > 0 Then
                        OLD_CAN_NO = dTable.Rows(0).Item("CAN_NO")
                        lblLastCanNo.Text = OLD_CAN_NO
                    End If
                    dTable.Clear()
                End If

                'Check previous and new can no same logic
                If CAN_NO = OLD_CAN_NO Then
                    Dim dTable1 As New Data.DataTable
                    dTable1.Clear()
                    Dim dAdpt1 As New SqlDataAdapter("select top 1 * from tbl_CAN_PROC where CAN_NO= " & CAN_NO & " and CAN_ST=2 ", Con)
                    dAdpt1.Fill(dTable1)
                    If dTable1.Rows.Count > 0 Then

                        Cmd.CommandText = "update tbl_CAN_PROC set SNE_DT= getdate() where CAN_NO= " & CAN_NO & " and CAN_ST=2 and ID=" & dTable1.Rows(0).Item("ID") & ""
                        Cmd.ExecuteNonQuery()

                        lblStatus.Text = "Filling in progress"
                        Me.BackColor = Color.Green

                    Else
                        'lblStatus.Text = "CAN Filled."
                        Cmd.CommandText = "insert into tbl_CAN_TRANS values(" & CAN_NO & "," & line_no & ",0,getdate(),2,'Filling')"
                        Cmd.ExecuteNonQuery()

                        Cmd.CommandText = "insert into tbl_CAN_PROC values(" & CAN_NO & "," & line_no & ",getdate(),getdate(),2,'Filling')"
                        Cmd.ExecuteNonQuery()
                        lblStatus.Text = "NEW Filling Started."

                        Me.BackColor = Color.Green
                    End If
                    dTable1.Clear()

                Else
                    'New CAN logic
                    lblStatus.Text = "NEW Filling Started."
                    'Master can maintain logic
                    If Replicationcheck("select  * from tbl_CAN_Master where CAN_NO= " & CAN_NO & "") = False Then

                        Cmd.CommandText = "insert into tbl_CAN_Master values (" & CAN_NO & ",1001,getdate(),0,'')"
                        Cmd.ExecuteNonQuery()

                    End If
                    If OLD_CAN_NO <> 0 Then
                        'Old can finish logic

                        Cmd.CommandText = "insert into tbl_CAN_TRANS values(" & OLD_CAN_NO & "," & line_no & ",0,getdate(),3,'Filled')"
                        Cmd.ExecuteNonQuery()


                        Cmd.CommandText = "update tbl_CAN_PROC set  CAN_ST=3,Remark='Filled' where LI_NO= " & line_no & " and CAN_ST=2 and CAN_NO= " & OLD_CAN_NO & " "
                        Cmd.ExecuteNonQuery()

                    End If

                    Cmd.CommandText = "insert into tbl_CAN_TRANS values(" & CAN_NO & "," & line_no & ",0,getdate(),2,'Filling')"
                    Cmd.ExecuteNonQuery()

                    Cmd.CommandText = "insert into tbl_CAN_PROC values(" & CAN_NO & "," & line_no & ",getdate(),getdate(),2,'Filling')"
                    Cmd.ExecuteNonQuery()


                    lblLastCanNo.Text = OLD_CAN_NO
                    OLD_CAN_NO = CAN_NO
                    Me.BackColor = Color.Green

                End If

                Cmd.CommandText = "update tbl_CAN_Master set CAN_ST=3, Remark='Filled' where CAN_NO in ( select Distinct CAN_NO from tbl_CAN_PROC where LI_NO= " & line_no & " and CAN_ST=2 ) and CAN_ST=2  and CAN_NO <>" & CAN_NO
                Cmd.ExecuteNonQuery()

                Cmd.CommandText = "update tbl_CAN_Master set CAN_ST=2 where CAN_NO= " & CAN_NO
                Cmd.ExecuteNonQuery()

            End If

            lbltime.Text = Now()

        Catch ex As Exception
            Me.BackColor = Color.Red
            WriteErrorLog(ex.ToString)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If MsgBox("Are you sure, you want to close the Scheduler?", MsgBoxStyle.YesNo, CompanyName) = DialogResult.Yes Then
            If InputBox("Enter Password ", "Password", "Close") <> "Stallion@123" Then Exit Sub
            Application.Exit()
        End If
    End Sub
End Class
