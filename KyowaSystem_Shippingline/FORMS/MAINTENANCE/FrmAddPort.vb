Public Class FrmAddPort
    Public ModeIs As String = "NEW"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Create_SAVING_OF_2_PORTS_TABLES_ADD_EDIT_DELETE

        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SavePort(KVal(txtCodeIs.Text), KVal(txtparticular.Text), USER_ID, Now, "1")
                Call FrmAddPort_Load(e, e)

                Call LoadStrCmb(FrmInitialBooking.cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(frmSetCharges.cmbPlace, "SELECT CODEIS , NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY   NAME ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_LOADING_UNLOADING_PORT SET CODEIS = '" & KVal(txtCodeIs.Text) & "', NAME = '" & KVal(txtparticular.Text) & "', AddedBy = '" & USER_ID & "', DateAdded  = '" & Now & "' WHERE  rstat = '1' AND ID = '" & txtparticular.Tag & "'")
                Call SetJob("UPDATE TBL_PORTS SET CODEIS = '" & KVal(txtCodeIs.Text) & "' , AddedBy = '" & USER_ID & "', DateAdded  = '" & Now & "' WHERE  STAT = '1' AND NAME = '" & KVal(txtparticular.Text) & "'  ")
                Call SetJob("UPDATE TBL_SUB_TRADE_OPTIONS SET CODEIS = '" & KVal(txtCodeIs.Text) & "' , AddedBy = '" & USER_ID & "', DateAdded  = '" & Now & "' WHERE  STAT = '1' AND NAME = '" & KVal(txtparticular.Text) & "'  ")


                Call FrmAddPort_Load(e, e)
                Call LoadStrCmb(FrmInitialBooking.cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(FrmInitialBooking.cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                Call LoadStrCmb(frmSetCharges.cmbPlace, "SELECT CODEIS , NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY   NAME ASC")

                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
    End Sub

    Public Sub SavePort(cODEiS, NAME, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_LOADING_UNLOADING_PORT(cODEiS, NAME, AddedBy, DateAdded, Stat, rstat)"
        SQL = SQL + "VALUES('" & KVal(cODEiS) & "','" & KVal(NAME) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "','1')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmAddPort_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID , CODEIS, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE   NAME LIKE '" & KVal(txtparticular.Text) & "%' AND rstat = '1' and NAME <> '' ORDER BY NAME ASC"
            'SQL = "SELECT  CODEIS, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE   NAME LIKE '%' AND rstat = '1' and NAME <> ''  
            '        UNION  
            '        SELECT CODEIS, NAME FROM TBL_PORTS WHERE   NAME LIKE '%' AND SUB_TRADE_ID <> '0' and NAME <> '' ORDER BY NAME ASc
            '        "
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                '.Rows.Add(Format(CInt(0)), "00000"), Dbo.reader(0).ToString, Dbo.reader(1).ToString)
                .Rows.Add(Format(CInt(Dbo.reader(0).ToString), "00000"), Dbo.reader(1).ToString, Dbo.reader(2).ToString)
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub txtparticular_TextChanged(sender As Object, e As EventArgs) Handles txtparticular.TextChanged

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        txtCodeIs.Text = ""
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 3 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_LOADING_UNLOADING_PORT SET STAT = '0', rstat = '0' WHERE STAT = '1' and rstat = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddPort_Load(e, e)
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

    Private Sub FrmAddPort_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class