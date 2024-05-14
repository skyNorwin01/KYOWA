﻿Public Class FrmAddCharges
    Public ModeIs As String = "NEW"
    Public Sub FrmAddCharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT  ID, CHARGES_CODE, CHARGES_NAME FROM TBL_CHARGES_NAME WHERE STAT = '1' AND charges_NAME LIKE '" & KVal(txtparticular.Text) & "%' AND CHARGES_CODE LIKE '" & KVal(txtCodeIs.Text) & "%'   ORDER BY charges_name ASC"
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        txtCodeIs.Text = ""
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub

    Public Sub SaveCharges(CHARGES_CODE, CHARGES_NAME, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CHARGES_NAME(CHARGES_CODE, CHARGES_NAME, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(CHARGES_CODE) & "',  '" & KVal(CHARGES_NAME) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveCharges(KVal(txtCodeIs.Text), KVal(txtparticular.Text), USER_ID, Now, "1")
                Call FrmAddCharges_Load(e, e)

                Call LoadCmbCharges(frmSetCharges.cmbCharges, "SELECT ID, CHARGES_NAME, CHARGES_CODE FROM TBL_CHARGES_NAME WHERE STAT = '1' ORDER BY CHARGES_NAME ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CHARGES_NAME SET CHARGES_CODE = '" & KVal(txtCodeIs.Text) & "', CHARGES_NAME = '" & KVal(txtparticular.Text) & "', AddedBy = '" & USER_ID & "', DateAdded  = '" & Now & "' WHERE STAT = '1' AND ID = '" & txtparticular.Tag & "'")
                Call FrmAddCharges_Load(e, e)
                Call LoadCmbCharges(frmSetCharges.cmbCharges, "SELECT ID, CHARGES_NAME, CHARGES_CODE FROM TBL_CHARGES_NAME WHERE STAT = '1' ORDER BY CHARGES_NAME ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 3 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CHARGES_NAME SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddCharges_Load(e, e)
                Call frmSetCharges.frmSetCharges_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If
        End If
        If e.ColumnIndex = 4 Then
            ModeIs = "EDIT"
            With dtList
                .Enabled = False
                txtparticular.Tag = CInt(.CurrentRow.Cells(0).Value)
                txtparticular.Text = .CurrentRow.Cells(2).Value
                txtCodeIs.Text = .CurrentRow.Cells(1).Value
            End With
        End If
    End Sub

    Private Sub FrmAddCharges_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()

    End Sub
End Class