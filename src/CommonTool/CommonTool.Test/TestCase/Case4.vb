Imports CommonTool.FileIO

Namespace TestCase

    ''' <summary>
    ''' ケース：INIキー一覧読み込みテスト
    ''' </summary>
    Public Class Case4
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try
                Dim section As String = String.Empty
                Dim keys As String() = Nothing

                Dim control As IniControl = New IniControl("..\..\INI\Test.ini")

                Try
                    section = "Section1"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section2"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section3"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section4"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section5"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section6"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section7"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section8"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
                    End If
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try


                Try
                    control = New IniControl("..\..\INI\Nothing.ini")
                    section = "Section1"
                    keys = control.ReadKeys(section)
                    If keys Is Nothing Then
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & " の取得結果はNothing"
                    Else
                        Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                            "セクション " & section & ": " & String.Join(", ", keys).Trim
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
