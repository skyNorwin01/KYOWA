Public Class FrmAddManualContainer
    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click
        With FrmContainerInventoryPerBooking.dtList
            For i As Integer = 0 To .RowCount - 1
                If .Rows(i).Cells(1).Value = KVal(txtcontainerno.Text) Then
                    MsgBox("Already existing!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Next
        End With

        If MsgBox("Are you sure you want to save this container?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call saveRecords(lblSysref.Text, txtcontainerno.Text, cmbSize.Text, LandingForm.ServiceIs)
            Call FrmContainerInventoryPerBooking.LoadList(lblSysref.Text)
            FrmContainerInventoryPerBooking.lblSysref.Text = lblSysref.Text
            txtcontainerno.Text = ""
            Exit Sub
        End If
    End Sub



    Public Sub saveRecords(bookingno As String, CONTAINER_NO As String, containertype As String, TypeOfService As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CONTAINER_INVENTORY (BOOKINGNO,CONTAINER_NO, CONTAINER_TYPE, TypeOfService, AddedBy, DateAdded, Stat, OneWay)"
        SQL = SQL + "VALUES('" & KVal(bookingno) & "', '" & KVal(CONTAINER_NO) & "','" & KVal(containertype) & "', '" & KVal(TypeOfService) & "', '" & USER_ID & "', '" & Now & "', '1', '0')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmAddManualContainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbSize, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE STAT = '1'  ORDER BY   SIZEIS ASC")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class