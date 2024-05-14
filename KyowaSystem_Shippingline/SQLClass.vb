Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class SQLClass

    'Dim ServerName As String = "G112617\SQLEXPRESS"
    'Dim ServerName As String = "192.168.10.19"
    'Dim ServerName As String = "KLOUD\SQLEXPRESS"
    'Dim ServerName As String = "ALIENWAREI7\SQLEXPRESS"
    'Dim ServerName As String = "122.3.66.174"
    'Dim ServerName As String = "KLOUD\SQLEXPRESS"



    'Dim ServerName As String = "192.168.10.114"


    Dim ServerName As String = "192.168.10.213"
    Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=r_KYOWA_v2;User=mis;Pwd=;Connect Timeout=300"}

    'Dim ServerName As String = "192.168.10.213"
    'Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=r_KYOWA_v2_TESTING;User=mis;Pwd=;Connect Timeout=300"}

    Dim ServerName2 As String = "192.168.10.87"
    Public SqlAcctgCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName2 & ";Database=ACCT_TEST;User=mis;Pwd=;Connect Timeout=300"}

    Dim ServerName4 As String = "104.248.176.159"
    Public MysqlCon As New MySqlConnection With {.ConnectionString = "Server=" & ServerName4 & ";Database=generalagent;User=root;Pwd=Test@12345;Connect Timeout=300"}



    'aaa

    'Dim ServerName As String = "DESKTOP-NSDPC98"
    'Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Initial Catalog=r_KYOWA_v2;Integrated Security=True"}

    ''Dim ServerName As String = "192.168.10.213"
    ''Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=r_KYOWA_v2_TESTING;User=mis;Pwd=;Connect Timeout=300"}

    'Dim ServerName2 As String = "DESKTOP-NSDPC98"
    'Public SqlAcctgCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName2 & ";Database=ACCT_TEST;Integrated Security=True"}





    ''''''''''''Dim ServerName As String = "DELL_KR\SQLEXPRESS"
    ''''''''''''Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=r_KYOWA_TEST_2;User=mis;Pwd=;Connect Timeout=300"}



    'Dim ServerName As String = "192.168.10.213"
    'Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=R_KYOWA_NEW_DEMO;User=mis;Pwd=;Connect Timeout=300"}


    'Dim ServerName As String = "DELL_KR\SQLEXPRESS"
    'Public SqlCon As New SqlConnection With {.ConnectionString = "Server=" & ServerName & ";Database=r_KYOWA_DEMO;User=mis;Pwd=;Connect Timeout=300"}





    Public MysqlCmd As New MySqlCommand

    Public SQLCmd As New SqlCommand
    Public OSQLCmd As New OleDb.OleDbCommand
    Public reader As IDataReader
    Public OReader As OleDb.OleDbDataReader

    Public record As IDataRecord
    Public lvi As New ListViewItem
    Public SQL As String
    Public adapter As SqlDataAdapter
    Public adapter2 As SqlDataAdapter
    Public adapter3 As SqlDataAdapter
    Public adapter4 As SqlDataAdapter
    Public adapter5 As SqlDataAdapter
    Public builder As SqlCommandBuilder
    Public table As New DataTable
    Public table2 As New DataTable
    Public table3 As New DataTable
    Public table4 As New DataTable
    Public bindingSource As New BindingSource
    Public rd As SqlDataReader
End Class
