Public Class FrmBLForm
    Private Sub FrmBLForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtShipper.Select()
        dtDescriptions.Columns(6).DisplayIndex = 2
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Public Sub InsertBLDetails(BLNO, REFNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL, PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat, TermIs, DateIssue)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_BL(BLNO, REFNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat, TermIs, DateIssue)"
        SQL = SQL + "VALUES('" & KVal(BLNO) & "',  '" & KVal(REFNO) & "',  '" & KVal(Shipper) & "',  '" & KVal(ShipperAddress) & "',  '" & KVal(Consignee) & "',  '" & KVal(ConsigneeAddress) & "',  '" & KVal(Notify) & "',  '" & KVal(NotifyAddress) & "',  '" & KVal(LocalVessel) & "',  '" & KVal(LocalVesselPOL) & "',  '" & KVal(OceanVessel) & "',  '" & KVal(OceanVesselPOL) & "',  '" & KVal(POD) & "',  '" & KVal(PayableAt) & "',  '" & KVal(NosOfBL) & "',  '" & KVal(PlaceDateIssue) & "',  '" & KVal(OnBoardDate) & "',  '" & KVal(PortFromCode) & "',  '" & KVal(PortToCode) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(TermIs) & "', '" & KVal(DateIssue) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub SaveRemarks(BLNO, REFNO, CODE, Mark, PKGNos, DescriptionIs, KGS, CBM, DateAdded, AddedBy, STAT, Description1)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_MARKS_AND_NUMBERS(BLNO, REFNO, CODE, Mark, PKGNos, DescriptionIs, KGS, CBM, DateAdded, AddedBy, STAT, Description1)"
        SQL = SQL + "VALUES('" & KVal(BLNO) & "',  '" & KVal(REFNO) & "',  '" & KVal(CODE) & "',  '" & KVal(Mark) & "',  '" & KVal(PKGNos) & "',  '" & KVal(DescriptionIs) & "',  '" & KVal(KGS) & "',  '" & KVal(CBM) & "',  '" & KVal(DateAdded) & "',  '" & KVal(AddedBy) & "',  '" & KVal(STAT) & "', '" & KVal(Description1) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'REMOVE_BL_NUMBERS_FOR_CHECKING_THEN_COPY_ALL_MODIFIED_TO_WESPAC_OBL

        Dim crnSelRefno = "", CRNSelBLno As String = ""

        If GetRyzk("select floatrecord from TBL_BOOKING where refno = '" & crnSelRefno & "'", "") = "1" Then
            If MsgBox("Are you sure you want to proceed with FLOAT bl?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf GetRyzk("select floatrecord from TBL_BOOKING where refno = '" & crnSelRefno & "'", "") = "0" Then
            If MsgBox("Are you sure you want to proceed with UNFLOAT bl?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If FrmBookingList.CorrectionNoticeRevised = "CNR-" Then
            CRNSelBLno = "CNR-" & selBLno
            crnSelRefno = "CNR-" & SelRefno

            If MsgBox("Are you sure you want to save CORRECT BLs?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                With Me
                    Call SetJob("UPDATE TBL_BL SET STAT = '2' WHERE STAT = '1' AND  BLNO = '" & CRNSelBLno & "'")
                    Call InsertBLDetails(CRNSelBLno, crnSelRefno, txtShipper.Text, txtShipperAddress.Text, txtConsignee.Text, txtConsigneeAddress.Text, txtNotify1.Text, txtNotifyAddress1.Text, txtLocalVessel.Text, txtLocalVesselPOL.Text, txtOceanVessel.Text, txtOceanVesselPOL.Text, txtPortOfDischarge.Text, txtPayableAt.Text, txtNosOfBL.Text, txtPlaceDateIssue.Text, dtOnBoardDate.Value, txtFromPortCode.Text, txtToPortCode.Text, USER_ID, Now, "1", "C", DtDateIssue.Value)
                End With

                Call SetJob("UPDATE TBL_MARKS_AND_NUMBERS SET STAT = '2' WHERE STAT = '1' AND REFNO = '" & crnSelRefno & "' AND BLNO = '" & CRNSelBLno & "'")
                With dtDescriptions
                    For i As Integer = 0 To .RowCount - 1

                        If String.IsNullOrEmpty(.Rows(i).Cells(0).Value) And String.IsNullOrEmpty(.Rows(i).Cells(1).Value) And String.IsNullOrEmpty(.Rows(i).Cells(2).Value) And String.IsNullOrEmpty(.Rows(i).Cells(3).Value) And String.IsNullOrEmpty(.Rows(i).Cells(4).Value) Then
                            If i = .RowCount - 1 Then
                            Else
                                If String.IsNullOrEmpty(.Rows(i + 1).Cells(0).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(1).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(2).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(3).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(4).Value) Then
                                Else
                                    Call SaveRemarks(CRNSelBLno, crnSelRefno, "", .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value, Now, USER_ID, "1", .Rows(i).Cells(6).Value)
                                End If
                            End If

                        Else
                            Call SaveRemarks(CRNSelBLno, crnSelRefno, "", .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value, Now, USER_ID, "1", .Rows(i).Cells(6).Value)
                        End If

                    Next
                End With
                MsgBox("Saved!", MsgBoxStyle.Information)
            End If
            Exit Sub
        End If

        If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            With Me
                Call SetJob("UPDATE TBL_BL SET STAT = '2' WHERE STAT = '1' AND  BLNO = '" & selBLno & "'")
                Call InsertBLDetails(selBLno, SelRefno, txtShipper.Text, txtShipperAddress.Text, txtConsignee.Text, txtConsigneeAddress.Text, txtNotify1.Text, txtNotifyAddress1.Text, txtLocalVessel.Text, txtLocalVesselPOL.Text, txtOceanVessel.Text, txtOceanVesselPOL.Text, txtPortOfDischarge.Text, txtPayableAt.Text, txtNosOfBL.Text, txtPlaceDateIssue.Text, dtOnBoardDate.Value, txtFromPortCode.Text, txtToPortCode.Text, USER_ID, Now, "1", FrmBookingList.BLTermIs, DtDateIssue.Value)
            End With

            Call SetJob("UPDATE TBL_MARKS_AND_NUMBERS SET STAT = '2' WHERE STAT = '1' AND REFNO = '" & SelRefno & "' AND BLNO = '" & selBLno & "'")
            With dtDescriptions
                For i As Integer = 0 To .RowCount - 1

                    If String.IsNullOrEmpty(.Rows(i).Cells(0).Value) And String.IsNullOrEmpty(.Rows(i).Cells(1).Value) And String.IsNullOrEmpty(.Rows(i).Cells(2).Value) And String.IsNullOrEmpty(.Rows(i).Cells(3).Value) And String.IsNullOrEmpty(.Rows(i).Cells(4).Value) Then
                        If i = .RowCount - 1 Then
                        Else
                            If String.IsNullOrEmpty(.Rows(i + 1).Cells(0).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(1).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(2).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(3).Value) And String.IsNullOrEmpty(.Rows(i + 1).Cells(4).Value) Then
                            Else
                                Call SaveRemarks(selBLno, SelRefno, "", .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value, Now, USER_ID, "1", .Rows(i).Cells(6).Value)
                            End If
                        End If

                    Else
                        Call SaveRemarks(selBLno, SelRefno, "", .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, .Rows(i).Cells(4).Value, Now, USER_ID, "1", .Rows(i).Cells(6).Value)
                    End If

                Next
            End With
            MsgBox("Saved!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub dtDescriptions_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtDescriptions.CellContentClick

    End Sub

    Private Sub dtDescriptions_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtDescriptions.CellEnter
        If dtDescriptions.CurrentRow.Index = 0 Then
            'dtDescriptions.CurrentCell = dtDescriptions.Item(2, 1)
            dtDescriptions.BeginEdit(False)
        Else
            dtDescriptions.BeginEdit(True)
        End If
    End Sub

    Private Sub dtDescriptions_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtDescriptions.CellMouseUp
        With dtDescriptions
            If e.Button = MouseButtons.Right Then
                .Rows(e.RowIndex).Selected = True
                .CurrentCell = .Rows(e.RowIndex).Cells(1)
                Me.ContextMenuStrip1.Show(dtDescriptions, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If
        End With

    End Sub

    Private Sub AddRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRowToolStripMenuItem.Click
        If Not dtDescriptions.Rows(dtDescriptions.CurrentRow.Index).IsNewRow Then
            dtDescriptions.Rows.Insert(dtDescriptions.CurrentRow.Index)
        End If
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        If Not dtDescriptions.Rows(dtDescriptions.CurrentRow.Index).IsNewRow Then
            dtDescriptions.Rows.RemoveAt(dtDescriptions.CurrentRow.Index)
        End If
    End Sub

    Private Sub FrmBLForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class