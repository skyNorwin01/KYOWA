Public Class FrmAddCurrency
    Public ModeIs As String = "NEW"
    Private Sub FrmAddCurrency_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtName.TextChanged, txtCurrency.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID, CURR, NAME FROM TBL_CURRENCY WHERE STAT = '1' AND NAME LIKE '" & KVal(txtName.Text) & "%' AND CURR LIKE '" & KVal(txtCurrency.Text) & "%'  AND STAT = '1'  ORDER BY NAME ASC"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Format(CInt(Dbo.reader(0).ToString), "00000"), Dbo.reader(1).ToString, Dbo.reader(2).ToString)
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub
    Public Sub SaveCurr(Name, Curr, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CURRENCY(Name, Curr, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(Name) & "',  '" & KVal(Curr) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveCurr(KVal(txtName.Text), txtCurrency.Text, USER_ID, Now, "1")
                Call FrmAddCurrency_Load(e, e)
                Call LoadStrCmb(frmSetCharges.cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CURRENCY SET CURR = '" & KVal(txtCurrency.Text) & "', NAME = '" & KVal(txtName.Text) & "', AddedBy = '" & USER_ID & "', DateAdded  = '" & Now & "' WHERE STAT = '1' AND ID = '" & txtName.Tag & "'")
                Call FrmAddCurrency_Load(e, e)
                Call LoadStrCmb(frmSetCharges.cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtName.Text = ""
        txtCurrency.Text = ""
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 3 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CURRENCY SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddCurrency_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If
        End If
        If e.ColumnIndex = 4 Then
            ModeIs = "EDIT"
            With dtList
                .Enabled = False
                txtName.Tag = CInt(.CurrentRow.Cells(0).Value)
                txtName.Text = .CurrentRow.Cells(2).Value
                txtCurrency.Text = .CurrentRow.Cells(1).Value
            End With
        End If
    End Sub

End Class