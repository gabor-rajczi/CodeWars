using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.BattleshipFieldValidator
{
    public class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            try
            {
                var battleField = new Field(field);
                var battleShip = battleField.SearchForShip(4, 1);
                battleField.SetTileToFounded(battleShip);
                battleField.ValidateShip(battleShip);
                var cruisers = battleField.SearchForShip(3, 2);
                battleField.SetTileToFounded(cruisers);
                battleField.ValidateShip(cruisers);
                var destroyers = battleField.SearchForShip(2, 3);
                battleField.SetTileToFounded(destroyers);
                battleField.ValidateShip(destroyers);
                var submarines = battleField.SearchForShip(1, 4);
                battleField.SetTileToFounded(submarines);
                battleField.ValidateShip(submarines);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public class Field
        {
            public Field(int[,]field)
            {
                Tiles = new List<Tile>();
                for (var i = 0; i < 100; i++)
                {
                    AddTile(i, field);
                }
            }
            public List<Tile> Tiles { get; set; }

            private void AddTile(int i, int[,] field)
            {
                var tile = new Tile(i);
                tile.SetValue(field);
                Tiles.Add(tile);
            }

            public List<List<Tile>> SearchForShip(int size, int count)
            {
                var shipList = new List<List<Tile>>();
                for (var i = 0; i < 10; i++)
                {
                    var ship = new List<Tile>();
                    var row = i;
                    var occupiedTilesInARow = Tiles.Where(t => t.Row == row && t.Value == 1 && !t.Founded).ToList();
                    var firstTileList = occupiedTilesInARow
                        .Where(t1 => occupiedTilesInARow.Any(t2 => t2.Column == t1.Column + 1) &&
                                     occupiedTilesInARow.Any(t3 => t3.Column == t1.Column + 2) &&
                                     occupiedTilesInARow.Any(t4 => t4.Column == t1.Column + 3) && 
                                     size == 4 ||
                                     occupiedTilesInARow.Any(t2 => t2.Column == t1.Column + 1) &&
                                     occupiedTilesInARow.Any(t3 => t3.Column == t1.Column + 2) &&
                                     size == 3 ||
                                     occupiedTilesInARow.Any(t2 => t2.Column == t1.Column + 1) &&
                                     size == 2 ||
                                     size == 1
                                     )
                        .ToList();
                    if (firstTileList.Count > count)
                        throw new Exception("More Battleships in a Row");
                    if (firstTileList.Count == 0)
                        continue;
                    foreach (var tile in firstTileList)
                    {
                        var firstTile = tile;
                        ship.AddRange(occupiedTilesInARow.Where(t => t.Column >= firstTile.Column && t.Column <= firstTile.Column + size - 1));
                        shipList.Add(ship);
                    }
                }
                if (shipList.Count > count)
                    throw new Exception("More Battleships in horizontal direction");
                for (var i = 0; i < 10 && size > 1; i++)
                {
                    var ship = new List<Tile>();
                    var column = i;
                    var occupiedTilesInAColumn = Tiles.Where(t => t.Column == column && t.Value == 1 && !t.Founded).ToList();
                    var firstTileList = occupiedTilesInAColumn
                        .Where(t1 => occupiedTilesInAColumn.Any(t2 => t2.Row == t1.Row + 1) &&
                                     occupiedTilesInAColumn.Any(t3 => t3.Row == t1.Row + 2) &&
                                     occupiedTilesInAColumn.Any(t4 => t4.Row == t1.Row + 3) &&
                                     size == 4 ||
                                     occupiedTilesInAColumn.Any(t2 => t2.Row == t1.Row + 1) &&
                                     occupiedTilesInAColumn.Any(t3 => t3.Row == t1.Row + 2) &&
                                     size == 3 ||
                                     occupiedTilesInAColumn.Any(t2 => t2.Row == t1.Row + 1) &&
                                     size == 2 ||
                                     size == 1)
                        .ToList();
                    if (firstTileList.Count > count)
                        throw new Exception("More Battleships in a Column");
                    if (firstTileList.Count == 0)
                        continue;
                    foreach (var tile in firstTileList)
                    {
                        var firstTile = tile;
                        ship.AddRange(occupiedTilesInAColumn.Where(t => t.Row >= firstTile.Row && t.Row <= firstTile.Row + size - 1));
                        shipList.Add(ship);
                    }
                }
                if (shipList.Count > count)
                    throw new Exception("More Battleships in field");
                if (shipList.Count == 0)
                {
                    throw new Exception("No Battleship in field");
                }
                return shipList;
            }

            public void SetTileToFounded(List<Tile> tileList)
            {
                tileList.ForEach(t => t.Founded = true);
            }

            public void SetTileToFounded(List<List<Tile>> tileList)
            {
                tileList.ForEach(SetTileToFounded);
            }

            public void ValidateShip(List<Tile> tileList)
            {
                var firstColumn = tileList.First().Column;
                if (firstColumn > 0)
                    firstColumn--;
                var lastColumn = tileList.Last().Column;
                if (lastColumn < 8)
                    lastColumn++;
                var firstRow = tileList.First().Row;
                if (firstRow > 0)
                    firstRow--;
                var lastRow = tileList.Last().Row;
                if (lastRow < 8)
                    lastRow++;
                if (
                    Tiles.Any(
                        t =>
                            !tileList.Contains(t) && t.Founded && 
                            t.Column >= firstColumn && t.Column <= lastColumn &&
                            t.Row >= firstRow && t.Row <= lastRow))
                    throw new Exception("Ship placement is invalid");
            }

            public void ValidateShip(List<List<Tile>> tileList)
            {
                tileList.ForEach(ValidateShip);
            }
        }

        public class Tile
        {
            public Tile(int position)
            {
                Row = position/10;
                Column = position%10;
            }

            public int Column { get; set; }

            public int Row { get; set; }

            public void SetValue(int[,] field)
            {
                Value = field[Row, Column];
            }

            public int Value { get; set; }
            public bool Founded { get; set; }
        }
    }

}
