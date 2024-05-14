Public Class FrmTransferBooking
    Private Sub FrmTransferBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbService.Items
            .Clear()
            .Add("IMPORT")
            .Add("EXPORT")
        End With

        With cmbContainerCapacity.Items
            .Clear()
            .Add("FULL CONTAINER LOAD")
            .Add("LESS THAN CONTAINER LOAD")
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'MsgBox(selBLno)
        'MsgBox(SelRefno)
        'MsgBox(SelBkNo)
        'Exit Sub
        Dim CurrBKNO As String = ""
        Dim CurrRefno As String = ""

        CurrBKNO = SelBkNo
        CurrRefno = SelRefno

        Dim NewRefno As String = ""
        Dim NewBKNo As String = ""

        Dim SelService As String = ""
        Dim SelCapacity As String = ""

        Dim StrService As String = ""
        Dim StrCapacity As String = ""

        StrService = Mid(SelBkNo, 4, 1)
        StrCapacity = Mid(SelBkNo, 6, 1)


        'MsgBox(StrService)
        'MsgBox(StrCapacity)

        SelService = Mid(cmbService.Text, 1, 1)
        SelCapacity = Mid(cmbContainerCapacity.Text, 1, 1)

        'MsgBox(SelService)
        'MsgBox(SelCapacity)

        If StrService = SelService And StrCapacity = SelCapacity Then
            MsgBox("Invalid to transfer the booking with same service and container capacity!", MsgBoxStyle.Critical)
            Exit Sub
        End If



        If cmbService.SelectedIndex = -1 Then
            MsgBox("Invalid service!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbContainerCapacity.SelectedIndex = -1 Then
            MsgBox("Invalid container capacity!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        'NewRefno = Replace(SelRefno, StrService, SelService)
        'MsgBox(NewRefno)
        'NewRefno = Replace(NewRefno, StrCapacity, SelCapacity)
        'MsgBox(NewRefno)

        'Exit Sub


        If MsgBox("Are you sure you want to transfer this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            NewBKNo = Replace(SelBkNo, StrService, SelService)
            'MsgBox(NewBKNo)
            NewBKNo = Replace(NewBKNo, StrCapacity, SelCapacity)
            'MsgBox(NewBKNo)

            NewRefno = Replace(SelRefno, StrService, SelService)
            'MsgBox(NewRefno)
            NewRefno = Replace(NewRefno, StrCapacity, SelCapacity)
            'MsgBox(NewRefno)


            If SelRefno <> "" Then
                Call SetJob("UPDATE TBL_BOOKING SET REFNO = '" & NewRefno & "', BKNO = '" & NewBKNo & "', TransferBy = '" & USER_ID & "', TransferDate = '" & Now & "',  FromBKNO = '" & CurrBKNO & "', FromRefno = '" & CurrRefno & "' WHERE  BKNO = '" & CurrBKNO & "' and refno = '" & CurrRefno & "' ")
            Else
                Call SetJob("UPDATE TBL_BOOKING SET   BKNO = '" & NewBKNo & "', TransferBy = '" & USER_ID & "', TransferDate = '" & Now & "',  FromBKNO = '" & CurrBKNO & "', FromRefno = '" & CurrRefno & "' WHERE  BKNO = '" & CurrBKNO & "'")
            End If

            Call SetJob("UPDATE TBL_BL SET REFNO = '" & NewRefno & "' WHERE REFNO = '" & CurrRefno & "'")
            Call SetJob("UPDATE TBL_MARKS_AND_NUMBERS SET REFNO = '" & NewRefno & "' WHERE REFNO = '" & CurrRefno & "'")
            Call SetJob("UPDATE TBL_CONTAINER SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")
            Call SetJob("UPDATE TBL_CONTAINER_BOOKING SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")
            Call SetJob("UPDATE TBL_DELIVERY_ORDER SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")
            Call SetJob("UPDATE TBL_OPERATIONS SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")
            Call SetJob("UPDATE TBL_RIDER SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")
            Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET BKNO = '" & NewBKNo & "' WHERE BKNO = '" & CurrBKNO & "'")



            FrmBookingList.btnSearch_Click(e, e)
            MsgBox("Successfully done!", MsgBoxStyle.Information)
            Me.Dispose()

        End If
    End Sub

    Private Sub FrmTransferBooking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class