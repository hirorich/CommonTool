﻿Imports System.Data.Common
Imports LogUtil.LOG

Namespace DB

    ''' <summary>
    ''' DB接続制御クラス
    ''' </summary>
    Public MustInherit Class ConnectionController
        Implements IDisposable

        ''' <summary>
        ''' 接続先
        ''' </summary>
        Private dbname As String

        ''' <summary>
        ''' 接続情報
        ''' </summary>
        Private connection As IDbConnection

        ''' <summary>
        ''' トランザクション
        ''' </summary>
        Private transaction As IDbTransaction

        ''' <summary>
        ''' 接続の現在の状態を取得
        ''' </summary>
        ''' <returns>接続状態</returns>
        Public ReadOnly Property State() As ConnectionState
            Get
                Return connection.State
            End Get
        End Property

        ''' <summary>
        ''' 接続情報を指定してインスタンス生成
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="connection">接続情報</param>
        Protected Friend Sub New(ByVal dbname As String, ByVal connection As IDbConnection)
            If String.IsNullOrWhiteSpace(dbname) Then
                Me.dbname = String.Empty
            Else
                Me.dbname = dbname.Trim
            End If
            Me.connection = connection
            Me.transaction = Nothing
        End Sub

        ''' <summary>
        ''' レコード検索に使用するDbDataAdapterインスタンス生成
        ''' </summary>
        ''' <returns>DbDataAdapter</returns>
        Protected MustOverride Function CreateDbDataAdapter() As DbDataAdapter

        ''' <summary>
        ''' クエリ実行に使用するIDbCommandインスタンス生成
        ''' </summary>
        ''' <returns>IDbCommand</returns>
        Protected MustOverride Function CreateIDbCommand() As IDbCommand

        ''' <summary>
        ''' 接続を開く
        ''' </summary>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function Open() As Boolean
            Try

                ' 接続を開く
                Call Me.connection.Open()
                Call LogTool.WriteLog(Me.dbname & "の接続を開きました。")
                Open = True

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception(Me.dbname & "の接続を開くことに失敗しました。", ex))
                Open = False
            End Try
        End Function

        ''' <summary>
        ''' 接続を閉じる
        ''' </summary>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function Close() As Boolean
            Try

                ' トランザクションが開始されている場合ロールバック
                If Me.transaction IsNot Nothing Then
                    Call Me.Rollback()
                End If

                ' 接続を閉じる
                Call Me.connection.Close()
                Call LogTool.WriteLog(Me.dbname & "の接続を閉じました。")
                Close = True

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception(Me.dbname & "の接続を閉じることに失敗しました。", ex))
                Close = False
            End Try
        End Function

        ''' <summary>
        ''' トランザクションを開始する
        ''' </summary>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function BeginTransaction() As Boolean
            Try

                ' 並列トランザクションの制限
                If Me.transaction IsNot Nothing Then
                    LogTool.WriteLog(New InvalidOperationException("並列トランザクションはサポートされていません。"))
                    Return False
                End If

                ' トランザクションを開始
                Me.transaction = Me.connection.BeginTransaction()
                Call LogTool.WriteLog("トランザクションを開始しました。")
                BeginTransaction = True

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("トランザクションの開始に失敗しました。", ex))
                BeginTransaction = False
            End Try
        End Function

        ''' <summary>
        ''' トランザクションをコミットする
        ''' </summary>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function Commit() As Boolean
            Try

                ' コミット実施
                If Me.transaction IsNot Nothing Then
                    Me.transaction.Commit()

                    ' トランザクション解放
                    Call Me.transaction.Dispose()
                    Me.transaction = Nothing

                    Call LogTool.WriteLog("トランザクションをコミットしました。")
                End If
                Commit = True

            Catch ex As Exception

                ' 例外時はロールバック
                Call LogTool.WriteLog(New Exception("トランザクションのコミットに失敗しました。", ex))
                Call Me.transaction.Rollback()
                Commit = False
            End Try
        End Function

        ''' <summary>
        ''' トランザクションをロールバックする
        ''' </summary>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Function Rollback() As Boolean
            Try

                ' ロールバック実施
                If Me.transaction IsNot Nothing Then
                    Call Me.transaction.Rollback()

                    Call LogTool.WriteLog("トランザクションをロールバックしました。")
                End If
                Rollback = True

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("トランザクションのロールバックに失敗しました。", ex))
                Rollback = False
            Finally

                ' トランザクション解放
                If Me.transaction IsNot Nothing Then
                    Call Me.transaction.Dispose()
                    Me.transaction = Nothing
                End If

            End Try
        End Function

        ''' <summary>
        ''' クエリを指定してレコードを検索する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>検索したレコード</returns>
        Protected Function SearchRecord(ByVal query As String, Optional ByVal parameters As IDataParameterCollection = Nothing) As DataTable
            Dim command As IDbCommand
            Dim adapter As DbDataAdapter

            SearchRecord = New DataTable

            Try

                ' 実行準備
                command = Me.Prepare(query, parameters)
                adapter = Me.CreateDbDataAdapter()
                adapter.SelectCommand = command

                ' コマンド実行
                Call adapter.Fill(SearchRecord)
                Call LogTool.WriteLog("レコードの検索に成功しました。")

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("レコードの検索に失敗しました。", ex))
                Call Me.transaction.Rollback()
                Call SearchRecord.Dispose()
                SearchRecord = Nothing
            End Try
        End Function

        ''' <summary>
        ''' クエリを指定してレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Protected Function UpdateRecord(ByVal query As String, Optional ByVal parameters As IDataParameterCollection = Nothing) As Integer
            Dim command As IDbCommand

            Try

                ' 実行準備
                command = Me.Prepare(query, parameters)

                ' コマンド実行
                UpdateRecord = command.ExecuteNonQuery()
                Call LogTool.WriteLog("レコードの更新に成功しました。")

            Catch ex As Exception
                Call LogTool.WriteLog(New Exception("レコードの更新に失敗しました。", ex))
                Call Me.transaction.Rollback()
                UpdateRecord = 0
            End Try
        End Function

        ''' <summary>
        ''' コマンドの実行準備
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>実行可能コマンド</returns>
        Private Function Prepare(ByVal query As String, Optional ByVal parameters As IDataParameterCollection = Nothing) As IDbCommand
            Try
                Prepare = Me.CreateIDbCommand()

                ' 各種情報付与
                Prepare.Connection = Me.connection
                If Me.transaction IsNot Nothing Then
                    Prepare.Transaction = Me.transaction
                End If
                Prepare.CommandText = query
                If parameters IsNot Nothing Then
                    Prepare.Parameters.Add(parameters)
                End If

                ' 準備済みコマンド作成
                Call Prepare.Prepare()
                Call LogTool.WriteLog("コマンドの作成に成功しました。")

            Catch ex As Exception
                Throw New Exception("コマンドの作成に失敗しました。", ex)
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
