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
let GlassTube = ("Glass Tube", 1)
let Redstone = ("Redstone", 1)
let SteelIngot = ("Steel Ingot", 1)
let SteelPlate = ("Steel Plate", 1)
let SteelRod = ("Steel Rod", 1)
let SteelCasing = ("Steel Casing", 1)
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
let CopperIngot = ("Copper Ingot", 1)
let CopperWire1 = ("1x Copper Wire", 1)
let FineCopperWire = ("Fine Copper Wire", 1)
let RubberPlate = ("Rubber Plate", 1)
let RubberBar = ("Rubber Bar", 1)
let RawRubberDust = ("Raw Rubber Dust", 1)
let SulfurDust = ("Sulfur Dust", 1)
let StickyResin = ("Sticky Resin", 1)
let TinRotor = ("Tin Rotor", 1)
let TinPlate = ("Tin Plate", 1)
let TinRing = ("Tin Ring", 1)
let TinScrew = ("Tin Screw", 1)
let TinBolt = ("Tin Bolt", 1)
let TinIngot = ("Tin Ingot", 1)
let TinRod = ("Tin Rod", 1)
let RedAlloyIngot = ("Red Alloy Ingot", 1)
let RedAlloyWire1 = ("1x Red Alloy Wire", 1)
let RedAlloyCable1 = ("Red Alloy Cable", 1)
let RedAlloyRod = ("Red Alloy Rod", 1)
let RedAlloyBolt = ("Red Alloy Bolt", 1)
let VacuumTube = ("Vacuum Tube", 1)
let Resistor = ("Resistor", 1)
let CoalDust = ("Coal Dust", 1)
let CircuitBoard = ("Circuit Board", 1)
let CoatedCircuitBoard = ("Coated Circuit Board", 1)
let WoodPlank = ("Wood Plank", 1)
let WoodPulp = ("Wood Pulp", 1)
let Wood = ("Wood", 1)
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
let BasicChemicalReactor = ("Basic Chemical Reactor", 1)

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
           ElectronicCircuit .* 2]}
     {Output = BasicChemicalReactor
      Input =
          [("Glass", 2)
           TinCable1 .* 2
           ElectronicCircuit .* 2
           ElectricMotor
           LVMachineHull
           TinRotor]}
     {Output = TinRotor
      Input =
          [TinPlate .* 4
           TinRing
           TinScrew]}
     {Output = ElectronicCircuit
      Input =
          [SteelCasing
           CircuitBoard
           Resistor .* 2
           VacuumTube .* 2
           RedAlloyCable1 .* 3]}
     {Output = RedAlloyCable1
      Input = [RedAlloyWire1; RubberPlate]}
     {Output = RedAlloyWire1
      Input = [RedAlloyIngot]}
     {Output = RubberBar
      Input =
          [SulfurDust
           RawRubberDust .* 3]}
     {Output = RawRubberDust .* 3
      Input = [StickyResin]}
     {Output = TinPlate
      Input = [TinIngot]}
     {Output = TinRing
      Input = [TinRod]}
     {Output = TinRod
      Input = [TinIngot]}
     {Output = TinScrew
      Input = [TinBolt .* 2]}
     {Output = TinBolt .* 2
      Input = [TinRod]}
     {Output = SteelCasing
      Input = [SteelPlate]}
     {Output = Resistor
      Input =
          [FineCopperWire .* 2
           CoalDust
           CopperWire1 .* 2
           StickyResin .* 2]}
     {Output = FineCopperWire .* 4
      Input = [CopperWire1]}
     {Output = VacuumTube
      Input =
          [RedAlloyBolt
           GlassTube
           FineCopperWire .* 2
           CopperWire1 .* 3
           SteelRod .* 2]}
     {Output = RedAlloyBolt .* 2
      Input = [RedAlloyRod]}
     {Output = RedAlloyRod
      Input = [RedAlloyIngot]}
     {Output = TinWire1
      Input = [TinIngot]}
     {Output = CircuitBoard
      Input =
          [CoatedCircuitBoard
           CopperWire1 .* 8]}
     {Output = CoatedCircuitBoard
      Input =
          [WoodPlank
           StickyResin .* 2]}
     {Output = WoodPlank
      Input = [WoodPulp .* 8]}
     {Output = WoodPulp .* 6
      Input = [Wood]}]
