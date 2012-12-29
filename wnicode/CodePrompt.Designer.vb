<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodePrompt
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.Input = New System.Windows.Forms.TextBox()
		Me.Details = New wnicode.FadeLabel()
		Me.Preview = New wnicode.FadeLabel()
		Me.SuspendLayout()
		'
		'Input
		'
		Me.Input.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Input.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Input.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Input.Font = New System.Drawing.Font("Segoe UI Light", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Input.ForeColor = System.Drawing.Color.White
		Me.Input.Location = New System.Drawing.Point(12, 12)
		Me.Input.Name = "Input"
		Me.Input.Size = New System.Drawing.Size(471, 47)
		Me.Input.TabIndex = 0
		'
		'Details
		'
		Me.Details.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Details.FadeDuration = System.TimeSpan.Parse("00:00:00.1000000")
		Me.Details.Location = New System.Drawing.Point(7, 113)
		Me.Details.Name = "Details"
		Me.Details.Size = New System.Drawing.Size(476, 25)
		Me.Details.TabIndex = 2
		Me.Details.Text = "details"
		'
		'Preview
		'
		Me.Preview.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Preview.FadeDuration = System.TimeSpan.Parse("00:00:00.1000000")
		Me.Preview.ForeColor = System.Drawing.Color.Silver
		Me.Preview.Location = New System.Drawing.Point(7, 75)
		Me.Preview.Name = "Preview"
		Me.Preview.Size = New System.Drawing.Size(476, 25)
		Me.Preview.TabIndex = 1
		Me.Preview.Text = "preview"
		'
		'CodePrompt
		'
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
		Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.ClientSize = New System.Drawing.Size(495, 159)
		Me.Controls.Add(Me.Details)
		Me.Controls.Add(Me.Preview)
		Me.Controls.Add(Me.Input)
		Me.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "CodePrompt"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "wnicode"
		Me.TopMost = True
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Private WithEvents Input As System.Windows.Forms.TextBox
	Private WithEvents Preview As wnicode.FadeLabel
	Private WithEvents Details As wnicode.FadeLabel

End Class
