Public Class FrmRequestForPayment

    Dim iClear As Integer = 0
    Public rfpMode As String = ""
    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click
        If String.IsNullOrEmpty(cmbRFPType.Text) Then
            Me.Dispose()
        End If

        If String.IsNullOrEmpty(cmbRFPSubType.Text) Then
            Me.Dispose()
        End If

        If String.IsNullOrEmpty(lblInfavorID.Text) Then
            MsgBox("Invalid Feeder Vessel!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'If ifExistingFeeder(cmbFeederVessel) = False Then
        '    MsgBox("Invalid Feeder Vessel!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        'If ifExistingVOYAGE(cmbVoyage) = False Then
        '    MsgBox("Invalid voyage!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If


        If ifExistingPolPod(cmbPOL) = False Then
            MsgBox("Invalid POL")
            Exit Sub
        End If

        If ifExistingPolPod(cmbPOD) = False Then
            MsgBox("Invalid POD")
            Exit Sub
        End If



        If String.IsNullOrEmpty(txtErate.Text) Then
            MsgBox("Invalid Erate!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        'If ifExistingFeederCarrier(cmbInFavor) = False Then
        '    MsgBox("Invalid Feeder carrier/ In Favor")
        '    Exit Sub
        'End If





        If ifExistingCharges(cmbCharges) = False Then
            MsgBox("Invalid Charges!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        'If cmbCharges.SelectedIndex = -1 Then
        '    MsgBox("Invalid Charges!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        If CmbSize.SelectedIndex = -1 Then
            MsgBox("Invalid container size!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbUnit.SelectedIndex = -1 Then
            MsgBox("Invalid Unit!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If ifExistingCurrency(cmbCurrency) = False Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'If cmbCurrency.SelectedIndex = -1 Then
        '    MsgBox("Invalid currency!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        If dtList.RowCount > 0 Then
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = False
                End If
            Next cntrl
            dtDueDate.Enabled = False
            txtErate.Enabled = False
            txtInvoiceNo.Enabled = False
            Panel5.Enabled = False
        Else
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = True
                End If
            Next cntrl
            dtDueDate.Enabled = True
            txtErate.Enabled = True
            txtInvoiceNo.Enabled = True
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
            Call SaveRFP(txtSysref.Text, "", Now, dtDueDate.Value, cmbFeederVessel.Text, cmbVoyage.Text, cmbPOL.Text, cmbPOD.Text, cmbInFavor.Text, lblCode.Text, cmbCharges.Text, CmbSize.Text, cmbUnit.Text, SaveMoneyNDec(txtNosUnit.Text, 3), SaveMoneyNDec(txtRate.Text, 3), cmbCurrency.Text, txtErate.Text, USER_ID, Now, "1", CheckTypeIs, cmbRFPType.Text, cmbRFPSubType.Text, txtInvoiceNo.Text, lblInfavorID.Text)
            'Call SaveRFP()
            Call LoadList()

        End If

        If rfpMode = "EDIT" Then
            If MsgBox("Are you sure you want to update this charges?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_REQUEST_FOR_PAYMENT SET STAT = '2' WHERE STAT = '1' AND ID = '" & lblCode.Tag & "'")
                Call SaveRFP(txtSysref.Text, "", Now, dtDueDate.Value, cmbFeederVessel.Text, cmbVoyage.Text, cmbPOL.Text, cmbPOD.Text, cmbInFavor.Text, lblCode.Text, cmbCharges.Text, CmbSize.Text, cmbUnit.Text, SaveMoneyNDec(txtNosUnit.Text, 3), SaveMoneyNDec(txtRate.Text, 3), cmbCurrency.Text, txtErate.Text, USER_ID, Now, "1", CheckTypeIs, cmbRFPType.Text, cmbRFPSubType.Text, txtInvoiceNo.Text, lblInfavorID.Text)
                'Call SaveRFP()
                Call LoadList()
                Call Button1_Click(e, e)
            End If


        End If

    End Sub

    Public Sub LoadList()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, POL, POD, InFavorOf, ChargesId, ChargesName, ContSize, Unit, NosOfUnit, Rate, Currency, ERate, AddedBy, DateAdded, stat, ID, RFP_TYPE, RFP_SUB_TYPE, InFavorOfID FROM TBL_REQUEST_FOR_PAYMENT WHERE STAT = '1' AND SYSREF = '" & txtSysref.Text & "' "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString, Dbo.reader(13).ToString, FormatMoneyN(Dbo.reader(14).ToString), SaveMoneyNDec(Dbo.reader(14).ToString, 3) * SaveMoneyNDec(Dbo.reader(13).ToString, 3), Dbo.reader(15).ToString, Dbo.reader(12).ToString, Dbo.reader(16).ToString, "X", "E")
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(20).ToString

                txtSysref.Text = Dbo.reader(0).ToString
                cmbFeederVessel.Text = Dbo.reader(4).ToString
                cmbVoyage.Text = Dbo.reader(5).ToString
                cmbPOL.Text = Dbo.reader(6).ToString
                cmbPOD.Text = Dbo.reader(7).ToString
                txtErate.Text = Dbo.reader(16).ToString
                dtDueDate.Value = Dbo.reader(3).ToString
                cmbInFavor.Text = Dbo.reader(8).ToString
                lblInfavorID.Text = Dbo.reader(23).ToString
                cmbRFPType.Text = Dbo.reader(21).ToString
                cmbRFPSubType.Text = Dbo.reader(22).ToString

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
            txtInvoiceNo.Enabled = False
            Panel5.Enabled = False
        Else
            For Each cntrl In Panel4.Controls
                If TypeOf cntrl Is ComboBox Then
                    cntrl.Enabled = True
                End If
            Next cntrl
            dtDueDate.Enabled = True
            txtErate.Enabled = True
            txtInvoiceNo.Enabled = True
            Panel5.Enabled = True
        End If

    End Sub

    Public Sub SaveRFP(SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, POL, POD, InFavorOf, ChargesId, ChargesName, ContSize, Unit, NosOfUnit, Rate, Currency, ERate, AddedBy, DateAdded, stat, CheckType, RFP_TYPE, RFP_SUB_TYPE, InvoiceNo, InfavorOfID)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_REQUEST_FOR_PAYMENT( SYSREF, SERIES, DateTrans, DueDate, Feeder, FeederVoyage, POL, POD, InFavorOf, ChargesId, ChargesName, ContSize, Unit, NosOfUnit, Rate, Currency, ERate, AddedBy, DateAdded, stat, CheckType, RFP_TYPE, RFP_SUB_TYPE, InvoiceNo, InfavorOfID)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(SERIES) & "',  '" & KVal(DateTrans) & "',  '" & KVal(DueDate) & "',  '" & KVal(Feeder) & "',  '" & KVal(FeederVoyage) & "',  '" & KVal(POL) & "',  '" & KVal(POD) & "',  '" & KVal(InFavorOf) & "',  '" & KVal(ChargesId) & "',  '" & KVal(ChargesName) & "',  '" & KVal(ContSize) & "',  '" & KVal(Unit) & "',  '" & KVal(NosOfUnit) & "',  '" & KVal(Rate) & "',  '" & KVal(Currency) & "',  '" & KVal(ERate) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(stat) & "', '" & KVal(CheckType) & "','" & KVal(RFP_TYPE) & "',  '" & KVal(RFP_SUB_TYPE) & "', '" & KVal(InvoiceNo) & "', '" & KVal(InfavorOfID) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmRequestForPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbUnit.Items
            .Clear()
            .Add("UNIT")
            '.Add("PER INVOICE")
        End With

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

        cmbUnit.SelectedIndex = 0
        Call LoadStrCmb(cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
        Call LoadStrCmb(CmbSize, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE STAT = '1'  ORDER BY   SIZEIS ASC")
        'Call LoadCmbCharges(cmbCharges, "SELECT ID, CHARGES_NAME, CHARGES_CODE FROM TBL_CHARGES_NAME WHERE STAT = '1' ORDER BY CHARGES_NAME ASC")
        Call LoadCmbCharges(cmbCharges, "SELECT itemListID, itemName, itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' order by  itemName asc")

        Call LoadStrCmb(cmbFeederVessel, "SELECT ID , VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'  ORDER BY   VESSELNAME ASC")
        Call LoadStrCmb(cmbVoyage, "SELECT DISTINCT stat , FVoyage1st FROM TBL_BOOKING WHERE (STAT = '1' or stat = '3')  ORDER BY   FVoyage1st ASC")
        'Call LoadStrCmbPolPod(cmbPOL, cmbPOD, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
        Call LoadStrCmb(cmbPOL, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")
        Call LoadStrCmb(cmbPOD, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'")

        'Call LoadStrCleintAcctg(cmbInFavor, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
        Call LoadStrCleintAcctg(cmbInFavor, "SELECT BPListID,  CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  + ' - ' + CARDCODE as NICKNAME, Address, CardCode FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,3)) LIKE 'V%' OR (SUBSTRING(CARDCODE,1,3)) LIKE 'V%')  AND hideFromExternal = '0'  and accessibleToKyowaSystem = '1'   ORDER BY CARDNAME")


        'Call LoadStrCmb(cmbInFavor, "SELECT  ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1' ORDER BY   FEEDER_CARRIER ASC")
        Call LoadList()


    End Sub


    Private Sub txtNosUnit_TextChanged(sender As Object, e As EventArgs) Handles txtNosUnit.TextChanged
        txtTotalRate.Text = FormatMoneyNDecPLace(SaveMoneyNDec(txtNosUnit.Text, 3) * SaveMoneyNDec(txtRate.Text, 3), 3)
    End Sub

    Private Sub txtRate_LostFocus(sender As Object, e As EventArgs) Handles txtRate.LostFocus
        sender.text = FormatMoneyNDecPLace(sender.text, 3)
    End Sub

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

    Private Sub cmbCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCharges.SelectedIndexChanged

    End Sub

    Private Sub cmbCharges_TextChanged(sender As Object, e As EventArgs) Handles cmbCharges.TextChanged
        'Dim ChargesCode As String = GetRyzk("SELECT CHARGES_CODE FROM TBL_CHARGES_NAME WHERE CHARGES_NAME = '" & KVal(cmbCharges.Text) & "' and STAT = '1'", "L")
        'If ChargesCode = NoRecordFound Then
        '    ChargesCode = ""
        '    lblCode.Text = ""
        'Else
        '    lblCode.Text = ChargesCode
        'End If


        With lblCode
            If sender.SelectedIndex = -1 Then
                .Text = ""
                lblCode.Tag = ""
                Exit Sub
            End If
            .Tag = Format(CInt(CType(sender.SelectedItem, Charges).itemListID), "00000")
            lblCode.Text = CType(sender.SelectedItem, Charges).itemCode
        End With

    End Sub

    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        If e.ColumnIndex = 9 Then
            If MsgBox("Are you sure you want to remove this charges?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
                    txtInvoiceNo.Text = False
                    Panel5.Enabled = False
                Else
                    For Each cntrl In Panel4.Controls
                        If TypeOf cntrl Is ComboBox Then
                            cntrl.Enabled = True
                        End If
                    Next cntrl
                    dtDueDate.Enabled = True
                    txtErate.Enabled = True
                    txtInvoiceNo.Text = True
                    Panel5.Enabled = True
                End If

            End If
        End If
        If e.ColumnIndex = 10 Then
            With dtList.CurrentRow
                cmbCharges.Text = .Cells(1).Value
                CmbSize.Text = .Cells(2).Value
                cmbUnit.Text = .Cells(7).Value
                txtNosUnit.Text = .Cells(3).Value
                txtRate.Text = .Cells(4).Value
                cmbCurrency.Text = .Cells(6).Value
                txtTotalRate.Text = .Cells(5).Value
                lblCode.Tag = .Cells(0).Tag
            End With
            rfpMode = "EDIT"
            btnPrintRfp.Enabled = False
            dtList.Enabled = False
            btnSaveCs.Text = "UPDATE"
            Button1.Text = "CANCEL"
        End If
    End Sub

    Private Sub btnPrintRfp_Click(sender As Object, e As EventArgs) Handles btnPrintRfp.Click
        If MsgBox("Are you sure you want to generate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            'MainSysref = txtSysref.Text
            ''MainBkno = dtList.CurrentRow.Cells(0).Tag
            'Dim DboM As New SQLClass
            'Dim objrepRFP As New crGenerateRfp


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


            'objrepRFP.SetParameterValue("designation", UserDesignationLabel & " In-charge")
            'objrepRFP.SetParameterValue("sysref", MainSysref)
            'objrepRFP.SetParameterValue("User", FNAME & " " & LNAME)





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

            '--------------------------------------------------------------
            MainSysref = txtSysref.Text
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

            objRep.SummaryInfo.ReportTitle = txtInvoiceNo.Text & "-RC"

            With FrmPrintForm

                With .stsID
                    .Items(0).Text = txtSysref.Text
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
            '--------------------------------------------------------------
        End If
    End Sub



    Private Sub txtNosUnit_LostFocus(sender As Object, e As EventArgs) Handles txtNosUnit.LostFocus
        sender.text = FormatMoneyNDecPLace(sender.text, 3)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With FrmMenus.cmsMaintenance
            .Show(sender, 0, 0 - FrmMenus.cmsMaintenance.Height)
        End With
    End Sub

    Private Sub txtErate_TextChanged(sender As Object, e As EventArgs) Handles txtErate.TextChanged

    End Sub

    Private Sub txtErate_LostFocus(sender As Object, e As EventArgs) Handles txtErate.LostFocus
        If Not IsNumeric(sender.text) Then
            sender.text = "1"
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

    Private Sub cmbRFPType_GotFocus(sender As Object, e As EventArgs) Handles cmbRFPType.GotFocus
        cmbRFPType.Items.Clear()
    End Sub

    Private Sub cmbRFPSubType_GotFocus(sender As Object, e As EventArgs) Handles cmbRFPSubType.GotFocus
        cmbRFPSubType.Items.Clear()
    End Sub

    Private Sub cmbRFPType_LostFocus(sender As Object, e As EventArgs) Handles cmbRFPType.LostFocus
        If String.IsNullOrEmpty(cmbRFPType.Text) Then
            Me.Dispose()
        End If
    End Sub

    Private Sub cmbRFPSubType_LostFocus(sender As Object, e As EventArgs) Handles cmbRFPSubType.LostFocus
        If String.IsNullOrEmpty(cmbRFPSubType.Text) Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmRequestForPayment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub cmbInFavor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInFavor.SelectedIndexChanged

    End Sub

    Private Sub cmbInFavor_TextChanged(sender As Object, e As EventArgs) Handles cmbInFavor.TextChanged
        With lblInfavorID
            If sender.SelectedIndex = -1 Then
                .Text = ""
                lblInfavorID.Text = ""
                Exit Sub
            ElseIf sender.text = "" Then
                .Text = ""
                lblInfavorID.Text = ""
                Exit Sub
            End If
            lblInfavorID.Text = CType(sender.SelectedItem, Client).Address
            .Text = CType(sender.SelectedItem, Client).CardCode
            '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
        End With
    End Sub

    Private Sub txtRate_TextChanged(sender As Object, e As EventArgs) Handles txtRate.TextChanged
        txtTotalRate.Text = FormatMoneyNDecPLace(SaveMoneyNDec(txtNosUnit.Text, 3) * SaveMoneyNDec(txtRate.Text, 3), 3)
    End Sub
End Class