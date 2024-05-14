Public Class FrmNewRequestForPaymentForCy
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not GetRyzk("SELECT refno FROM TBL_CY_RFP WHERE refno = '" & KVal(txtRefno.Text) & "'", "") = NoRecordFound Then
            MsgBox("Existing Reference No.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_CY_RFP SET STAT = '2' WHERE STAT = '1' AND REFNO = '" & KVal(txtRefno.Text) & "'")
            Call SaveCyRfp(dtDate.Value, cmbTo.Text, cmbFrom.Text, cmbCheck.Text, cmbInfavorOf.Text, SaveMoney(txtAmount.Text), cmbParticular.Text, dtPeriod1.Value, dtPeriod2.Value, txtBsno.Text, txtRefno.Text, Now, USER_ID, "1", dtDueOn.Value)

            FrmRequestForPaymentCY.btnSearch_Click(e, e)

            Dim Dbo As New SQLClass
            Dim objRep As New crCyRfp


            Dbo.SqlCon.Open()
            SQL = "spGenerateRfpCy;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()

            objRep.SetParameterValue("refno", txtRefno.Text)
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")

            objRep.SetParameterValue("User", FNAME & " " & LNAME)

            objRep.SummaryInfo.ReportTitle = txtRefno.Text & "_" & txtBsno.Text & "-CY"

            With FrmPrintForm
                With .stsID
                    .Items(0).Text = txtRefno.Text
                    .Items(1).Text = "RFP cy"
                    .Items(2).Text = txtBsno.Text
                End With

                'objRep.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
                .crViewer.EnableDrillDown = False
                .crViewer.AllowedExportFormats = formats
                '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

            'Me.Dispose()
        End If
    End Sub

    Public Sub SaveCyRfp(DateTrans, ToIs, FromIs, CheckIs, InfavorOf, AmountIs, ParticularIs, PeriodStart, PeriodEnd, bsno, refno, DateAdded, AddedBy, Stat, DueOn)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CY_RFP(DateTrans, ToIs, FromIs, CheckIs, InfavorOf, AmountIs, ParticularIs, PeriodStart, PeriodEnd, bsno, refno, DateAdded, AddedBy, Stat, DueOn)"
        SQL = SQL + "VALUES('" & KVal(DateTrans) & "',  '" & KVal(ToIs) & "',  '" & KVal(FromIs) & "',  '" & KVal(CheckIs) & "',  '" & KVal(InfavorOf) & "',  '" & KVal(AmountIs) & "',  '" & KVal(ParticularIs) & "',  '" & KVal(PeriodStart) & "',  '" & KVal(PeriodEnd) & "',  '" & KVal(bsno) & "',  '" & KVal(refno) & "',  '" & KVal(DateAdded) & "',  '" & KVal(AddedBy) & "',  '" & KVal(Stat) & "', '" & KVal(DueOn) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmNewRequestForPaymentForCy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbParticular.Items
            .Clear()
            .Add("REPAIR AND CLEANING SERVICES")
            .Add("CONTAINER STORAGE, LIFT ON-LIFT OF CHARGES")
        End With

        With cmbInfavorOf.Items
            .Clear()
            .Add("TBS CONTAINER YARD OPC")
        End With

        With cmbCheck.Items
            .Clear()
            .Add("CHECK")
            .Add("MANAGER'S CHECK")
        End With


    End Sub

    Private Sub cmbFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFrom.SelectedIndexChanged

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtAmount_LostFocus(sender As Object, e As EventArgs) Handles txtAmount.LostFocus
        txtAmount.Text = FormatMoney(txtAmount.Text)
    End Sub
End Class