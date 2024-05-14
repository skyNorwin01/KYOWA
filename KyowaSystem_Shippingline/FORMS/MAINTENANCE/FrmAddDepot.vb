Public Class FrmAddDepot

    Public ModeIs As String = "NEW"
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        txtTelNo.Text = ""
        txtAddress.Text = ""
        dtStartOH.Value = Now
        dtEndOH.Value = Now
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveDepot(txtparticular.Text, txtAddress.Text, dtStartOH.Value, dtEndOH.Value, txtTelNo.Text, USER_ID, Now, "1")
                Call FrmAddDepot_Load(e, e)
                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_DEPOT SET NAME = '" & KVal(txtparticular.Text) & "', ADDRESSIS = '" & KVal(txtAddress.Text) & "',  OperatingHrsStart = '" & Now.Date & " " & Format(CDate(dtStartOH.Value), "hh:mm tt") & "', OperatingHrsEnd= '" & Now.Date & " " & Format(CDate(dtEndOH.Value), "hh:mm tt") & "', TelNo  = '" & KVal(txtTelNo.Text) & "', AddedBy = '" & USER_ID & "', DateAdded = '" & Now & "' WHERE STAT = '1' AND ID = '" & txtparticular.Tag & "'")
                Call FrmAddDepot_Load(e, e)
                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
    End Sub

    Public Sub SaveDepot(NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, TelNo, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_DEPOT(NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, TelNo, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(NAME) & "',  '" & KVal(ADDRESSIS) & "',  '" & KVal(OperatingHrsStart) & "',  '" & KVal(OperatingHrsEnd) & "',  '" & KVal(TelNo) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub


    Private Sub FrmAddDepot_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID, NAME, ADDRESSIS, TelNo, OperatingHrsStart, OperatingHrsEnd FROM TBL_DEPOT WHERE STAT = '1' AND NAME LIKE '" & KVal(txtparticular.Text) & "%' AND NAME <> '' ORDER BY NAME ASC"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Format(CInt(Dbo.reader(0).ToString), "00000"), Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Format(CDate(Dbo.reader(4).ToString), "hh:mm tt"), Format(CDate(Dbo.reader(5).ToString), "hh:mm tt"))
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 6 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_DEPOT SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddDepot_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
                ModeIs = "NEW"
            End If
        End If
        If e.ColumnIndex = 7 Then
            ModeIs = "EDIT"
            With dtList
                .Enabled = False
                txtparticular.Tag = CInt(.CurrentRow.Cells(0).Value)
                txtparticular.Text = .CurrentRow.Cells(1).Value
                txtAddress.Text = .CurrentRow.Cells(2).Value
                txtTelNo.Text = .CurrentRow.Cells(3).Value
                dtStartOH.Value = Now.Date & " " & Format(CDate(.CurrentRow.Cells(4).Value), "hh:mm tt")
                dtEndOH.Value = Now.Date & " " & Format(CDate(.CurrentRow.Cells(5).Value), "hh:mm tt")
            End With
        End If
    End Sub

    Private Sub FrmAddDepot_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class