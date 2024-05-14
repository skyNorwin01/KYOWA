Public Class FrmOnhireUnitEditRow
    Dim ItemId As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'Call LoadStrCmb(FrmOnhireUnitEditRow.cmbCy, "SELECT DISTINCT CYNAME,  CYNAME FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")
        'Call LoadStrCmb(FrmOnhireUnitEditRow.cmbOnHireUnits, "SELECT DISTINCT onhire_company, onhire_company  FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")
        'Call LoadStrCmb(FrmOnhireUnitEditRow.cmbShipper, "SELECT DISTINCT clientname, clientname  FROM TBL_CLIENT WHERE STAT = '1'")
        'Call LoadDepot(FrmOnhireUnitEditRow.cmbCy, "SELECT NAME, NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, Telno FROM TBL_DEPOT WHERE STAT = '1'")

        Dim xssql As String = "SELECT   NAME FROM TBL_DEPOT WHERE STAT = '1' AND name = '" & KVal(cmbCy.Text) & "'"

        If GetRyzk("SELECT   NAME FROM TBL_DEPOT WHERE STAT = '1' AND name = '" & KVal(cmbCy.Text) & "'", "") = NoRecordFound Then
            MsgBox("Invalid CY!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetRyzk("SELECT clientname  FROM TBL_CLIENT WHERE STAT = '1' AND clientname = '" & KVal(cmbShipper.Text) & "'", "") = NoRecordFound Then
            MsgBox("Invalid Shipper!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbSize.Items.Contains(cmbSize.Text) = False Then
            MsgBox("Invalid Size!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If mTxtValidity.Text = "  /  /       :" Then
            MsgBox("Invalid Validity date!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'If mTxtValidity.ValidatingType = GetType(System.DateTime) = False Then

        'End If


        'Exit Sub


        'Exit Sub
        If FrmOnhireUnits.ModeIs = "NEW" Then
            Call SaveRecord(txtBookingNo.Text, cmbCy.Text, cmbOnHireUnits.Text, mtxtContainer.Text, mTxtValidity.Text, cmbShipper.Text, cmbSize.Text, txtLctOfFV.Text, txtContainer.Text, mTxtPullout.Text, USER_ID, Now, "1")
            'MsgBox(ItemId)
            FrmOnhireUnits.dtList.Rows.Add(KVal(cmbCy.Text), KVal(cmbOnHireUnits.Text), KVal(mtxtContainer.Text), KVal(txtBookingNo.Text), KVal(mTxtValidity.Text), KVal(cmbShipper.Text), KVal(cmbSize.Text), KVal(txtLctOfFV.Text), KVal(txtContainer.Text), KVal(mTxtPullout.Text))
            FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.dtList.RowCount - 2).Cells(0).Tag = ItemId
            MsgBox("Saved!", MsgBoxStyle.Information)

        End If
        If FrmOnhireUnits.ModeIs = "EDIT" Then
            Call SetJob("UPDATE TBL_ONHIRE_UNITS SET STAT = '2', ModifiedBy = '" & USER_ID & "', DateModified = '" & Now & "' WHERE STAT = '1' AND ID = '" & FrmOnhireUnits.dtList.CurrentRow.Cells(0).Tag & "'")

            Call SaveRecord(txtBookingNo.Text, cmbCy.Text, cmbOnHireUnits.Text, mtxtContainer.Text, mTxtValidity.Text, cmbShipper.Text, cmbSize.Text, txtLctOfFV.Text, txtContainer.Text, mTxtPullout.Text, USER_ID, Now, "1")
            'MsgBox(ItemId)
            FrmOnhireUnits.dtList.Rows.Insert(FrmOnhireUnits.dtList.CurrentRow.Index, KVal(cmbCy.Text), KVal(cmbOnHireUnits.Text), KVal(mtxtContainer.Text), KVal(txtBookingNo.Text), KVal(mTxtValidity.Text), KVal(cmbShipper.Text), KVal(cmbSize.Text), KVal(txtLctOfFV.Text), KVal(txtContainer.Text), KVal(mTxtPullout.Text))
            FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.dtList.CurrentRow.Index - 1).Cells(0).Tag = ItemId
            'FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.dtList.CurrentRow.Index - 1).Selected = True


            FrmOnhireUnits.dtList.Rows.RemoveAt(FrmOnhireUnits.dtList.CurrentRow.Index)
            'FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.dtList.CurrentRow.Index).Selected = False
            'FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.dtList.CurrentRow.Index - 1).Selected = True
            FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.selItemRow).Selected = True
            FrmOnhireUnits.dtList.CurrentCell = FrmOnhireUnits.dtList.Rows(FrmOnhireUnits.selItemRow).Cells(0)

            MsgBox("Saved!", MsgBoxStyle.Information)

        End If
    End Sub
    Public Sub SaveRecord(BKNO, cyname, onhire_company, NosOfContainer, validity_date, Shipper, Size, LCT, ContainerNo, PulloutDate, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_ONHIRE_UNITS(BKNO, cyname, onhire_company, NosOfContainer, validity_date, Shipper, Size, LCT, ContainerNo, PulloutDate, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(BKNO) & "',  '" & KVal(cyname) & "',  '" & KVal(onhire_company) & "',  '" & KVal(NosOfContainer) & "',  '" & KVal(validity_date) & "',  '" & KVal(Shipper) & "',  '" & KVal(Size) & "',  '" & KVal(LCT) & "',  '" & KVal(ContainerNo) & "',  '" & KVal(PulloutDate) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "'); SELECT SCOPE_IDENTITY()"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        'Dbo.SQLCmd.ExecuteNonQuery()
        ItemId = Dbo.SQLCmd.ExecuteScalar()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub FrmOnhireUnitEditRow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmOnhireUnits.ModeIs = ""
    End Sub

    Private Sub FrmOnhireUnitEditRow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mTxtValidity.ValidatingType = GetType(System.DateTime)
        With cmbSize.Items
            .Clear()
            .Add("10DC")
            .Add("20DC")
            .Add("40DC")
            .Add("40HQ")
            .Add("20RF")
            .Add("40RF")
            .Add("CBM")
            .Add("KGS")
        End With


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmbCy.Text = ""
        cmbOnHireUnits.Text = ""
        mtxtContainer.Text = ""
        txtBookingNo.Text = ""
        mTxtValidity.Text = ""
        cmbShipper.Text = ""
        cmbSize.Text = ""
        txtLctOfFV.Text = ""
        txtContainer.Text = ""
        mTxtPullout.Text = ""
        Me.Hide()
    End Sub

    Private Sub mTxtValidity_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mTxtValidity.MaskInputRejected

    End Sub

    Private Sub mTxtValidity_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles mTxtValidity.TypeValidationCompleted
        If e.IsValidInput = False Then
            MsgBox("Invalid Validity date!", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub
End Class