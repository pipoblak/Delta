Class MainWindow
    Dim verifMove As Boolean = True
    Dim animationLoading As Animation.Storyboard

    Private Sub lblClose_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblClose.PreviewMouseLeftButtonDown

        Me.Close()
    End Sub

    Private Sub window_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles window.MouseUp
        Me.Cursor = Cursors.Arrow
        verifMove = True
    End Sub

    Private Sub canvasTop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles canvasTop.MouseLeftButtonDown
        If verifMove Then
            Me.Cursor = Cursors.SizeAll
            Me.DragMove()
            Keyboard.ClearFocus()
        End If

    End Sub

    Private Sub lblRegistrar_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblRegistrar.MouseEnter
        verifMove = False
    End Sub
    Private Sub lblRegistrar_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblRegistrar.MouseLeave
        verifMove = True

    End Sub

    Private Sub lblConectar_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblConectar.MouseEnter
        verifMove = False
    End Sub
    Private Sub lblConectar_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblConectar.MouseLeave
        verifMove = True
    End Sub

    Private Sub lblConectar_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lblConectar.MouseLeftButtonDown
        Try
            animationLoading.GetIsPaused()

        Catch ex As Exception
            cnvsButtonsLoginRegister.IsEnabled = False
            animationLoading.Begin()
        End Try

        Dim a As New FrmHome

        a.Show()
        Me.Close()

    End Sub

    Private Sub window_Loaded(sender As Object, e As RoutedEventArgs) Handles window.Loaded
        animationLoading = TryFindResource("LoadingLogo")

    End Sub
End Class
