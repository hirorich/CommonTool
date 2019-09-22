Imports System.Text

Namespace WinAPI

    ''' <summary>
    ''' kernel32.dll のラッパークラス
    ''' </summary>
    Friend Class Kernel32

        ''' <summary>
        ''' コンストラクタ(非推奨)
        ''' </summary>
        Private Sub New()
        End Sub

        ''' <summary>
        ''' INIファイルからセクション一覧取得
        ''' </summary>
        ''' <param name="lpszReturnBuffer">取得した文字列</param>
        ''' <param name="nSize">取得領域のサイズ</param>
        ''' <param name="lpFileName">ファイル名</param>
        ''' <returns></returns>
        Friend Declare Function GetPrivateProfileSectionNames Lib "Kernel32.dll" Alias "GetPrivateProfileSectionNamesA" (
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
        Friend Declare Function GetPrivateProfileSection Lib "kernel32" Alias "GetPrivateProfileSectionA" (
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
        Friend Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (
            ByVal lpApplicationName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As StringBuilder,
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
        Friend Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (
            ByVal lpApplicationName As String,
            ByVal lpKeyName As String,
            ByVal lpString As String,
            ByVal lpFileName As String) As Integer

    End Class

End Namespace
