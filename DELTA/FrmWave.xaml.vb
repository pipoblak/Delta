Imports System.IO.Ports
Imports System.Windows.Threading
Public Class FrmWave

    Dim comPORT As String
    Dim receivedData As String = ""
    Dim SeP As String
    Dim timeNow As Integer = 0
    Dim incomingData As String
    Dim porta As New System.IO.Ports.SerialPort
    Dim dispatcherTimer As New DispatcherTimer
    Dim staticTopEnabled, pulseTopEnabled, waveTopEnabled As Boolean
    Dim staticLogoEnabled, pulseLogoEnabled, waveLogoEnabled As Boolean
#Region "TOP"
    Private Sub canvasTop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles canvasTop.MouseLeftButtonDown
        Me.Cursor = Cursors.SizeAll
        Me.DragMove()
    End Sub
    Private Sub canvasTop_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles Me.MouseUp

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnClose_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As RoutedEventArgs)
        Me.WindowState = WindowState.Minimized
    End Sub
#End Region
    Private Sub ColorPicker_SelectedColorChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Color?)) Handles colorpickerLogo.SelectedColorChanged
        Dim BrushColor As Brush
        Dim selectColor As Color = colorpickerLogo.SelectedColor.GetValueOrDefault
        BrushColor = New SolidColorBrush(selectColor)
        cnvsGabinete.Background = BrushColor
        Try
            System.Threading.Thread.Sleep(200)

            porta.Write("#R" & selectColor.R & "G" & selectColor.G & "B" & selectColor.B & "S1")


        Catch ex As Exception

        End Try


    End Sub
    Private Sub colorpickerTop_SelectedColorChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Color?)) Handles colorpickerTop.SelectedColorChanged
        Dim BrushColor As Brush
        Dim selectColor As Color = colorpickerTop.SelectedColor.GetValueOrDefault
        BrushColor = New SolidColorBrush(selectColor)
        TOP.Fill = BrushColor
        Try
            System.Threading.Thread.Sleep(200)

            porta.Write("#R" & selectColor.R & "G" & selectColor.G & "B" & selectColor.B & "S2")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_MouseLeftButtonDown(sender As Object, e As RoutedEventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMinimize_MouseLeftButtonDown(sender As Object, e As RoutedEventArgs) Handles btnMinimize.Click
        Me.WindowState = WindowState.Minimized
    End Sub


    Public Sub dispatcherTimer_Tick()
        Try

            If porta.IsOpen Then
            Else
                porta.Open()
            End If
            porta.Write("$")
            receivedData = ReceiveSerialData()


            incomingData += receivedData
            If incomingData.Contains("WAVE DEVICE") Then
                lblDeviceStatus.Content = ""
                cnvsDeviceStatus.ToolTip = "Dispositivo Conectado"
                cnvsButtonsLogo.Visibility = Visibility.Visible
                colorpickerLogo.Visibility = Visibility.Visible
                colorpickerTop.Visibility = Visibility.Visible
                cnvsLogoTip.Visibility = Visibility.Visible
                cnvsButtonsTop.Visibility = Visibility.Visible
                cnvsTopTip.Visibility = Visibility.Visible

            Else
                lblDeviceStatus.Content = ""
                cnvsDeviceStatus.ToolTip = "Dispositivo Desconectado"
                cnvsButtonsLogo.Visibility = Visibility.Hidden
                colorpickerLogo.Visibility = Visibility.Hidden
                colorpickerTop.Visibility = Visibility.Hidden
                cnvsLogoTip.Visibility = Visibility.Hidden
                cnvsButtonsTop.Visibility = Visibility.Hidden
                cnvsTopTip.Visibility = Visibility.Hidden

                porta.Close()
            End If

            dispatcherTimer.Stop()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub searchDevice()
        Try
            incomingData = ""
            comPORT = ""

            For Each sp As String In My.Computer.Ports.SerialPortNames

                Try
                    Try
                        porta.Close()
                    Catch ex As Exception

                    End Try
                    Try
                        porta.PortName = sp
                        porta.BaudRate = 115200
                        porta.DataBits = 8
                        porta.Parity = Parity.None
                        porta.StopBits = StopBits.One
                        porta.Handshake = Handshake.None
                        porta.Encoding = System.Text.Encoding.Default
                        porta.ReadTimeout = 10000

                    Catch ex As Exception

                    End Try

                    SeP = sp


                    porta.Open()
                    dispatcherTimer.Start()

                Catch ex As Exception

                End Try

            Next
            If SeP = "" Then
                lblDeviceStatus.Content = ""
                cnvsDeviceStatus.ToolTip = "Dispositivo Desconectado"
            End If

        Catch ex As Exception

        End Try

    End Sub
    Function ReceiveSerialData() As String
        Try
            Dim Incoming As String
            System.Threading.Thread.Sleep(200)
            Try
                Incoming = porta.ReadExisting()
                If Incoming Is Nothing Then
                    Return "nothing" & vbCrLf
                Else
                    Return Incoming
                End If
            Catch ex As TimeoutException

            End Try
        Catch ex As Exception

        End Try



    End Function

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)


        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        dispatcherTimer.Interval = New TimeSpan(0, 0, 1)
        searchDevice()



    End Sub
#Region "HOVER BUTTONS"
    Private Sub btnSTATIC_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnSTATIC.MouseEnter
        btnSTATIC.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub btnSTATIC_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnSTATIC.MouseLeave
        btnSTATIC.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnWAVE_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnWAVE.MouseEnter
        btnWAVE.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub btnWAVE_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnWAVE.MouseLeave
        btnWAVE.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnPulse_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnPULSE.MouseLeave
        btnPULSE.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub btnPulse_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnPULSE.MouseEnter
        btnPULSE.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub btnSTATICTop_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnSTATICTop.MouseEnter
        btnSTATICTop.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub btnSTATICTop_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnSTATICTop.MouseLeave
        btnSTATICTop.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnWAVETop_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnWAVETop.MouseEnter
        btnWAVETop.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub btnWAVETop_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnWAVETop.MouseLeave
        btnWAVETop.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnPulseTop_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnPULSETop.MouseLeave
        btnPULSETop.Opacity = 1
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub btnPulseTop_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnPULSETop.MouseEnter
        btnPULSETop.Opacity = 0.4
        Me.Cursor = Cursors.Hand
    End Sub




#End Region
    Private Sub btnSTATIC_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnSTATIC.MouseLeftButtonDown
        porta.Write("@1D5S1")
        System.Threading.Thread.Sleep(100)
        colorpickerLogo.Visibility = Visibility.Visible
        cnvsGabineteChroma.Visibility = Visibility.Hidden

        staticLogoEnabled = True
        waveLogoEnabled = False
        pulseLogoEnabled = False

        setClicked()
        verifySincro()
    End Sub

    Private Sub btnWAVE_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnWAVE.MouseLeftButtonDown
        porta.Write("@0D5S1")
        System.Threading.Thread.Sleep(100)
        colorpickerLogo.Visibility = Visibility.Hidden
        cnvsGabineteChroma.Visibility = Visibility.Visible

        staticLogoEnabled = False
        waveLogoEnabled = True
        pulseLogoEnabled = False

        setClicked()
        verifySincro()
    End Sub

    Private Sub btnPULSE_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnPULSE.MouseLeftButtonDown
        porta.Write("@2D5S1")
        System.Threading.Thread.Sleep(100)
        colorpickerLogo.Visibility = Visibility.Visible
        cnvsGabineteChroma.Visibility = Visibility.Hidden

        staticLogoEnabled = False
        waveLogoEnabled = False
        pulseLogoEnabled = True

        setClicked()
        verifySincro()
    End Sub
    Private Sub btnSTATICTop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnSTATICTop.MouseLeftButtonDown
        porta.Write("@1D5S2")
        System.Threading.Thread.Sleep(100)
        colorpickerTop.Visibility = Visibility.Visible
        TopChroma.Visibility = Visibility.Hidden
        TOP.Visibility = Visibility.Visible

        staticTopEnabled = True
        waveTopEnabled = False
        pulseTopEnabled = False

        setClicked()
        verifySincro()
    End Sub

    Private Sub btnSincro_Click(sender As Object, e As RoutedEventArgs) Handles btnSincro.Click
        If staticLogoEnabled = True And staticTopEnabled = True Then


        ElseIf waveLogoEnabled = True And waveTopEnabled = True Then
            porta.Write("@0D5S0")
        ElseIf pulseLogoEnabled = True And pulseTopEnabled = True Then
            porta.Write("@2D5S0")
        End If



    End Sub

    Private Sub btnWAVETop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnWAVETop.MouseLeftButtonDown
        porta.Write("@0D5S2")
        System.Threading.Thread.Sleep(100)
        colorpickerTop.Visibility = Visibility.Hidden
        TopChroma.Visibility = Visibility.Visible
        TOP.Visibility = Visibility.Hidden

        staticTopEnabled = False
        waveTopEnabled = True
        pulseTopEnabled = False

        setClicked()
        verifySincro()
    End Sub

    Private Sub btnPULSETop_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles btnPULSETop.MouseLeftButtonDown
        porta.Write("@2D5S2")
        System.Threading.Thread.Sleep(100)
        colorpickerTop.Visibility = Visibility.Visible
        TopChroma.Visibility = Visibility.Hidden
        TOP.Visibility = Visibility.Visible

        staticTopEnabled = False
        waveTopEnabled = False
        pulseTopEnabled = True

        setClicked()
        verifySincro()
    End Sub

    Private Sub setClicked()

        If staticLogoEnabled = True Then
            btnSTATIC.Opacity = 0.4
            btnWAVE.Opacity = 1
            btnPULSE.Opacity = 1
        ElseIf waveLogoEnabled = True Then
            btnSTATIC.Opacity = 1
            btnWAVE.Opacity = 0.4
            btnPULSE.Opacity = 1
        ElseIf pulseLogoEnabled = True Then
            btnSTATIC.Opacity = 1
            btnWAVE.Opacity = 1
            btnPULSE.Opacity = 0.4

        End If

        If staticTopEnabled = True Then
            btnSTATICTop.Opacity = 0.4
            btnWAVETop.Opacity = 1
            btnPULSETop.Opacity = 1
        ElseIf waveTopEnabled = True Then
            btnSTATICTop.Opacity = 1
            btnWAVETop.Opacity = 0.4
            btnPULSETop.Opacity = 1
        ElseIf pulseTopEnabled = True Then
            btnSTATICTop.Opacity = 1
            btnWAVETop.Opacity = 1
            btnPULSETop.Opacity = 0.4

        End If

    End Sub

    Public Function verifySincro()

        If staticLogoEnabled = True And staticTopEnabled = True Then


        ElseIf waveLogoEnabled = True And waveTopEnabled = True Then
            btnSincro.Visibility = Visibility.Visible
        ElseIf pulseLogoEnabled = True And pulseTopEnabled = True Then
            btnSincro.Visibility = Visibility.Visible
        End If



    End Function

End Class
