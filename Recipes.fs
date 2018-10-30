module Recipes

open System.Collections.Immutable

type Item = string

type Itemq = Item * int

type Items = Itemq list

type Recipe =
    {Input: Items
     Output: Itemq}

type Recipeq = Recipe * int

let inline (.*) (i, q) number = (i, q * number)
let Redstone = ("Redstone", 1)
let SteelIngot = ("Steel Ingot", 1)
let SteelPlate = ("Steel Plate", 1)
let SteelRod = ("Steel Rod", 1)
let IronIngot = ("Iron Ingot", 1)
let IronPlate = ("Iron Plate", 1)
let IronRod = ("Iron Rod", 1)
let WroughtIronIngot = ("Wrought Iron Ingot", 1)
let WroughtIronPlate = ("Wrought Iron Plate", 1)
let WroughtIronRod = ("Wrought Iron Rod", 1)
let MagneticIronRod = ("Magnetic Iron Rod", 1)
let SmallSteelGear = ("Small Steel Gear", 1)
let TinWire1 = ("1x Tin Wire", 1)
let TinCable1 = ("1x Tin Cable", 1)
let RubberPlate = ("Rubber Plate", 1)
let RubberBar = ("Rubber Bar", 1)
//Components
let LVMachineCasing = ("LV Machine Casing", 1)
let LVMachineHull = ("LV Machine Hull", 1)
let ElectricMotor = ("Electric Motor", 1)
let ElectricPiston = ("Electric Piston", 1)
let ElectronicCircuit = ("Electronic Circuit", 1)
let ConveyorModule = ("Conveyor Module", 1)
let RobotArm = ("Robot Arm", 1)
//Machines
let Assembler = ("Assembler", 1)

let recipes: Recipe list =
    [{Output = SteelPlate
      Input = [SteelIngot]}
     {Output = SteelRod
      Input = [SteelIngot]}
     {Output = IronPlate
      Input = [IronIngot]}
     {Output = IronRod
      Input = [IronIngot]}
     {Output = TinCable1
      Input = [TinWire1; RubberPlate]}
     {Output = MagneticIronRod
      Input =
          [IronRod
           Redstone .* 4]}
     {Output = SmallSteelGear
      Input =
          [SteelPlate
           SteelRod .* 2]}
     {Output = LVMachineCasing
      Input = [SteelPlate .* 8]}
     {Output = RobotArm
      Input =
          [ElectricMotor .* 2
           ElectronicCircuit
           ElectricPiston
           TinCable1 .* 3
           SteelRod .* 2]}
     {Output = ElectricMotor
      Input =
          [TinCable1 .* 2
           IronRod .* 2
           MagneticIronRod
           ("1x Copper Wire", 4)]}
     {Output = ElectricPiston
      Input =
          [TinCable1 .* 2
           ElectricMotor .* 2
           SteelPlate .* 3
           SteelRod .* 2
           SmallSteelGear]}
     {Output = ConveyorModule
      Input =
          [ElectricMotor .* 2
           ElectricPiston
           RubberPlate .* 6]}
     {Output = LVMachineHull
      Input =
          [LVMachineCasing
           TinCable1 .* 2
           WroughtIronPlate .* 2
           SteelPlate]}
     {Output = WroughtIronPlate
      Input = [WroughtIronIngot]}
     {Output = RubberPlate
      Input = [RubberBar .* 2]}
     {Output = Assembler
      Input =
          [LVMachineHull
           TinCable1 .* 2
           RobotArm .* 2
           ConveyorModule .* 2
           ElectronicCircuit .* 2]}]
