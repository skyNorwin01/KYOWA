Public Class FrmRequestForPaymentCY
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT_CY"
        FrmRequestForPaymentStorage.rfpMode = "ADD"
        FrmRequestForPaymentStorage.cmbRFPType.Text = "CY"
        FrmRequestForPaymentStorage.cmbRFPSubType.Text = "CY"
        FrmRequestForPaymentStorage.txtSysref.Text = "R-CY" & Format(Now, "yyMMddhhmmssff")
        'LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - STORAGE - GENERAL")


        LoadForm(FrmNewRequestForPaymentForCy, "CY RFP")
    End Sub

    Private Sub FrmRequestForPaymentCY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbCategory.Items
            .Clear()
            .Add("REFNO")
            .Add("BSNO")
            .Add("STATUS")
        End With
        cmbCategory.SelectedIndex = 0

        Call btnSearch_Click(e, e)
    End Sub

    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadList()
    End Sub

    Public Sub LoadList()

        If cmbCategory.Text = "REFNO" Then
            SQL = "SELECT DateTrans, refno, bsno, InfavorOf , ParticularIs, AmountIs, PeriodStart, PeriodEnd, Stat, SERIES FROM    TBL_CY_RFP WHERE STAT <> '2' AND REFNO LIKE '%" & KVal(cmbValue.Text) & "%'"
        ElseIf cmbCategory.Text = "BSNO" Then
            SQL = "SELECT DateTrans, refno, bsno, InfavorOf , ParticularIs, AmountIs, PeriodStart, PeriodEnd, Stat, SERIES FROM    TBL_CY_RFP WHERE STAT <> '2' AND BSNO LIKE '%" & KVal(cmbValue.Text) & "%'"
        ElseIf cmbCategory.Text = "STATUS" Then
            Dim StatSearch As String = ""

            SQL = "SELECT DateTrans, refno, bsno, InfavorOf , ParticularIs, AmountIs, PeriodStart, PeriodEnd, Stat, SERIES FROM    TBL_CY_RFP WHERE STAT <> '2' AND STAT LIKE '%" & KVal(cmbValue.Text) & "%'"
        End If


        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()

        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                Dim PeriodIs As String = ""
                If Dbo.reader(6).ToString = Dbo.reader(7).ToString Then
                    PeriodIs = Format(CDate(Dbo.reader(6).ToString), "MMMM-dd-yyyy")
                Else
                    PeriodIs = Format(CDate(Dbo.reader(6).ToString), "MMMM-dd") & "-" & Format(CDate(Dbo.reader(7).ToString), "dd-yyyy")
                End If

                Dim Stats As String = Dbo.reader(8).ToString
                If Dbo.reader(8).ToString = "0" Then
                    Stats = "CANCELLED"
                ElseIf Dbo.reader(8).ToString = "1" Then
                    Stats = "ACTIVE"
                End If
                .Rows.Add(Format(CDate(Dbo.reader(0).ToString), "MM-dd-yyyy"), Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, FormatMoney(Dbo.reader(5).ToString), PeriodIs, Stats, Dbo.reader(9).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure you want to cancel this request for payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_CY_RFP SET STAT = 0 WHERE STAT = '1' AND REFNO = '" & dtList.CurrentRow.Cells(1).Value & "'")
            MsgBox("Cancelled!", MsgBoxStyle.Information)
            Call btnSearch_Click(e, e)
            Exit Sub
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        PrintActionMode = ""
        If MsgBox("Are you sure you want to view this request for payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

            objRep.SetParameterValue("refno", dtList.CurrentRow.Cells(1).Value)
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")

            objRep.SetParameterValue("User", FNAME & " " & LNAME)


            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(1).Value
                    .Items(1).Text = "RFP cy"
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
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dtList.CurrentRow.Cells(dtList.ColumnCount - 2).Value = "CANCELLED" Then
            MsgBox("This request for payment is cancelled", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(dtList.CurrentRow.Cells(dtList.ColumnCount - 1).Value) Then
            MsgBox("This request for payment is already submitted", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT_CY"
        If MsgBox("Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

            objRep.SetParameterValue("refno", dtList.CurrentRow.Cells(1).Value)
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")

            objRep.SetParameterValue("User", FNAME & " " & LNAME)


            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(1).Value
                    .Items(1).Text = "RFP cy"
                    .Items(2).Text = dtList.CurrentRow.Cells(2).Value
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
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PrintActionMode = ""
        PrintModeIs = "REQUEST_FOR_PAYMENT"



        If MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

            objRep.SetParameterValue("refno", dtList.CurrentRow.Cells(1).Value)
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")

            objRep.SetParameterValue("User", FNAME & " " & LNAME)


            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(1).Value
                    .Items(1).Text = "RFP cy"
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
        End If
    End Sub
End Class