Imports System.Text.RegularExpressions

Public Class CodePrompt
	Private Shared ReadOnly hexadecimal As New Regex("^[\da-fA-F]+$", RegexOptions.Compiled)
	Private isValid As Boolean = False

	Private Sub Input_KeyDown(sender As Object, e As KeyEventArgs) Handles Input.KeyDown
		If e.KeyCode = Keys.Enter Then
			If isValid Then _
				Clipboard.SetText(Me.Preview.Text)

			Me.Input.Clear()
			e.SuppressKeyPress = True
		End If
	End Sub

	Private Sub Input_TextChanged(sender As Object, e As EventArgs) Handles Input.TextChanged
		Dim input As String = Me.Input.Text.Trim()

		If input = String.Empty Then
			Me.Preview.Text = "preview"
			Me.Details.Text = "details"
			Exit Sub
		End If

		Dim code As UInteger?

		If hexadecimal.IsMatch(input) Then
			Try
				code = Convert.ToUInt32(input, 16)
			Catch ex As OverflowException
				' Ignore it.
			End Try
		End If

		isValid = code.HasValue

		If isValid Then
			Me.Preview.Text = System.Text.UTF32Encoding.UTF32.GetString(BitConverter.GetBytes(code.Value))
		Else
			Me.Preview.Text = "unrecognized code"
			Me.Details.Text = String.Empty
		End If
	End Sub
End Class
