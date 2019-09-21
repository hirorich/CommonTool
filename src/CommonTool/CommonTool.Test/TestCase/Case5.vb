Imports CommonTool.FileIO

Namespace TestCase

    ''' <summary>
    ''' ケース：INIセクション一覧読み込みテスト
    ''' </summary>
    Public Class Case5
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try
                Dim sections As String() = Nothing
                Dim control As IniControl = Nothing

                Try
                    sections = Nothing
                    control = New IniControl("..\..\INI\Test.ini")

                    sections = control.ReadSections()
                    If sections Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクションの取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション一覧: " & String.Join(", ", sections).Trim
                    End If

                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    sections = Nothing
                    control = New IniControl("..\..\INI\TestFoo.ini")

                    sections = control.ReadSections()
                    If sections Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクションの取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション一覧: " & String.Join(", ", sections).Trim
                    End If

                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

End Namespace
