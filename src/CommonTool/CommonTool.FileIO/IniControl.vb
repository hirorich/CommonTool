Imports System.Text
Imports CommonTool.FileIO.WinAPI

''' <summary>
''' iniファイル読み書きクラス
''' </summary>
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
        Me.m_filename = filename
    End Sub

    ''' <summary>
    ''' セクション一覧読み込み
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadSections() As String()
        Try

            ' 値読み込み
            Dim buffer As String = Space(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileSectionNames(buffer, buffer.Length - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ReadSections = buffer.Split(Constants.vbNullChar)

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' キー一覧読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <returns></returns>
    Public Function ReadKeys(ByVal section As String) As String()
        Try

            ' 値読み込み
            Dim buffer As String = Space(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileSection(section, buffer, buffer.Length - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ReadKeys = buffer.Split(Constants.vbNullChar)

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 値読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <param name="key">キー</param>
    ''' <returns></returns>
    Public Function ReadValue(ByVal section As String, ByVal key As String) As String
        Try

            ' 値読み込み
            Dim objBuilder As StringBuilder = New StringBuilder(1024)
            Dim intRet As Integer = Kernel32.GetPrivateProfileString(section, key, String.Empty, objBuilder, objBuilder.Capacity - 1, Me.m_filename)

            ' 失敗時は例外をスロー
            If intRet <= 0 Then
                Throw New Exception()
            End If

            ReadValue = objBuilder.ToString()
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
    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        Try
            ' 値書き込み
            Dim intRet As Integer = Kernel32.WritePrivateProfileString(section, key, value, Me.m_filename)

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
