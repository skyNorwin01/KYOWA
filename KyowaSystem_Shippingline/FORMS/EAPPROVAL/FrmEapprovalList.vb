Public Class FrmEapprovalList
    Private Sub btnSendRequest_Click(sender As Object, e As EventArgs) Handles btnSendRequest.Click
        Call LoadForm(FrmEApprovalMenu, "EAPPROVAL MENU")
    End Sub



    Public Sub LoadList()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        'SQL = "SELECT RTG, DateAdded, PARAM1, BLNO, REFNO, ReqToManagerUrgentLevel, RequestToManager, ReqToManagerApproveStat, ReqToManagerApproveDate, ManagerToReqNote, RequestToExecom, ReqToExecomApproveStat, ReqToExecomApproveDate, SignatoryNoteC, AddedBy, ID   FROM TBL_REQUEST_E_APPROVAL WHERE STAT = '1'"
        SQL = "SELECT RTG, E.DateAdded, PARAM1, BLNO, REFNO, ReqToManagerUrgentLevel, RequestToManager, ReqToManagerApproveStat, ReqToManagerApproveDate, ManagerToReqNote, RequestToExecom, ReqToExecomApproveStat, ReqToExecomApproveDate, SignatoryNoteC, U.fname + ' ' + U.LNAME , E.ID   FROM TBL_REQUEST_E_APPROVAL AS E LEFT JOIN TBL_USERS AS U ON E.AddedBy = U.ID WHERE E.STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                Dim urgLvl As String = Dbo.reader(5).ToString
                Dim ManagerStats = "", ExecomStats As String = ""
                If Dbo.reader(7).ToString = "0" Then
                    ManagerStats = ""
                ElseIf Dbo.reader(7).ToString = "3" Then
                    ManagerStats = "DISAPPROVED / " & Format(CDate(Dbo.reader(8).ToString), "MM-dd-yyyy hh:mm tt")
                ElseIf Dbo.reader(7).ToString = "1" Then
                    ManagerStats = "APPROVED    / " & Format(CDate(Dbo.reader(8).ToString), "MM-dd-yyyy hh:mm tt")
                End If

                If Dbo.reader(11).ToString = "0" Then
                    ExecomStats = ""
                ElseIf Dbo.reader(11).ToString = "3" Then
                    ExecomStats = "DISAPPROVED / " & Format(CDate(Dbo.reader(12).ToString), "MM-dd-yyyy hh:mm tt")
                ElseIf Dbo.reader(11).ToString = "1" Then
                    ExecomStats = "APPROVED    / " & Format(CDate(Dbo.reader(12).ToString), "MM-dd-yyyy hh:mm tt")
                End If

                If urgLvl = 1 Then
                    urgLvl = "REGULAR"
                Else
                    urgLvl = "URGENT"
                End If

                Dim ClosedStats As String = ""
                If Dbo.reader(7).ToString = 0 And Dbo.reader(11).ToString = 0 Then
                    ClosedStats = "WAITING"
                ElseIf Dbo.reader(7).ToString = 1 And Dbo.reader(11).ToString = 0 Then
                    ClosedStats = "WAITING"
                ElseIf Dbo.reader(7).ToString = 3 And Dbo.reader(11).ToString = 0 Then
                    ClosedStats = "CLOSED"
                ElseIf Dbo.reader(7).ToString = 1 And Dbo.reader(11).ToString = 1 Then
                    ClosedStats = "CLOSED"
                ElseIf Dbo.reader(7).ToString = 1 And Dbo.reader(11).ToString = 3 Then
                    ClosedStats = "CLOSED"
                Else
                    ClosedStats = "ERROR"
                End If

                .Rows.Add(Dbo.reader(0).ToString, Format(CDate(Dbo.reader(1).ToString), "MM-dd-yyyy hh:mm tt"), Dbo.reader(2).ToString & "  :   " & Dbo.reader(3).ToString & "  -  " & Dbo.reader(4).ToString, urgLvl, KVal(Dbo.reader(6).ToString), ManagerStats, Dbo.reader(9).ToString, UCase(Dbo.reader(10).ToString), ExecomStats, Dbo.reader(13).ToString, Dbo.reader(14).ToString, ClosedStats)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(14).ToString

                If .Rows(.RowCount - 1).Cells(.ColumnCount - 1).Value = "CLOSED" Then
                    .Rows(.RowCount - 1).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    .Rows(.RowCount - 1).DefaultCellStyle.Font = New Font(dtList.Font, FontStyle.Bold)
                    .Rows(.RowCount - 1).DefaultCellStyle.ForeColor = Color.Black
                End If

                If Dbo.reader(7).ToString = "3" Then
                    .Rows(.RowCount - 1).DefaultCellStyle.ForeColor = Color.Gray
                End If

                'If Dbo.reader(11).ToString = "3" Then
                '    .Rows(.RowCount - 1).DefaultCellStyle.ForeColor = Color.LightBlue
                'End If
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub UpdateCorrInfo(RTG As String, RequestToExecom As String, ReqToExecomApproveStat As Integer, ReqToExecomApproveDate As DateTime, SignatoryNoteC As String, RequestToManager As String, ReqToManagerApproveStat As Integer, ReqToManagerApproveDate As DateTime, ManagerToReqNote As String)
        Call SetJob("UPDATE TBL_REQUEST_E_APPROVAL SET  RequestToExecom = '" & RequestToExecom & "', ReqToExecomApproveStat = '" & ReqToExecomApproveStat & "', ReqToExecomApproveDate = '" & ReqToExecomApproveDate & "', SignatoryNoteC = '" & SignatoryNoteC & "', RequestToManager = '" & RequestToManager & "', ReqToManagerApproveStat = '" & ReqToManagerApproveStat & "', ReqToManagerApproveDate = '" & ReqToManagerApproveDate & "', ManagerToReqNote = '" & ManagerToReqNote & "' where stat = '1' and RTG = '" & RTG & "'")
        Call SetJobMysql("UPDATE tbl_eapprove_n SET  fstat = 1  where stat = '1' and RTG = '" & RTG & "' and fstat = '0'")

    End Sub
    Public Sub fAll()
        'check online stats
        Dim DBOO As New SQLClass
        DBOO.MysqlCon.Open()
        SQL = "SELECT RTG, RequestToExecom, ReqToExecomApproveStat, ReqToExecomApproveDate, fstat, SignatoryNoteC, RequestToManager, ReqToManagerApproveStat, ReqToManagerApproveDate, ManagerToReqNote FROM tbl_eapprove_n where fstat = '0'"
        DBOO.MysqlCmd = New MySql.Data.MySqlClient.MySqlCommand(SQL, DBOO.MysqlCon)
        DBOO.MysqlCmd.ExecuteNonQuery()
        DBOO.reader = DBOO.MysqlCmd.ExecuteReader
        Do While DBOO.reader.Read
            Dim ReqToExDate As DateTime = "01/01/1990"
            If Not String.IsNullOrEmpty(DBOO.reader(3).ToString) Then
                ReqToExDate = DBOO.reader(3).ToString
            End If
            Dim ReqToManagerDate As DateTime = "01/01/1990"
            If Not String.IsNullOrEmpty(DBOO.reader(8).ToString) Then
                ReqToManagerDate = DBOO.reader(8).ToString
            End If

            Call UpdateCorrInfo(DBOO.reader(0).ToString, DBOO.reader(1).ToString, DBOO.reader(2).ToString, ReqToExDate, DBOO.reader(5).ToString, DBOO.reader(6).ToString, DBOO.reader(7).ToString, ReqToManagerDate, DBOO.reader(9).ToString)
        Loop
        DBOO.reader.Close()
        DBOO.MysqlCon.Close()
    End Sub

    Private Sub btnSync_Click(sender As Object, e As EventArgs) Handles btnSync.Click
        Call fAll()
        Call LoadList()
    End Sub

    Private Sub FrmEapprovalList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dtList
            .Columns(.ColumnCount - 1).DisplayIndex = 0
        End With
        Call fAll()
        Call LoadList()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class