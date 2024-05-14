Imports Microsoft.Office.Interop
Module GlobalDeclaration
    Public USER_ID As String = "1"
    Public FNAME = "RAYZ", MNAME = "", LNAME As String = "EUGENIO"
    Public LockAccess As Integer = 0
    Public UserDesignation As String = ""
    Public UserDesignationLabel As String = ""
    Public SQL As String = ""
    Public NoRecordFound As String = UCase("NORECORDFOUNDRAYZK1212")
    Public PasswordIs As String = ""
    Public QuotationModeProcessIs As String = ""
    Public TransmittalAccess As String = ""
    Public TypeOfShipment As String = ""
    Public PrintModeIs As String = ""
    Public PrintActionMode As String = ""

    Public strDemmurageDetention As String = ""

    Public RefnoGlobal As String = ""
    Public RefundAccessType As String = ""

    Public MainSysref As String = ""
    Public MainBkno As String = ""

    Public SelRefno = "", SelSysref = "", selBLno = "", SelBkNo = "", SelShipper = "", SelConsignee = "", SelPort = "", SelStatIs As String = ""
    Public selFeederVsl = "", SelMotherVessel As String = ""

    Public EApprovalAccess = "", UserEmail = "", EPass As String = ""

    Public Sub SetJobMysql(sql As String)
        Dim Dbo As New SQLClass
        Dbo.MysqlCon.Open()
        Dbo.MysqlCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, Dbo.MysqlCon)
        Dbo.MysqlCmd.ExecuteNonQuery()
        Dbo.MysqlCon.Close()
    End Sub

    Public Function iSExisting(tBL As String, LookFor As String, valueIs As String) As Boolean
        If GetRyzk("SELECT " & LookFor & " FROM " & tBL & " WHERE " & LookFor & " = '" & KVal(valueIs) & "' AND STAT = '1'", "") = NoRecordFound Then
            iSExisting = False
        Else
            iSExisting = True
        End If
    End Function

    Public Function ifExistingCharges(cmb As ComboBox) As Boolean

        Dim Charges As String = ""
        Charges = GetRyzk("SELECT itemCode FROM  tblR_ItemListMasterData WHERE itemGroup LIKE '%shipping%' and itemname = '" & KVal(cmb.Text) & "'", "ACCTG")
        'If GetRyzk("SELECT CHARGES_NAME FROM TBL_CHARGES_NAME WHERE CHARGES_NAME = '" & KVal(cmb.Text) & "' AND STAT = '1'", "") = NoRecordFound Then
        If Charges = NoRecordFound Then
            ifExistingCharges = False
        Else
            ifExistingCharges = True
        End If
    End Function

    'SELECT DISTINCT stat , FVoyage1st FROM TBL_BOOKING WHERE STAT = '1'  ORDER BY   FVoyage1st ASC
    Public Function ifExistingVOYAGE(cmb As ComboBox) As Boolean
        If GetRyzk("SELECT DISTINCT  FVoyage1st FROM TBL_BOOKING WHERE STAT = '1' AND  FVoyage1st  = '" & KVal(cmb.Text) & "'", "") = NoRecordFound Then
            ifExistingVOYAGE = False
        Else
            ifExistingVOYAGE = True
        End If
    End Function

    Public Function ColumnIndexToColumnLetter(colIndex As Integer) As String
        Dim div As Integer = colIndex
        Dim colLetter As String = String.Empty
        Dim modnum As Integer = 0

        While div > 0
            modnum = (div - 1) Mod 26
            colLetter = Chr(65 + modnum) & colLetter
            div = CInt((div - modnum) \ 26)
        End While

        Return colLetter
    End Function


    Public Function ShowDateAsKyowa(dateIs) As String
        If Not String.IsNullOrEmpty(dateIs) Then
            ShowDateAsKyowa = Format(CDate(dateIs), "yyyy-MM-dd")
        Else
            ShowDateAsKyowa = Format(CDate(Now), "yyyy-MM-dd")
        End If
    End Function
    Public Function ifExistingFeeder(cmb As ComboBox) As Boolean
        If GetRyzk("SELECT  VESSELNAME FROM TBL_VESSEL WHERE STAT = '1' AND VESSELNAME = '" & KVal(cmb.Text) & "'", "") = NoRecordFound Then
            ifExistingFeeder = False
        Else
            ifExistingFeeder = True
        End If
    End Function

    Public Function ifExistingPolPod(cmb As ComboBox) As Boolean
        If GetRyzk("SELECT NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' AND NAME = '" & KVal(cmb.Text) & "'", "") = NoRecordFound Then
            ifExistingPolPod = False
        Else
            ifExistingPolPod = True
        End If
    End Function
    Public Function ifExistingFeederCarrier(cmb As ComboBox) As Boolean
        If GetRyzk("SELECT FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE FEEDER_CARRIER = '" & KVal(cmb.Text) & "' AND STAT = '1'", "") = NoRecordFound Then
            ifExistingFeederCarrier = False
        Else
            ifExistingFeederCarrier = True
        End If
    End Function

    Public Function ifExistingCurrency(cmb As ComboBox) As Boolean
        If GetRyzk("SELECT curr FROM TBL_CURRENCY WHERE curr = '" & KVal(cmb.Text) & "' AND STAT = '1'", "") = NoRecordFound Then
            ifExistingCurrency = False
        Else
            ifExistingCurrency = True
        End If
    End Function

    Public Sub InputTextNum(my_range As String, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, FieldTypeAS As String, SecondFormat As String)


        With Sheet
            With .Range(my_range)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                '.RowHeight = rowHeight
                '.ColumnWidth = colWidth
                '.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                ''''''''''''''''''''''''''

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                '.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''
                '.Borders.Weight = Excel.XlBorderWeight.xlMedium
                '''''''''''''''''''''''''''''''''''''

                '.Font.Size = fontSize
                '.Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If
                .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                If FieldTypeAS = "N" Then
                    .NumberFormat = "#,##0.00_);(#,##0.00)"
                End If

                If SecondFormat <> "" Then
                    .NumberFormat = SecondFormat
                End If



                If sTr = "0" Then
                    .Cells(1, 1) = ""
                ElseIf sTr = "" Then
                    .Cells(1, 1) = ""
                Else
                    .Cells(1, 1) = sTr
                End If
            End With
        End With
    End Sub
    Public Sub InputTextCompleteIntRange(cellIs As Integer, RowIs As Integer, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, Color As System.Drawing.Color, BColor As Integer)


        With Sheet
            With .Cells(RowIs, cellIs)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If

                If BColor = 0 Then
                    .Interior.Pattern = Excel.XlPattern.xlPatternNone
                Else
                    .Interior.Pattern = Excel.XlPattern.xlPatternAutomatic
                    .Interior.ColorIndex = BColor
                End If

                .Font.Color = System.Drawing.ColorTranslator.ToOle(Color)
                .Cells(1, 1) = sTr

            End With
        End With
    End Sub

    Public Function getCountOfCharges(blno As String) As Integer
        getCountOfCharges = 0
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT  CONVERT(NVARCHAR(500),CN.foreignname) AS CHARGES_NAME,CURR.Name, CURR.Curr , R.SYSREF, R.BLNO, CHARGES, SIZEIS, Currency, qty, DestinationRate, PrincipalRate, BillingRate, BillingOthers, Term, PlaceIs, R.AddedBy, R.DateAdded, R.Stat, convert(nvarchar(150),V.VESSELNAME) as VESSELNAME, CONVERT(NVARCHAR(150),P.NAME) AS POD FROM TBL_RATES AS R LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_ItemListMasterData] AS CN ON R.CHARGES = CN.itemcode LEFT JOIN TBL_CURRENCY AS CURR ON R.Currency = CURR.ID LEFT JOIN TBL_BOOKING AS B ON R.BLNO = B.BLNO AND B.STAT = '1' LEFT JOIN TBL_VESSEL AS V ON B.MotherVessel = V.ID LEFT JOIN TBL_PORTS AS P ON B.PORTS = P.ID  WHERE R.STAT = '1' and CN.ITEMNAME IS NOT NULL AND R.BLNO = '" & blno & "'  order by sortis asc"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            getCountOfCharges = getCountOfCharges + 1
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Function
    Public Sub InputTextComplete(myrange As String, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, Color As System.Drawing.Color, BColor As Integer)


        With Sheet
            With .Range(myrange)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                If colWidth = 0 Then
                Else
                    .ColumnWidth = colWidth
                End If


                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If

                If BColor = 0 Then
                    .Interior.Pattern = Excel.XlPattern.xlPatternNone
                Else
                    .Interior.Pattern = Excel.XlPattern.xlPatternAutomatic
                    .Interior.ColorIndex = BColor
                End If

                .Font.Color = System.Drawing.ColorTranslator.ToOle(Color)
                .Cells(1, 1) = sTr

            End With
        End With
    End Sub
    Public Sub InputTextRFC(myrange As String, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, Color As System.Drawing.Color)


        With Sheet
            With .Range(myrange)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If

                '.interior.color = System.Drawing.ColorTranslator.ToOle(BColor)
                .Font.Color = System.Drawing.ColorTranslator.ToOle(Color)
                .Cells(1, 1) = sTr

            End With
        End With
    End Sub

    Public Sub InputTextCF(cellIs As Integer, RowIs As Integer, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, Color As System.Drawing.Color)


        With Sheet
            With .Cells(RowIs, cellIs)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If

                '.interior.color = System.Drawing.ColorTranslator.ToOle(BColor)
                .Font.Color = System.Drawing.ColorTranslator.ToOle(Color)
                .Cells(1, 1) = sTr

            End With
        End With
    End Sub

    Public Sub InputTextCFB(cellIs As Integer, RowIs As Integer, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet, Color As System.Drawing.Color, BColor As Integer)


        With Sheet
            With .Cells(RowIs, cellIs)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If

                If BColor = 0 Then
                    .Interior.Pattern = Excel.XlPattern.xlPatternNone
                Else
                    .Interior.Pattern = Excel.XlPattern.xlPatternAutomatic
                    .interior.colorindex = BColor
                End If


                .Font.Color = System.Drawing.ColorTranslator.ToOle(Color)
                .Cells(1, 1) = sTr

            End With
        End With
    End Sub


    Public Sub InputTextC(cellIs As Integer, RowIs As Integer, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet)


        With Sheet
            With .Cells(RowIs, cellIs)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If
                .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                .Cells(1, 1) = sTr
            End With
        End With
    End Sub

    Public Sub InputTextF(my_range As String, Merge As Boolean, rowHeight As Double, colWidth As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet)


        With Sheet
            With .Range(my_range)
                If Merge = True Then
                    .Merge()
                End If

                '''''''''''''''''''''
                .RowHeight = rowHeight
                '.ColumnWidth = colWidth

                ''''''''''''''''''''''''''

                'If BorderIs = "" Then

                'ElseIf BorderIs = "C" Then
                '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
                'End If

                If Horizontal_Alignment = "L" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
                ElseIf Horizontal_Alignment = "R" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
                ElseIf Horizontal_Alignment = "C" Then
                    .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                End If
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter

                '''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''

                .Font.Size = fontSize
                .Font.Name = FontName
                If strbold = True Then
                    .Font.Bold = True
                End If
                .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
                .Cells(1, 1) = sTr
            End With
        End With
    End Sub


    Public Function IfHas(sql As String) As Boolean
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(sql, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            IfHas = True
        Else
            IfHas = False
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Function

    Public Function HasAccess(FieldName As String, ValueIs As String, TransmittalType As String) As Boolean
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT " & FieldName & " FROM TBL_USERS WHERE STAT = '1' AND " & FieldName & " = " & ValueIs & " AND ID = '" & USER_ID & "'" ' AND SHOW_TRANSMITTAL = '" & TransmittalType & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            HasAccess = True
        Else
            HasAccess = False
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Function


    Public Sub PrintForView()
        'With frmPrintForm.crViewer
        '    .ShowGroupTreeButton = False
        '    .ShowPrintButton = True
        '    .Zoom(1)
        '    .ShowCopyButton = False
        '    .ShowExportButton = False
        '    .ShowRefreshButton = False
        '    .ShowParameterPanelButton = False
        '    .ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        'End With
    End Sub
    Public Sub LoadSizes(cmb As ComboBox)
        With cmb.Items
            .Clear()
            .Add("")
            .Add("10D")
            .Add("20D")
            .Add("40D")
            .Add("40H")
            .Add("20R")
            .Add("40R")
        End With

    End Sub
    Public Sub LoadForm(frm As Form, FrmTitle As String)
        With frm
            .Text = FrmTitle
            .Icon = My.Resources.icons8_ship_wheel_100__3_
            .StartPosition = FormStartPosition.CenterScreen
            .ShowInTaskbar = False
            .ShowDialog()
        End With
    End Sub


    Public Function FormatMoneyN(str As Double)

        If String.IsNullOrEmpty(str) Then
            FormatMoneyN = "0.00"
            Exit Function
        End If
        If Not IsNumeric(str) Then
            FormatMoneyN = "0.00"
            Exit Function
        End If
        If Not IsNumeric(str) Then
            FormatMoneyN = "0.00"
            Exit Function
        End If

        FormatMoneyN = str.ToString("#,0.00' ';(#,0.00)")
    End Function


    Public Function FormatMoneyNDecPLace(str As Double, nDec As Integer)

        If String.IsNullOrEmpty(str) Then
            FormatMoneyNDecPLace = "0.00"
            Exit Function
        End If
        If Not IsNumeric(str) Then
            FormatMoneyNDecPLace = "0.00"
            Exit Function
        End If
        If Not IsNumeric(str) Then
            FormatMoneyNDecPLace = "0.00"
            Exit Function
        End If
        If nDec = 2 Then
            FormatMoneyNDecPLace = str.ToString("#,0.00'';(#,0.00)")
        ElseIf nDec = 3 Then
            FormatMoneyNDecPLace = str.ToString("#,0.000'';(#,0.000)")
        ElseIf nDec = 4 Then
            FormatMoneyNDecPLace = str.ToString("#,0.000'';(#,0.0000)")
        Else
            FormatMoneyNDecPLace = str.ToString("#,0.00'';(#,0.00)")
        End If

    End Function


    Public Function FormatMoney(str As String)
        If String.IsNullOrEmpty(str) Then
            FormatMoney = "0.00"
            Exit Function
        End If
        If Not IsNumeric(str) Then
            FormatMoney = "0.00"
            Exit Function
        End If
        FormatMoney = Format(CDbl(str), "###,###,##0.00")


    End Function
    Public Function KValWONextLine(str As String) As String
        str = Replace(str, "'", "''")
        str = Replace(str, vbNewLine, "")
        str = Trim(UCase(str))
        KValWONextLine = str
    End Function
    Public Function KVal(str As String) As String
        str = Replace(str, "'", "''")
        str = Trim(UCase(str))
        KVal = str
    End Function

    Public Function KValNoEnter(str As String) As String
        str = Replace(str, "'", "''")
        str = Replace(str, vbCr, "")
        str = Trim(UCase(str))
        KValNoEnter = str
    End Function

    Public Function KValnQuote(str As String) As String
        str = Replace(str, "'", "'")
        str = Trim(UCase(str))
        KValnQuote = str
    End Function


    Public Function KValNCase(str As String) As String
        str = Replace(str, "'", "''")
        str = Trim(str)
        KValNCase = str
    End Function


    Public Function GetRyzk(str As String, ConnectionIs As String) As String
        Dim Dbo As New SQLClass
        If ConnectionIs = "" Then
            Dbo.SqlCon.Open()
        End If
        If ConnectionIs = "ACCTG" Then
            Dbo.SqlAcctgCon.Open()
        End If
        If ConnectionIs = "L" Then
            Dbo.SqlCon.Open()
        End If
        If ConnectionIs = "S" Then
            Dbo.SqlCon.Open()
        End If
        If ConnectionIs = "SLC" Then
            Dbo.SqlCon.Open()
        End If



        If ConnectionIs = "L" Then
            Dbo.SQLCmd = New SqlClient.SqlCommand(str, Dbo.SqlCon)
        End If
        If ConnectionIs = "ACCTG" Then
            Dbo.SQLCmd = New SqlClient.SqlCommand(str, Dbo.SqlAcctgCon)
        End If
        If ConnectionIs = "" Then
            Dbo.SQLCmd = New SqlClient.SqlCommand(str, Dbo.SqlCon)
        End If
        If ConnectionIs = "S" Then
            Dbo.SQLCmd = New SqlClient.SqlCommand(str, Dbo.SqlCon)
        End If
        If ConnectionIs = "SLC" Then
            Dbo.SQLCmd = New SqlClient.SqlCommand(str, Dbo.SqlCon)
        End If


        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        NoRecordFound = ""
        GetRyzk = NoRecordFound
        Do While Dbo.reader.Read
            GetRyzk = Dbo.reader(0).ToString
        Loop
        Dbo.reader.Close()



        If ConnectionIs = "" Then
            Dbo.SqlCon.Close()
        End If
        If ConnectionIs = "ACCTG" Then
            Dbo.SqlAcctgCon.Close()
        End If
        If ConnectionIs = "L" Then
            Dbo.SqlCon.Close()
        End If
        If ConnectionIs = "S" Then
            Dbo.SqlCon.Close()
        End If
        If ConnectionIs = "SLC" Then
            Dbo.SqlCon.Close()
        End If




    End Function

    Public Function HasPettyCash(SYSREF, BLNO, Charges, MultBy, Currency, Amount, Fao, Parameter, Size) As Boolean
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "Select ID, SERIES FROM TBL_PETTYCASH WHERE SYSREF = '" & SYSREF & "' AND  BLNO = '" & KVal(BLNO) & "'  AND Charges = '" & KVal(Charges) & "' AND MultBy  = '" & KVal(MultBy) & "' AND Currency = '" & KVal(Currency) & "' AND  Amount = '" & SaveMoney(Amount) & "'   AND Fao = '" & KVal(Fao) & "' AND PARAM1 = '" & KVal(Parameter) & "' AND Size = '" & KVal(Size) & "' AND STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            If Not String.IsNullOrEmpty(Dbo.reader(1).ToString) Then
                HasPettyCash = True
            Else
                HasPettyCash = False
            End If
        Else
            HasPettyCash = False
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Function

    Public Function HasRequestForPayment(SYSREF, BLNO, Charges, MultBy, Currency, Amount, Fao, Parameter, Size) As Boolean
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ID,SERIES FROM TBL_REQUEST_FOR_PAYMENT WHERE SYSREF = '" & SYSREF & "' AND  BLNO = '" & KVal(BLNO) & "'  AND Charges = '" & KVal(Charges) & "' AND MultBy  = '" & KVal(MultBy) & "' AND Currency = '" & KVal(Currency) & "' AND  Amount = '" & SaveMoney(Amount) & "'   AND Fao = '" & KVal(Fao) & "' AND PARAM1 = '" & KVal(Parameter) & "' AND Size = '" & KVal(Size) & "' and stat = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            If Not String.IsNullOrEmpty(Dbo.reader(1).ToString) Then
                HasRequestForPayment = True
            Else
                HasRequestForPayment = False
            End If
        Else
            HasRequestForPayment = False
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Function

    Public Sub SetJob(sql As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(sql, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Function SaveMoney(str As String) As Double
        If String.IsNullOrEmpty(str) Then
            str = "0.00"
        End If
        If Not IsNumeric(str) Then
            str = "0.00"
        End If

        str = Trim(Format(CDbl(str), "########0.00"))

        SaveMoney = str
    End Function
    Public Function SaveMoneyNDec(str As String, nDec As Integer) As Double
        If String.IsNullOrEmpty(str) Then
            str = "0.00"
        End If
        If Not IsNumeric(str) Then
            str = "0.00"
        End If
        If nDec = 1 Then
            str = Trim(Format(CDbl(str), "########0.0"))
        ElseIf nDec = 2 Then
            str = Trim(Format(CDbl(str), "########0.00"))
        ElseIf nDec = 3 Then
            str = Trim(Format(CDbl(str), "########0.000"))
        ElseIf nDec = 4 Then
            str = Trim(Format(CDbl(str), "########0.0000"))
        Else
            str = Trim(Format(CDbl(str), "########0.00"))
        End If


        SaveMoneyNDec = str
    End Function

    Public Function FormatWDecimal(str As String, formatWDec As String) As Double
        If String.IsNullOrEmpty(str) Then
            str = "0.000"
        End If
        If Not IsNumeric(str) Then
            str = "0.000"
        End If

        str = Trim(Format(CDbl(str), formatWDec))

        FormatWDecimal = str
    End Function

    Public Function HasFinal(sysref As String, refno As String, BLNO As String) As Boolean
        SQL = "SELECT ID FROM TBL_WORKFILE_PRINT WHERE STAT = '1' AND SYSREF = '" & sysref & "' AND REFNO = '" & refno & "' AND PARAM1 = 'FINAL' AND BLNO = '" & BLNO & "'"
        If GetRyzk(SQL, "L") <> NoRecordFound Then
            HasFinal = True
        Else
            HasFinal = False
            'Str = GetRyzk("Select COUNT(ID) FROM TBL_WORKFILE_PRINT WHERE STAT = '1' AND SYSREF = '" & sysref & "' AND REFNO = '" & refno & "'", "L")
        End If
    End Function

    'Public Function SpReplaceNextLine(str As String, nos As Integer) As String
    '    Dim spaceAre As String = ""
    '    'For i As Integer = Len(str) To nos - 1
    '    '    spaceAre = spaceAre + " "
    '    'Next
    '    spaceAre = Replace(str, vbCrLf, " ")
    '    'Spacer = str & spaceAre
    'End Function


    Public Function Spacer(str As String, nos As Integer) As String
        Dim spaceAre As String = ""
        For i As Integer = Len(str) To nos - 1
            spaceAre = spaceAre + " "
        Next
        'spaceAre = Replace(str, vbCrLf, " ")
        Spacer = str & spaceAre
    End Function


    'Public Sub InputText(my_range As String, Merge As Boolean, Horizontal_Alignment As String, Vertical_Alignment As String, sTr As String, strbold As Boolean, Sheet As Excel.Worksheet)


    '    With Sheet
    '        With .Range(my_range)
    '            If Merge = True Then
    '                .Merge()
    '            End If

    '            '''''''''''''''''''''
    '            '.RowHeight = rowHeight
    '            '.ColumnWidth = colWidth

    '            ''''''''''''''''''''''''''

    '            'If BorderIs = "" Then

    '            'ElseIf BorderIs = "C" Then
    '            '    .Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            '    .Borders.Weight = Excel.XlBorderWeight.xlMedium
    '            'End If

    '            If Horizontal_Alignment = "L" Then
    '                .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft
    '            ElseIf Horizontal_Alignment = "R" Then
    '                .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    '            ElseIf Horizontal_Alignment = "C" Then
    '                .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    '            End If

    '            If Vertical_Alignment = "T" Then
    '                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
    '            ElseIf Vertical_Alignment = "B" Then
    '                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
    '            End If

    '            '''''''''''''''''''''''''''''''''''

    '            '''''''''''''''''''''''''''''''''''''

    '            '.Font.Size = fontSize
    '            '.Font.Name = FontName
    '            If strbold = True Then
    '                .Font.Bold = True
    '            End If
    '            .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
    '            .Cells(1, 1) = sTr
    '        End With
    '    End With
    'End Sub

    'Public Sub nInputText(my_range As String, Merge As Boolean, rowHeight As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, sheet As Excel.Worksheet)
    '    With sheet
    '        With .Range(my_range)
    '            If Merge = True Then
    '                .Merge()
    '            End If
    '            .RowHeight = rowHeight
    '            '.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            If Horizontal_Alignment = "L" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
    '            ElseIf Horizontal_Alignment = "R" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    '            ElseIf Horizontal_Alignment = "C" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    '            End If
    '            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '            '.Borders.Weight = Excel.XlBorderWeight.xlMedium
    '            .Font.Size = fontSize
    '            .Font.Name = FontName
    '            If strbold = True Then
    '                .Font.Bold = True
    '            End If
    '            .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
    '            .Cells(1, 1) = sTr
    '        End With
    '    End With
    'End Sub

    'Public Sub nInputTextContent(my_range As String, Merge As Boolean, rowHeight As Double, fontSize As Integer, FontName As String, Horizontal_Alignment As String, sTr As String, strbold As Boolean, sheet As Excel.Worksheet)
    '    With sheet
    '        With .Range(my_range)
    '            If Merge = True Then
    '                .Merge()
    '            End If
    '            .RowHeight = rowHeight
    '            '.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            If Horizontal_Alignment = "L" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
    '            ElseIf Horizontal_Alignment = "R" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
    '            ElseIf Horizontal_Alignment = "C" Then
    '                .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    '            End If
    '            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '            '.Borders.Weight = Excel.XlBorderWeight.xlMedium
    '            .Font.Size = fontSize
    '            .Font.Name = FontName
    '            If strbold = True Then
    '                .Font.Bold = True
    '            End If
    '            .Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
    '            .Cells(1, 1) = sTr
    '        End With
    '    End With
    'End Sub

    Class Client
        Property BPListID As String
        Property nickName As String
        Property Address As String
        Property CardCode As String
    End Class


    Class ClientKY
        Property ID As String
        Property ClientName As String
        Property Clientaddress As String
        Property CLIENT_CODE As String
    End Class

    Class Depot
        Property Id As String
        Property Name As String
        Property AddressIs As String
        Property OperatingHrsStart As String
        Property OperationHrsEnd As String
        Property TelephoneNos As String
    End Class

    Public Sub LoadDepot(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Dim _DepotIs As New List(Of Depot)
        Do While Dbo.reader.Read
            _DepotIs.Add(New Depot With {.Id = Dbo.reader(0).ToString, .Name = KVal(Dbo.reader(1).ToString), .AddressIs = KVal(Dbo.reader(2).ToString), .OperatingHrsStart = Dbo.reader(3).ToString, .OperationHrsEnd = Dbo.reader(4).ToString, .TelephoneNos = KVal(Dbo.reader(5).ToString)})
        Loop
        cmb.DataSource = _DepotIs
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()
    End Sub

    'Public _Client As New List(Of Client)
    Public Sub LoadStrCleintAcctg(cmb As ComboBox, SQL As String)

        Dim Dbo As New SQLClass
        Dbo.SqlAcctgCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlAcctgCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)

        Dbo.reader = Dbo.SQLCmd.ExecuteReader

        Dim _Client As New List(Of Client)

        Do While Dbo.reader.Read
            _Client.Add(New Client With {.BPListID = KVal(Dbo.reader(0).ToString), .nickName = KValnQuote(Dbo.reader(1).ToString), .Address = KVal(Dbo.reader(2).ToString), .CardCode = KVal(Dbo.reader(3).ToString)})
        Loop
        cmb.DataSource = _Client
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlAcctgCon.Close()

    End Sub

    Public Sub LoadStrCleint(cmb As ComboBox, SQL As String)

        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)

        Dbo.reader = Dbo.SQLCmd.ExecuteReader

        Dim _Client As New List(Of ClientKY)

        Do While Dbo.reader.Read
            _Client.Add(New ClientKY With {.ID = KVal(Dbo.reader(0).ToString), .ClientName = KValnQuote(Dbo.reader(1).ToString), .Clientaddress = KVal(Dbo.reader(2).ToString)})
        Loop
        cmb.DataSource = _Client
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()

    End Sub

    Public Sub LoadStrCmbWithSame(SQL As String)

        'Call LoadStrCmb(cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1") & ")")
        'Call LoadStrCmb(cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1") & ")")
        'Call LoadStrCmb(CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1") & ")")
        'Call LoadStrCmb(CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1") & ")")
        'Call LoadStrCmb(cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1") & ")")

        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)

        With FrmInitialBooking.cmbLoading1
            .ValueMember = KVal(Dbo.table.Columns(0).ToString)
            .DisplayMember = KVal(Dbo.table.Columns(1).ToString)
            .DataSource = Dbo.table
            .SelectedIndex = -1
        End With

        With FrmInitialBooking.cmbLoading2
            .ValueMember = KVal(Dbo.table.Columns(0).ToString)
            .DisplayMember = KVal(Dbo.table.Columns(1).ToString)
            .DataSource = Dbo.table
            .SelectedIndex = -1
        End With

        With FrmInitialBooking.CmbMotherVesselLoading
            .ValueMember = KVal(Dbo.table.Columns(0).ToString)
            .DisplayMember = KVal(Dbo.table.Columns(1).ToString)
            .DataSource = Dbo.table
            .SelectedIndex = -1
        End With

        With FrmInitialBooking.CmbPOD1
            .ValueMember = KVal(Dbo.table.Columns(0).ToString)
            .DisplayMember = KVal(Dbo.table.Columns(1).ToString)
            .DataSource = Dbo.table
            .SelectedIndex = -1
        End With

        With FrmInitialBooking.cmbPOD2
            .ValueMember = KVal(Dbo.table.Columns(0).ToString)
            .DisplayMember = KVal(Dbo.table.Columns(1).ToString)
            .DataSource = Dbo.table
            .SelectedIndex = -1
        End With



        'cmb.ValueMember = KVal(Dbo.table.Columns(0).ToString)
        'cmb.DisplayMember = KVal(Dbo.table.Columns(1).ToString)
        'cmb.DataSource = Dbo.table
        ''cmb.Text = ""
        'cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()
    End Sub

    Public Sub LoadStrCmb(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        cmb.ValueMember = KVal(Dbo.table.Columns(0).ToString)
        cmb.DisplayMember = KVal(Dbo.table.Columns(1).ToString)
        cmb.DataSource = Dbo.table
        'cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadStrCmbPolPod(cmb As ComboBox, CmbPOD As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        cmb.ValueMember = KVal(Dbo.table.Columns(0).ToString)
        cmb.DisplayMember = KVal(Dbo.table.Columns(1).ToString)
        cmb.DataSource = Dbo.table
        'cmb.Text = ""
        cmb.SelectedIndex = -1

        CmbPOD.ValueMember = KVal(Dbo.table.Columns(0).ToString)
        CmbPOD.DisplayMember = KVal(Dbo.table.Columns(1).ToString)
        CmbPOD.DataSource = Dbo.table
        'cmb.Text = ""
        CmbPOD.SelectedIndex = -1


        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadStrCmbTrade(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        cmb.ValueMember = KVal(Dbo.table.Columns(0).ToString)
        cmb.DisplayMember = KVal(Dbo.table.Columns(1).ToString)
        cmb.DataSource = Dbo.table
        'cmb.Text = ""
        Dbo.SqlCon.Close()
    End Sub


    Class Charges
        Property itemListID As String
        Property itemCode As String
        Property itemName As String
    End Class

    Class ChargesFreetime
        Property ID As String
        Property CCODE As String
        Property CHARGENAME As String
    End Class

    Public Sub LoadCmbCharges(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlAcctgCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlAcctgCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Dim _Charges As New List(Of Charges)
        Do While Dbo.reader.Read
            _Charges.Add(New Charges With {.itemListID = Dbo.reader(0).ToString, .itemName = Dbo.reader(1).ToString, .itemCode = Dbo.reader(2).ToString})
        Loop
        cmb.DataSource = _Charges
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlAcctgCon.Close()
    End Sub

    Public Function getClientAttgCode(str As String)
        Dim a As String() = str.Split("-")
        If a.Count = 2 Then
            getClientAttgCode = Trim(a(1))
        Else
            getClientAttgCode = ""
        End If
    End Function

    Public Sub LoadCmbChargesFreetime(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Dim _Charges As New List(Of ChargesFreetime)
        Do While Dbo.reader.Read
            _Charges.Add(New ChargesFreetime With {.ID = Dbo.reader(0).ToString, .CHARGENAME = Dbo.reader(1).ToString, .CCODE = Dbo.reader(2).ToString})
        Loop
        cmb.DataSource = _Charges
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()
    End Sub

End Module
