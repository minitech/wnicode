Imports System.Threading
Imports System.ComponentModel

''' <summary>
''' A label that fades to transition between its contents.
''' </summary>
''' <remarks>
''' Doesn't handle wrapping or alignment or anything like that.
''' </remarks>
<Description("A label that fades to transition between its contents.")>
Public Class FadeLabel
	Inherits Label

	Private animationThread As Thread
	Protected ReadOnly updater As New AutoResetEvent(False)

	Protected Overridable Sub AnimationLoop()
		Dim invalidate As New Action(AddressOf Me.Invalidate)

		Do
			Dim overlayCount As Integer
			Dim now As Date = Date.Now

			SyncLock textOverlays
				overlayCount = textOverlays.Count

				For i As Integer = overlayCount - 1 To 0 Step -1
					If now.Subtract(textOverlays(i).Removed) > FadeDuration Then _
						textOverlays.RemoveAt(i)
				Next
			End SyncLock

			If overlayCount = 0 Then updater.WaitOne()

			Me.Invoke(invalidate)

			Thread.Sleep(10)
		Loop
	End Sub

	Protected Structure TextOverlay
		Public Removed As Date
		Public Text As String

		Public Overrides Function GetHashCode() As Integer
			Return Removed.GetHashCode()
		End Function

		Public Overrides Function Equals(obj As Object) As Boolean
			If Not TypeOf obj Is TextOverlay Then Return False

			Dim other = CType(obj, TextOverlay)

			Return other.Text = Me.Text AndAlso other.Removed = Me.Removed
		End Function
	End Structure

	Protected textOverlays As New List(Of TextOverlay)
	Private _fadeDuration As TimeSpan = TimeSpan.FromSeconds(0.2)

	Public Overrides Property Text As String
		Get
			Return MyBase.Text
		End Get
		Set(value As String)
			If Me.Text = value Then _
				Exit Property

			If Not Me.DesignMode Then
				SyncLock textOverlays
					textOverlays.Add(New TextOverlay() With {
										.Removed = Date.Now,
										.Text = Me.Text
									 })
				End SyncLock

				updater.Set()
			End If

			MyBase.Text = value
		End Set
	End Property

	<DefaultValue(GetType(TimeSpan), "0:0:0.2")>
	<Category("Appearance")>
	Public Property FadeDuration As TimeSpan
		Get
			Return _fadeDuration
		End Get
		Set(value As TimeSpan)
			If value <= TimeSpan.Zero Then Throw New ArgumentOutOfRangeException("value", "Duration must be positive.")

			_fadeDuration = value
		End Set
	End Property

	Private Shared Function CreateAlpha(value As Double) As Integer
		CreateAlpha = CInt(value * 255)

		If CreateAlpha < 0 Then Return 0
		If CreateAlpha > 255 Then Return 255
	End Function

	Protected Overrides Sub OnVisibleChanged(e As EventArgs)
		If Me.Visible Then
			animationThread = New Thread(AddressOf AnimationLoop)
			animationThread.IsBackground = True
			animationThread.Start()
		ElseIf animationThread IsNot Nothing Then
			animationThread.Abort()
			animationThread.Join()
			animationThread = Nothing
		End If

		MyBase.OnVisibleChanged(e)
	End Sub

	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Dim g As Graphics = e.Graphics

		If Me.DesignMode Then
			MyBase.OnPaint(e)
			Exit Sub
		End If

		SyncLock textOverlays
			If textOverlays.Count > 0 Then
				For Each textOverlay In textOverlays
					Dim opacity As Integer = CreateAlpha(1 - Date.Now.Subtract(textOverlay.Removed).TotalSeconds / FadeDuration.TotalSeconds)
					g.DrawString(textOverlay.Text, Me.Font, New SolidBrush(Color.FromArgb(opacity, Me.ForeColor)), 0, 0)
				Next

				Dim lastOpacity As Integer = CreateAlpha(Date.Now.Subtract(textOverlays.Last().Removed).TotalSeconds / FadeDuration.TotalSeconds)
				g.DrawString(Me.Text, Me.Font, New SolidBrush(Color.FromArgb(lastOpacity, Me.ForeColor)), 0, 0)
			Else
				g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), 0, 0)
			End If
		End SyncLock
	End Sub
End Class
