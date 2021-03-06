module Recipes

open Shared

let inline (.*) (i, q) number = (i, q * number)
let R o i =
    {Output = o
     Input = i}
let Ri o x i =
    {Output = o .* x
     Input = i}
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
let RefinedGlue = ("Refined Glue", 1)
let CopperFoil = ("Copper Foil", 1)
let CopperPlate = ("Copper Plate", 1)
let MoltenRedAlloy = ("Molten Red Alloy", 1)
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
//GoodCircuits
let GoodCircuitBoard = ("Good Circuit Board", 1)
let GoldWire1 = ("1x Gold Wire", 1)
let PhenolicCircuitBoard = ("Phenolic Circuit Board", 1)
let Diode = ("Diode", 1)
let GalliumArsenideSmallPile = ("Small Pile of Gallium Arsenide Dust", 1)
let MoltenGlass = ("Molten Glass", 1)
let QuartziteDust = ("Quartzite Dust", 1)
//Conductive
let BlackSteel = ("Black Steel Dust", 1)
let ConductiveIronDust = ("Conductive Iron Dust", 1)
let GoldDust = ("Gold Dust", 1)
let SteelDust = ("Steel Dust", 1)
let NickelDust = ("Nickel Dust", 1)
let BlackBronzeDust = ("Black Bronze Dust", 1)
let SilverDust = ("Silver Dust", 1)
let CopperDust = ("Copper Dust", 1)
let IronDust = ("Iron Dust", 1)
let RedstoneAlloyDust = ("Redstone Alloy Dust", 1)
let SiliconDust = ("Silicon Dust", 1)
//Molten Polyethylene
let MoltenPolyethylene = ("Molten Polyethylene", 1)
let Oxygen = ("Oxygen", 1)
let Ethylene = ("Ethylene", 1)
let Ethanol = ("Ethanol", 1)
let SulfuricAcid = ("Sulfuric Acid", 1)
let FermentedBiomass = ("Fermented Biomass", 1)
let Biomass = ("Biomass", 1)
let Plantmass = ("Plantmass", 1)
let Plantball = ("Plantball", 1)
let BioChaff = ("Bio Chaff", 1)
let Water = ("Water", 1)

let recipes: Recipe list =
    [
     R (Plantmass) [Plantball .* 2]
     R (BioChaff) [Plantmass]
     R (Biomass .* 750) [Water .* 750; BioChaff]
     R (FermentedBiomass .* 100) [Biomass .* 100]
     R (Ethanol .* 150) [FermentedBiomass .* 1000]
     R (Ethylene .* 1000) [Ethanol .* 1000; SulfuricAcid .* 1000]
     R (MoltenPolyethylene .* 216) [Oxygen .* 1000; Ethylene .* 144]
     R (RedstoneAlloyDust .*2) [Redstone;CoalDust;SiliconDust]
     R (ConductiveIronDust .* 2) [SilverDust;IronDust;RedstoneAlloyDust]
     R (BlackBronzeDust .* 5) [GoldDust; SilverDust;CopperDust.*3]
     R (BlackSteel .* 5) [SteelDust .* 3; NickelDust; BlackBronzeDust]
     R ("Energetic Alloy Dust", 3) [GoldDust;BlackSteel;ConductiveIronDust]
     R QuartziteDust [QuartzSand .* 60]
     Ri MoltenGlass 72 [QuartziteDust]
     Ri Diode 2 [GalliumArsenideSmallPile;FineCopperWire .* 4; MoltenGlass .* 288]
     R GoodCircuitBoard [PhenolicCircuitBoard; GoldWire1 .* 8]
     R PhenolicCircuitBoard [WoodPulp; RefinedGlue .* 36]
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
     R (Resistor .* 4) [FineCopperWire .* 4; CopperWire1 .* 4; CoalDust]
     {Output = FineCopperWire .* 4
      Input = [CopperWire1]}
     R VacuumTube [GlassTube; CopperWire1; SteelRod; MoltenRedAlloy .* 18]
     R (MoltenRedAlloy .* 144) [RedAlloyIngot]
     {Output = RedAlloyBolt .* 2
      Input = [RedAlloyRod]}
     {Output = RedAlloyRod
      Input = [RedAlloyIngot]}
     {Output = TinWire1 .* 2
      Input = [TinIngot]}
     R CopperPlate [CopperIngot]
     R (CopperFoil .* 4) [CopperPlate]
     R CircuitBoard [RefinedGlue .* 72; WoodPlank; CopperFoil .* 4]
     R (RefinedGlue .* 100) [StickyResin]
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
