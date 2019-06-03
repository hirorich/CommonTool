Namespace LOG

    ''' <summary>
    ''' ログ出力共通クラス
    ''' </summary>
    Public Class LogTool

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Private Shared instance As ILogParts

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Public Shared WriteOnly Property LogInstance As ILogParts
            Set(value As ILogParts)

                ' 実装クラスを既に保持する場合解放する
                If LogTool.instance IsNot Nothing Then
                    Call LogTool.instance.Dispose()
                End If

                ' 実装クラスを指定する
                LogTool.instance = value

            End Set
        End Property

        ''' <summary>
        ''' ログ出力フラグ
        ''' </summary>
        Private Shared flg_output As Boolean = True

        ''' <summary>
        ''' ログ出力フラグ
        ''' </summary>
        ''' <returns></returns>
        Public Shared Property Output As Boolean
            Get
                Return LogTool.flg_output
            End Get
            Set(value As Boolean)
                LogTool.flg_output = value
            End Set
        End Property

        Private Sub New()
        End Sub

        ''' <summary>
        ''' message の内容をログ出力する
        ''' </summary>
        ''' <param name="message">出力メッセージ</param>
        ''' <param name="parameters">パラメータ</param>
        Public Shared Sub WriteLog(ByVal message As String, Optional ByVal parameters As List(Of Object) = Nothing)
            Dim tool As ILogParts

            ' ログ出力を行わない場合処理を抜ける
            If Not LogTool.flg_output Then
                Exit Sub
            End If

            Try

                ' 実装クラスの指定有無によって使用するインスタンスを切り替える
                If LogTool.instance IsNot Nothing Then
                    tool = LogTool.instance
                Else
                    tool = DefaultLogPartsImpl.CreateInstance()
                End If

                ' message の内容をログ出力する
                Call tool.WriteLog(message, parameters)

            Catch ex As Exception

                ' 例外は潰す

            End Try

        End Sub

        ''' <summary>
        ''' 発生した例外の内容をログに出力する
        ''' </summary>
        ''' <param name="e">Exception</param>
        ''' <param name="parameters">パラメータ</param>
        Public Shared Sub WriteLog(ByVal e As Exception, Optional ByVal parameters As List(Of Object) = Nothing)
            Dim tool As ILogParts

            ' ログ出力を行わない場合処理を抜ける
            If Not LogTool.flg_output Then
                Exit Sub
            End If

            Try

                ' 実装クラスの指定有無によって使用するインスタンスを切り替える
                If LogTool.instance IsNot Nothing Then
                    tool = LogTool.instance
                Else
                    tool = DefaultLogPartsImpl.CreateInstance()
                End If

                ' 例外の内容をログに出力
                Call tool.WriteLog(e, parameters)

            Catch ex As Exception

                ' 例外は潰す

            End Try

        End Sub

    End Class

End Namespace
