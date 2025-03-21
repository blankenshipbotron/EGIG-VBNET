Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    'Private WithEvents serialPort1 As New SerialPort()
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If

            SerialPort1.PortName = ComboBox1.SelectedItem.ToString()
            SerialPort1.BaudRate = 115200
            SerialPort1.Parity = Parity.None
            SerialPort1.DataBits = 8
            SerialPort1.StopBits = StopBits.One
            SerialPort1.DtrEnable = 1


            SerialPort1.Open()
            TextBox1.AppendText("Serial port opened." & vbCrLf)



        Catch ex As Exception
            TextBox1.AppendText("Error opening serial port: " & ex.Message & vbCrLf)
        End Try





    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Populate the combo box with available serial ports
        ComboBox1.Items.AddRange(SerialPort.GetPortNames())
    End Sub

    Private Sub serialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim receivedData As String = SerialPort1.ReadLine() ' Read data until a newline character
            parseData(receivedData)

            'Me.Invoke(Sub() TextBox1.AppendText("Received: " & receivedData & vbCrLf)) ' Update TextBox1 on the UI thread
            Me.Invoke(Sub() TextBox1.AppendText(receivedData & vbCrLf)) ' Update TextBox1 on the UI thread
        Catch ex As Exception
            Me.Invoke(Sub() TextBox1.AppendText("Error receiving data: " & ex.Message & vbCrLf))
        End Try
    End Sub
    Function parseData(ByVal data As String)
        Dim inputString As String = data
        Dim parts() As String = inputString.Split(","c)

        MessageBox.Show(parts(0), "Scan ID") ' SCAN ID
        MessageBox.Show(parts(1), "Date") ' DATE
        MessageBox.Show(parts(2), "Time") ' TIME
        MessageBox.Show(parts(3), "Temperature") ' TEMP
        MessageBox.Show(parts(4), "Humidity") ' HUMIDITY
        MessageBox.Show(parts(5), "FW Version") ' FW version
        MessageBox.Show(parts(6), "Test Volatge") ' Test Voltage
        MessageBox.Show(parts(7), "Test Result") ' Test result
        ' RED CODE

        'data.timestamp = millis() / 1000;
        'data.temperature = Random(0, 255);
        'data.humidity = Random(0, 100);
        'data.test_voltage = Random(0, 2000);
        'data.resistance = Random(0, 4294967295);






    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub

    Private Sub btnSendata_Click(sender As Object, e As EventArgs) Handles btnSendata.Click
        TextBox1.Text = ""

        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Write("CMD_EEPROM" & vbCr) ' Send the text from TextBox2
            Else
                TextBox1.AppendText("Serial port is not open." & vbCrLf)
            End If
        Catch ex As Exception
            TextBox1.AppendText("Error sending data: " & ex.Message & vbCrLf)
        End Try


    End Sub
End Class
