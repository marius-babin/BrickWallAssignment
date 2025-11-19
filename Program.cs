using BrickWallAssignment.Function;

Console.WriteLine("Generated simple wall:");
new GenerateWall().BuildWall(10,9);
        
Console.WriteLine(new string('-',50));
        
Console.WriteLine("Generated smart wall:");
new SmartWallGenerator().BuildSmartWall(10,10);

Console.WriteLine(new string('-',50));
new SuperSmartWallGenerator().BuildSuperSmartWall(40,12); // Re-run the app couple times to get a result if not gotten from first try :)
