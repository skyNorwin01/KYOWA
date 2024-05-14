Public Class FrmAddShipperConsigneeNotify
    Public ModeIs As String = "NEW"


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ModeIs = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveClient(KVal(txtparticular.Text), KVal(txtAddress.Text), KVal(txtTelNo.Text), Now, "1", USER_ID, txtEAddress.Text)
                Call FrmAddShipperConsigneeNotify_Load(e, e)

                Call LoadStrCleint(FrmInitialBooking.cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                Call LoadStrCleint(FrmInitialBooking.cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                Call LoadStrCleint(FrmInitialBooking.cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")


                MsgBox("Successfully saved!", MsgBoxStyle.Information)
                btnClear_Click(e, e)
            End If
        End If
        If ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to save changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CLIENT SET ClientName = '" & KVal(txtparticular.Text) & "', Clientaddress = '" & KVal(txtAddress.Text) & "', TELNO = '" & KVal(txtTelNo.Text) & "', EmailAddress = '" & KValNCase(txtEAddress.Text) & "' , DateAdded = '" & Now & "',   AddedBy = '" & USER_ID & "' WHERE STAT = '1' AND ID = '" & txtparticular.Tag & "'")
                Call FrmAddShipperConsigneeNotify_Load(e, e)
                Call LoadStrCleint(FrmInitialBooking.cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                Call LoadStrCleint(FrmInitialBooking.cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                Call LoadStrCleint(FrmInitialBooking.cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")


                MsgBox("Saved!", MsgBoxStyle.Information)
                Call btnClear_Click(e, e)
            End If
        End If
    End Sub
    Public Sub SaveClient(ClientName, Clientaddress, TELNO, DateAdded, STAT, AddedBy, EmailAddress)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CLIENT( ClientName, Clientaddress, TELNO, DateAdded, STAT, AddedBy, EmailAddress)"
        SQL = SQL + "VALUES('" & KVal(ClientName) & "',  '" & KVal(Clientaddress) & "',  '" & KVal(TELNO) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "',  '" & KVal(AddedBy) & "' , '" & KVal(EmailAddress) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub txtparticular_TextChanged(sender As Object, e As EventArgs) Handles txtparticular.TextChanged

    End Sub

    Private Sub FrmAddShipperConsigneeNotify_Load(sender As Object, e As EventArgs) Handles MyBase.Load, txtparticular.TextChanged
        With dtList
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT ID, ClientName, Clientaddress, TELNO, EmailAddress FROM TBL_CLIENT WHERE STAT = '1' AND CLIENTNAME LIKE '" & KVal(txtparticular.Text) & "%' AND CLIENTNAME <> '' ORDER BY CLIENTNAME ASC"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Format(CInt(Dbo.reader(0).ToString), "00000"), Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString)
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If e.ColumnIndex = 5 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CLIENT SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Value & "'")
                Call FrmAddShipperConsigneeNotify_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If
        End If
        If e.ColumnIndex = 6 Then
            ModeIs = "EDIT"
            With dtList
                .Enabled = False
                txtparticular.Tag = CInt(.CurrentRow.Cells(0).Value)
                txtparticular.Text = .CurrentRow.Cells(1).Value
                txtAddress.Text = .CurrentRow.Cells(2).Value
                txtTelNo.Text = .CurrentRow.Cells(3).Value
                txtEAddress.Text = .CurrentRow.Cells(4).Value
            End With
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtparticular.Text = ""
        txtAddress.Text = ""
        txtTelNo.Text = ""
        txtEAddress.Text = ""
        ModeIs = "NEW"
        dtList.Enabled = True
    End Sub

    Private Sub FrmAddShipperConsigneeNotify_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class