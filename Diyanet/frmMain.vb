Public Class frmMain
    Dim diyanetAddress As String = "http://www.diyanet.gov.tr/tr/PrayerTime/WorldPrayerTimes"
    Dim db As DiyanetEntities = New DiyanetEntities()
    'form load
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get date
        lblMiladi.Text = ConvertDateCalendar(DateTime.Now.ToShortDateString, enumCalendars.Gregorian.ToString(), "tr-TR")
        lblHicri.Text = ConvertDateCalendar(DateTime.Now.ToShortDateString, enumCalendars.Hijri.ToString(), "tr-TR")
        'find diyanet url
        Dim req As WebRequest = WebRequest.Create(diyanetAddress)
        Try
            Dim res As WebResponse = req.GetResponse()
        Catch ex As WebException
            diyanetAddress = diyanetAddress.Replace("www", "web1")
        End Try
        'write url
        lblUrl.Text = diyanetAddress
        Browser.Navigate(diyanetAddress)
    End Sub
    'adter web load
    Private Sub Browser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted
        Dim Country As HtmlElement = Browser.Document.GetElementById("Country")

    End Sub
    'insert country
    Private Sub InsertCountry()
        Dim webelement As HtmlElement = Browser.Document.GetElementById("Country")
        Dim txt As String = webelement.InnerHtml
        txt = txt.Replace(" selected=""selected""", "").Replace("</option>", "").Replace("<option value=""", "").Replace(""">", ",")
        Dim list = txt.Split(vbLf)
        For Each item In list
            Dim tmp = item.Split(",")
            Dim sonuc = db.InsertCountry(tmp(0), tmp(1))
        Next
    End Sub
    'insert state/city
    Private Sub InsertState()
        Dim list = db.Ulkes.ToList()
        For Each item In list
            Dim txt As String = New WebClient().DownloadString("http://www.diyanet.gov.tr/PrayerTime/FillState?countryCode=" & item.No)
            txt = txt.Replace("Disabled", "").Replace("false", "").Replace("Group", "").Replace("null", "").Replace("Selected", "").Replace("Text", "").Replace("Value", ";")
            txt = txt.Replace("{", "").Replace("}", vbLf).Replace("[", "").Replace("]", "").Replace("""", "").Replace(":", "").Replace(",", "")
            Dim list2 = txt.Split(vbLf)
            For Each item2 In list2
                Dim tmp = item2.Split(";")
                If tmp.Length > 1 Then Dim sonuc = db.InsertState(item.No, tmp(1), tmp(0))
            Next
        Next
    End Sub
    'insert city/town
    Private Sub InsertCity()
        Dim list = db.Sehirs.Where(Function(m) m.UlkeNo = 1 Or m.UlkeNo = 2 Or m.UlkeNo = 33).ToList()
        For Each item In list
            Dim txt As String = New WebClient().DownloadString("http://www.diyanet.gov.tr/PrayerTime/FillCity?itemId=" & item.No)
            txt = txt.Replace("Disabled", "").Replace("false", "").Replace("Group", "").Replace("null", "").Replace("Selected", "").Replace("Text", "").Replace("Value", ";")
            txt = txt.Replace("{", "").Replace("}", vbLf).Replace("[", "").Replace("]", "").Replace("""", "").Replace(":", "").Replace(",", "")
            Dim list2 = txt.Split(vbLf)
            For Each item2 In list2
                Dim tmp = item2.Split(";")
                If tmp.Length > 1 Then Dim sonuc = db.InsertState(item.No, tmp(1), tmp(0))
            Next
        Next
    End Sub
End Class
