Public Class frmApplyBlno
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub frmApplyBlno_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmApplyBlno_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to apply BLNO for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim BLNOis As String = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & FrmBookingList.SelServiceIs & "' AND PARAM3 = '" & FrmBookingList.SelBookingType & "'", "L")
            BLNOis = txtToBL.Text
            'BLNOis = Format(CInt(BLNOis), "0000000")
            SetJob("Update TBL_BOOKING SET BLNO = '" & KVal(BLNOis) & "' WHERE STAT = '1' AND SYSREF = '" & FrmBookingList.dtList.CurrentRow.Cells(1).Tag & "'")
            'SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(BLNOis) + 1 & "' WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & FrmBookingList.SelServiceIs & "'")
            FrmBookingList.dtList.CurrentRow.Cells(25).Value = KVal(BLNOis)
            'Call FrmBookingList.btnSearch_Click(e, e)
            MsgBox("BLNO successfully applied!", MsgBoxStyle.Information)
            Me.Dispose()
            Exit Sub
        End If
    End Sub
End Class