Public Class FrmNewBLNO
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If KVal(txtFromBl.Text) = KVal(txtToBL.Text) Then
            MsgBox("Same BLNO is invalid!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        If FrmBookingList.dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            If MsgBox("Are you sure you want to save this new bl?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_BOOKING SET BLNO = '" & KVal(txtToBL.Text) & "',  OldBLNO = '" & KVal(txtFromBl.Text) & "', BLChangedBy = '" & KVal(USER_ID) & "', BLChangedDate = '" & Now & "' WHERE BLNO = '" & KVal(txtFromBl.Text) & "' AND SYSREF = '" & SelSysref & "' AND STAT = '4'")
                FrmBookingList.dtList.CurrentRow.Cells(25).Value = KVal(txtToBL.Text)
                MsgBox("Successfully saved!", MsgBoxStyle.Information)
                Me.Dispose()
            End If
            Exit Sub
        End If


        SQL = "SELECT * FROM TBL_BOOKING WHERE STAT <> '2' AND ISNULL(FLOATRECORD,'') <> '1' AND BLNO  = '" & KVal(txtToBL.Text) & "'"
        If Not GetRyzk(SQL, "") = NoRecordFound Then
            MsgBox("BLNO already existing!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to save this new bl?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_BOOKING SET BLNO = '" & KVal(txtToBL.Text) & "',  OldBLNO = '" & KVal(txtFromBl.Text) & "', BLChangedBy = '" & KVal(USER_ID) & "', BLChangedDate = '" & Now & "' WHERE BLNO = '" & KVal(txtFromBl.Text) & "' AND SYSREF = '" & SelSysref & "' AND STAT = '1'")
            FrmBookingList.dtList.CurrentRow.Cells(25).Value = KVal(txtToBL.Text)
            MsgBox("Successfully saved!", MsgBoxStyle.Information)
            Me.Dispose()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class