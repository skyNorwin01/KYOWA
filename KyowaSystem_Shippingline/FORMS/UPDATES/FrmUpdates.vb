Public Class FrmUpdates
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Dispose()

    End Sub

    Private Sub FrmUpdates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Visible = False
        Dim CondIs = "", CondIs2 As String = ""
        Dim Col1 = "", Col2 As String = ""


        For i As Integer = 0 To dtUpdates.ColumnCount - 1
            dtUpdates.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        'SQL = " SELECT PatchNo, ParticularIs , UPDATES, DateStart , HeadSort,ItemSortIs FROM TBL_UPDATES WHERE STAT = '1'  AND DateStart BETWEEN  '" & DateAdd(DateInterval.Day, -10, Now).Date & "' AND  '" & Now.Date & "' ORDER BY  PatchNo DESC, HeadSort, ItemSortIs"
        SQL = " SELECT PatchNo, ParticularIs , UPDATES, DateStart , HeadSort,ItemSortIs FROM TBL_UPDATES WHERE STAT = '1'  ORDER BY  CONVERT(INT,PatchNo) DESC, HeadSort, ItemSortIs"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtUpdates
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            With .Columns(0).DefaultCellStyle
                .ForeColor = SystemColors.HotTrack
                .Font = New Font("Calibri", 14, FontStyle.Bold)
            End With
            .Rows.Clear()
            Do While Dbo.reader.Read
                If Not dtUpdates.RowCount = 0 Then
                    If Col1 = Dbo.reader(0).ToString Then
                        Col1 = ""
                    Else
                        .Rows.Add()
                        '.Rows.Add()
                    End If
                Else
                    Col1 = Dbo.reader(0).ToString
                    '.Rows.Add()
                    '.Rows(.RowCount - 1).DefaultCellStyle.BackColor = SystemColors.Highlight
                End If

                If Not dtUpdates.RowCount = 0 Then
                    If Col2 = Dbo.reader(1).ToString Then
                        Col2 = ""
                    Else
                        .Rows.Add()
                        If Col1 = Dbo.reader(0).ToString Then

                        End If
                    End If
                Else
                    Col2 = Dbo.reader(1).ToString
                End If

                'If "PTCH" & Format(CInt(Dbo.reader(0).ToString), "0000") = CondIs Then
                '    If Not dtUpdates.RowCount = 0 Then
                '        If Not Dbo.reader(1).ToString = CondIs2 Then
                '            .Rows.Add()
                '            .Rows.Add("", Dbo.reader(1).ToString, "", "")
                '            .Rows.Add("", "", Dbo.reader(2).ToString, "")
                '            CondIs2 = Dbo.reader(1).ToString
                '        Else
                '            .Rows.Add("", "", Dbo.reader(2).ToString, "")
                '        End If
                '    Else
                '        .Rows.Add("", "", Dbo.reader(2).ToString, "")
                '    End If

                'Else

                .Rows.Add(IIf(Col1 = "", "", "PTCH" & Format(CInt(Dbo.reader(0).ToString), "0000")), IIf(Col1 = "", IIf(Col2 = "", "", Dbo.reader(1).ToString), Dbo.reader(1).ToString), Dbo.reader(2).ToString, IIf(Col2 = "", "", Format(CDate(Dbo.reader(3).ToString), "MM-dd-yyyy")))
                'End If
                'CondIs = "PTCH" & Format(CInt(Dbo.reader(0).ToString), "0000")

                'CondIs2 = Dbo.reader(1).ToString
                Col1 = Dbo.reader(0).ToString
                Col2 = Dbo.reader(1).ToString
            Loop
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
        Me.Width = dtUpdates.Width + 35
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call FrmUpdates_Load(e, e)
    End Sub

    Private Sub FrmUpdates_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub dtUpdates_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtUpdates.CellContentClick

    End Sub

    Private Sub dtUpdates_KeyDown(sender As Object, e As KeyEventArgs) Handles dtUpdates.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub
End Class