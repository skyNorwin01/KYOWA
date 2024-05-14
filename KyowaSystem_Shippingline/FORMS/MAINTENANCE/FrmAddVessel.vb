Public Class FrmAddVessel
    Public ModeIs As String = "NEW"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveVessel(KVal(txtparticular.Text), USER_ID, Now, "1")
                Call FrmAddVessel_Load(e, e)

                Call LoadStrCmb(FrmInitialBooking.cmbFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

                Call LoadStrCmb(FrmInitialBooking.cmb2ndFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

                Call LoadStrCmb(FrmInitialBooking.cmbMotherVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")


                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_VESSEL SET VESSELNAME = '" & KVal(txtparticular.Text) & "', AddedBy = '" & USER_ID & "', DateAdded= '" & Now & "' WHERE STAT = '1' AND ID = '" & txtparticular.Tag & "' ")
                Call FrmAddVessel_Load(e, e)

                Call LoadStrCmb(FrmInitialBooking.cmbFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

                Call LoadStrCmb(FrmInitialBooking.cmb2ndFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

                Call LoadStrCmb(FrmInitialBooking.cmbMotherVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")


                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
    End Sub

    Public Sub SaveVessel(VESSELNAME, AddedBy, DateAdded, STAT)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_VESSEL(VESSELNAME, AddedBy, DateAdded, STAT)"
        SQL = SQL + "VALUES('" & KVal(VESSELNAME) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmAddVessel_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1' AND VESSELNAME LIKE '" & KVal(txtparticular.Text) & "%' AND VESSELNAME <> '' ORDER BY VESSELNAME ASC"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Format(CInt(Dbo.reader(0).ToString), "00000"), Dbo.reader(1).ToString)
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 2 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_VESSEL SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddVessel_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If
        End If
        If e.ColumnIndex = 3 Then
            ModeIs = "EDIT"
            With dtList
                .Enabled = False
                txtparticular.Tag = CInt(.CurrentRow.Cells(0).Value)
                txtparticular.Text = .CurrentRow.Cells(1).Value
            End With
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub

    Private Sub FrmAddVessel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class