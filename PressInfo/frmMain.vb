Imports Microsoft.Win32

Public Class frmMain
    Dim db As PressInfoEntities = New PressInfoEntities()
    Dim alanlar1() = {"Ticari Unvanı", "Kuruluş Tarihi", "Yetkili Kişiler", "Adres", "Tel", "Faks", "E-mail", "Web", "Özgeçmiş", "Yayıncılık Alanı", "ISBN Yayıncı Kodu"}
    Dim alanlar2() = {"Ticari Unvanı", "Kuruluş Tarihi", "Yetkili Kişiler", "Adres", "TEL", "FAX", "E-posta", "Internet", "Özgeçmiş", "Yayıncılık Alanı", "ISBN Yayıncı Kodu"}
    Dim alanlar3() = {"Ticari Unvanı", "Kuruluş Tarihi", "Yetkili Kişiler", "Adres", "TEL", "Telefax", "E-posta", "Internet", "Özgeçmiş", "Yayıncılık Alanı", "ISBN Yayıncı Kodu"}
    Dim no As Integer
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SetBrowserFeatureControl()
        'InitializeComponent()
        Me.Show()
        Dim list = db.Yayınevi.Where(Function(m) m.bitti = False).ToList()
        For Each item In list
            no = item.No
            Browser.Navigate(item.Link)
            Do Until Browser.ReadyState = WebBrowserReadyState.Complete
                Application.DoEvents()
                Threading.Thread.Sleep(5000)
            Loop
        Next
    End Sub
    'sayfa açışınca bilgileri bul
    Private Sub Browser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted
        Dim txt As String = ""
        Dim allelements As HtmlElementCollection = Browser.Document.GetElementsByTagName("table")
        For Each webpageelement As HtmlElement In allelements
            txt = webpageelement.InnerHtml
        Next
        If txt = "" Then Exit Sub
        'gereksiz veriyi sil
        txt = txt.Replace("<table border=""0"" cellspacing=""5"" cellpadding=""5"">", "").Replace("<tbody>", "").Replace("</tbody>", "").Replace("</table>", "")
        txt = txt.Replace("<a href=""", "").Replace(" target=""_blank"">", "").Replace("</a>", "").Replace("<span class=""et_bloom_bottom_trigger""></span>", "")
        txt = txt.Replace("font-family: Arial, Helvetica, sans-serif;", "").Replace("font-family: inherit;", "").Replace(" margin: 0px;", "").Replace(" padding: 0px;", "").Replace(" padding: 11px 0px 0px;", "").Replace(" border: 0px;", "")
        txt = txt.Replace(" font-style: inherit;", "").Replace(" font-stretch: inherit;", "").Replace(" font-size: 12px;", "").Replace(" line-height: 17px;", "").Replace(" vertical-align: baseline;", "").Replace(" outline: 0px;", "").Replace(" color: #393939;", "").Replace(" background-color: #fffefe;", "")
        txt = txt.Replace(" text-decoration: none;", "").Replace(" outline: none;", "").Replace("color: #393939;", "").Replace(" background-color: #fffefe;", "").Replace(" color: rgb(57, 57, 57);", "").Replace("  background-color: rgb(255, 254, 254);", "")
        txt = txt.Replace("color: rgb(57, 57, 57);", "").Replace("  background-color: rgb(255, 254, 254);", "").Replace("margin: 0px;", "").Replace(" border: 0px currentColor;", "").Replace(" border-image: none;", "").Replace("font: inherit;", "")
        txt = txt.Replace(" style=", "").Replace("mailto:", "").Replace("İletişim", "").Replace("&nbsp;", "").Replace("""", "").Replace(vbTab, "").Replace(vbCrLf, vbLf)
        txt = txt.Replace("</tr>", vbCrLf).Replace("<tr>", "").Replace("<td>", "").Replace("</td>", "").Replace("<br>", "").Replace("<p>", "").Replace("</p>", "").Replace("<span>", "").Replace("</span>", "")
        txt = txt.Trim()
        'clean empty lines
        Dim items = txt.Split(vbLf) : txt = ""
        For Each item In items
            If item.Trim() <> "" Then txt &= item.Trim() & vbLf
        Next
        'detayları bul
        If txt <> "" Then
            items = txt.Split(vbLf) : Dim ix As Integer = 0, alanlar(10) As String, adVar As Boolean, totalStr = ""
            For Each item In items
                adVar = False
                'ix bulunur
                For i = alanlar1.Length - 1 To 0 Step -1
                    If Strings.Left(item, alanlar1(i).Length) = alanlar1(i) Or Strings.Left(item, alanlar2(i).Length) = alanlar2(i) Or Strings.Left(item, alanlar3(i).Length) = alanlar3(i) Then
                        ix = i : adVar = True : totalStr = "" : Exit For
                    End If
                Next
                If adVar = True Then
                    'belki deger buradadır
                    item = item.Replace(alanlar3(ix), "").Replace(alanlar2(ix), "").Replace(alanlar1(ix), "").Trim()
                    If item <> "" Then
                        If item.Contains(">") Then item = item.Remove(0, item.IndexOf(">") + 1)
                        alanlar(ix) = item.Replace(":", "").Trim()
                    End If
                Else
                    If totalStr <> "" Then totalStr &= ", "
                    alanlar(ix) = item.Replace(":", "").Trim()
                End If
            Next
            'update db
            Dim s = db.UpdatePress(no, alanlar(0), alanlar(1), alanlar(2), alanlar(3), alanlar(4), alanlar(5), alanlar(6), alanlar(7), alanlar(8), alanlar(9), alanlar(10))
        End If
    End Sub
    'xtra
    Private Sub SetBrowserFeatureControlKey(feature As String, appName As String, value As UInteger)
        Using key = Registry.CurrentUser.CreateSubKey([String].Concat("Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature), RegistryKeyPermissionCheck.ReadWriteSubTree)
            key.SetValue(appName, value, RegistryValueKind.DWord)
        End Using
    End Sub
    Private Sub SetBrowserFeatureControl()
        ' http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

        ' FeatureControl settings are per-process
        Dim fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName)

        ' make the control is not running inside Visual Studio Designer
        If [String].Compare(fileName, "devenv.exe", True) = 0 OrElse [String].Compare(fileName, "XDesProc.exe", True) = 0 Then
            Return
        End If

        SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode())
        ' Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
        SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1)
        SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0)
        SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1)
    End Sub
    Private Function GetBrowserEmulationMode() As UInt32
        Dim browserVersion As Integer = 7
        Using ieKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Internet Explorer", RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.QueryValues)
            Dim version = ieKey.GetValue("svcVersion")
            If version Is Nothing Then
                version = ieKey.GetValue("Version")
                If version Is Nothing Then
                    Throw New ApplicationException("Microsoft Internet Explorer is required!")
                End If
            End If
            Integer.TryParse(version.ToString().Split("."c)(0), browserVersion)
        End Using

        Dim mode As UInt32 = 11000
        ' Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
        Select Case browserVersion
            Case 7
                mode = 7000
                ' Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                Exit Select
            Case 8
                mode = 8000
                ' Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                Exit Select
            Case 9
                mode = 9000
                ' Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                Exit Select
            Case 10
                mode = 10000
                ' Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                Exit Select
            Case Else
                ' use IE11 mode by default
                Exit Select
        End Select

        Return mode
    End Function
End Class
