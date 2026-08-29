Dim spd As Double
Dim RotSpd As Double
Dim steering As Double
Dim count = 1

Sub OnInitParameters()

    RegisterParameterDouble("sspeed", "Suspension Speed :", 5, 2, 20)
    RegisterParameterDouble("RotSpeed", "Tires Speed :", 1, 1, 10)
    RegisterParameterDouble("Steer", "Steering :", 0, -40, 40)

    RegisterPushButton("BTN_init", "Build The Tree!", 0)

End Sub

Sub OnExecPerField()

    Dim master = FindSubContainer("Master")
    Dim body = FindSubContainer("Body")
    Dim cctr = FindSubContainer("Control")
    Dim FrntLftTire = FindSubContainer("FrontLeftTire")
    Dim FrntRitTire = FindSubContainer("FrontRightTire")
    Dim RearTires = FindSubContainer("RearTires")
    Dim AllTires = FindSubContainer("Main Tires Container")

    spd = GetParameterDouble("sspeed")
    RotSpd = GetParameterDouble("RotSpeed")
    steering = GetParameterDouble("Steer")

    ' Copy the driven wheel rotation to the other tires.
    FrntRitTire.Rotation.Z = FrntLftTire.Rotation.Z
    RearTires.Rotation.Z = FrntLftTire.Rotation.Z

    ' Apply steering to both front tires.
    FrntRitTire.Rotation.Y = steering
    FrntLftTire.Rotation.Y = steering

    ' Smoothly follow the Master container on the X axis.
    If master.Position.X < cctr.Position.X Then

        cctr.Position.X = cctr.Position.X - ((cctr.Position.X - master.Position.X) / spd)
        body.Rotation.Z = (master.Position.X - cctr.Position.X) / spd
        FrntLftTire.Rotation.Z = master.Position.X * -RotSpd

    ElseIf master.Position.X > cctr.Position.X Then

        cctr.Position.X = cctr.Position.X + ((master.Position.X - cctr.Position.X) / spd)
        body.Rotation.Z = (master.Position.X - cctr.Position.X) / spd
        FrntLftTire.Rotation.Z = master.Position.X * -RotSpd

    End If

    ' Simulate vertical suspension movement.
    AllTires.Position.Y = master.Position.Y * -1

    If master.Position.Y > 0 Then
        If master.Position.Y > spd Then
            AllTires.Position.Y = spd * -1
        End If
    End If

    If master.Position.Y < 0 Then
        If master.Position.Y < spd * -2 Then
            AllTires.Position.Y = spd * 2
        End If
    End If

End Sub

Sub BuildTree()

    If count = 1 Then

        This.Name = "Car_Main"

        Dim Control = This.AddContainer(TL_DOWN)
        Control.Name = "Control"

        Dim Master = Control.AddContainer(TL_NEXT)
        Master.Name = "Master"

        Dim Tires = Master.AddContainer(TL_DOWN)
        Tires.Name = "Main Tires Container"

        Dim Body = Master.AddContainer(TL_DOWN)
        Body.Name = "Body"

        Dim RearTires = Tires.AddContainer(TL_DOWN)
        RearTires.Name = "RearTires"

        Dim FrontRightTire = Tires.AddContainer(TL_DOWN)
        FrontRightTire.Name = "FrontRightTire"

        Dim FrontLeftTire = Tires.AddContainer(TL_DOWN)
        FrontLeftTire.Name = "FrontLeftTire"

    End If

    count = count + 1
    Scene.UpdateSceneTree()

End Sub

Sub OnExecAction(buttonId As Integer)

    Select Case buttonId
        Case 0
            BuildTree()
    End Select

End Sub
