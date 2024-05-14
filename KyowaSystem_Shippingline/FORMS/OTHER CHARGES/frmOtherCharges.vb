Public Class frmOtherCharges
    Private Sub frmOtherCharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtStorage_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtStorage.CellContentClick

    End Sub

    Private Sub dtStorage_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtStorage.CellEndEdit
        With sender
            If String.IsNullOrEmpty(.CurrentRow.Cells(6).Value) Then
                .CurrentRow.Cells(8).Value = ""
                Exit Sub
            End If
            If String.IsNullOrEmpty(.CurrentRow.Cells(7).Value) Then
                .CurrentRow.Cells(7).Value = .CurrentRow.Cells(6).Value
            End If
            If String.IsNullOrEmpty(.CurrentRow.Cells(7).Value) Then
                .CurrentRow.Cells(8).Value = ""
                Exit Sub
            End If

            If Not IsDate(.CurrentRow.Cells(6).Value) Then
                .CurrentRow.Cells(8).Value = ""
                Exit Sub
            End If
            If Not IsDate(.CurrentRow.Cells(7).Value) Then
                .CurrentRow.Cells(8).Value = ""
                Exit Sub
            End If
            .CurrentRow.Cells(8).Value = Val(DateDiff(DateInterval.Day, .CurrentRow.Cells(6).Value, (.CurrentRow.Cells(7).Value)) + 1)


            'If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Or e.ColumnIndex = 4 Then
            '    CalculatePerDay()
            'End If
            'Call CalcGrandTotal()
        End With

    End Sub

    Public Sub CalculatePerDay()
        With dtStorage
            'Dim str As String = ""
            'If String.IsNullOrEmpty(.CurrentRow.Cells(3).Value) Then
            '    str = " 0.00"
            'Else
            '    str = .CurrentRow.Cells(3).Value
            'End If


            'Dim StrVal() As String
            'StrVal = str.Split(" ")

            'Dim ColRate = 0.00, ColErate As Double = 0.00
            'If Not IsNumeric(StrVal(1)) Then
            '    ColRate = 0.00
            'Else
            '    ColRate = StrVal(1)
            'End If
            'If Not IsNumeric(txtER.Text) Then
            '    ColErate = 0.00
            'Else
            '    ColErate = txtER.Text
            'End If
            '.CurrentRow.Cells(7).Value = "PHP " & FormatMoney(Val(ColRate) * Val(ColErate))
            '.CurrentRow.Cells(9).Value = "PHP " & FormatMoney((Val(ColRate) * Val(ColErate)) * .CurrentRow.Cells(8).Value)
            '.CurrentRow.Cells(10).Value = "1"
            '.CurrentRow.Cells(11).Value = "PHP"
            '.CurrentRow.Cells(12).Value = FormatMoney((Val(ColRate) * Val(ColErate)) * .CurrentRow.Cells(8).Value)

        End With

    End Sub

    Private Sub dtStorage_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtStorage.CellClick
        If e.ColumnIndex = 9 Then
            If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_OTHER_CHARGES SET STAT = '2' WHERE STAT = '1' AND BLNO = '" & txtBLNo.Text & "' AND containerNo = '" & dtStorage.CurrentRow.Cells(1).Value & "' AND CHARGESNAME = 'STORAGE CHARGES'")
                Call Save("", "STORAGE CHARGES", txtRefno.Text, txtBKNo.Text, txtBLNo.Text, txtShipper.Tag, cmbFeederVessel.Tag, cmbMotherVessel.Tag, dtStorage.CurrentRow.Cells(1).Value, dtStorage.CurrentRow.Cells(2).Value, dtStorage.CurrentRow.Cells(5).Value, dtStorage.CurrentRow.Cells(6).Value, dtStorage.CurrentRow.Cells(7).Value, dtStorage.CurrentRow.Cells(8).Value, SaveMoney(dtStorage.CurrentRow.Cells(3).Value), SaveMoney(txtER.Text), Now, USER_ID, "1", dtStorage.CurrentRow.Cells(4).Value, txtFeederVesselVoyage.Text, txtMotherVesselVoyage.Text, FrmBookingList.dtList.CurrentRow.Cells(3).Value, FrmBookingList.dtList.CurrentRow.Cells(6).Value, FrmBookingList.dtList.CurrentRow.Cells(12).Value, FrmBookingList.dtList.CurrentRow.Cells(4).Tag)
                Call FrmBookingList.lOADContainersforOtherCharges(FrmBookingList.dtList.CurrentRow.Cells(1).Tag, FrmBookingList.dtList.CurrentRow.Cells(0).Tag, "1", FrmBookingList.dtList.CurrentRow.Cells(24).Value, FrmBookingList.dtList.CurrentRow.Cells(25).Value, dtStorage, "S")
                MsgBox("Saved!", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If

        If e.ColumnIndex = 10 Then
            If MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_OTHER_CHARGES SET STAT = '0' WHERE STAT = '1' AND BLNO = '" & txtBLNo.Text & "' AND containerNo = '" & dtStorage.CurrentRow.Cells(1).Value & "' AND CHARGESNAME = 'STORAGE CHARGES'")
                dtStorage.Rows.Remove(dtStorage.CurrentRow)
            End If
            Exit Sub
        End If
    End Sub
    Public Sub Save(ChargesCode, ChargesName, refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, gateIn, startBillDate, endBillDate, nosOfDay, RateIs, eRate, dateAdded, addedBy, stat, curr, FeederVesselVoyage, MotherVesselVoyage, shipperName, feederVesselName, motherVesselName, shipperAddress)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO  TBL_OTHER_CHARGES(ChargesCode, ChargesName,  refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, gateIn, startBillDate, endBillDate, nosOfDay, RateIs, eRate, dateAdded, addedBy, stat, curr, FeederVesselVoyage, MotherVesselVoyage, clock, shipperName, feederVesselName, motherVesselName, shipperAddress)"
        SQL = SQL + "VALUES('" & KVal(ChargesCode) & "',  '" & KVal(ChargesName) & "',  '" & KVal(refno) & "',  '" & KVal(bkno) & "',  '" & KVal(blno) & "',  '" & KVal(Shipper) & "',  '" & KVal(feederVessel) & "',  '" & KVal(motherVessel) & "',  '" & KVal(containerNo) & "',  '" & KVal(sizeIs) & "',  '" & KVal(gateIn) & "',  '" & KVal(startBillDate) & "',  '" & KVal(endBillDate) & "',  '" & KVal(nosOfDay) & "',  '" & KVal(RateIs) & "',  '" & KVal(eRate) & "',  '" & KVal(dateAdded) & "',  '" & KVal(addedBy) & "',  '" & KVal(stat) & "', '" & KVal(curr) & "', '" & KVal(FeederVesselVoyage) & "', '" & KVal(MotherVesselVoyage) & "', '0', '" & KVal(shipperName) & "' , '" & KVal(feederVesselName) & "' , '" & KVal(motherVesselName) & "', '" & KVal(shipperAddress) & "' )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged, TabControl1.SelectedIndexChanged, TabControl1.Selected
        If cmbCategory.Text.ToString.Contains("STORAGE") Then
            TabControl1.SelectedIndex = 0
        ElseIf cmbCategory.Text.ToString.Contains("TRUCKING") Then
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Sub dtTrucking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtTrucking.CellContentClick

    End Sub

    Private Sub dtTrucking_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtTrucking.CellClick
        If e.ColumnIndex = 7 Then
            If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_OTHER_CHARGES SET STAT = '2' WHERE STAT = '1' AND BLNO = '" & txtBLNo.Text & "' AND containerNo = '" & dtTrucking.CurrentRow.Cells(1).Value & "' AND CHARGESNAME = 'TRUCKING CHARGES'")
                Call SavetRUCKING("", "TRUCKING CHARGES", txtRefno.Text, txtBKNo.Text, txtBLNo.Text, txtShipper.Tag, cmbFeederVessel.Tag, cmbMotherVessel.Tag, dtTrucking.CurrentRow.Cells(1).Value, dtTrucking.CurrentRow.Cells(2).Value, dtTrucking.CurrentRow.Cells(3).Value, SaveMoney(txtER.Text), Now, USER_ID, "1", dtTrucking.CurrentRow.Cells(4).Value, txtFeederVesselVoyage.Text, txtMotherVesselVoyage.Text, FrmBookingList.dtList.CurrentRow.Cells(3).Value, FrmBookingList.dtList.CurrentRow.Cells(6).Value, FrmBookingList.dtList.CurrentRow.Cells(12).Value, FrmBookingList.dtList.CurrentRow.Cells(4).Tag, SaveMoney(dtTrucking.CurrentRow.Cells(5).Value), dtTrucking.CurrentRow.Cells(6).Value)
                Call FrmBookingList.lOADContainersforOtherCharges(FrmBookingList.dtList.CurrentRow.Cells(1).Tag, FrmBookingList.dtList.CurrentRow.Cells(0).Tag, "1", FrmBookingList.dtList.CurrentRow.Cells(24).Value, FrmBookingList.dtList.CurrentRow.Cells(25).Value, dtTrucking, "T")
                MsgBox("Saved!", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If

        If e.ColumnIndex = 8 Then
            If MsgBox("Are you sure you want to delete?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_OTHER_CHARGES SET STAT = '0' WHERE STAT = '1' AND BLNO = '" & txtBLNo.Text & "' AND containerNo = '" & dtTrucking.CurrentRow.Cells(1).Value & "' AND CHARGESNAME = 'TRUCKING CHARGES'")
                dtTrucking.Rows.Remove(dtTrucking.CurrentRow)
            End If
            Exit Sub
        End If
    End Sub

    Public Sub SavetRUCKING(ChargesCode, ChargesName, refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, RateIs, eRate, dateAdded, addedBy, stat, curr, FeederVesselVoyage, MotherVesselVoyage, shipperName, feederVesselName, motherVesselName, shipperAddress, truckingWaitFee, truckingWaitFeeCurr)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO  TBL_OTHER_CHARGES(ChargesCode, ChargesName,  refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, RateIs, eRate, dateAdded, addedBy, stat, curr, FeederVesselVoyage, MotherVesselVoyage, clock, shipperName, feederVesselName, motherVesselName, shipperAddress, truckingWaitFee, truckingWaitFeeCurr)"
        SQL = SQL + "VALUES('" & KVal(ChargesCode) & "',  '" & KVal(ChargesName) & "',  '" & KVal(refno) & "',  '" & KVal(bkno) & "',  '" & KVal(blno) & "',  '" & KVal(Shipper) & "',  '" & KVal(feederVessel) & "',  '" & KVal(motherVessel) & "',  '" & KVal(containerNo) & "',  '" & KVal(sizeIs) & "',  '" & KVal(RateIs) & "',  '" & KVal(eRate) & "',  '" & KVal(dateAdded) & "',  '" & KVal(addedBy) & "',  '" & KVal(stat) & "', '" & KVal(curr) & "', '" & KVal(FeederVesselVoyage) & "', '" & KVal(MotherVesselVoyage) & "', '0', '" & KVal(shipperName) & "' , '" & KVal(feederVesselName) & "' , '" & KVal(motherVesselName) & "', '" & KVal(shipperAddress) & "','" & SaveMoney(truckingWaitFee) & "','" & KVal(truckingWaitFeeCurr) & "'  )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
End Class