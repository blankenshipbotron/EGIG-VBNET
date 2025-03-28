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

            If receivedData Like "*MD_1*" Then

                parseData(receivedData)
            Else
                displayRTB(receivedData)
            End If


            'Me.Invoke(Sub() TextBox1.AppendText("Received: " & receivedData & vbCrLf)) ' Update TextBox1 on the UI thread
            'Me.Invoke(Sub() TextBox1.AppendText(receivedData & vbCrLf)) ' Update TextBox1 on the UI thread
        Catch ex As Exception
            'Me.Invoke(Sub() TextBox1.AppendText("Error receiving data: " & ex.Message & vbCrLf))
        End Try
    End Sub
    Function parseData(ByVal data As String)
        Dim inputString As String = data
        Dim parts() As String = inputString.Split(","c)

        Dim displayString As String = parts(1) & "  " & parts(2) & "  " & parts(3) & "  " & parts(4) & "  " & parts(5) & "  " & parts(6) & "  " & parts(7) & "  " & parts(8) ' Use spaces for separation
        ' Dim displayString As String = parts(0) & "  " & parts(1) & "  " & parts(2) & "  " & parts(3) & "  " & parts(4) & "  " & parts(5) & "  " & parts(6) & "  " & parts(7) ' Use spaces for separation
        ' Use Invoke to update ListBox1 on the UI thread
        Me.Invoke(Sub()
                      'ListView1.Items.Clear()
                      ListBox1.Items.Add(displayString)
                  End Sub)

        ' Use Invoke to update ListView1 on the UI thread
        Me.Invoke(Sub()


                      ' Create a new ListViewItem
                      Dim item As New ListViewItem(parts(1)) ' SCAN ID (1st column)

                      ' Add subitems for the other columns

                      item.SubItems.Add(parts(2)) ' Date (2nd column)
                      item.SubItems.Add(parts(3)) ' Time (3rd column)
                      item.SubItems.Add(parts(4)) ' TEMP (4th column)
                      item.SubItems.Add(parts(5)) ' HUMIDITY (5th column)
                      item.SubItems.Add(parts(6)) ' FW ver (6th column)
                      item.SubItems.Add(parts(7)) ' Test Voltage (7th column)
                      item.SubItems.Add(parts(8)) ' Test Result (8th column)

                      ' Add the item to the ListView
                      ListView1.Items.Add(item)
                      If ListView1.Items.Count > 0 Then
                          ListView1.Items(ListView1.Items.Count - 1).EnsureVisible()
                      End If
                  End Sub)
    End Function
    Function displayRTB(ByVal myData As String)
        Me.Invoke(Sub()
                      Dim parts2() As String = myData.Split(","c)
                      rtbData.AppendText(parts2(1))
                      rtbData.SelectionStart = rtbData.TextLength
                      rtbData.ScrollToCaret()
                      lblPercent.Text = parts2(1)

                  End Sub)

    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub

    Private Sub btnSendata_Click(sender As Object, e As EventArgs) Handles btnSendata.Click
        TextBox1.Text = ""
        ListView1.Items.Clear()

        Try
            If SerialPort1.IsOpen Then
                'SerialPort1.Write("CMD_EEPROM" & vbCr) ' Send the text from TextBox2
                SerialPort1.Write("e" & vbCr) ' Send the text from TextBox2
            Else
                TextBox1.AppendText("Serial port is not open." & vbCrLf)
            End If
        Catch ex As Exception
            TextBox1.AppendText("Error sending data: " & ex.Message & vbCrLf)
        End Try


    End Sub

    Private Sub btnEraseRead_Click(sender As Object, e As EventArgs) Handles btnEraseRead.Click
        TextBox1.Text = ""
        ListView1.Items.Clear()

        Try
            If SerialPort1.IsOpen Then
                'SerialPort1.Write("CMD_EEPROM" & vbCr) ' Send the text from TextBox2
                SerialPort1.Write("6" & vbCr) ' Send the text from TextBox2
            Else
                TextBox1.AppendText("Serial port is not open." & vbCrLf)
            End If
        Catch ex As Exception
            TextBox1.AppendText("Error sending data: " & ex.Message & vbCrLf)
        End Try
    End Sub
End Class
