Imports System.Data.SqlClient

Public Class frmMain
    Dim conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=NamazVaktim;Trusted_Connection=True;MultipleActiveResultSets=True;") : Dim cmd As SqlCommand : Dim sdr As SqlDataReader
    Dim bSource As New BindingSource() : Dim dataAdapter As New SqlDataAdapter() : Dim table As New DataTable() : Dim commandBuilder As SqlCommandBuilder
    Dim Sql As String : Dim rowid As Integer = 0
    Private Property pageready As Boolean = False
    Dim resultready, exitter As Boolean
    Dim counter As Integer
    'form load
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sql = "SELECT top (1000) Ilce._id, Ilce.Kible, Ilce.Ad+','+Ulke.Ad AS ilce FROM Ulke INNER JOIN Sehir ON Ulke._id = Sehir.Ulke_id INNER JOIN Ilce ON Sehir._id = Ilce.Sehir_id WHERE Ilce.Kible IS NULL"
        bSource = New BindingSource() : table = New DataTable : dgv.DataSource = bSource : dataAdapter = New SqlDataAdapter(Sql, conn) : commandBuilder = New SqlCommandBuilder(dataAdapter) : dataAdapter.Fill(table) : bSource.DataSource = table
        exitter = False
    End Sub
    'dgv rows loop
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False : btnStop.Enabled = True
        ProgressBar1.Visible = True : ProgressBar1.Maximum = dgv.Rows.Count : ProgressBar1.Value = 0
        exitter = False
        For Each row As DataGridViewRow In dgv.Rows
            resultready = False : counter = 0
            WebNavigate(row)
            If exitter = True Then Exit For
            While counter < 2
                If exitter = True Then Exit For
                Application.DoEvents()
            End While
            row.Selected = True
            dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows(0).Index
            row.Cells("Kible").Value = web1.Document.Body.InnerHtml
            Try
                ProgressBar1.Value += 1
            Catch ex As Exception
            End Try
        Next
        ProgressBar1.Visible = False
        btnStart.Enabled = True : btnStop.Enabled = False
    End Sub
    'stopper
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        exitter = True
        btnStart.Enabled = True : btnStop.Enabled = False
    End Sub
    'saver
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        conn.Open()
        For Each row As DataGridViewRow In dgv.Rows
            row.Selected = True
            dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows(0).Index
            If row.Cells("Kible").Value.ToString() = "" Then Exit For
            cmd = New SqlCommand("Update Ilce set Kible=" & row.Cells("Kible").Value & " where _id=" & row.Cells("_id").Value, conn)
            cmd.ExecuteNonQuery()
        Next
        conn.Close()
        frmMain_Load(sender, e)
    End Sub
    'web1
    Private Sub WebNavigate(row As DataGridViewRow)
        Dim ilce As String = row.Cells("ilce").Value
        If ilce.Contains("(") = True And ilce.Contains(")") = True Then
            Dim ekle As Boolean = True
            Dim tmp As String = ""
            For i As Integer = 0 To ilce.Length - 1
                If ilce(i) = "(" Then ekle = False
                If ekle = True Then tmp &= ilce(i)
                If ilce(i) = ")" Then ekle = True
            Next
            ilce = tmp
        End If
        web1.Navigate("file:///" & Application.StartupPath & "/find.html?s=" & ilce)
    End Sub
    Private Sub web1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles web1.DocumentCompleted
        counter += 1
    End Sub
#Region "Page Loading Functions"
    Private Sub WaitForPageLoad()
        AddHandler web1.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            If exitter = True Then Exit While
            Application.DoEvents()
        End While
        pageready = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If web1.ReadyState = WebBrowserReadyState.Complete Then
            pageready = True
            RemoveHandler web1.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub

#End Region
End Class
