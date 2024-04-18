namespace Classes.Plants
{
    public class AloeVera : PlantClass
    {

        public AloeVera()
        {
            
            setPlantName("Aloe Vera");
            
            setWaterDrainMultiplier(.30); // Doesnt need that much water so it'll drain slower
            
            setSunDrainMultiplier(.40); // Needs average amount of sun
            
            setSunMinRange(40); 
            setWaterMinRange(40);
            
            setSunDecayThresh(getSunMinRange() * .5);
            setWaterDecayThresh(getWaterMinRange() * .5);
            
            setSunMaxRange(80);
            setWaterMaxRange(70);
            
            setSunlightAmount(50); // Default: 50
            setWaterAmount(50); // Default: 50
            
            setGrowing(true);
            
            setStatus(0.01);
            setStatusCap(1f);
            
            setState("Seedling");
            
            setPerferedSoil("Sandy");
            
            setHealthString("Healthy");
            
        }
        
        
        
    }
}