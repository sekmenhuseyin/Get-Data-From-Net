Public Class frmMain
    Dim il As Integer = 48, ilce As Integer = 1, sayfa As Integer = 1, ad As String, sayfaVar As Boolean, isLoaded As Boolean
    Dim db As MEBEntities = New MEBEntities()
    'frm load
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        'ad = db.GetIlceAd(il, ilce).FirstOrDefault()
        'ReloadFrame()
    End Sub
    'resize
    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        WebBrowser1.Height = Me.Height - 70
    End Sub
    'reload frame
    Private Sub ReloadFrame()
        Dim url = "http://www.meb.gov.tr/baglantilar/okullar/?ILKODU=" & il & "&ILCEKODU=" & ilce & "&SAYFANO=" & sayfa
        lblUrl1.Text = url.Replace("&", "&&") : WebBrowser1.Navigate(url)
    End Sub
    'tüm ilcelerde döngü yap
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim tbl = db.Ilces.OrderBy(Function(m) m.IlNo).ThenBy(Function(m) m.Kod).ToList()
        For Each item In tbl
            il = item.IlNo
            ilce = item.Kod
            sayfa = 1
            sayfaVar = True
            ad = db.GetIlceAd(il, ilce).FirstOrDefault()
            Do While sayfaVar = True
                isLoaded = False
                ReloadFrame()
                Application.DoEvents()
                Do While isLoaded = False
                    Threading.Thread.Sleep(1000)
                    Application.DoEvents()
                Loop
                sayfa += 1
            Loop
        Next
    End Sub
    'web 1
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
        If WebBrowser1.Document.Body.InnerHtml.Contains("Bulunan Kayıt Sayısı: 0") = True Then btnNext_Click("ilce", e) : Exit Sub
        'tüm tablolara bak
        Dim allelements As HtmlElementCollection = WebBrowser1.Document.GetElementsByTagName("table")
        For Each webpageelement As HtmlElement In allelements
            If webpageelement.TagName.ToLower() = "table" And webpageelement.GetAttribute("classname") = "table" Then
                txtLists.Text = webpageelement.InnerHtml
            End If
        Next
        'gereksiz veriyi sil
        txtLists.Text = txtLists.Text.Replace("<tbody>", "").Replace("</tbody>", "")
        txtLists.Text = txtLists.Text.Replace("<th></th>", "").Replace("<th>Harita</th>", "").Replace("<th>Bilgi</th>", "")
        txtLists.Text = txtLists.Text.Replace("</tr>", vbCrLf).Replace("<tr>", "").Replace(" align=""center""", "").Replace("<td>", "").Replace("</td>", vbTab)
        txtLists.Text = txtLists.Text.Replace("<a href=""", "").Replace(" target=""_blank"">", vbTab).Replace("</a>", "").Replace("<img src=""Help-icon.png"" border=""0"">", "")
        txtLists.Text = txtLists.Text.Replace("<img class=""harita"" style=""border: currentColor; border-image: none;"" src=""Maps-icon.png"" border=""0"" data-host=""", "").Replace("data-veri=", "")
        txtLists.Text = txtLists.Text.Replace("""", "").Replace(">", "").Replace("  ", " ").Replace(ad, " ")
        txtLists.Text = txtLists.Text.Trim()
        'sayfa kontrol
        If txtLists.Text = "" Then sayfaVar = False ': btnNext_Click("ilce", e)
        'kaydet ve geç
        btnSave_Click(sender, e)
        Application.DoEvents()
        isLoaded = True
    End Sub
    'reload
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If sender.ToString() = "ilce" Then
            Dim sonuc As Boolean = False
            Do While sonuc = False
                Dim tmp = db.GetIlceNo(il, ilce + 1).FirstOrDefault()
                If IsNothing(tmp) = True Then
                    ilce = 0
                    il += 1
                    If il > 81 Then Exit Sub
                Else
                    ilce = tmp
                    ad = db.GetIlceAd(il, ilce).FirstOrDefault()
                    sonuc = True
                End If
            Loop
        Else
            sayfa += 1
        End If
        ReloadFrame()
    End Sub
    'kaydet
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For Each line In txtLists.Text.Split(vbCrLf)
            Dim items = line.Split(vbTab)
            If items.Count > 1 Then Dim sonuc = db.InsertSchool(il, ilce, items(1), items(0), items(2))
        Next
        'btnNext_Click(sender, e)
    End Sub
End Class
