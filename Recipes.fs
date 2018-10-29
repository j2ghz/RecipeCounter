module Recipes

open System.Collections.Immutable

type Item = string

type Itemq = Item * int

type Inventory = Itemq list

type Recipe =
    {Input: Inventory
     Output: Itemq}

let SteelPlate x = ("Steel Plate", x)
let SteelRod x = ("Steel Rod", x)
let TinCable1 x = ("1x Tin Cable", x)
let ElectricMotor x = ("Electric Motor", x)
let ElectricPiston x = ("Electric Piston", x)
let RubberPlate x = ("Rubber Plate", x)
let RubberBar x = ("Rubber Bar", x)
let ConveyorModule x = ("Conveyor Module", x)

let recipes: Recipe list =
    [{Output = ("Steel Plate", 1)
      Input = [("Steel Ingot", 1)]}
     {Output = ("LV Machine Casing", 1)
      Input = [("Steel Plate", 8)]}
     {Output = ElectricMotor 1
      Input =
          [TinCable1 2
           ("Iron Rod", 2)
           ("Magnetic Iron Rod", 1)
           ("1x Copper Wire", 4)]}
     {Output = ElectricPiston 1
      Input =
          [TinCable1 2
           ElectricMotor 2
           SteelPlate 3
           SteelRod 2
           ("Small Steel Gear", 1)]}
     {Output = ConveyorModule 1
      Input =
          [ElectricMotor 2
           ElectricPiston 1
           RubberPlate 6]}
     {Output = ("LV Machine Hull", 1)
      Input =
          [("LV Machine Casing", 1)
           ("1x Tin Cable", 2)
           ("Wrought Iron Plate", 2)]}
     {Output = RubberPlate 1
      Input = [RubberBar 1]}]
