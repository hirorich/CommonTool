Imports System.Data.Common
Imports System.Data.OleDb

Namespace DB

    Public Class OleDbController
        Inherits DbController

        Friend Sub New(ByVal connection As OleDbConnection)
            MyBase.New(connection)
        End Sub

        Protected Overrides Function NewDbDataAdapter() As DbDataAdapter
            Return New OleDbDataAdapter()
        End Function

        Public Function SelectData(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As DataTable

        End Function

        Public Function InsertData(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer

        End Function

        Public Function DeleteData(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer

        End Function

        Public Function UpdateData(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer

        End Function

    End Class

End Namespace
