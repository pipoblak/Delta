
Imports System.IO.Ports
Imports System.Windows.Threading
Public Class FrmHome

    Dim comPORT As String
    Dim receivedData As String = ""
    Dim SeP As String
    Dim timeNow As Integer = 0
    Dim incomingData As String
    Dim porta As New System.IO.Ports.SerialPort
    Dim dispatcherTimer As New DispatcherTimer

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

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        dispatcherTimer.Interval = New TimeSpan(0, 0, 1)
        searchDevice()
        Dim cpu As New System.Diagnostics.PerformanceCounter()
        With cpu
            .CategoryName = "Processor"
            .CounterName = "% Processor Time"

        End With



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
            If incomingData.Contains("DELTA DEVICE") Then
                lblDeviceStatus.Content = ""
                cnvsDeviceStatus.ToolTip = "Dispositivo Conectado"
            Else
                lblDeviceStatus.Content = ""
                cnvsDeviceStatus.ToolTip = "Dispositivo Desconectado"

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



    Public Function calculaIntensidadeCooler(ByVal intensidade As Integer)
        Return ((100 * intensidade) / 255)
    End Function

    Private Sub slider_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles slider.ValueChanged
        lblCooler1.Text = Math.Round(calculaIntensidadeCooler(slider.Value)) & "%"

    End Sub

    Private Sub slidera_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles slider2.ValueChanged
        lblCooler2.Text = Math.Round(calculaIntensidadeCooler(slider2.Value)) & "%"
    End Sub

    Private Sub slider2_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles slider3.ValueChanged
        lblCooler3.Text = Math.Round(calculaIntensidadeCooler(slider3.Value)) & "%"
    End Sub

    Private Sub txtExpert_MouseEnter(sender As Object, e As MouseEventArgs) Handles txtExpert.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub txtExpert_MouseLeave(sender As Object, e As MouseEventArgs) Handles txtExpert.MouseLeave
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSilent_MouseEnter(sender As Object, e As MouseEventArgs) Handles txtSilent.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub txtSilent_MouseLeave(sender As Object, e As MouseEventArgs) Handles txtSilent.MouseLeave
        Me.Cursor = Cursors.Arrow

    End Sub
End Class
