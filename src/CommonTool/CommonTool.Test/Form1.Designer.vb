<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTestResult = New System.Windows.Forms.TextBox()
        Me.cmbTestCase = New System.Windows.Forms.ComboBox()
        Me.btnExeTest = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTestResult
        '
        Me.txtTestResult.Location = New System.Drawing.Point(304, 37)
        Me.txtTestResult.Multiline = True
        Me.txtTestResult.Name = "txtTestResult"
        Me.txtTestResult.Size = New System.Drawing.Size(460, 384)
        Me.txtTestResult.TabIndex = 0
        '
        'cmbTestCase
        '
        Me.cmbTestCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTestCase.FormattingEnabled = True
        Me.cmbTestCase.Location = New System.Drawing.Point(39, 37)
        Me.cmbTestCase.Name = "cmbTestCase"
        Me.cmbTestCase.Size = New System.Drawing.Size(228, 23)
        Me.cmbTestCase.TabIndex = 1
        '
        'btnExeTest
        '
        Me.btnExeTest.Location = New System.Drawing.Point(39, 144)
        Me.btnExeTest.Name = "btnExeTest"
        Me.btnExeTest.Size = New System.Drawing.Size(75, 23)
        Me.btnExeTest.TabIndex = 2
        Me.btnExeTest.Text = "実行"
        Me.btnExeTest.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(166, 144)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "リセット"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnExeTest)
        Me.Controls.Add(Me.cmbTestCase)
        Me.Controls.Add(Me.txtTestResult)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTestResult As TextBox
    Friend WithEvents cmbTestCase As ComboBox
    Friend WithEvents btnExeTest As Button
    Friend WithEvents btnReset As Button
End Class
