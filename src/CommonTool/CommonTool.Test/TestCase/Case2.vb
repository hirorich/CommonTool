Imports CommonTool.FileIO

Namespace TestCase

    ''' <summary>
    ''' ケース：INI値読み込みテスト
    ''' </summary>
    Public Class Case2
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try
                Dim section As String = String.Empty
                Dim key As String = String.Empty

                Dim control As IniControl = New IniControl("..\..\INI\Test.ini")

                Try
                    section = "Section1"
                    key = "key1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section1"
                    key = "key2"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section1"
                    key = "key3"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section2"
                    key = "key1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section2"
                    key = "key2"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section2"
                    key = "key3"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section3"
                    key = "key1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section3"
                    key = "#key2"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section3"
                    key = "##key3"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section4"
                    key = "key4"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section4"
                    key = "key5"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section4"
                    key = "key6"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section3"
                    key = "key4"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section3"
                    key = "key5"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section3"
                    key = "key6"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    section = "Section5"
                    key = "key1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key2"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key3"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key4"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key5"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key6"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key7"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section5"
                    key = "key8"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    control = New IniControl("..\..\INI\Nothing.ini")
                    section = "Section1"
                    key = "key1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

End Namespace
