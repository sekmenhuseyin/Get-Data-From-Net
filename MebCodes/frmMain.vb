Public Class frmMain
    Dim il As Integer = 1, ilce As Integer = 18
    Dim db As MEBEntities = New MEBEntities()
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUrl1.Text = "http://www.meb.gov.tr/baglantilar/okullar/?ILKODU=" & il & "&ILCEKODU=" & ilce
        WebBrowser1.Navigate(lblUrl1.Text)
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        ''iller
        'Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
        'For Each webpageelement As HtmlElement In allelements
        '    If webpageelement.Id = "jumpMenu5" Then txtLists.Text = webpageelement.InnerHtml
        'Next
        'txtLists.Text = txtLists.Text.Replace("<option value="""">İL</option>", "")
        'txtLists.Text = txtLists.Text.Replace(" selected=""selected""", "")
        'txtLists.Text = txtLists.Text.Replace("</option>", vbCrLf)
        'txtLists.Text = txtLists.Text.Replace("<option value=""?ILKODU=", "")
        'txtLists.Text = txtLists.Text.Replace(""">", vbTab)

        ''ilçeler
        'Dim allelements As HtmlElementCollection = WebBrowser1.Document.All
        'For Each webpageelement As HtmlElement In allelements
        '    If webpageelement.Id = "jumpMenu6" Then txtLists.Text = webpageelement.InnerHtml
        'Next
        'txtLists.Text = txtLists.Text.Replace("<option value=""?ILKODU=" & il & "&amp;ILCEKODU=0"">Tüm ilçeler</option>", "")
        'txtLists.Text = txtLists.Text.Replace(" selected=""selected""", "")
        'txtLists.Text = txtLists.Text.Replace("</option>", vbCrLf)
        'txtLists.Text = txtLists.Text.Replace("<option value=""?ILKODU=" & il & "&amp;ILCEKODU=", "1" & vbTab & il & vbTab)
        'txtLists.Text = txtLists.Text.Replace(""">", vbTab)

        'okullar
        If WebBrowser1.Document.Body.InnerHtml.Contains("Bulunan Kayıt Sayısı: 0") = True Then btnNext_Click(sender, e) : Exit Sub


    End Sub
    'reload
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim sonuc As Boolean = False
        Do While sonuc = False
            Dim tmp = db.GetIlceNo(il, ilce + 1).FirstOrDefault()
            If IsNothing(tmp) = True Then
                ilce = 0
                il += 1
            Else
                ilce = tmp
                sonuc = True
            End If
        Loop
        frmMain_Load(sender, e)
    End Sub
End Class
