Public Class FrmRequestForPaymentList
    Private Sub FrmRequestForPaymentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbCategory.Items
            .Clear()
            .Add("ALL")
            .Add("SERIES")
            .Add("FEEDER VESSEL/VOYAGE")
            .Add("IN FAVOR OF")
            .Add("CANCELLED")
            .Add("PENDING")
            .Add("LOCKED")
            .Add("TYPE OF RFP")
            .Add("CARGO TYPE")
            .Add("INVOICE NO")
        End With
        cmbCategory.SelectedIndex = 0



        Call LoadStrCmb(cmbFVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        Call LoadList()
    End Sub

    Public Sub LoadList()

        If cmbCategory.Text = "SERIES" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'')  FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' ) AND SERIES LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "FEEDER VESSEL/VOYAGE" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )  AND Feeder LIKE '%" & KVal(cmbFVessel.Text) & "%' AND FeederVoyage LIKE '%" & KVal(cmbFVoyage.Text) & "%' "
        ElseIf cmbCategory.Text = "IN FAVOR OF" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )  AND InFavorOf LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "CANCELLED" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )  AND STAT = '3'"
        ElseIf cmbCategory.Text = "PENDING" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )  AND STAT = '1' and series = ''"
        ElseIf cmbCategory.Text = "LOCKED" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )  AND ACCTG_VOUCHER_NO <> ''"
        ElseIf cmbCategory.Text = "ALL" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' )"
        ElseIf cmbCategory.Text = "TYPE OF RFP" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' ) AND RFP_TYPE LIKE '%" & KVal(cmbValue.Text) & "%'"
        ElseIf cmbCategory.Text = "CARGO TYPE" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' ) AND RFP_SUB_TYPE LIKE '%" & KVal(cmbValue.Text) & "%'"
        ElseIf cmbCategory.Text = "INVOICE NO" Then
            SQL = "SELECT distinct SYSREF, SERIES,Feeder, FeederVoyage, InFavorOf, ACCTG_VOUCHER_NO, ACCTG_VOUCHER_DATE, ACCTG_USER, RFP_TYPE, RFP_SUB_TYPE, stat,isnull(InvoiceNo,'') FROM TBL_REQUEST_FOR_PAYMENT WHERE (STAT <> '2' AND STAT <> '0' ) AND isnull(InvoiceNo,'') LIKE '%" & KVal(cmbValue.Text) & "%'"

        End If



        Dim StatusIs As String = ""
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read

                If Dbo.reader(1).ToString = "" Then
                    StatusIs = "PENDING"
                Else
                    StatusIs = "SUBMITTED"
                End If

                If Dbo.reader(5).ToString <> "" Then
                    StatusIs = "LOCKED"
                End If

                If Dbo.reader(10).ToString = "3" Then
                    StatusIs = "CANCELLED"
                End If

                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, StatusIs, Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(11).ToString)
                .Rows(.RowCount - 1).Cells(1).Tag = Dbo.reader(11).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
        With dtList
            .Columns(6).DisplayIndex = 2
            .Columns(7).DisplayIndex = 3
            .Columns(8).DisplayIndex = 2
        End With
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not dtList.CurrentRow.Cells(5).Value = "PENDING" Then
            MsgBox("Unable To edit!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        If dtList.CurrentRow.Cells(6).Value = "CHARGES" Then
            FrmRequestForPayment.rfpMode = "ADD"
            If dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
                MsgBox("This rfp Is already submited!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            FrmRequestForPayment.txtSysref.Text = dtList.CurrentRow.Cells(0).Value
            FrmRequestForPayment.txtInvoiceNo.Text = dtList.CurrentRow.Cells(1).Tag
            Call LoadForm(FrmRequestForPayment, "REQUEST For PAYMENT - CHARGES")

        ElseIf dtList.CurrentRow.Cells(6).Value = "STORAGE" Then
            FrmRequestForPaymentStorage.rfpMode = "ADD"
            If dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
                MsgBox("This rfp Is already submited!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            FrmRequestForPaymentStorage.txtSysref.Text = dtList.CurrentRow.Cells(0).Value
            FrmRequestForPayment.txtInvoiceNo.Text = dtList.CurrentRow.Cells(1).Tag
            Call LoadForm(FrmRequestForPaymentStorage, "REQUEST For PAYMENT - STORAGE")

        ElseIf dtList.CurrentRow.Cells(6).Value = "FLATRACK" Then
            FrmRequestForPayment.rfpMode = "ADD"
            If dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
                MsgBox("This rfp Is already submited!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            FrmRequestForPayment.txtSysref.Text = dtList.CurrentRow.Cells(0).Value
            FrmRequestForPayment.txtInvoiceNo.Text = dtList.CurrentRow.Cells(1).Tag
            Call LoadForm(FrmRequestForPayment, "REQUEST For PAYMENT - FLATRACK")

        ElseIf dtList.CurrentRow.Cells(6).Value = "SHUTOUT" Then
            FrmRequestForPaymentStorage.rfpMode = "ADD"
            If dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
                MsgBox("This rfp Is already submited!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            FrmRequestForPaymentStorage.txtSysref.Text = dtList.CurrentRow.Cells(0).Value
            FrmRequestForPayment.txtInvoiceNo.Text = dtList.CurrentRow.Cells(1).Tag
            Call LoadForm(FrmRequestForPaymentStorage, "REQUEST For PAYMENT - SHUTOUT")


        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Not dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
            MsgBox("Unable To edit!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not dtList.CurrentRow.Cells(5).Value = "PENDING" Then
            If MsgBox("Are you sure you want To cancel this request For payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_REQUEST_FOR_PAYMENT Set STAT = '3' , DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(0).Value & "'")
                LoadList()
                MsgBox("Request for payment cancelled!", MsgBoxStyle.Information)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged

    End Sub

    Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
        If cmbCategory.Text = "FEEDER VESSEL/VOYAGE" Then
            pnlAdvanceSearch.Visible = True
        Else
            pnlAdvanceSearch.Visible = False
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadList()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click

        PrintActionMode = ""
        PrintModeIs = ""

        'If dtList.CurrentRow.Cells(0).Value.ToString.Contains("RC-") Then
        MainSysref = dtList.CurrentRow.Cells(0).Value.ToString
        'MainBkno = dtList.CurrentRow.Cells(0).Tag
        Dim Dbo As New SQLClass





        'Dbo.SqlCon.Open()
        'SQL = "sp_GenerateATW;1"
        'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        'Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        'Dbo.SQLCmd.Parameters.Clear()

        'Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        'Dbo.table = New DataTable
        'Dbo.adapter.Fill(Dbo.table)

        'objRep.SetDataSource(Dbo.table)
        'Dbo.SqlCon.Close()
        If dtList.CurrentRow.Cells(6).Value.ToString = "CHARGES" Then
            Dim objRep As New crPrintRFP
            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass

                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(0).SetParameterValue("UserIs", FNAME & " " & LNAME)


                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(1).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(1).SetParameterValue("UserIs", FNAME & " " & LNAME)



            End If
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")
            objRep.SetParameterValue("sysref", MainSysref)
            objRep.SetParameterValue("User", FNAME & " " & LNAME)





            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            'If ContSize = NoRecordFound Then
            '    ContSize = ""
            'End If



            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(0).Value.ToString
                    .Items(1).Text = "RFP"
                    .Items(2).Text = dtList.CurrentRow.Cells(8).Value.ToString
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
        Else
            MainSysref = dtList.CurrentRow.Cells(0).Value.ToString
            'MainBkno = dtList.CurrentRow.Cells(0).Tag

            Dim objRep As New crPrintRFPStorage


            'Dbo.SqlCon.Open()
            'SQL = "sp_GenerateATW;1"
            'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            'Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            'Dbo.SQLCmd.Parameters.Clear()

            'Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            'Dbo.table = New DataTable
            'Dbo.adapter.Fill(Dbo.table)

            'objRep.SetDataSource(Dbo.table)
            'Dbo.SqlCon.Close()

            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass
                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(0).SetParameterValue("UserIs", FNAME & " " & LNAME)


                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(1).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(1).SetParameterValue("UserIs", FNAME & " " & LNAME)



            End If
            objRep.SetParameterValue("sysref", MainSysref)
            objRep.SetParameterValue("User", FNAME & " " & LNAME)
            objRep.SetParameterValue("countIs", dtList.RowCount)




            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            'If ContSize = NoRecordFound Then
            '    ContSize = ""
            'End If

            objRep.SummaryInfo.ReportTitle = dtList.CurrentRow.Cells(8).Value.ToString & "-RS"

            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(0).Value.ToString
                    .Items(1).Text = "RFP-STORAGE"
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
        If CheckInEApproval("SELECT * FROM TBL_REQUEST_E_APPROVAL WHERE BLNO = '" & dtList.CurrentRow.Cells(8).Value & "' AND STAT = '1'") = False Then
            MsgBox("No eapproval found!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        PrintActionMode = ""
        PrintModeIs = "REQUEST_FOR_PAYMENT"



        If MsgBox("Are you sure you want to proceed?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainSysref = dtList.CurrentRow.Cells(0).Value
            'MainBkno = dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New crPrintRFP


            'Dbo.SqlCon.Open()
            'SQL = "sp_GenerateATW;1"
            'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            'Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            'Dbo.SQLCmd.Parameters.Clear()

            'Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            'Dbo.table = New DataTable
            'Dbo.adapter.Fill(Dbo.table)

            'objRep.SetDataSource(Dbo.table)
            'Dbo.SqlCon.Close()

            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass
                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(0).SetParameterValue("UserIs", FNAME & " " & LNAME)


                Dbo2.SqlCon.Open()
                SQL = "spGenerateRFP;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(1).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()
                'objRep.Subreports(1).SetParameterValue("UserIs", FNAME & " " & LNAME)



            End If
            objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")
            objRep.SetParameterValue("sysref", MainSysref)
            objRep.SetParameterValue("User", FNAME & " " & LNAME)





            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            'If ContSize = NoRecordFound Then
            '    ContSize = ""
            'End If



            With FrmPrintForm
                With .stsID
                    .Items(0).Text = dtList.CurrentRow.Cells(0).Value
                    .Items(1).Text = "RFP"
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

    Public Function CheckInEApproval(sql As String) As Boolean
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(sql, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            CheckInEApproval = False
            Do While Dbo.reader.Read
                CheckInEApproval = True
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If dtList.CurrentRow.Cells(5).Value = "CANCELLED" Then
            MsgBox("This request for payment is cancelled", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If dtList.CurrentRow.Cells(5).Value = "SUBMITTED" Then
            MsgBox("This request for payment is already submitted", MsgBoxStyle.Exclamation)
            Exit Sub
        End If


        If MsgBox("Continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            PrintActionMode = "NEW"
            PrintModeIs = "REQUEST_FOR_PAYMENT"

            'If dtList.CurrentRow.Cells(0).Value.ToString.Contains("RC-") Then
            MainSysref = dtList.CurrentRow.Cells(0).Value.ToString
                'MainBkno = dtList.CurrentRow.Cells(0).Tag
                Dim Dbo As New SQLClass
                Dim objRep As New crPrintRFP


                'Dbo.SqlCon.Open()
                'SQL = "sp_GenerateATW;1"
                'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                'Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo.SQLCmd.Parameters.Clear()

                'Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                'Dbo.table = New DataTable
                'Dbo.adapter.Fill(Dbo.table)

                'objRep.SetDataSource(Dbo.table)
                'Dbo.SqlCon.Close()

                If objRep.Subreports.Count > 0 Then
                    Dim Dbo2 As New SQLClass
                    Dbo2.SqlCon.Open()
                    SQL = "spGenerateRFP;1"
                    Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                    Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                    'Dbo2.SQLCmd.Parameters.Clear()
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                    Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                    Dbo2.table2 = New DataTable
                    Dbo2.adapter2.Fill(Dbo2.table2)
                    objRep.Subreports(0).SetDataSource(Dbo2.table2)

                    Dbo2.SqlCon.Close()
                    'objRep.Subreports(0).SetParameterValue("UserIs", FNAME & " " & LNAME)


                    Dbo2.SqlCon.Open()
                    SQL = "spGenerateRFP;1"
                    Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                    Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                    'Dbo2.SQLCmd.Parameters.Clear()
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                    'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                    Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                    Dbo2.table2 = New DataTable
                    Dbo2.adapter2.Fill(Dbo2.table2)
                    objRep.Subreports(1).SetDataSource(Dbo2.table2)

                    Dbo2.SqlCon.Close()
                    'objRep.Subreports(1).SetParameterValue("UserIs", FNAME & " " & LNAME)



                End If
                objRep.SetParameterValue("designation", UserDesignationLabel & " In-charge")
                objRep.SetParameterValue("sysref", MainSysref)
                objRep.SetParameterValue("User", FNAME & " " & LNAME)





                'For i As Integer = 0 To 20
                '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
                'Next
                'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
                'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
                'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

                'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
                'If ContSize = NoRecordFound Then
                '    ContSize = ""
                'End If



                With FrmPrintForm
                    With .stsID
                        .Items(0).Text = dtList.CurrentRow.Cells(0).Value.ToString
                        .Items(1).Text = "RFP"
                        .Items(2).Text = dtList.CurrentRow.Cells(8).Value.ToString
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
                'End If

            End If

    End Sub
End Class