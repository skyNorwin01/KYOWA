Public Class FrmGenerateTSReport
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to generate T/S Report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Dbo As New SQLClass
            Dim objRep As New crGenerateTsReport
            Dbo.SqlCon.Open()
            SQL = "sp_GenerateTSReport;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)
            objRep.SetParameterValue("MV", KVal(cmbMVessel.Text))
            objRep.SetParameterValue("MV_VY", KVal(cmbVoy.Text))
            objRep.SetParameterValue("mv_sETA", KVal(dtsETA.Value))
            objRep.SetParameterValue("mv_eETa", KVal(dteETA.Value))
            objRep.SetParameterValue("mv_sETD", KVal(dtsETD.Value))
            objRep.SetParameterValue("mv_eETD", KVal(dteETD.Value))

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

    Private Sub dtsETA_ValueChanged(sender As Object, e As EventArgs) Handles dtsETA.ValueChanged
        dteETA.Value = sender.TEXT
    End Sub

    Private Sub dtsETD_ValueChanged(sender As Object, e As EventArgs) Handles dtsETD.ValueChanged
        dteETD.Value = sender.TEXT
    End Sub

    Private Sub FrmGenerateTSReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbMVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        'Call LoadStrCmb(cmbVoy, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
    End Sub
End Class