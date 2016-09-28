Public Class FrmHome
    Private Sub canvasTop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles canvasTop.MouseLeftButtonDown
        Me.Cursor = Cursors.SizeAll
        Me.DragMove()
    End Sub
    Private Sub canvasTop_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseUp

        Me.Cursor = Cursors.Arrow
    End Sub


End Class
