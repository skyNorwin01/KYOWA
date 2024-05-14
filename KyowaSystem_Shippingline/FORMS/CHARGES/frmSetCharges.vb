Imports System.ComponentModel

Public Class frmSetCharges

    Dim ModeIs As String = ""

    Private Sub txtDestinationRate_TextChanged(sender As Object, e As EventArgs) Handles txtDestinationRate.TextChanged
        txtPrincipalRate.Text = sender.text
    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged, txtDestinationRate.TextChanged, txtPrincipalRate.TextChanged, txtBillingRate.TextChanged
        If String.IsNullOrEmpty(txtqty.Text) OrElse Not IsNumeric(txtqty.Text) Then
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtDestinationRate.Text) OrElse Not IsNumeric(txtDestinationRate.Text) Then
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtPrincipalRate.Text) OrElse Not IsNumeric(txtPrincipalRate.Text) Then
            Exit Sub
        ElseIf String.IsNullOrEmpty(txtBillingRate.Text) OrElse Not IsNumeric(txtBillingRate.Text) Then
            Exit Sub
        End If

        txtDestinationAmount.Text = Format(FormatMoneyN(CDbl(txtDestinationRate.Text) * CDbl(txtqty.Text)))
        txtPrincipalAmount.Text = Format(FormatMoneyN(CDbl(txtPrincipalRate.Text) * CDbl(txtqty.Text)))
        txtBillingAmount.Text = Format(FormatMoneyN(CDbl(txtBillingRate.Text) * CDbl(txtqty.Text)))
    End Sub
    Public Sub LoadListRatesTemplates()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT C.CHARGES_CODE , C.CHARGES_NAME, R.SIZEIS, CC.Curr, R.qty, R.DestinationRate , r.PrincipalRate, r.BillingRate , LU.NAME, R.Term , r.id, r.erate FROM TBL_CHARGES_TEMPLATE AS R LEFT JOIN TBL_CHARGES_NAME AS C ON R.CHARGES = C.ID LEFT JOIN TBL_CURRENCY AS CC ON R.Currency = CC.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LU ON R.PlaceIs = LU.ID  WHERE R.STAT = '1' AND R.DESTINATION = '" & cmbTrade.Text & "' AND R.PORT  = '" & cmbSubTrade.Text & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, FormatMoney(Dbo.reader(5).ToString), FormatMoney(Dbo.reader(6).ToString), FormatMoney(Dbo.reader(7).ToString), Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(10).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub SaveRecords(SYSREF As String, BLNO As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_RATES (SYSREF, BLNO, SortIs, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, AddedBy, DateAdded, Stat )"
        SQL = SQL + "SELECT SYSREF, 'CNR-" & BLNO & "', SortIs, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, '" & USER_ID & "', '" & Now & "', Stat  FROM TBL_RATES WHERE SYSREF = '" & SYSREF & "' AND  BLNO = '" & BLNO & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadListRates()
        Dim cnrSelBLNo = "", cnrSelBKno As String = ""

        Dim Dbo As New SQLClass
        If FrmBookingList.CorrectionNoticeRevised = "CNR-" Then
            'cnrSelBLNo = "CNR-" & selBLno
            cnrSelBLNo = selBLno
            If GetRyzk("SELECT * FROM TBL_RATES WHERE SYSREF = '" & SelSysref & "' AND BLNO = '" & "CNR-" & selBLno & "' AND STAT = '1'", "") = NoRecordFound Then
                Call SetJob("UPDATE TBL_RATES SET STAT = '2' WHERE STAT = '1' AND SYSREF = '" & SelSysref & "' AND BLNO = '" & "CNR-" & selBLno & "' ")
                Call SaveRecords(SelSysref, selBLno)
            End If

            cnrSelBLNo = "CNR-" & selBLno
            Dbo.SqlCon.Open()
            SQL = "SELECT C.CHARGES_CODE , C.CHARGES_NAME, R.SIZEIS, CC.Curr, R.qty, R.DestinationRate , r.PrincipalRate, r.BillingRate , LU.NAME, R.Term , r.id, r.erate FROM TBL_RATES AS R LEFT JOIN TBL_CHARGES_NAME AS C ON R.CHARGES = C.ID LEFT JOIN TBL_CURRENCY AS CC ON R.Currency = CC.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LU ON R.PlaceIs = LU.ID  WHERE R.STAT = '1' AND R.SYSREF = '" & SelSysref & "' AND R.BLNO  = '" & cnrSelBLNo & "' order by sortis asc"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtList
                .Rows.Clear()
                Do While Dbo.reader.Read
                    .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, FormatMoneyNDecPLace(Dbo.reader(4).ToString, 3), FormatMoney(Dbo.reader(5).ToString), FormatMoney(Dbo.reader(6).ToString), FormatMoney(Dbo.reader(7).ToString), Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString)
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(10).ToString
                Loop
                .Columns(.ColumnCount - 1).DisplayIndex = 0
                .Columns(.ColumnCount - 2).DisplayIndex = 0
                .Columns(.ColumnCount - 3).DisplayIndex = 0
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            For i As Integer = 0 To 4
                dtList.Columns(i).Frozen = True
            Next

            Exit Sub
        End If


        Dbo.SqlCon.Open()
        'SQL = "SELECT C.CHARGES_CODE , C.CHARGES_NAME, R.SIZEIS, CC.Curr, R.qty, R.DestinationRate , r.PrincipalRate, r.BillingRate , LU.NAME, R.Term , r.id, r.erate FROM TBL_RATES AS R LEFT JOIN TBL_CHARGES_NAME AS C ON R.CHARGES = C.ID LEFT JOIN TBL_CURRENCY AS CC ON R.Currency = CC.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LU ON R.PlaceIs = LU.ID  WHERE R.STAT = '1' AND R.SYSREF = '" & SelSysref & "' AND R.BLNO  = '" & selBLno & "' order by sortis asc"
        SQL = "SELECT C.itemcode , C.itemname, R.SIZEIS, CC.Curr, R.qty, R.DestinationRate , r.PrincipalRate, r.BillingRate , LU.NAME, R.Term , r.id, r.erate FROM TBL_RATES AS R LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_ItemListMasterData] AS C ON R.CHARGES = C.itemcode LEFT JOIN TBL_CURRENCY AS CC ON R.Currency = CC.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LU ON R.PlaceIs = LU.ID  WHERE R.STAT = '1' AND R.SYSREF = '" & SelSysref & "' AND R.BLNO  = '" & selBLno & "' order by sortis asc"

        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, FormatMoneyNDecPLace(Dbo.reader(4).ToString, 3), FormatMoney(Dbo.reader(5).ToString), FormatMoney(Dbo.reader(6).ToString), FormatMoney(Dbo.reader(7).ToString), Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(10).ToString
            Loop
            .Columns(.ColumnCount - 1).DisplayIndex = 0
            .Columns(.ColumnCount - 2).DisplayIndex = 0
            .Columns(.ColumnCount - 3).DisplayIndex = 0
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        For i As Integer = 0 To 4
            dtList.Columns(i).Frozen = True
        Next

    End Sub
    Public Sub frmSetCharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'RemoveHandler btnUp.Click, AddressOf btnUp_Click
        'RemoveHandler btnDown.Click, AddressOf btnDown_Click
        btnSaveCs.Text = "ADD"
        cmbCharges.Enabled = True
        txtChargesId.ReadOnly = True
        'With cmbCurrency.Items
        '    .Clear()
        '    .Add("PHP")
        '    .Add("USD")
        'End With

        For i As Integer = 0 To dtList.ColumnCount - 1
            If i = dtList.ColumnCount - 1 Then
                dtList.Columns(i).ReadOnly = False
            Else
                dtList.Columns(i).ReadOnly = True
            End If

        Next

        Call LoadStrCmb(cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
        Call LoadStrCmb(cmbPlace, "SELECT CODEIS , NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY   NAME ASC")
        Call LoadStrCmb(cmbSize, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE STAT = '1'  ORDER BY   SIZEIS ASC")
        Call LoadCmbCharges(cmbCharges, "SELECT itemListID, itemName, itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' order by  itemName asc")
        'Call LoadCmbCharges(cmbCharges, "SELECT ID, CHARGES_NAME, CHARGES_CODE FROM TBL_CHARGES_NAME WHERE STAT = '1' ORDER BY CHARGES_NAME ASC")

        Call LoadStrCmbTrade(cmbTrade, "SELECT ID, NAME  FROM TBL_TRADE WHERE STAT = '1'")
        If FrmMenus.IsForTemplateOnly = "Y" Then
            LoadListRatesTemplates()
            Exit Sub
        End If
        Call LoadListRates()

        Dim PromtMessage As String = ""
        With dtList
            For i As Integer = 0 To .RowCount - 1
                If String.IsNullOrEmpty(.Rows(i).Cells(11).Value) Then
                    PromtMessage = "Y"
                    Exit For
                End If
            Next
        End With
        If PromtMessage = "Y" Then
            MsgBox("Please double check all charges erate!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadForm(FrmAddCurrency, "ADD CURRENCY")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadForm(FrmAddPort, "ADD PLACE")
    End Sub

    Private Sub cmbPlace_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlace.SelectedIndexChanged, cmbPlace.TextChanged
        With txtPlaceCode
            If sender.SelectedIndex = -1 Then
                .Text = ""
                Exit Sub
            End If
            .Text = sender.selectedvalue.ToString
        End With
    End Sub

    Private Sub txtDestinationRate_LostFocus(sender As Object, e As EventArgs) Handles txtDestinationRate.LostFocus, txtPrincipalRate.LostFocus, txtBillingRate.LostFocus
        sender.TEXT = FormatMoney(sender.TEXT)
    End Sub

    Private Sub cmbCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCharges.SelectedIndexChanged, cmbCharges.TextChanged
        With txtChargesId
            If sender.SelectedIndex = -1 Then
                .Text = ""
                txtChargesId.Tag = ""
                Exit Sub
            End If
            .Tag = Format(CInt(CType(sender.SelectedItem, Charges).itemListID), "00000")
            txtChargesId.Text = CType(sender.SelectedItem, Charges).itemCode
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        LoadForm(FrmAddCharges, "ADD CHARGES")
    End Sub

    Private Sub txtqty_LostFocus(sender As Object, e As EventArgs) Handles txtqty.LostFocus
        If String.IsNullOrEmpty(txtqty.Text) OrElse Not IsNumeric(txtqty.Text) Then
            txtqty.Text = "0.00"
        ElseIf String.IsNullOrEmpty(txtDestinationRate.Text) OrElse Not IsNumeric(txtDestinationRate.Text) Then
            txtDestinationRate.Text = "0.00"
        ElseIf String.IsNullOrEmpty(txtPrincipalRate.Text) OrElse Not IsNumeric(txtPrincipalRate.Text) Then
            txtPrincipalRate.Text = "0.00"
        ElseIf String.IsNullOrEmpty(txtBillingRate.Text) OrElse Not IsNumeric(txtBillingRate.Text) Then
            txtBillingRate.Text = "0.00"
        End If

    End Sub


    Public Sub SaveRates(SYSREF, BLNO, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, AddedBy, DateAdded, Stat, erate)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_RATES(SYSREF, BLNO, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, AddedBy, DateAdded, Stat, SortIs, erate)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BLNO) & "',  '" & KVal(CHARGES) & "',  '" & KVal(SIZEIS) & "',  '" & KVal(Currency) & "',  '" & KVal(qty) & "',  '" & KVal(DestinationRate) & "',  '" & KVal(PrincipalRate) & "',  '" & KVal(BillingRate) & "',  '" & KVal(BillingOthers) & "',  '" & KVal(Term) & "',  '" & KVal(PlaceIs) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "','1', '" & KVal(erate) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click
        If String.IsNullOrEmpty(txtERATE.Text) Then
            MsgBox("Invalid erate!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not IsNumeric(txtERATE.Text) Then
            MsgBox("Invalid erate!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        Dim Charges = "", Cur = "", pLACEiS As String = ""
        'Charges = GetRyzk("SELECT ID FROM TBL_CHARGES_NAME WHERE CHARGES_NAME = '" & KVal(cmbCharges.Text) & "'", "L")
        Charges = GetRyzk("SELECT itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' and itemname = '" & KVal(cmbCharges.Text) & "' and itemCode = '" & txtChargesId.Text & "'", "ACCTG")
        If Charges = NoRecordFound Then
            MsgBox("Invalid charges!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbSize.SelectedIndex = -1 Then
            MsgBox("Invalid Volume!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbCurrency.SelectedIndex = -1 Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Cur = GetRyzk("SELECT ID FROM TBL_CURRENCY WHERE CURR = '" & KVal(cmbCurrency.Text) & "'", "L")
        If Cur = NoRecordFound Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Exit Sub

        If ModeIs = "" Then


            'If cmbSize.FindString(cmbSize.Text) < 0 Then
            '    MsgBox("Invalid container size!", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If



            'pLACEiS = GetRyzk("SELECT FORMAT(ID,'00000') FROM TBL_LOADING_UNLOADING_PORT WHERE NAME = '" & KVal(cmbPlace.Text) & "'", "L")
            'If pLACEiS = NoRecordFound Then
            '    MsgBox("Invalid place!", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If

            Dim Term As String = ""
            If rdPrepaid.Checked = True Then
                Term = "P"
            ElseIf rdCollect.Checked = True Then
                Term = "C"
            End If

            'Charges = GetRyzk("SELECT ID FROM TBL_CHARGES_NAME WHERE CHARGES_NAME = '" & KVal(cmbCharges.Text) & "'", "L")
            Charges = GetRyzk("SELECT itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' and itemname = '" & KVal(cmbCharges.Text) & "' and itemCode = '" & txtChargesId.Text & "'", "ACCTG")

            If Charges = NoRecordFound Then
                MsgBox("Invalid charges!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If FrmMenus.IsForTemplateOnly = "Y" Then
                Call SaveTemplateRates(cmbTrade.Text, cmbSubTrade.Text, Charges, cmbSize.Text, Cur, SaveMoneyNDec(txtqty.Text, 3), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
                Call LoadListRatesTemplates()
                Exit Sub
            End If
            If FrmBookingList.CorrectionNoticeRevised = "CNR-" Then
                Call SaveRates(SelSysref, "CNR-" & selBLno, Charges, cmbSize.Text, Cur, SaveMoneyNDec(txtqty.Text, 3), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
                Call LoadListRates()
                btnSaveCs.Text = "ADD"
                Button1.Text = "CLEAR"
                dtList.Enabled = True
                Button1_Click(e, e)
                Exit Sub
            End If
            Call SaveRates(SelSysref, selBLno, Charges, cmbSize.Text, Cur, SaveMoneyNDec(txtqty.Text, 3), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
            Call LoadListRates()
            btnSaveCs.Text = "ADD"
            Button1.Text = "CLEAR"
            dtList.Enabled = True
            Button1_Click(e, e)
        ElseIf ModeIs = "EDIT" Then
            If MsgBox("Are you sure you want to update this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Dim Charges = "", Cur = "", pLACEiS As String = ""
                'Charges = GetRyzk("SELECT ID FROM TBL_CHARGES_NAME WHERE CHARGES_NAME = '" & KVal(cmbCharges.Text) & "'", "L")
                Charges = GetRyzk("SELECT itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' and itemname = '" & KVal(cmbCharges.Text) & "' and itemCode = '" & txtChargesId.Text & "'", "ACCTG")
                If Charges = NoRecordFound Then
                    MsgBox("Invalid charges!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Cur = GetRyzk("SELECT ID FROM TBL_CURRENCY WHERE CURR = '" & KVal(cmbCurrency.Text) & "'", "L")
                If Cur = NoRecordFound Then
                    MsgBox("Invalid currency!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim Term As String = ""
                If rdPrepaid.Checked = True Then
                    Term = "P"
                ElseIf rdCollect.Checked = True Then
                    Term = "C"
                End If


                If FrmBookingList.CorrectionNoticeRevised = "CNR-" Then
                    Call SetJob("UPDATE TBL_RATES SET STAT = '2', DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(10).Value & "'")
                    Call SaveRates(SelSysref, "CNR-" & selBLno, Charges, cmbSize.Text, Cur, SaveMoneyNDec(txtqty.Text, 3), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
                    Call LoadListRates()
                    MsgBox("Saved!", MsgBoxStyle.Information)
                    dtList.Enabled = True
                    pnlEdit.Enabled = True
                    Button1_Click(e, e)
                    Exit Sub
                End If

                Call SetJob("UPDATE TBL_RATES SET STAT = '2', DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(10).Value & "'")
                Call SaveRates(SelSysref, selBLno, Charges, cmbSize.Text, Cur, SaveMoneyNDec(txtqty.Text, 3), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
                Call LoadListRates()
                MsgBox("Saved!", MsgBoxStyle.Information)
                dtList.Enabled = True
                pnlEdit.Enabled = True
                Button1_Click(e, e)
            End If


        End If

    End Sub

    Public Sub SaveTemplateRates(SYSREF, BLNO, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, AddedBy, DateAdded, Stat, erate)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CHARGES_TEMPLATE(DESTINATION, PORT, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, AddedBy, DateAdded, Stat, SortIs, erate)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BLNO) & "',  '" & KVal(CHARGES) & "',  '" & KVal(SIZEIS) & "',  '" & KVal(Currency) & "',  '" & KVal(qty) & "',  '" & KVal(DestinationRate) & "',  '" & KVal(PrincipalRate) & "',  '" & KVal(BillingRate) & "',  '" & KVal(BillingOthers) & "',  '" & KVal(Term) & "',  '" & KVal(PlaceIs) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '1', '" & KVal(erate) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub LoadList()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = ""
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()

            Do While Dbo.reader.Read

            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If ModeIs = "EDIT" Then
        '    pnlEdit.Enabled = True
        '    btnSaveCs.Text = "ADD"
        '    Button1.Text = "CLEAR"
        '    dtList.Enabled = True
        '    ModeIs = ""
        'Else
        For Each c As Control In Panel5.Controls
            If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then
                c.Text = ""
            End If
        Next
        txtBillingAmount.Text = "0.00"
        txtBillingOthers.Text = "0.00"
        txtDestinationAmount.Text = "0.00"
        txtPrincipalAmount.Text = "0.00"
        txtDestinationRate.Text = ""
        txtPrincipalRate.Text = ""
        txtBillingRate.Text = ""
        pnlEdit.Enabled = True
        btnSaveCs.Text = "ADD"
        Button1.Text = "CLEAR"
        dtList.Enabled = True
        cmbCharges.Enabled = True
        txtChargesId.Text = ""
        ModeIs = ""
        'End If

        'If MsgBox("Are you sure you want to close?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Me.Dispose()
        'End If

    End Sub

    Private Sub frmSetCharges_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim PromtMessage As String = ""
        With dtList
            For i As Integer = 0 To .RowCount - 1
                If String.IsNullOrEmpty(.Rows(i).Cells(11).Value) Then
                    PromtMessage = "Y"
                    Exit For
                End If
            Next
        End With
        If PromtMessage = "Y" Then
            MsgBox("Please double check all charges erate!", MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End If


        FrmMenus.IsForTemplateOnly = ""
        Me.Dispose()
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        'MsgBox(dtList.CurrentRow.Cells(0).Tag)
        If e.ColumnIndex = 12 Then
            If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If FrmMenus.IsForTemplateOnly = "Y" Then
                    Call SetJob("UPDATE TBL_CHARGES_TEMPLATE SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                    Call LoadListRatesTemplates()
                    'frmSetCharges_Load(e, e)
                    MsgBox("Deleted!", MsgBoxStyle.Information)
                    Exit Sub
                End If

                Call SetJob("UPDATE TBL_RATES SET STAT = '0' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                frmSetCharges_Load(e, e)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If
        ElseIf e.ColumnIndex = 13 Then

        End If

    End Sub

    Private Sub cmbTrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrade.SelectedIndexChanged

    End Sub

    Private Sub cmbTrade_TextChanged(sender As Object, e As EventArgs) Handles cmbTrade.TextChanged
        Dim cTag As String = ""
        With sender
            If .SelectedIndex < 0 Then
                .Tag = ""
                cTag = ""
            Else
                .Tag = Format(CInt(sender.selectedvalue.ToString), "00000")
                cTag = CInt(sender.tag)
            End If

        End With

        LoadStrCmb(cmbSubTrade, "SELECT ID, NAME FROM TBL_SUB_TRADE_OPTIONS WHERE STAT = '1' AND TRADE_ID = '" & cTag & "'")


        If FrmMenus.IsForTemplateOnly = "Y" Then
            'Call SaveTemplateRates(cmbTrade.Text, cmbSubTrade.Text, Charges, cmbSize.Text, Cur, SaveMoney(txtqty.Text), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1")
            Call LoadListRatesTemplates()
            Exit Sub
        End If
    End Sub

    Private Sub cmbSubTrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubTrade.SelectedIndexChanged

    End Sub

    Private Sub cmbSubTrade_TextChanged(sender As Object, e As EventArgs) Handles cmbSubTrade.TextChanged
        If FrmMenus.IsForTemplateOnly = "Y" Then
            'Call SaveTemplateRates(cmbTrade.Text, cmbSubTrade.Text, Charges, cmbSize.Text, Cur, SaveMoney(txtqty.Text), SaveMoney(txtDestinationRate.Text), SaveMoney(txtPrincipalRate.Text), SaveMoney(txtBillingRate.Text), SaveMoney(txtBillingOthers.Text), Term, pLACEiS, USER_ID, Now, "1")
            Call LoadListRatesTemplates()
            Exit Sub
        End If
    End Sub

    Private Sub btnImportTemplateRates_Click(sender As Object, e As EventArgs) Handles btnImportTemplateRates.Click
        Dim strChargesTemplate As String = ""
        strChargesTemplate = GetRyzk("SELECT * FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination  = '" & FrmBookingList.SelectedTrade & "' AND Port = '" & FrmBookingList.SelectedSubTrade & "' AND SIZEIS = '" & KVal(cmbVolume.Text) & "'", "L")

        If strChargesTemplate = NoRecordFound Then
            MsgBox("No template for this record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to add charges from template?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT Destination, Port, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination  = '" & FrmBookingList.SelectedTrade & "' AND Port = '" & FrmBookingList.SelectedSubTrade & "' AND SIZEIS = '" & KVal(cmbVolume.Text) & "'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                Call SaveRates(SelSysref, selBLno, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString, Dbo.reader(7).ToString, Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString, USER_ID, Now, "1", SaveMoney(txtERATE.Text))
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()


            Call LoadListRates()
            MsgBox("Successfully added!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ItemsSelected As Integer = 0
        For i As Integer = 0 To dtList.RowCount - 1
            If dtList.Rows(i).Cells(14).Value = True Then
                ItemsSelected += 1
            End If
        Next

        'MsgBox(dtList.RowCount - 1)


        If MsgBox("Are you sure you want to delete (" & ItemsSelected & ") charges?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i As Integer = 0 To dtList.RowCount - 1
                If dtList.Rows(i).Cells(14).Value = True Then
                    Call SetJob("UPDATE TBL_RATES SET STAT ='0' , DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE ID = '" & dtList.Rows(i).Cells(10).Value & "' ")
                End If
            Next
            For i As Integer = dtList.RowCount - 1 To 0 Step -1
                If dtList.Rows(i).Cells(14).Value = True Then
                    dtList.Rows.Remove(dtList.Rows(i))

                End If

            Next

        End If

        'For i As Integer = 0 To dtList.RowCount - 1
        '    If dtList.Rows(i).Cells(12).Value = 1 Then
        '        dtList.Rows.Remove(dtList.Rows(i))
        '    End If
        'Next

        'Dim ItemsSelected As Integer = 0

        'With dtList
        '    If .SelectedRows.Count > 1 Then
        '        ItemsSelected = 1
        '    Else
        '        ItemsSelected = 0
        '        'If MsgBox("You have selected 2 or more items. Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        '    Exit Sub
        '        'End If
        '    End If

        '    If MsgBox(IIf(ItemsSelected = 1, "You have selected 2 or more items. ", "") & "Are you sure you want to delete item/s?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        For i As Integer = 0 To dtList.RowCount - 1
        '            If .Rows(i).Selected = True Then
        '                Call SetJob("UPDATE TBL_RATES SET STAT ='0' , DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE ID = '" & .Rows(i).Cells(0).Tag & "' ")
        '            End If
        '        Next
        '        Call LoadListRates()
        '    End If

        'End With

    End Sub

    Private Sub cmbVolume_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVolume.SelectedIndexChanged

    End Sub

    Private Sub cmbVolume_GotFocus(sender As Object, e As EventArgs) Handles cmbVolume.GotFocus
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT SIZEIS FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination = '" & KVal(FrmBookingList.SelectedTrade) & "' AND PORT = '" & KVal(FrmBookingList.SelectedSubTrade) & "' GROUP BY SIZEIS "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbVolume.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With dtList
            cmbCharges.Enabled = False
            cmbCharges.Text = .CurrentRow.Cells(1).Value
            cmbSize.Text = .CurrentRow.Cells(2).Value
            cmbCurrency.Text = .CurrentRow.Cells(3).Value
            txtqty.Text = .CurrentRow.Cells(4).Value
            txtDestinationRate.Text = FormatMoney(.CurrentRow.Cells(5).Value)
            txtPrincipalRate.Text = FormatMoney(.CurrentRow.Cells(6).Value)
            txtBillingRate.Text = FormatMoney(.CurrentRow.Cells(7).Value)
            txtERATE.Text = FormatMoney(.CurrentRow.Cells(11).Value)

            If .CurrentRow.Cells(8).Value = "P" Then
                rdPrepaid.Checked = True
            Else
                rdCollect.Checked = False
            End If
        End With
        dtList.Enabled = False
        ModeIs = "EDIT"
        Button1.Text = "CANCEL"
        btnSaveCs.Text = "SAVE"
        pnlEdit.Enabled = False
    End Sub

    Private Sub cmbSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSize.SelectedIndexChanged

    End Sub

    Private Sub cmbSize_Validating(sender As Object, e As CancelEventArgs) Handles cmbSize.Validating

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        'RemoveHandler dtList.CellClick, AddressOf dtList_CellClick
        RemoveHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged

        Dim RowIndex As Integer = 0
        Dim RR As New DataGridViewRow


        'MsgBox(RR)
        'MsgBox(RR.Cells(0).Value)
        'Exit Sub

        With dtList

            Dim SelRow As Integer = .CurrentRow.Index
            RR = dtSel.CurrentRow


            If SelRow = 0 Then
                AddHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged
                Exit Sub
            End If
            '.CurrentRow.Clone()

            .Rows.Insert(.CurrentRow.Index - 1, RR.Cells(0).Value, RR.Cells(1).Value, RR.Cells(2).Value, RR.Cells(3).Value, RR.Cells(4).Value, RR.Cells(5).Value, RR.Cells(6).Value, RR.Cells(7).Value, RR.Cells(8).Value, RR.Cells(9).Value, RR.Cells(10).Value, RR.Cells(11).Value)


            .Rows.RemoveAt(.CurrentRow.Index)


            .CurrentCell = .Rows(SelRow - 1).Cells(0)


            'RowIndex = .SelectedCells(0).OwningRow.Index
            '.Rows(.CurrentRow.Index).Selected = True

            '.SelectionMode = DataGridViewSelectionMode.CellSelect
        End With
        'CalculateTotal()

        'AddHandler dtList.CellClick, AddressOf dtList_CellClick
        AddHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged
    End Sub

    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        'With dtList
        '    dtSel.Rows.Clear()
        '    dtSel.Rows.Add(.CurrentRow.Cells(0).Value, .CurrentRow.Cells(1).Value, .CurrentRow.Cells(2).Value, .CurrentRow.Cells(3).Value, .CurrentRow.Cells(4).Value, .CurrentRow.Cells(5).Value, .CurrentRow.Cells(6).Value, .CurrentRow.Cells(7).Value, .CurrentRow.Cells(8).Value, .CurrentRow.Cells(9).Value)

        'End With
    End Sub



    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        'RemoveHandler dtList.CellClick, AddressOf dtList_CellClick
        RemoveHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged
        Dim RowIndex As Integer = 0
        Dim RR As New DataGridViewRow
        RR = dtSel.CurrentRow

        'MsgBox(RR)
        'MsgBox(RR.Cells(0).Value)
        'Exit Sub

        With dtList
            Dim SelRow As Integer = .CurrentRow.Index
            If SelRow = .RowCount - 1 Then
                AddHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged
                Exit Sub
            End If


            '.CurrentRow.Clone()

            .Rows.Insert(.CurrentRow.Index + 2, RR.Cells(0).Value, RR.Cells(1).Value, RR.Cells(2).Value, RR.Cells(3).Value, RR.Cells(4).Value, RR.Cells(5).Value, RR.Cells(6).Value, RR.Cells(7).Value, RR.Cells(8).Value, RR.Cells(9).Value, RR.Cells(10).Value, RR.Cells(11).Value)
            .Rows.RemoveAt(.CurrentRow.Index)



            'RowIndex = .SelectedCells(0).OwningRow.Index
            '.Rows(.CurrentRow.Index).Selected = True
            .CurrentCell = .Rows(SelRow + 1).Cells(0)
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
        End With
        'CalculateTotal()
        'AddHandler dtList.CellClick, AddressOf dtList_CellClick
        AddHandler dtList.SelectionChanged, AddressOf dtList_SelectionChanged
    End Sub



    Private Sub dtList_SelectionChanged(sender As Object, e As EventArgs) Handles dtList.SelectionChanged
        With dtList
            dtSel.Rows.Clear()
            dtSel.Rows.Add(.CurrentRow.Cells(0).Value, .CurrentRow.Cells(1).Value, .CurrentRow.Cells(2).Value, .CurrentRow.Cells(3).Value, .CurrentRow.Cells(4).Value, .CurrentRow.Cells(5).Value, .CurrentRow.Cells(6).Value, .CurrentRow.Cells(7).Value, .CurrentRow.Cells(8).Value, .CurrentRow.Cells(9).Value, .CurrentRow.Cells(10).Value, .CurrentRow.Cells(11).Value)

        End With
    End Sub

    Private Sub BTNsAVEoRDER_Click(sender As Object, e As EventArgs) Handles BTNsAVEoRDER.Click
        For i As Integer = 0 To dtList.RowCount - 1
            Call UpdateSort(i, dtList.Rows(i).Cells(10).Value)
        Next

    End Sub

    Public Sub UpdateSort(sortIs As Integer, ids As String)
        Call SetJob("UPDATE TBL_RATES SET SORTIS = '" & sortIs & "' where stat = '1' and id = '" & ids & "'")
    End Sub

    Private Sub frmSetCharges_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


    End Sub

    Private Sub btnER_Click(sender As Object, e As EventArgs) Handles btnER.Click
        If (dtList.Rows.Count > 0) Then
            Dim dr As DialogResult
            dr = MessageBox.Show("Update ER List All ERATE will be automatically updated proceed?", "Kyowa System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (dr = DialogResult.Yes) Then
                For x = 0 To dtList.Rows.Count - 1
                    If String.IsNullOrEmpty(txtERATE.Text) Then
                        MsgBox("Invalid Erate!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If Not IsNumeric(txtERATE.Text) Then
                        MsgBox("Invalid Erate!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    Dim Dbo As New SQLClass
                    Dbo.SqlCon.Open()
                    SQL = "UPDATE TBL_RATES SET ERATE = '" & SaveMoney(txtERATE.Text) & "' where ID = '" & dtList.Rows(x).Cells("Column14").Value & "'"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.ExecuteNonQuery()
                    Dbo.SqlCon.Close()

                    dtList.Rows(x).Cells("Column16").Value = txtERATE.Text
                Next
            End If
        Else
            MessageBox.Show("Please Enter Charges First!", "Kyowa System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class