Public Class FrmGenerateBookingList
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbMVessel.SelectedIndex = -1 Then
            MsgBox("Invalid Mother Vessel!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to generate Booking List?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Dbo As New SQLClass
            Dim objRep As New crBookingList
            Dbo.SqlCon.Open()
            SQL = "spGenerateBookingList;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)
            objRep.SetParameterValue("MV", KVal(cmbMVessel.Text))
            objRep.SetParameterValue("MV_VY", KVal(cmbVoy.Text))
            objRep.SetParameterValue("COLOADER_BK", KVal(txtCoLoaderBk.Text))

            'objRep.Subreports("crMnN").SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()
            With FrmPrintForm
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub

        End If
    End Sub

    Private Sub FrmGenerateBookingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbMVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        'Call LoadStrCmb(cmbVoy, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")


    End Sub
End Class