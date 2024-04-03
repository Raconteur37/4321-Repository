namespace Classes.Plants
{
    public class AloeVera : PlantClass
    {

        public AloeVera()
        {
            
            setPlantName("Aloe Vera");
            
            setWaterDrainMultiplier(.30); // Doesnt need that much water so itll drain slower
            
            setSunDrainMultiplier(.50); // Needs average amount of sun
            
            setSunMinRange(40); 
            setWaterMinRange(40);
            
            setSunMaxRange(80);
            setWaterMaxRange(70);
            
            setSunlightAmount(50);
            setWaterAmount(50);
            
            setGrowing(true);
            
            setStatus(0.01);
            
            setState("Seedling");
            
            setHealthString("Healthy");
            
        }
        
        
        
    }
}