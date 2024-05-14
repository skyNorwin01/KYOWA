Public Class FrmAddFeederCarrier

    Public ModeIs As String = "NEW"
    Private Sub FrmAddFeederCarrier_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1' AND FEEDER_CARRIER LIKE '" & KVal(txtparticular.Text) & "%' AND FEEDER_CARRIER <> '' ORDER BY FEEDER_CARRIER ASC"
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        dtList.Enabled = True
        ModeIs = "NEW"
    End Sub
    Public Sub SaveFeederCarrier(CARRIER, AddedBy, DateAdded, STAT)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_FEEDER_CARRIER(FEEDER_CARRIER, AddedBy, DateAdded, STAT)"
        SQL = SQL + "VALUES('" & KVal(CARRIER) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this recod?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveFeederCarrier(KVal(txtparticular.Text), USER_ID, Now, "1")
                Call FrmAddFeederCarrier_Load(e, e)



                Call LoadStrCmb(FrmInitialBooking.cmbTrucker, "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1'")

                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_FEEDER_CARRIER SET FEEDER_CARRIER = '" & KVal(txtparticular.Text) & "', AddedBy = '" & USER_ID & "', DateAdded = '" & Now & "' WHERE STAT = '1' AND  ID =  '" & txtparticular.Tag & "'")
                Call FrmAddFeederCarrier_Load(e, e)
                Call LoadStrCmb(FrmInitialBooking.cmbTrucker, "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1'")

                'Call LoadStrCleint(cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                'Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                'Call LoadStrCleint(cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")

                'Call LoadStrCmbTrade(cmbTrade, "SELECT ID, NAME  FROM TBL_TRADE WHERE STAT = '1'")
                'Call LoadStrCmb(cmbOutPort, "SELECT ID, OUTPORT FROM TBL_OUTPORT WHERE STAT = '1'")

                'Call LoadStrCmb(cmbFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
                'Call LoadStrCmb(cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                'Call LoadStrCmb(cmb2ndFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
                'Call LoadStrCmb(cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                'Call LoadStrCmb(cmbMotherVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
                'Call LoadStrCmb(CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                'Call LoadStrCmb(cmbTrucker, "SELECT ID, TRUCKER FROM TBL_TRUCKER WHERE STAT = '1'")
                'Call LoadStrCmb(CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                'Call LoadStrCmb(cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
                'Call LoadStrCmb(cmbPlace, "SELECT CODEIS , NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY   NAME ASC")
                MsgBox("Saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If

    End Sub

    Private Sub txtparticular_TextChanged(sender As Object, e As EventArgs) Handles txtparticular.TextChanged

    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 2 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_FEEDER_CARRIER SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddFeederCarrier_Load(e, e)
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

    Private Sub FrmAddFeederCarrier_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class