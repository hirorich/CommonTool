Imports System.Text
Imports CommonTool.FileIO.WinAPI

''' <summary>
''' iniファイル読み書きクラス
''' </summary>
''' <remarks>空文字のセクション、キーは無視する</remarks>
Public Class IniControl

    ''' <summary>
    ''' 読み書き対象ファイル
    ''' </summary>
    Private m_filename As String

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="filename">読み書き対象ファイル</param>
    Public Sub New(ByVal filename As String)
        Me.m_filename = filename.Trim
    End Sub

    ''' <summary>
    ''' セクション一覧読み込み
    ''' </summary>
    ''' <returns>セクション一覧</returns>
    ''' <remarks>空文字のセクションは取得しない</remarks>
    Public Function ReadSections() As String()
        Try

            ' 値読み込み
            Dim buffer As String = Space(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileSectionNames(buffer, buffer.Length - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ' 空白以外を取得
            Dim objSectionList As List(Of String) = New List(Of String)
            For Each sec As String In buffer.Trim.Split(Constants.vbNullChar)

                ' セクションが空白の場合飛ばす
                If String.IsNullOrWhiteSpace(sec) Then
                    Continue For
                End If

                objSectionList.Add(sec.Trim)
            Next

            ' 取得数が0の場合は例外をスロー
            If objSectionList.Count = 0 Then
                Throw New Exception()
            End If

            ReadSections = objSectionList.ToArray

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' キー一覧読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <returns>キー一覧</returns>
    ''' <remarks>空文字のセクション、キーは取得しない</remarks>
    Public Function ReadKeys(ByVal section As String) As String()
        Try

            ' セクションの入力チェック
            If String.IsNullOrWhiteSpace(section) Then
                Throw New Exception()
            End If

            ' 値読み込み
            Dim buffer As String = Space(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileSection(section.Trim, buffer, buffer.Length - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ' 空白以外からキーを取得
            Dim objKeyList As List(Of String) = New List(Of String)
            Dim key As String = String.Empty
            For Each keyvalue As String In buffer.Trim.Split(Constants.vbNullChar)

                ' キーと値のセットが空白の場合飛ばす
                If String.IsNullOrWhiteSpace(keyvalue) Then
                    Continue For
                End If

                ' キーが空白の場合飛ばす
                key = keyvalue.Trim.Split("=")(0)
                If String.IsNullOrWhiteSpace(key) Then
                    Continue For
                End If

                objKeyList.Add(key.Trim)
            Next

            ' 取得数が0の場合は例外をスロー
            If objKeyList.Count = 0 Then
                Throw New Exception()
            End If

            ReadKeys = objKeyList.ToArray

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 値読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <param name="key">キー</param>
    ''' <returns>値</returns>
    ''' <remarks>空文字のセクション、キーは取得しない</remarks>
    Public Function ReadValue(ByVal section As String, ByVal key As String) As String
        Try

            ' セクション、キーの入力チェック
            If String.IsNullOrWhiteSpace(section) Then
                Throw New Exception()
            End If
            If String.IsNullOrWhiteSpace(key) Then
                Throw New Exception()
            End If

            ' 値読み込み
            Dim objBuilder As StringBuilder = New StringBuilder(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileString(section.Trim, key.Trim, String.Empty, objBuilder, objBuilder.Capacity - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ReadValue = objBuilder.ToString().Trim
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 値書き込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <param name="key">キー</param>
    ''' <param name="value">値</param>
    ''' <remarks>空文字のセクション、キーは書き込まない</remarks>
    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        Try

            ' セクション、キー、値の入力チェック
            If String.IsNullOrWhiteSpace(section) Then
                Throw New Exception()
            End If
            If String.IsNullOrWhiteSpace(key) Then
                Throw New Exception()
            End If
            If value Is Nothing Then
                Throw New Exception()
            End If

            ' 値書き込み
            Dim intRet As Integer = Kernel32.WritePrivateProfileString(section.Trim, key.Trim, value.Trim, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub



    ''' <summary>
    ''' エスケープ文字変換
    ''' </summary>
    ''' <param name="strSet">設定文字列</param>
    ''' <returns>変換後文字列</returns>
    Private Shared Function SetEscape(ByVal strSet As String) As String
        Dim strEscape As String() = {";", "#", "=", ":"}
        Dim strRet As String = strSet
        Try
            For Each esc As String In strEscape
                strRet = strRet.Replace(esc, "\" & esc)
            Next
            SetEscape = strRet
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' エスケープ文字解除
    ''' </summary>
    ''' <param name="strSet">設定文字列</param>
    ''' <returns>変換後文字列</returns>
    Private Shared Function ResetEscape(ByVal strSet As String) As String
        Dim strEscape As String() = {";", "#", "=", ":"}
        Dim strRet As String = strSet
        Try
            For Each esc As String In strEscape
                strRet = strRet.Replace("\" & esc, esc)
            Next
            ResetEscape = strRet
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
