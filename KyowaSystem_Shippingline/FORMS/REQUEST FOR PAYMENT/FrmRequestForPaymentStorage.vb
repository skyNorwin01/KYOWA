Public Class FrmRequestForPaymentStorage
    Public rfpMode As String = ""
    Private Sub FrmRequestForPaymentStorage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'With cmbRFPType.Items
        '    .Clear()
        '    .Add("CHARGES")
        '    .Add("STORAGE")
        '    .Add("FLATRACK")
        '    .Add("SHUTOUT")
        'End With

        'With cmbRFPSubType.Items
        '    .Add("GENERAL")
        '    .Add("DANGEROUS")
        'End With

        If cmbRFPType.Text = "SHUTOUT" Then
            lblDays.Text = "NOS. OF UNIT"
        Else
            lblDays.Text = "DAYS"
        End If

        'Call LoadStrCleint(cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE (CLIENTNAME IS NOT NULL AND CLIENTNAME <> '')")
        Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
        Call LoadStrCmb(cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
        Call LoadStrCmb(CmbSize, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE STAT = '1'  ORDER BY   SIZEIS ASC")
        Call LoadStrCmb(cmbFeederVessel, "SELECT ID , VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'  ORDER BY   VESSELNAME ASC")
        Call LoadStrCmb(cmbVoyage, "SELECT DISTINCT stat , FVoyage1st FROM TBL_BOOKING WHERE  (STAT = '1' or stat = '3')  ORDER BY   FVoyage1st ASC")
        Call LoadStrCmb(cmbContainerNo, "SELECT STAT , containerno FROM TBL_CONTAINER WHERE STAT = '1' AND   containerno <> '' ORDER BY   containerno ASC")
        Call LoadStrCmb(cmbInFavor, "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1' ORDER BY   FEEDER_CARRIER ASC")


        With cmbUnit.Items
            .Clear()
            .Add("DAY/S")
            .Add("UNIT")
        End With
        cmbUnit.SelectedIndex = 0
        dtList.Columns(10).DisplayIndex = 6
        dtList.Columns(11).DisplayIndex = 7

        dtList.Columns(7).Visible = False

        Call LoadList()

    End Sub

    Private Sub cmbShipper_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbShipper.SelectedIndexChanged

    End Sub

    Private Sub cmbShipper_TextChanged(sender As Object, e As EventArgs) Handles cmbShipper.TextChanged
        Dim ChargesCode As String = GetRyzk("SELECT ID FROM TBL_CLIENT WHERE ClientName = '" & KVal(cmbShipper.Text) & "' and STAT = '1' AND  (CLIENTNAME IS NOT NULL AND CLIENTNAME <> '')", "L")
        If ChargesCode = NoRecordFound Then
            ChargesCode = ""
            lblCode.Text = ""
        Else
            lblCode.Text = Format(CInt(ChargesCode), "00000")
        End If

    End Sub

    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click
        If String.IsNullOrEmpty(cmbRFPType.Text) Then
            Me.Dispose()
        End If

        If String.IsNullOrEmpty(cmbRFPSubType.Text) Then
            Me.Dispose()
        End If

        If ifExistingFeeder(cmbFeederVessel) = False Then
            MsgBox("Invalid Feeder Vessel!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        'If cmbVoyage.SelectedIndex = -1 Then
        '    MsgBox("Invalid voyage!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        If String.IsNullOrEmpty(cmbInFavor.Text) Then
            MsgBox("Invalid in favor of!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbShipper.SelectedIndex = -1 Then
            MsgBox("Invalid Shipper!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If CmbSize.SelectedIndex = -1 Then
            MsgBox("Invalid container size!", MsgBoxStyle.Critical)
            Exit Sub
        End If



        If String.IsNullOrEmpty(txtDays.Text) Then
            MsgBox("Invalid day/s!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf Not IsNumeric(txtDays.Text) Then
            MsgBox("Invalid day/s!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbUnit.SelectedIndex = -1 Then
            MsgBox("Invalid unit!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbContainerNo.SelectedIndex = -1 Then
            MsgBox("Invalid container no!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbCurrency.SelectedIndex = -1 Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        If dtList.RowCount > 0 Then
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = False
                End If
            Next cntrl
            dtDueDate.Enabled = False
            txtErate.Enabled = False
            Panel5.Enabled = False
        Else
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = True
                End If
            Next cntrl
            dtDueDate.Enabled = True
            txtErate.Enabled = True
            Panel5.Enabled = True
        End If

        'dtList.Rows.Add(cmbCharges.Text, "", "", "", "", "", "", "X")
        Dim CheckTypeIs As String = ""
        If rdCheck.Checked = True Then
            CheckTypeIs = "CHECK"
        Else
            CheckTypeIs = "MANAGERS CHECK"
        End If





        If rfpMode = "ADD" Then
            Call SaveRFPStorage(txtSysref.Text, "", Now, dtDueDate.Value, cmbFeederVessel.Text, cmbVoyage.Text, cmbInFavor.Text, lblCode.Text, cmbShipper.Text, CmbSize.Text, cmbContainerNo.Text, cmbUnit.Text, txtDays.Text, SaveMoney(txtAmount.Text), SaveMoney(txtTotalAmount.Text), cmbCurrency.Text, txtErate.Text, CheckTypeIs, USER_ID, Now, "1", cmbRFPType.Text, cmbRFPSubType.Text, txtInvoiceNo.Text)

            Call LoadList()
        End If

        If rfpMode = "EDIT" Then
            If MsgBox("Are you sure you want to update this charges?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_REQUEST_FOR_PAYMENT SET STAT = '2' WHERE STAT = '1' AND ID = '" & lblCode.Tag & "'")
                Call SaveRFPStorage(txtSysref.Text, "", Now, dtDueDate.Value, cmbFeederVessel.Text, cmbVoyage.Text, cmbInFavor.Text, lblCode.Text, cmbShipper.Text, CmbSize.Text, cmbContainerNo.Text, cmbUnit.Text, SaveMoney(txtDays.Text), SaveMoney(txtAmount.Text), SaveMoney(txtTotalAmount.Text), cmbCurrency.Text, txtErate.Text, CheckTypeIs, USER_ID, Now, "1", cmbRFPType.Text, cmbRFPSubType.Text, txtInvoiceNo.Text)
                'Call SaveRFP()
                Call LoadList()
                Call Button1_Click(e, e)
            End If


        End If

    End Sub

    Public Sub SaveRFPStorage(SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, InFavorOf, S_SHIPPER_ID, S_SHIPPER, ContSize, S_CONTAINER_NO, Unit, S_DAYS, S_AMOUNT, S_TOTAL_AMOUNT, Currency, ERate, CheckType, AddedBy, DateAdded, Stat, RFP_TYPE, RFP_SUB_TYPE, InvoiceNo)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_REQUEST_FOR_PAYMENT(SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, InFavorOf, S_SHIPPER_ID , S_SHIPPER, ContSize, S_CONTAINER_NO, Unit, S_DAYS, S_AMOUNT, S_TOTAL_AMOUNT, Currency, ERate, CheckType,  AddedBy, DateAdded, Stat, RFP_TYPE, RFP_SUB_TYPE, InvoiceNo)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(SERIES) & "',  '" & KVal(DateTrans) & "',  '" & KVal(DueDate) & "',  '" & KVal(Feeder) & "',  '" & KVal(FeederVoyage) & "',  '" & KVal(InFavorOf) & "', '" & KVal(S_SHIPPER_ID) & "' ,  '" & KVal(S_SHIPPER) & "',  '" & KVal(ContSize) & "',  '" & KVal(S_CONTAINER_NO) & "',  '" & KVal(Unit) & "',  '" & KVal(S_DAYS) & "',  '" & KVal(S_AMOUNT) & "',  '" & KVal(S_TOTAL_AMOUNT) & "',  '" & KVal(Currency) & "',  '" & KVal(ERate) & "',  '" & KVal(CheckType) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "','" & KVal(RFP_TYPE) & "',  '" & KVal(RFP_SUB_TYPE) & "', '" & KVal(InvoiceNo) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadList()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, InFavorOf, S_SHIPPER_ID, S_SHIPPER, ContSize, S_CONTAINER_NO, Unit, S_DAYS, S_AMOUNT, S_TOTAL_AMOUNT, Currency, ERate, CheckType, AddedBy, DateAdded, Stat, ID, RFP_TYPE, RFP_SUB_TYPE FROM TBL_REQUEST_FOR_PAYMENT WHERE STAT = '1' AND SYSREF = '" & txtSysref.Text & "'  "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(7).ToString, Dbo.reader(8).ToString, Dbo.reader(10).ToString, Dbo.reader(9).ToString, SaveMoney(Dbo.reader(13).ToString), SaveMoney(Dbo.reader(14).ToString), Dbo.reader(15).ToString, Dbo.reader(16).ToString, "X", "E", Dbo.reader(12).ToString, Dbo.reader(11).ToString)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(21).ToString

                txtSysref.Text = Dbo.reader(0).ToString
                cmbFeederVessel.Text = Dbo.reader(4).ToString
                cmbVoyage.Text = Dbo.reader(5).ToString
                txtErate.Text = Dbo.reader(16).ToString
                dtDueDate.Value = Dbo.reader(3).ToString
                cmbInFavor.Text = Dbo.reader(6).ToString

                cmbRFPType.Text = Dbo.reader(22).ToString
                cmbRFPSubType.Text = Dbo.reader(23).ToString

            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        If dtList.RowCount > 0 Then
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = False
                End If
            Next cntrl
            dtDueDate.Enabled = False
            txtErate.Enabled = False
            Panel5.Enabled = False
        Else
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = True
                End If
            Next cntrl
            dtDueDate.Enabled = True
            txtErate.Enabled = True
            Panel5.Enabled = True
        End If

    End Sub
    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtAmount_LostFocus(sender As Object, e As EventArgs) Handles txtAmount.LostFocus
        sender.text = FormatMoney(sender.text)
    End Sub

    Private Sub txtTotalAmount_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAmount.TextChanged

    End Sub

    Private Sub txtTotalAmount_LostFocus(sender As Object, e As EventArgs) Handles txtTotalAmount.LostFocus
        sender.text = FormatMoney(sender.text)
    End Sub
    Dim iClear As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If dtList.RowCount > -1 Then
        '    For Each cntrl In Panel4.Controls
        '        If TypeOf cntrl Is ComboBox Then
        '            cntrl.Enabled = False
        '        End If
        '    Next cntrl
        'End If

        'dtList.Rows.Add()
        'Exit Sub
        If dtList.RowCount = 0 Then
            If iClear > 1 Then
                For Each ctl In Panel4.Controls
                    If TypeOf ctl Is TextBox Then ctl.Text = ""
                Next ctl
                For Each ctl In Panel4.Controls
                    If TypeOf ctl Is ComboBox Then ctl.Text = ""
                Next ctl
                iClear = 0
                Exit Sub
            End If
        End If


        iClear = iClear + 1

        For Each ctl In Panel2.Controls
            If TypeOf ctl Is TextBox Then ctl.Text = ""
        Next ctl
        For Each ctl In Panel2.Controls
            If TypeOf ctl Is ComboBox Then ctl.Text = ""
        Next ctl

        dtList.Enabled = True
        rfpMode = "ADD"
        btnPrintRfp.Enabled = True
        btnSaveCs.Text = "ADD"
        Button1.Text = "CLEAR"


    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub btnPrintRfp_Click(sender As Object, e As EventArgs) Handles btnPrintRfp.Click
        If MsgBox("Are you sure you want to generate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            'MainSysref = txtSysref.Text
            ''MainBkno = dtList.CurrentRow.Cells(0).Tag
            'Dim DboM As New SQLClass
            'Dim objrepRFP As New crGenerateRFPStorage


            'DboM.SqlCon.Open()
            'SQL = "spGenerateRFP;1"
            'DboM.SQLCmd = New SqlClient.SqlCommand(SQL, DboM.SqlCon)
            'DboM.SQLCmd.CommandType = CommandType.StoredProcedure
            'DboM.SQLCmd.Parameters.Clear()
            ''DboM.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
            ''DboM.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
            ''DboM.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
            'DboM.adapter2 = New SqlClient.SqlDataAdapter(DboM.SQLCmd)
            'DboM.table2 = New DataTable
            'DboM.adapter2.Fill(DboM.table2)
            'objrepRFP.SetDataSource(DboM.table2)

            'DboM.SqlCon.Close()
            ''objrepRFP.Subreports(0).SetParameterValue("UserIs", FNAME & " " & LNAME)


            ''objrepRFP.SetParameterValue("designation", UserDesignationLabel & " In-charge")
            ''objrepRFP.SetParameterValue("sysref", MainSysref)
            ''objrepRFP.SetParameterValue("User", FNAME & " " & LNAME)





            ''For i As Integer = 0 To 20
            ''    MsgBox(i & " / " & objrepRFP.DataDefinition.FormulaFields(i).Text.ToString)
            ''Next
            ''TotalAmountIs = objrepRFP.DataDefinition.FormulaFields(3).Text.ToString
            ''TotalAmountIs = objrepRFP.DataDefinition.FormulaFields.Item(3).Text
            ''MsgBox(objrepRFP.DataDefinition.FormulaFields.Item(3).)

            ''Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            ''If ContSize = NoRecordFound Then
            ''    ContSize = ""
            ''End If

            'objrepRFP.SummaryInfo.ReportTitle = txtInvoiceNo.Text & "-RC"

            'With FrmPrintForm

            '    With .stsID
            '        .Items(0).Text = txtSysref.Text
            '        .Items(1).Text = "RFP"
            '    End With

            '    'objrepRFP.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
            '    Dim formats As Integer
            '    formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
            '    .crViewer.EnableDrillDown = False
            '    .crViewer.AllowedExportFormats = formats
            '    '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
            '    .crViewer.ReportSource = objrepRFP
            '    .crViewer.Refresh()
            '    .crViewer.ShowPrintButton = True
            '    .crViewer.Zoom(150)
            '    .WindowState = FormWindowState.Maximized
            '    .ShowDialog()
            'End With





            'Exit Sub





























            'Exit Sub
            MainSysref = txtSysref.Text
            'MainBkno = dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
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

            objRep.SummaryInfo.ReportTitle = txtInvoiceNo.Text & "-RS"

            With FrmPrintForm
                With .stsID
                    .Items(0).Text = txtSysref.Text
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

    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        If e.ColumnIndex = 8 Then
            If MsgBox("Are you sure you want to remove this shipper?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SetJob("UPDATE TBL_REQUEST_FOR_PAYMENT SET STAT = '0' WHERE ID = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                dtList.Rows.Remove(dtList.CurrentRow)
                If dtList.RowCount > 0 Then
                    For Each cntrl In Panel4.Controls
                        If TypeOf cntrl Is ComboBox Then
                            cntrl.Enabled = False
                        End If
                    Next cntrl
                    dtDueDate.Enabled = False
                    txtErate.Enabled = False
                    Panel5.Enabled = False
                Else
                    For Each cntrl In Panel4.Controls
                        If TypeOf cntrl Is ComboBox Then
                            cntrl.Enabled = True
                        End If
                    Next cntrl
                    dtDueDate.Enabled = True
                    txtErate.Enabled = True
                    Panel5.Enabled = True
                End If

            End If
        End If

        If e.ColumnIndex = 9 Then
            With dtList.CurrentRow
                cmbShipper.Text = .Cells(1).Value
                cmbContainerNo.Text = .Cells(2).Value
                CmbSize.Text = .Cells(3).Value
                txtDays.Text = .Cells(10).Value
                cmbUnit.Text = .Cells(11).Value

                cmbCurrency.Text = .Cells(6).Value
                txtAmount.Text = .Cells(4).Value
                txtTotalAmount.Text = .Cells(5).Value
                lblCode.Tag = .Cells(0).Tag
            End With
            rfpMode = "EDIT"
            btnPrintRfp.Enabled = False
            dtList.Enabled = False
            btnSaveCs.Text = "UPDATE"
            Button1.Text = "CANCEL"
        End If
    End Sub

    Private Sub cmbRFPType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFPType.SelectedIndexChanged

    End Sub

    Private Sub cmbRFPType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRFPType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRFPSubType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRFPSubType.SelectedIndexChanged

    End Sub

    Private Sub cmbRFPSubType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRFPSubType.KeyPress
        e.Handled = True
    End Sub

    Private Sub cmbRFPSubType_LostFocus(sender As Object, e As EventArgs) Handles cmbRFPSubType.LostFocus
        If String.IsNullOrEmpty(cmbRFPSubType.Text) Then
            Me.Dispose()
        End If

    End Sub

    Private Sub cmbRFPType_LostFocus(sender As Object, e As EventArgs) Handles cmbRFPType.LostFocus
        If String.IsNullOrEmpty(cmbRFPType.Text) Then
            Me.Dispose()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With FrmMenus.cmsMaintenance
            .Show(sender, 0, 0 - FrmMenus.cmsMaintenance.Height)
        End With
    End Sub

    Private Sub FrmRequestForPaymentStorage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub cmbInFavor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInFavor.SelectedIndexChanged

    End Sub
End Class