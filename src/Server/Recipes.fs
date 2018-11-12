module Recipes

open Shared

let inline (.*) (i, q) number = (i, q * number)
//Misc
let GlassTube = ("Glass Tube", 1)
let GlassDust = ("Glass Dust", 1)
let QuartzSand = ("Quartz Sand", 1)
let TinyPileFlintDust = ("Tiny Pile of Flint Dust", 1)
let Flint = ("Flint", 1)
let Sand = ("Sand", 1)
let Redstone = ("Redstone", 1)
//Steel
let SteelIngot = ("Steel Ingot", 1)
let SteelPlate = ("Steel Plate", 1)
let SteelRod = ("Steel Rod", 1)
let SteelCasing = ("Steel Casing", 1)
let SmallSteelFluidPipe = ("Small Steel Fluid Pipe", 1)
//Iron
let IronIngot = ("Iron Ingot", 1)
let IronPlate = ("Iron Plate", 1)
let IronRod = ("Iron Rod", 1)
let WroughtIronIngot = ("Wrought Iron Ingot", 1)
let WroughtIronPlate = ("Wrought Iron Plate", 1)
let WroughtIronRod = ("Wrought Iron Rod", 1)
let MagneticIronRod = ("Magnetic Iron Rod", 1)
let SmallSteelGear = ("Small Steel Gear", 1)
//Cables/Wires
let TinWire1 = ("1x Tin Wire", 1)
let TinCable1 = ("1x Tin Cable", 1)
let CopperIngot = ("Copper Ingot", 1)
let CopperWire1 = ("1x Copper Wire", 1)
let FineCopperWire = ("Fine Copper Wire", 1)
//Rubber
let RubberPlate = ("Rubber Plate", 1)
let RubberBar = ("Rubber Bar", 1)
let RubberRing = ("Rubber Ring", 1)
let RawRubberDust = ("Raw Rubber Dust", 1)
let SulfurDust = ("Sulfur Dust", 1)
let StickyResin = ("Sticky Resin", 1)
let MoltenRubber = ("Molten Rubber", 1)
//Tin
let TinRotor = ("Tin Rotor", 1)
let TinPlate = ("Tin Plate", 1)
let TinRing = ("Tin Ring", 1)
let TinScrew = ("Tin Screw", 1)
let TinBolt = ("Tin Bolt", 1)
let TinIngot = ("Tin Ingot", 1)
let TinRod = ("Tin Rod", 1)
//Red Alloy
let RedAlloyIngot = ("Red Alloy Ingot", 1)
let RedAlloyWire1 = ("1x Red Alloy Wire", 1)
let RedAlloyCable1 = ("Red Alloy Cable", 1)
let RedAlloyRod = ("Red Alloy Rod", 1)
let RedAlloyBolt = ("Red Alloy Bolt", 1)
let VacuumTube = ("Vacuum Tube", 1)
//Circuit
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
let LVPump = ("Electric Pump LV", 1)
let MiningPipe = ("Mining Pipe", 1)
//Machines
let Assembler = ("Assembler", 1)
let BasicChemicalReactor = ("Basic Chemical Reactor", 1)
let LVCombustion = ("Basic Combustion Generator", 1)
let LVDistillery = ("Basic Distillery", 1)
let LVFluidExtractor = ("Basic Fluid Extractor", 1)

let R o i =
    {Output = o
     Input = i}

let recipes: Recipe list =
    [
     {Output = SteelPlate
      Input = [SteelIngot]}
     {Output = SteelRod
      Input = [SteelIngot]}
     R (MiningPipe .* 2) [SmallSteelFluidPipe]
     R (SmallSteelFluidPipe .* 6) [SteelPlate .* 6]
     {Output = IronPlate
      Input = [IronIngot]}
     {Output = IronRod
      Input = [IronIngot]}
     {Output = TinCable1
      Input =
          [TinWire1
           MoltenRubber .* 144]}
     R (MoltenRubber .* 1296) [RawRubberDust .* 9
                               SulfurDust]
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
           ElectricMotor
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
     {Output = TinPlate
      Input = [TinIngot]}
     {Output = TinRing
      Input = [TinRod]}
     {Output = TinRod
      Input = [TinIngot]}
     {Output = TinScrew
      Input = [TinBolt]}
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
     {Output = TinWire1 .* 2
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
      Input = [Wood]}
     {Output = GlassTube
      Input = [GlassDust]}
     {Output = GlassDust
      Input = [QuartzSand; TinyPileFlintDust]}
     {Output = QuartzSand
      Input = [Sand]}
     {Output = TinyPileFlintDust .* 4
      Input = [Flint]}
     {Output = LVPump
      Input =
          [TinScrew
           TinRotor
           RubberRing .* 2
           ("Bronze Plate", 3)
           ElectricMotor
           TinCable1]}
     {Output = LVCombustion
      Input =
          [LVMachineHull
           ElectricMotor .* 2
           ElectricPiston .* 2
           ElectronicCircuit
           ("Steel Gear", 2)]}
     R ("Steel Gear", 1) [SteelIngot .* 8]]

let getRecipeItems(recipe: Recipe) =
    fst recipe.Output

let getAllItems recipes =
    recipes
    |> List.map getRecipeItems
    |> List.distinct
    |> List.sort
