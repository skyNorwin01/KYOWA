Public Class FrmContainerInventoryEditRow
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_CONTAINER_INVENTORY SET ArrivalManila = '" & IIf(mtxtArrivalMnl.Text = "  /  /", "", mtxtArrivalMnl.Text) & "', StatusOfContainer = '" & KVal(cmbContainerStats.Text) & "', ReturnToDepot = '" & IIf(mtxtReturdToDepot.Text = "  /  /", "", mtxtReturdToDepot.Text) & "', Remarks = '" & KVal(cmbRemarks.Text) & "', Shipper = '" & KVal(cmbReleasetoShipper.Text) & "', ContainerPullOut = '" & IIf(mtxtPullout.Text = "  /  /", "", mtxtPullout.Text) & "', DateUpdated = '" & Now & "', UpdateBy = '" & USER_ID & "' WHERE ID = '" & Me.Tag & "'")
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(3).Value = IIf(mtxtArrivalMnl.Text = "  /  /", "", mtxtArrivalMnl.Text)
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(4).Value = KVal(cmbContainerStats.Text)
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(5).Value = IIf(mtxtReturdToDepot.Text = "  /  /", "", mtxtReturdToDepot.Text)
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(6).Value = KVal(cmbRemarks.Text)
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(7).Value = KVal(cmbReleasetoShipper.Text)
            FrmContainerInventoryPerBooking.dtList.CurrentRow.Cells(8).Value = IIf(mtxtPullout.Text = "  /  /", "", mtxtPullout.Text)

            Me.Dispose()
        End If
    End Sub

    Private Sub FrmContainerInventoryEditRow_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, txtSize.KeyDown, mtxtArrivalMnl.KeyDown, cmbContainerStats.KeyDown, mtxtReturdToDepot.KeyDown, cmbRemarks.KeyDown, cmbReleasetoShipper.KeyDown, mtxtPullout.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmContainerInventoryEditRow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbContainerStats.Items
            .Clear()
            For i As Integer = 0 To FrmContainerInventoryPerBooking.dtList.RowCount - 1
                If Not String.IsNullOrEmpty(FrmContainerInventoryPerBooking.dtList.Rows(i).Cells(4).Value) Then
                    .Add(FrmContainerInventoryPerBooking.dtList.Rows(i).Cells(4).Value)
                End If
            Next
        End With

        With cmbRemarks.Items
            .Clear()
            .Add("AVL (A)")
            .Add("AVL (B)")
            .Add("WSH (A)")
            .Add("WSH (B)")
            .Add("DMG (A)")
            .Add("DMG (B)")
        End With


        'With cmbRemarks.Items
        '    .Clear()
        '    For i As Integer = 0 To FrmContainerInventoryPerBooking.dtList.RowCount - 1
        '        If Not String.IsNullOrEmpty(FrmContainerInventoryPerBooking.dtList.Rows(i).Cells(6).Value) Then
        '            .Add(FrmContainerInventoryPerBooking.dtList.Rows(i).Cells(6).Value)
        '        End If
        '    Next
        'End With



    End Sub
End Class