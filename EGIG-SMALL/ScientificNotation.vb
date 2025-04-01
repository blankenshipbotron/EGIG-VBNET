Public Module ScientificNotation

    ' Function to format a Decimal value with appropriate SI prefixes for ohms
    Public Function FormatTeraOhms(ByVal ohms As Decimal, ByVal decimalPlaces As Integer) As String
        Dim formattedValue As String
        Dim absOhms As Decimal = Math.Abs(ohms) ' Handle negative values if needed

        If absOhms < 1000D Then ' Ohms
            formattedValue = ohms.ToString("0." & New String("0", decimalPlaces)) & " Ω"
        ElseIf absOhms < 1000000D Then ' Kiloohms
            formattedValue = (ohms / 1000D).ToString("0." & New String("0", decimalPlaces)) & " KΩ"
        ElseIf absOhms < 1000000000D Then ' Megaohms
            formattedValue = (ohms / 1000000D).ToString("0." & New String("0", decimalPlaces)) & " MΩ"
        ElseIf absOhms < 1000000000000D Then ' Gigaohms
            formattedValue = (ohms / 1000000000D).ToString("0." & New String("0", decimalPlaces)) & " GΩ"
        Else ' Teraohms
            formattedValue = (ohms / 1000000000000D).ToString("0." & New String("0", decimalPlaces)) & " TΩ"
        End If

        Return formattedValue
    End Function

    ' Function to convert a Decimal to scientific notation String (as before)
    Public Function FormatScientificNotation(ByVal number As Decimal, ByVal decimalPlaces As Integer) As String
        ' Handle zero separately to avoid errors
        If number = 0D Then
            Return "0." & New String("0", decimalPlaces) & "E+00"
        End If

        Dim exponent As Integer = CInt(Math.Floor(Math.Log10(Math.Abs(number))))
        Dim coefficient As Decimal = number / (10 ^ exponent)

        ' Format the coefficient with the specified number of decimal places
        Dim coefficientFormat As String = "0." & New String("0", decimalPlaces)

        Return coefficient.ToString(coefficientFormat) & "E" & FormatExponent(exponent)
    End Function

    ' Helper function to format the exponent with a sign and leading zero
    Private Function FormatExponent(ByVal exponent As Integer) As String
        If exponent >= 0 Then
            Return "+" & exponent.ToString("00")
        Else
            Return exponent.ToString("00") ' Negative sign is already included
        End If
    End Function

End Module
