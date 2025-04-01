Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Form1
    'Private WithEvents serialPort1 As New SerialPort()
    Dim myRecordCount As Int32 = 0
    Private recordCountPerSecond As Integer = 0
    Private lastSecond As Integer = -1
    ' Create folder vars
    Dim gProgramDataFolder As String = My.Application.GetEnvironmentVariable("ProgramData") & "\Botron\B8590"
    Dim gDataPathFW As String = My.Application.GetEnvironmentVariable("ProgramData") & "\Botron\B8590\FW"
    Dim gDataPathLOGS As String = My.Application.GetEnvironmentVariable("ProgramData") & "\Botron\B8590\LOGS"
    Dim gDataPathBIN As String = My.Application.GetEnvironmentVariable("ProgramData") & "\Botron\B8590\BIN"
    Dim gDataPathTMP As String = My.Application.GetEnvironmentVariable("ProgramData") & "\Botron\B8590\TMP"
    ' Declare detailsForm as a class-level variable
    Private detailsForm As Form2
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If

            If String.IsNullOrEmpty(ComboBox1.Text) Then
                Return ' Exit the Sub/Function
            End If

            SerialPort1.PortName = ComboBox1.SelectedItem.ToString()
            SerialPort1.BaudRate = 115200
            SerialPort1.Parity = Parity.None
            SerialPort1.DataBits = 8
            SerialPort1.StopBits = StopBits.One
            SerialPort1.DtrEnable = 1


            SerialPort1.Open()
            btnSendata.Enabled = True
            btnSendata.BackColor = Color.LightGreen
            btnConnect.BackColor = Color.LightGreen
            'TextBox1.AppendText("Serial port opened." & vbCrLf)



        Catch ex As Exception
            btnSendata.BackColor = Color.Red
            'TextBox1.AppendText("Error opening serial port: " & ex.Message & vbCrLf)
        End Try





    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Populate the combo box with available serial ports
        ComboBox1.Items.AddRange(SerialPort.GetPortNames())

        If Not System.IO.Directory.Exists(gDataPathFW) Then
            System.IO.Directory.CreateDirectory(gDataPathFW)    ' Create C:\ProgramData\Botron\B8590\FW
        End If
        If Not System.IO.Directory.Exists(gDataPathLOGS) Then
            System.IO.Directory.CreateDirectory(gDataPathLOGS)  ' Create C:\ProgramData\Botron\B8590\LOGS
        End If
        If Not System.IO.Directory.Exists(gDataPathBIN) Then
            System.IO.Directory.CreateDirectory(gDataPathBIN)    ' Create C:\ProgramData\Botron\B8590\BIN
        End If
        If Not System.IO.Directory.Exists(gDataPathTMP) Then
            System.IO.Directory.CreateDirectory(gDataPathTMP)    ' Create C:\ProgramData\Botron\B8590\TMP
        End If

    End Sub

    Private Sub serialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim receivedData As String = SerialPort1.ReadLine() ' Read data until a newline character

            If receivedData Like "CMD_1*" Then ' "CMD_1*" gold

                parseData(receivedData)
                UpdateRecordsPerSecond() ' Call the update function

            Else
                'displayRTB(receivedData)
            End If

            If receivedData Like "CMD_2*" Then ' "CMD_1*" gold
                displayRTB(receivedData)
            End If
            If receivedData Like "CMD_3*" Then ' 
                displaySystemData(receivedData)
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
        myRecordCount = myRecordCount + 1
        recordCountPerSecond += 1 ' Increment record count

        Dim displayString As String = parts(1) & "  " & parts(2) & "  " & parts(3) & "  " & parts(4) & "  " & parts(5) & "  " & parts(6) & "  " & parts(7) & "  " & parts(8)
        ' Dim displayString As String = parts(0) & "  " & parts(1) & "  " & parts(2) & "  " & parts(3) & "  " & parts(4) & "  " & parts(5) & "  " & parts(6) & "  " & parts(7) ' Use spaces for separation
        ' Use Invoke to update ListBox1 on the UI thread (if you need it)
        Me.Invoke(Sub()
                      'ListView1.Items.Clear() ' You might not want to clear here!
                      'ListBox1.Items.Add(displayString)
                  End Sub)

        ' Use Invoke to update ListView1 on the UI thread
        Me.Invoke(Sub()
                      ListView1.BeginUpdate() ' Prevent repainting while adding items
                      Try
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
                          item.SubItems.Add(myRecordCount) ' Record Number
                          Dim EEusage As Int16 = CalculateEEPROMUsagePercentage(myRecordCount)
                          lblRecordCount.Text = myRecordCount & " of 1820"
                          lblEEusage.Text = EEusage & "%"


                          ProcessIncomingData(myRecordCount)



                          ' Add the item to the ListView
                          ListView1.Items.Add(item)


                      Finally
                          If ListView1.Items.Count > 0 Then
                              ListView1.Items(ListView1.Items.Count - 1).EnsureVisible()
                          End If
                          ListView1.EndUpdate() ' Allow repainting after adding items

                      End Try
                  End Sub)
    End Function

    Function displayRTB(ByVal myData As String)
        Me.Invoke(Sub()
                      Dim parts2() As String = myData.Split(","c)
                      If myData Like "*...*" Then
                      Else
                          rtbData.AppendText(parts2(1))
                          rtbData.SelectionStart = rtbData.TextLength
                          rtbData.ScrollToCaret()
                          'lblPercent.Text = parts2(1)
                      End If


                  End Sub)

    End Function
    Function displaySystemData(ByVal myData As String)
        Me.Invoke(Sub()
                      Try
                          lblFWver.Text = "*"
                          lblPCBver.Text = "*"
                          lblSerialNumber.Text = "*"
                          lblMFGdate.Text = "*"
                          lblCALdate.Text = "*"
                          'lblCALstatus.Text = "*"
                          lblCALstatus2.Text = "*"
                          lblRecordCount.Text = "*"
                          lblEEusage.Text = "*"
                          Application.DoEvents()
                          System.Threading.Thread.Sleep(250)
                          Dim parts3() As String = myData.Split(","c)
                          lblFWver.Text = parts3(1)
                          lblPCBver.Text = parts3(2)
                          lblSerialNumber.Text = parts3(3)
                          lblMFGdate.Text = parts3(4)
                          lblCALdate.Text = parts3(5)

                          Dim calibrationDate As String = lblCALdate.Text ' Example: March 25, 2025
                          Dim daysUntilNextCalibration As Integer = CalculateDaysUntilOneYear(calibrationDate)
                          If daysUntilNextCalibration > 0 Then
                              'Console.WriteLine("Days until one year from " & calibrationDate & ": " & daysUntilNextCalibration)
                              'MessageBox.Show("Days until one year from " & calibrationDate & ": " & daysUntilNextCalibration)
                              'lblCALstatus.Text = ("Current CAL Date " & calibrationDate)
                              lblCALstatus2.Text = (daysUntilNextCalibration & " Days")
                          ElseIf daysUntilNextCalibration = 0 Then
                              Console.WriteLine("One year from " & calibrationDate & " is today!")
                          Else
                              Console.WriteLine("Invalid date format.")
                          End If

                      Catch ex As Exception
                          MessageBox.Show(ex.Message)
                      End Try
                  End Sub)


    End Function
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub

    Private Sub btnSendata_Click(sender As Object, e As EventArgs) Handles btnSendata.Click

        lblRecordsPerSecond.Text = "*"
        myRecordCount = 0
        ListView1.Items.Clear()

        Try
            If SerialPort1.IsOpen Then
                btnSendata.BackColor = Color.LightGreen
                'SerialPort1.Write("CMD_EEPROM" & vbCr) ' Send the text from TextBox2
                SerialPort1.Write("READ_SYSTEM" & vbCr)
                SerialPort1.Write("READ" & vbCr) ' Send the text from TextBox2
            Else
                'TextBox1.AppendText("Serial port is not open." & vbCrLf)
            End If
        Catch ex As Exception
            'TextBox1.AppendText("Error sending data: " & ex.Message & vbCrLf)
        End Try


    End Sub
    Private Sub UpdateRecordsPerSecond()
        Dim currentSecond As Integer = DateTime.Now.Second

        If currentSecond <> lastSecond Then
            Me.Invoke(Sub()
                          lblRecordsPerSecond.Text = $"Records/Sec: {recordCountPerSecond}"
                      End Sub)

            recordCountPerSecond = 1 ' Reset for the new second
            lastSecond = currentSecond
        End If
    End Sub
    Private Sub btnEraseRead_Click(sender As Object, e As EventArgs) Handles btnEraseRead.Click

        ' Prompt the user with a Yes/No message box
        Dim result As DialogResult = MessageBox.Show("Do you want to erase data? WARNING!! be advised you cannot get this data back PLEASE SAVE DATA", "Botron B8590 EEPROM erase utility", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the user's response
        If result = DialogResult.Yes Then
            ' User clicked Yes, proceed with erasing data
            ' Switch to the TabPage
            For Each tabPage As TabPage In TabControl1.TabPages
                If tabPage.Name = "TabPage2" Then
                    TabControl1.SelectedTab = tabPage
                    Exit For
                End If
            Next

            ' Clear the ListView (you might want to move this inside the If block)
            ListView1.Items.Clear()

            Try
                If SerialPort1.IsOpen Then
                    SerialPort1.Write("ERASE" & vbCr) ' Send the erase command
                Else
                    MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error sending data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' User clicked No, do nothing
            MessageBox.Show("Erase operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Populate the combo box with available serial ports

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(SerialPort.GetPortNames())
    End Sub

    Function CalculateDaysUntilOneYear(ByVal startDateString As String) As Integer
        ' Define the date format (MM-DD-YYYY)
        Dim dateFormat As String = "MM-dd-yyyy"
        Dim provider As CultureInfo = CultureInfo.InvariantCulture ' Use InvariantCulture for consistent parsing

        ' Try to parse the input date string
        Dim startDate As Date
        If Not Date.TryParseExact(startDateString, dateFormat, provider, DateTimeStyles.None, startDate) Then
            ' If parsing fails, handle the error (e.g., throw an exception, return -1, etc.)
            ' For this example, I'll return -1 to indicate an error
            Return -1
        End If

        ' Calculate the date one year from the start date
        Dim endDate As Date = startDate.AddYears(1)

        ' Calculate the difference in days
        Dim timeSpan As TimeSpan = endDate.Subtract(Date.Now) ' Or endDate.Subtract(startDate), see notes

        ' Return the number of days
        Return CInt(Math.Floor(timeSpan.TotalDays))
    End Function
    ' Update Progress bar
    Function CalculateEEPROMUsagePercentage(ByVal recordCount As Integer) As Integer
        ' Assuming you know the maximum number of records
        Const MAX_RECORDS As Integer = 1820

        ' Basic validation to prevent errors
        If recordCount < 0 Then
            Return 0 ' Or throw an exception, depending on your error handling
        ElseIf recordCount > MAX_RECORDS Then
            Return 100 ' Or throw an exception
        End If

        ' Calculate the percentage
        Dim percentage As Integer = CInt(Math.Round((recordCount / CDbl(MAX_RECORDS)) * 100))

        ' Ensure percentage stays within 0-100 range (for extra safety)
        percentage = Math.Max(0, Math.Min(100, percentage))

        Return percentage
    End Function

    Sub ProcessIncomingData(ByVal data As String)
        ' ... Your code to process the incoming data and update ListView ...

        ' Assuming 'myRecordCount' is a variable that keeps track of the number of records received
        Dim eepromUsage As Integer = CalculateEEPROMUsagePercentage(myRecordCount)

        ' Update your progress bar (assuming 'myProgressBar' is your ProgressBar control)
        If myProgressBar1.InvokeRequired Then
            myProgressBar1.Invoke(Sub() myProgressBar1.Value = eepromUsage)
        Else
            myProgressBar1.Value = eepromUsage
        End If

        ' ... Rest of your data processing code ...
    End Sub

    Private Sub btnDataFolders_Click(sender As Object, e As EventArgs) Handles btnDataFolders.Click
        Process.Start(gProgramDataFolder)
    End Sub





    'Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
    'If ListView1.SelectedItems.Count > 0 Then
    '' Get the selected ListViewItem
    'Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

    ' Check if the details form is already open
    'If detailsForm IsNot Nothing AndAlso Not detailsForm.IsDisposed Then
    '            ' Update the existing details form
    '            UpdateDetailsForm(detailsForm, selectedItem)
    'Else
    ' Create a new instance of the details form
    '            detailsForm = New Form2()
    '           UpdateDetailsForm(detailsForm, selectedItem)
    ''           detailsForm.Show() ' Use Show() for non-modal behavior
    'End If
    'nd If
    'End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count > 0 Then
            ' Get the selected ListViewItem
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Check if the details form is already open
            If detailsForm IsNot Nothing AndAlso Not detailsForm.IsDisposed Then
                ' Update the existing details form
                UpdateDetailsForm(detailsForm, selectedItem)
            Else
                ' Create a new instance of the details form
                detailsForm = New Form2()
                UpdateDetailsForm(detailsForm, selectedItem)

                ' Position Form2 next to Form1
                detailsForm.StartPosition = FormStartPosition.Manual
                detailsForm.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

                detailsForm.Show() ' Use Show() for non-modal behavior
            End If
        End If
    End Sub

    ' Helper subroutine to update the details form

    Private Sub UpdateDetailsFormOLD(ByVal detailsForm As Form2, ByVal selectedItem As ListViewItem)
        detailsForm.lblScanID.Text = "*"
        detailsForm.lblDate.Text = "*"
        detailsForm.lblTime.Text = "*"
        detailsForm.lblTemp.Text = "*"
        detailsForm.lblHumidity.Text = "*"
        detailsForm.lblFWVer.Text = "*"
        detailsForm.lblTestVoltage.Text = "*"
        detailsForm.lblTestResult.Text = "*"
        detailsForm.lblNumber.Text = "*"

        detailsForm.lblScanID.Text = selectedItem.Text
        detailsForm.lblDate.Text = selectedItem.SubItems(1).Text
        detailsForm.lblTime.Text = selectedItem.SubItems(2).Text
        detailsForm.lblTemp.Text = selectedItem.SubItems(3).Text
        detailsForm.lblHumidity.Text = selectedItem.SubItems(4).Text
        detailsForm.lblFWVer.Text = selectedItem.SubItems(5).Text
        detailsForm.lblTestVoltage.Text = selectedItem.SubItems(6).Text
        detailsForm.lblTestResult.Text = selectedItem.SubItems(7).Text
        detailsForm.lblNumber.Text = selectedItem.SubItems(8).Text
    End Sub
    ' Helper subroutine to update the details form
    Private Sub UpdateDetailsForm(ByVal detailsForm As Form2, ByVal selectedItem As ListViewItem)
        detailsForm.lblScanID.Text = "*"
        detailsForm.lblDate.Text = "*"
        detailsForm.lblTime.Text = "*"
        detailsForm.lblTemp.Text = "*"
        detailsForm.lblHumidity.Text = "*"
        detailsForm.lblFWVer.Text = "*"
        detailsForm.lblTestVoltage.Text = "*"
        detailsForm.lblTestResult.Text = "*"
        detailsForm.lblNumber.Text = "*"
        detailsForm.lblSciPrefix.Text = "*"
        detailsForm.lblNumber.Text = "*"
        detailsForm.lblCondRange.Text = "*"
        lblRecordsPerSecond.Text = "*"


        detailsForm.lblScanID.Text = selectedItem.Text
        detailsForm.lblDate.Text = selectedItem.SubItems(1).Text
        detailsForm.lblTime.Text = selectedItem.SubItems(2).Text
        detailsForm.lblTemp.Text = selectedItem.SubItems(3).Text
        detailsForm.lblHumidity.Text = selectedItem.SubItems(4).Text
        detailsForm.lblFWVer.Text = selectedItem.SubItems(5).Text
        detailsForm.lblTestVoltage.Text = selectedItem.SubItems(6).Text
        detailsForm.lblTestResult.Text = selectedItem.SubItems(7).Text
        detailsForm.lblNumber.Text = selectedItem.SubItems(8).Text
        'lblCondRange
        'lblSciNotation
        Dim myDecimalSciNot As Decimal
        myDecimalSciNot = Decimal.Parse(detailsForm.lblTestResult.Text)
        detailsForm.lblSciNotation.Text = FormatScientificNotation(myDecimalSciNot, 2)
        ' SCIENTIFIC PREFIX K M G T
        Dim myDecimalSciPrefix As Decimal
        myDecimalSciPrefix = Decimal.Parse(detailsForm.lblTestResult.Text)
        detailsForm.lblSciPrefix.Text = FormatTeraOhms(myDecimalSciPrefix, 2)
        ' Determin CONDUCTIVE DISSIPATIVE INSULATIVE
        Dim myDecimaCondRange As Decimal
        myDecimaCondRange = Decimal.Parse(detailsForm.lblTestResult.Text)
        If myDecimaCondRange > 1 And myDecimaCondRange <= 1000000000 Then
            detailsForm.lblCondRange.BackColor = Color.Black
            detailsForm.lblCondRange.ForeColor = Color.LightGreen
            detailsForm.lblCondRange.Text = "CONDUCTIVE"
        End If
        If myDecimaCondRange > 1000000000 And myDecimaCondRange < 1000000000000 Then
            detailsForm.lblCondRange.BackColor = Color.Black
            detailsForm.lblCondRange.ForeColor = Color.Yellow
            detailsForm.lblCondRange.Text = "DISSIPATIVE"
        End If



    End Sub

    ' Handle Form2 closing to clean up
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If detailsForm IsNot Nothing AndAlso Not detailsForm.IsDisposed Then
            detailsForm.Close()
            detailsForm.Dispose()
            detailsForm = Nothing
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown

        If ListView1.SelectedItems.Count > 0 Then
            ' Get the selected ListViewItem
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Check if the details form is already open
            If detailsForm IsNot Nothing AndAlso Not detailsForm.IsDisposed Then
                ' Update the existing details form
                UpdateDetailsForm(detailsForm, selectedItem)
            Else
                ' Create a new instance of the details form
                detailsForm = New Form2()
                UpdateDetailsForm(detailsForm, selectedItem)

                ' Position Form2 next to Form1
                detailsForm.StartPosition = FormStartPosition.Manual
                detailsForm.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

                detailsForm.Show() ' Use Show() for non-modal behavior
            End If
        End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop

    End Sub

    Private Sub ListView1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListView1.KeyUp
        If ListView1.SelectedItems.Count > 0 Then
            ' Get the selected ListViewItem
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)

            ' Check if the details form is already open
            If detailsForm IsNot Nothing AndAlso Not detailsForm.IsDisposed Then
                ' Update the existing details form
                UpdateDetailsForm(detailsForm, selectedItem)
            Else
                ' Create a new instance of the details form
                detailsForm = New Form2()
                UpdateDetailsForm(detailsForm, selectedItem)

                ' Position Form2 next to Form1
                detailsForm.StartPosition = FormStartPosition.Manual
                detailsForm.Location = New Point(Me.Location.X + Me.Width, Me.Location.Y)

                detailsForm.Show() ' Use Show() for non-modal behavior
            End If
        End If
    End Sub
    Private Sub FindArduinoPort()
        Dim ports() As String = SerialPort.GetPortNames()
        Dim foundPort As String = ""

        For Each port As String In ports
            Using serialPort As New SerialPort(port, 115200, Parity.None, 8, StopBits.One)
                Try
                    serialPort.Open()
                    serialPort.WriteLine("WHAT_BOTRON_MODEL_ARE_YOU")
                    serialPort.ReadTimeout = 1000 ' Set a timeout (1 second in this example)
                    Dim myReceive As String = serialPort.ReadLine()
                    MessageBox.Show(serialPort.ReadLine().Trim())
                    If serialPort.ReadLine().Trim() = "I_AM_B8590" Then
                        foundPort = port
                        Exit For ' Found the correct port, exit the loop
                    End If

                Catch ex As TimeoutException
                    ' No response from Arduino, move to the next port
                    Console.WriteLine($"Timeout on port {port}: {ex.Message}")
                Catch ex As Exception
                    ' Handle other exceptions (e.g., port already in use)
                    Console.WriteLine($"Error on port {port}: {ex.Message}")
                Finally
                    If serialPort.IsOpen Then
                        serialPort.Close()
                    End If
                End Try
            End Using
        Next

        If foundPort <> "" Then
            MessageBox.Show($"Arduino found on port: {foundPort}")
            ' Now you can use foundPort for further communication
            ' ...
        Else
            MessageBox.Show("Arduino not found.")
        End If
    End Sub

    Private Sub btnFindArduinoPort_Click(sender As Object, e As EventArgs) Handles btnFindArduinoPort.Click
        FindArduinoPort()
    End Sub
End Class

