Namespace WinAPI

    Friend Class Kernel32

        ''' <summary>
        ''' INIファイルからセクション一覧取得
        ''' </summary>
        ''' <param name="lpszReturnBuffer">取得した文字列</param>
        ''' <param name="nSize">取得領域のサイズ</param>
        ''' <param name="lpFileName">ファイル名</param>
        ''' <returns></returns>
        Private Declare Function GetPrivateProfileSectionNames Lib "Kernel32.dll" Alias "GetPrivateProfileSectionNamesA" (
            ByVal lpszReturnBuffer As String,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer

        ''' <summary>
        ''' INIファイルからセクション内のキーと値を取得
        ''' </summary>
        ''' <param name="lpAppName">セクション</param>
        ''' <param name="lpReturnedString">取得した文字列</param>
        ''' <param name="nSize">取得領域のサイズ</param>
        ''' <param name="lpFileName">ファイル名</param>
        ''' <returns></returns>
        Private Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (
            ByVal lpAppName As String,
            ByVal lpReturnedString As String,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer

        ''' <summary>
        ''' INIファイルから値を読み込む
        ''' </summary>
        ''' <param name="lpApplicationName">セクション</param>
        ''' <param name="lpKeyName">キー</param>
        ''' <param name="lpDefault">取得失敗時の値</param>
        ''' <param name="lpReturnedString">取得した文字列</param>
        ''' <param name="nSize">取得領域のサイズ</param>
        ''' <param name="lpFileName">ファイル名</param>
        ''' <returns></returns>
        Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (
            ByVal lpApplicationName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As String,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer

        ''' <summary>
        ''' INIファイルに値を書き込む
        ''' </summary>
        ''' <param name="lpApplicationName">セクション</param>
        ''' <param name="lpKeyName">キー</param>
        ''' <param name="lpString">書き込む値</param>
        ''' <param name="lpFileName">ファイル名</param>
        ''' <returns></returns>
        Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (
            ByVal lpApplicationName As String,
            ByVal lpKeyName As String,
            ByVal lpString As String,
            ByVal lpFileName As String) As Integer

        ''' <summary>
        ''' セクション一覧読み込み
        ''' </summary>
        ''' <param name="filename">読み書き対象ファイル</param>
        ''' <returns></returns>
        Friend Shared Function ReadSections(ByVal filename As String) As String()
            Try

            Catch ex As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' キー一覧読み込み
        ''' </summary>
        ''' <param name="filename">読み書き対象ファイル</param>
        ''' <param name="section">セクション</param>
        ''' <returns></returns>
        Friend Shared Function ReadKeys(ByVal filename As String, ByVal section As String) As String()
            Try

            Catch ex As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' 値読み込み
        ''' </summary>
        ''' <param name="filename">読み書き対象ファイル</param>
        ''' <param name="section">セクション</param>
        ''' <param name="key">キー</param>
        ''' <returns></returns>
        Friend Shared Function ReadValue(ByVal filename As String, ByVal section As String, ByVal key As String) As String
            Try

            Catch ex As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' 値書き込み
        ''' </summary>
        ''' <param name="filename">読み書き対象ファイル</param>
        ''' <param name="section">セクション</param>
        ''' <param name="key">キー</param>
        ''' <param name="value">値</param>
        Friend Shared Sub WriteValue(ByVal filename As String, ByVal section As String, ByVal key As String, ByVal value As String)
            Try

            Catch ex As Exception
                Throw
            End Try
        End Sub

    End Class

End Namespace
