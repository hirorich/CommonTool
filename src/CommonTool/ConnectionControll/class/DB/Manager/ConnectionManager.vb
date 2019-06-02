Imports LogUtil.LOG

Namespace DB

    ''' <summary>
    ''' 接続情報管理クラス
    ''' </summary>
    Public MustInherit Class ConnectionManager
        Implements IDisposable

        ''' <summary>
        ''' 接続情報一覧
        ''' </summary>
        Private dbcontrollers As Dictionary(Of String, ConnectionController)

        Protected Friend Sub New()
            Me.dbcontrollers = New Dictionary(Of String, ConnectionController)
        End Sub

        ''' <summary>
        ''' 接続情報を追加
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="controller">レコード操作クラス</param>
        ''' <returns>True:成功 / False:失敗</returns>
        Protected Function Add(ByVal dbname As String, ByVal controller As ConnectionController) As Boolean
            Try

                ' 接続情報追加
                Call Me.dbcontrollers.Add(dbname.Trim, controller)
                Call LogTool.WriteLog(dbname.Trim & "への接続情報を追加しました。")
                Add = True

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("接続情報の追加に失敗しました。", ex))
                Call controller.Dispose()
                Add = False
            End Try
        End Function

        ''' <summary>
        ''' 接続情報を削除
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function Remove(ByVal dbname As String) As Boolean
            Dim controller As ConnectionController

            ' 存在しない場合
            If Not Me.Exists(dbname) Then
                LogTool.WriteLog("指定した接続先が追加されていません。")
                Return False
            End If

            Try

                ' 接続情報解放
                controller = Me.CreateDbController(dbname)
                Call controller.Dispose()
                controller = Nothing

                ' 接続情報削除
                Remove = Me.dbcontrollers.Remove(dbname.Trim)
                Call LogTool.WriteLog(dbname.Trim & "への接続情報を削除しました。")

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("接続情報の削除に失敗しました。", ex))
                Remove = False
            End Try
        End Function

        ''' <summary>
        ''' 接続情報の存在チェック
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <returns>True:存在する / False:存在しない</returns>
        Public Function Exists(ByVal dbname As String) As Boolean
            Try

                ' 接続先存在確認
                Exists = Me.dbcontrollers.ContainsKey(dbname.Trim)

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("接続情報の存在チェックに失敗しました。", ex))
                Exists = False
            End Try
        End Function

        ''' <summary>
        ''' 接続先を基にレコード操作クラスを取得
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <returns>レコード操作クラス</returns>
        Protected Function CreateDbController(ByVal dbname As String) As ConnectionController

            ' 存在しない場合
            If Not Me.Exists(dbname) Then
                LogTool.WriteLog("指定した接続先が追加されていません。")
                Return Nothing
            End If

            Try

                ' 接続情報取得
                CreateDbController = Me.dbcontrollers.Item(dbname.Trim)

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("接続情報の取得に失敗しました。", ex))
                CreateDbController = Nothing
            End Try
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: マネージド状態を破棄します (マネージド オブジェクト)。
                End If

                ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下の Finalize() をオーバーライドします。
                ' TODO: 大きなフィールドを null に設定します。
            End If
            disposedValue = True
        End Sub

        ' TODO: 上の Dispose(disposing As Boolean) にアンマネージド リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
        'Protected Overrides Sub Finalize()
        '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
            Dispose(True)
            ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Namespace
