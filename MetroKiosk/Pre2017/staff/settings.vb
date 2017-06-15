Imports System.Configuration
Imports System.Windows.Forms

Public Class settings

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        For Each setting As SettingsPropertyValue In My.Settings.PropertyValues

            'Need to repeat this block for each group control too. 
            For Each control As Control In Me.Controls
                If setting.Name = control.Name Then
                    'It's a match, apply the value.
                    Try
                        If setting.Property.PropertyType = True.GetType Then
                            'If it's a boolean
                            Dim checker As CheckBox = control
                            checker.Checked = setting.PropertyValue
                        Else
                            control.Text = setting.PropertyValue.ToString
                        End If

                    Catch ex As Exception
                        'RIP
                    End Try
                End If
            Next

            'PriceGroup
            For Each control As Control In PriceGroup.Controls
                If setting.Name = control.Name Then
                    'It's a match, apply the value.
                    Try
                        If setting.Property.PropertyType = True.GetType Then
                            'If it's a boolean
                            Dim checker As CheckBox = control
                            checker.Checked = setting.PropertyValue
                        Else
                            control.Text = setting.PropertyValue.ToString
                        End If

                    Catch ex As Exception
                        'RIP
                    End Try
                End If
            Next

            'OtherGroup
            For Each control As Control In OtherGroup.Controls
                If setting.Name = control.Name Then
                    'It's a match, apply the value.
                    Try
                        If setting.Property.PropertyType = True.GetType Then
                            'If it's a boolean
                            Dim checker As CheckBox = control
                            checker.Checked = setting.PropertyValue
                        Else
                            control.Text = setting.PropertyValue.ToString
                        End If

                    Catch ex As Exception
                        'RIP
                    End Try
                End If
            Next

            'DriveGroup
            For Each control As Control In DriveGroup.Controls
                If setting.Name = control.Name Then
                    'It's a match, apply the value.
                    Try
                        If setting.Property.PropertyType = True.GetType Then
                            'If it's a boolean
                            Dim checker As CheckBox = control
                            checker.Checked = setting.PropertyValue
                        Else
                            control.Text = setting.PropertyValue.ToString
                        End If

                    Catch ex As Exception
                        'RIP
                    End Try
                End If
            Next
        Next
        loaded = True
    End Sub
    Dim loaded As Boolean = False
    Private Sub SettingChanged(sender As Object, e As EventArgs) Handles Size1Text.TextChanged, StorageXD.TextChanged, StorageUSB.TextChanged, StorageTarget.TextChanged, StorageSD.TextChanged, StorageMS.TextChanged, StorageiDevice.TextChanged, StorageCF.TextChanged, StorageCD.TextChanged, Size5Text.TextChanged, Size5Price4.TextChanged, Size5Price3.TextChanged, Size5Price2.TextChanged, Size5Price1.TextChanged, Size5Img.TextChanged, Size5Channel.TextChanged, Size4Text.TextChanged, Size4Price4.TextChanged, Size4Price3.TextChanged, Size4Price2.TextChanged, Size4Price1.TextChanged, Size4Img.TextChanged, Size4Channel.TextChanged, Size3Text.TextChanged, Size3Price4.TextChanged, Size3Price3.TextChanged, Size3Price2.TextChanged, Size3Price1.TextChanged, Size3Img.TextChanged, Size3Channel.TextChanged, Size2Text.TextChanged, Size2Price4.TextChanged, Size2Price3.TextChanged, Size2Price2.TextChanged, Size2Price1.TextChanged, Size2Img.TextChanged, Size2Channel.TextChanged, Size1Price4.TextChanged, Size1Price3.TextChanged, Size1Price2.TextChanged, Size1Price1.TextChanged, Size1Img.TextChanged, Size1Channel.TextChanged, PriceBand3Max.TextChanged, PriceBand2Max.TextChanged, PriceBand1Max.TextChanged, LogmasterIp.TextChanged, DebugMode.CheckedChanged, BluetoothEnabled.CheckedChanged, Use2k17.CheckedChanged
        If loaded Then
            Try
                My.Settings.Item(sender.name) = sender.checked
            Catch ex As Exception
                Try
                    My.Settings.Item(sender.name) = sender.text
                Catch exa As Exception
                    Try
                        My.Settings.Item(sender.name) = Convert.ToSingle(sender.text.ToString)
                    Catch exb As Exception
                        MsgBox(exb.Message + " | " + exa.Message + " | " + ex.Message)
                    End Try
                End Try
            End Try
        End If
    End Sub
End Class
