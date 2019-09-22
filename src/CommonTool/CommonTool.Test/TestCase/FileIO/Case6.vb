Imports CommonTool.FileIO
Imports CommonTool.Test.TestCase

Namespace TestCase.FileIO

    ''' <summary>
    ''' ケース：INIセクション一覧読み込みテスト
    ''' </summary>
    Public Class Case6
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try

                Dim control As IniControl = New IniControl("..\..\INI\Test.ini")

                Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf & "ファイル: Test.ini"
                For Each sec As String In control.ReadSections()
                    Try
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf & "[" & sec & "]"
                        For Each key As String In control.ReadKeys(sec)
                            Try
                                Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf & "  " & key & "=" & control.ReadValue(sec, key)
                            Catch ex As Exception
                                Call LogUtil.WriteLog(ex)
                                Continue For
                            End Try
                        Next
                    Catch ex As Exception
                        Call LogUtil.WriteLog(ex)
                        Continue For
                    End Try
                Next

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

End Namespace
