Public Class Form1
    Private WithEvents bufferedWriter As NetworkVariableBufferedWriter(Of Int32)
    Private readerInterval As NetworkVariableReader(Of Int32)
    Private readerBoolean As NetworkVariableReader(Of Boolean)
    Private readerInt As NetworkVariableReader(Of Int64)
    'Private Const NetworkVariableLocation As String = "\\localhost\system\doublearray"
    Private Const DoubleNetworkVariableLocation As String = "\\localhost\OPC\OPC\PLC\_System\_WriteOptimizationDutyCycle"
    Private Const BooleanExample As String = "\\localhost\OPC\OPC\PLC\PLC0\Test_L_Start"
    Private Const IntExample As String = "\\localhost\OPC\OPC\PLC\PLC0\Program_PN"

    Public Sub New()
        InitializeComponent()

        bufferedWriter = New NetworkVariableBufferedWriter(Of Int32)(DoubleNetworkVariableLocation)
        'doubleBufferedWriter = New NetworkVariableBufferedWriter(Of Double)(DoubleNetworkVariableLocation)
        readerInterval = New NetworkVariableReader(Of Int32)(DoubleNetworkVariableLocation)
        readerBoolean = New NetworkVariableReader(Of Boolean)(BooleanExample)
        readerInt = New NetworkVariableReader(Of Int64)(IntExample)
        bufferedWriter.Connect()
        readerInterval.Connect()
        readerBoolean.Connect()
        readerInt.Connect()
        'doubleBufferedWriter.Connect()
        Label1.Text = readerInterval.ReadData().GetValue
        Label2.Text = readerBoolean.ReadData().GetValue
        Label3.Text = readerInt.ReadData().GetValue

    End Sub
End Class
