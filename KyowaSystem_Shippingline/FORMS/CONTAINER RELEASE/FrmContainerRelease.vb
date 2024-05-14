Public Class FrmContainerRelease
    Private Sub FrmContainerRelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbFilter.Items
            .Clear()
            .Add("CONTAINER NO.")
            .Add("BLNO")
            .Add("REFNO")
        End With
        dtList.Columns(6).DefaultCellStyle.ForeColor = Color.Green
        If strDemmurageDetention = "DEM" Then
            dtList.Columns(4).HeaderText = "DATE DISCHARGE YYYY-MM-DD"
        Else
            dtList.Columns(4).HeaderText = "DATE RELEASED YYYY-MM-DD"
        End If
        cmbFilter.SelectedIndex = 0
        Call LoadAllContainers()
    End Sub

   Public Sub LoadAllContainers()
        If strDemmurageDetention = "DEM" Then

            If cmbFilter.Text = "CONTAINER NO." Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat, DateDischarged  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(C.ContainerNo,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            ElseIf cmbFilter.Text = "BLNO" Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat, DateDischarged  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(B.BLNO,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            ElseIf cmbFilter.Text = "REFNO" Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat, DateDischarged  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(B.REFNO,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            Else
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat, DateDischarged  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(C.ContainerNo,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            End If

            Dim i As Integer = 1
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> ''"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtList
                .Rows.Clear()
                Do While Dbo.reader.Read
                    Dim DischargedStatus As String = ""
                    If Dbo.reader(4).ToString = "1" Then
                        DischargedStatus = "✓ (DISCHARGED)"
                    Else
                        DischargedStatus = ""
                    End If

                    Dim DateDischarged As DateTime = Now
                    If Dbo.reader(4).ToString = "1" Then
                        DateDischarged = Dbo.reader(5).ToString
                    End If





                    .Rows.Add(i, Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Format(CDate(DateDischarged), "yyyy-MM-dd"), "DISCHARGE", DischargedStatus)
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(3).ToString

                    If Dbo.reader(4).ToString = "1" Then
                        dtList.Rows(.RowCount - 1).Cells(4).Style.BackColor = SystemColors.HotTrack
                        dtList.Rows(.RowCount - 1).Cells(4).Style.ForeColor = Color.White
                        dtList.Rows(.RowCount - 1).Cells(4).ReadOnly = True
                        dtList.Rows(.RowCount - 1).Cells(5).Value = "UNDO"
                    Else
                        dtList.Rows(.RowCount - 1).Cells(4).Style.BackColor = Color.White
                        dtList.Rows(.RowCount - 1).Cells(4).Style.ForeColor = Color.Black
                        dtList.Rows(.RowCount - 1).Cells(4).ReadOnly = False
                        dtList.Rows(.RowCount - 1).Cells(5).Value = "DISCHARGE"
                    End If


                    i += 1
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Exit Sub
        End If

        If strDemmurageDetention = "DET" Then
            If cmbFilter.Text = "CONTAINER NO." Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, ReleasedStat, DateReleased  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(C.ContainerNo,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            ElseIf cmbFilter.Text = "BLNO" Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, ReleasedStat, DateReleased FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(B.BLNO,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            ElseIf cmbFilter.Text = "REFNO" Then
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, ReleasedStat, DateReleased  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(B.REFNO,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            Else
                SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, ReleasedStat, DateReleased  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> '' AND ISNULL(C.ContainerNo,'')  LIKE '%" & KVal(txtSearch.Text) & "%' AND ISNULL(B.REFNO,'') LIKE 'KYW" & LandingForm.ServiceIs & "%'"
            End If

            Dim i As Integer = 1
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT ISNULL(C.ContainerNo,'') ContainerNo, ISNULL(B.BLNO,'') BLNO, ISNULL(B.REFNO,'') REFNO, C.ID, DischargedStat  FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND B.STAT = '1' WHERE C.STAT = '1' AND B.STAT = '1' AND ISNULL(C.ContainerNo,'')  <> '' AND  ISNULL(B.BLNO,'')  <> '' AND ISNULL(B.REFNO,'') <> ''"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtList
                .Rows.Clear()
                Do While Dbo.reader.Read
                    Dim RELEASEDStats As String = ""
                    If Dbo.reader(4).ToString = "1" Then
                        RELEASEDStats = "✓ (RELEASED)"
                    Else
                        RELEASEDStats = ""
                    End If

                    Dim DateDischarged As DateTime = Now
                    If Dbo.reader(4).ToString = "1" Then
                        DateDischarged = Dbo.reader(5).ToString
                    End If





                    .Rows.Add(i, Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Format(CDate(DateDischarged), "yyyy-MM-dd"), "RELEASED", RELEASEDStats)
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(3).ToString

                    If Dbo.reader(4).ToString = "1" Then
                        dtList.Rows(.RowCount - 1).Cells(4).Style.BackColor = SystemColors.HotTrack
                        dtList.Rows(.RowCount - 1).Cells(4).Style.ForeColor = Color.White
                        dtList.Rows(.RowCount - 1).Cells(4).ReadOnly = True
                        dtList.Rows(.RowCount - 1).Cells(5).Value = "UNDO"
                    Else
                        dtList.Rows(.RowCount - 1).Cells(4).Style.BackColor = Color.White
                        dtList.Rows(.RowCount - 1).Cells(4).Style.ForeColor = Color.Black
                        dtList.Rows(.RowCount - 1).Cells(4).ReadOnly = False
                        dtList.Rows(.RowCount - 1).Cells(5).Value = "RELEASED"
                    End If


                    i += 1
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End If



    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Call LoadAllContainers()
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick
        If strDemmurageDetention = "DEM" Then
            If e.ColumnIndex = 5 Then
                If dtList.CurrentRow.Cells(6).Value = "✓ (DISCHARGED)" Then
                    If MsgBox("Are you sure you want to undo this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Call SetJob("UPDATE TBL_CONTAINER SET DischargedStat = '0', UndoDischargeBy = '" & USER_ID & "', DateUndoDischarge = '" & Format(CDate(dtList.CurrentRow.Cells(4).Value), "yyyy-MM-dd hh:mm:ss.fff") & "' where id = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                        dtList.CurrentRow.Cells(6).Value = ""
                        dtList.CurrentRow.Cells(5).Value = "DISCHARGE"
                        dtList.CurrentRow.Cells(4).Style.BackColor = Color.White
                        dtList.CurrentRow.Cells(4).Style.ForeColor = Color.Black
                        dtList.CurrentRow.Cells(4).ReadOnly = False
                    End If
                    Exit Sub
                End If

                If Not Information.IsDate(dtList.CurrentRow.Cells(4).Value) Then
                    MsgBox("Invalid Discharge Date!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Are you sure you want to discharge this container?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call SetJob("UPDATE TBL_CONTAINER SET DischargedStat = '1', DischargedBy = '" & USER_ID & "', DateDischarged = '" & Format(CDate(dtList.CurrentRow.Cells(4).Value), "yyyy-MM-dd hh:mm:ss.fff") & "', DateUserDischarged = '" & Now & "' where id = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                    dtList.CurrentRow.Cells(6).Value = "✓ (DISCHARGED)"
                    dtList.CurrentRow.Cells(5).Value = "UNDO"
                    dtList.CurrentRow.Cells(4).Style.BackColor = SystemColors.HotTrack
                    dtList.CurrentRow.Cells(4).Style.ForeColor = Color.White
                    dtList.CurrentRow.Cells(4).ReadOnly = True
                End If

            End If
            Exit Sub
        End If

        If strDemmurageDetention = "DET" Then
            If e.ColumnIndex = 5 Then
                If dtList.CurrentRow.Cells(6).Value = "✓ (RELEASED)" Then
                    If MsgBox("Are you sure you want to undo this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Call SetJob("UPDATE TBL_CONTAINER SET RELEASEDStat = '0', UndoRELEASEDBy = '" & USER_ID & "', DateUndoRELEASED = '" & Format(CDate(dtList.CurrentRow.Cells(4).Value), "yyyy-MM-dd hh:mm:ss.fff") & "' where id = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                        dtList.CurrentRow.Cells(6).Value = ""
                        dtList.CurrentRow.Cells(5).Value = "RELEASED"
                        dtList.CurrentRow.Cells(4).Style.BackColor = Color.White
                        dtList.CurrentRow.Cells(4).Style.ForeColor = Color.Black
                        dtList.CurrentRow.Cells(4).ReadOnly = False
                    End If
                    Exit Sub
                End If

                If Not Information.IsDate(dtList.CurrentRow.Cells(4).Value) Then
                    MsgBox("Invalid RELEASED Date!", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Are you sure you want to release this container?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call SetJob("UPDATE TBL_CONTAINER SET RELEASEDStat = '1', RELEASEDBy = '" & USER_ID & "', DateRELEASED = '" & Format(CDate(dtList.CurrentRow.Cells(4).Value), "yyyy-MM-dd hh:mm:ss.fff") & "', DateUserRELEASED = '" & Now & "' where id = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                    dtList.CurrentRow.Cells(6).Value = "✓ (RELEASED)"
                    dtList.CurrentRow.Cells(5).Value = "UNDO"
                    dtList.CurrentRow.Cells(4).Style.BackColor = SystemColors.HotTrack
                    dtList.CurrentRow.Cells(4).Style.ForeColor = Color.White
                    dtList.CurrentRow.Cells(4).ReadOnly = True
                End If

            End If
            Exit Sub
        End If


    End Sub

    Private Sub FrmContainerRelease_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class